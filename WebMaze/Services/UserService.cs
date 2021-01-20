using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;


namespace WebMaze.Services
{
    public class UserService
    {
        private CitizenUserRepository citizenUserRepository;
        private RoleRepository roleRepository;
        private UserPasswordValidator userPasswordValidator;
        private IHttpContextAccessor httpContextAccessor;

        public UserService(CitizenUserRepository citizenUserRepository, RoleRepository roleRepository,
            UserPasswordValidator userPasswordValidator, IHttpContextAccessor httpContextAccessor)
        {
            this.citizenUserRepository = citizenUserRepository;
            this.roleRepository = roleRepository;
            this.userPasswordValidator = userPasswordValidator;
            this.httpContextAccessor = httpContextAccessor;
        }

        public CitizenUser GetCurrentUser()
        {
            var idStr = httpContextAccessor.HttpContext.
                User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(idStr))
            {
                return null;
            }

            var id = int.Parse(idStr);
            var citizen = citizenUserRepository.Get(id);
            return citizen;
        }

        public virtual List<CitizenUser> GetUsers()
        {
            return citizenUserRepository.GetAll();
        }

        public virtual CitizenUser FindById(long id)
        {
            return citizenUserRepository.Get(id);
        }

        public virtual CitizenUser FindByLogin(string login)
        {
            return citizenUserRepository.GetUserByName(login);
        }

        public virtual CitizenUser FindUserByNameAndPassword(string userName, string password)
        {
            return citizenUserRepository.GetUserByNameAndPassword(userName, password);
        }

        public virtual void Save(CitizenUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (!ValidateUser(user))
            {
                throw new Exception("User validation failed.");
            }

            citizenUserRepository.Save(user);
        }

        public virtual void Delete(CitizenUser user)
        {
            citizenUserRepository.Delete(user.Id);
        }

        public virtual void ChangePassword(CitizenUser user, string oldPassword, string newPassword)
        {
            if (userPasswordValidator.Validate(newPassword))
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        public virtual async Task SignInAsync(CitizenUser user, bool isPersistent)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var claimsIdentity = new ClaimsIdentity(Startup.AuthMethod);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Login));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.AuthenticationMethod, Startup.AuthMethod));

            foreach (var role in user.Roles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
            }

            var userPrincipal =  new ClaimsPrincipal(claimsIdentity);

            await httpContextAccessor.HttpContext.SignInAsync(userPrincipal,
                new AuthenticationProperties {IsPersistent = isPersistent});
        }

        public virtual bool IsInRole(CitizenUser user, string roleName)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var role = roleRepository.GetRoleByName(roleName);

            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            return user.Roles.Any(useRole => useRole.Name == roleName);
        }

        public virtual void AddToRole(CitizenUser user, string roleName)
        {
            if (IsInRole(user, roleName))
            {
                throw new InvalidOperationException($"User {user.Login} is already in role = {roleName}");
            }

            var role = roleRepository.GetRoleByName(roleName);
            user.Roles.Add(role);
            citizenUserRepository.Save(user);
        }

        public virtual void RemoveFromRole(CitizenUser user, string roleName)
        {
            if (!IsInRole(user, roleName))
            {
                throw new InvalidOperationException($"User {user.Login} is not in role = {roleName}");
            }

            var role = roleRepository.GetRoleByName(roleName);
            user.Roles.Remove(role);
            citizenUserRepository.Save(user);
        }

        protected bool ValidateUser(CitizenUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrWhiteSpace(user.Login))
            {
                return false;
            }

            var owner = FindByLogin(user.Login);

            if (owner != null && owner.Id != user.Id)
            {
                return false;
            }

            if (!userPasswordValidator.Validate(user.Password))
            {
                throw new Exception("Password validation failed.");
            }

            return true;
        }
    }
}
