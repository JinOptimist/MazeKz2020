using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private UserValidator userValidator;
        private IHttpContextAccessor httpContextAccessor;

        public UserService(CitizenUserRepository citizenUserRepository, RoleRepository roleRepository,
            UserValidator userValidator, IHttpContextAccessor httpContextAccessor)
        {
            this.citizenUserRepository = citizenUserRepository;
            this.roleRepository = roleRepository;
            this.userValidator = userValidator;
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

        public virtual void Save(CitizenUser user)
        {
            userValidator.Validate(user);
            citizenUserRepository.Save(user);
        }

        public virtual void Delete(CitizenUser user)
        {
            citizenUserRepository.Delete(user.Id);
        }

        public virtual void ChangePassword(CitizenUser user, string oldPassword, string newPassword)
        {
            userValidator.ValidatePassword(newPassword);
            
            throw new NotImplementedException();
        }

        public virtual async Task SignInAsync(string userName, string password, bool isPersistent)
        {
            var user = citizenUserRepository.GetUserByNameAndPassword(userName, password);

            if (user == null)
            {
                throw new ValidationException("Login or password is incorrect.");
            }

            var claimsIdentity = new ClaimsIdentity(Startup.AuthMethod);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Login));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.AuthenticationMethod, Startup.AuthMethod));

            foreach (var role in user.Roles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
            }

            var userPrincipal = new ClaimsPrincipal(claimsIdentity);

            await httpContextAccessor.HttpContext.SignInAsync(userPrincipal,
                new AuthenticationProperties { IsPersistent = isPersistent });
        }

        public virtual bool IsInRole(CitizenUser user, string roleName)
        {
            if (user == null)
            {
                throw new ValidationException("Specified user does not exist.");
            }

            var role = roleRepository.GetRoleByName(roleName);

            if (role == null)
            {
                throw new ValidationException("Specified role does not exist.");
            }

            return user.Roles.Any(useRole => useRole.Name == roleName);
        }

        public virtual void AddToRole(CitizenUser user, string roleName)
        {
            if (IsInRole(user, roleName))
            {
                throw new ValidationException($"User {user.Login} is already in role = {roleName}");
            }

            var role = roleRepository.GetRoleByName(roleName);
            user.Roles.Add(role);
            citizenUserRepository.Save(user);
        }

        public virtual void RemoveFromRole(CitizenUser user, string roleName)
        {
            if (!IsInRole(user, roleName))
            {
                throw new ValidationException($"User {user.Login} is not in role = {roleName}");
            }

            var role = roleRepository.GetRoleByName(roleName);
            user.Roles.Remove(role);
            citizenUserRepository.Save(user);
        }
    }
}
