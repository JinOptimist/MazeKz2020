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
        private IHttpContextAccessor httpContextAccessor;

        public UserService(CitizenUserRepository citizenUserRepository, RoleRepository roleRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            this.citizenUserRepository = citizenUserRepository;
            this.roleRepository = roleRepository;
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
            citizenUserRepository.Save(user);
        }

        public virtual void Delete(CitizenUser user)
        {
            citizenUserRepository.Delete(user.Id);
        }

        public virtual void ChangePassword(CitizenUser user, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<OperationResult> SignInAsync(string userName, string password, bool isPersistent)
        {
            var user = citizenUserRepository.GetUserByNameAndPassword(userName, password);

            if (user == null)
            {
                return OperationResult.Failed("Login or password is incorrect.");
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

            return OperationResult.Success();
        }

        public virtual bool IsInRole(CitizenUser user, string roleName)
        {
            return user.Roles.Any() && user.Roles.All(useRole => useRole.Name == roleName);
        }

        public virtual OperationResult AddToRole(CitizenUser user, string roleName)
        {
            if (user == null)
            {
                return OperationResult.Failed("Specified user does not exist.");
            }

            var role = roleRepository.GetRoleByName(roleName);

            if (role == null)
            {
                return OperationResult.Failed("Specified role does not exist.");
            }

            if (IsInRole(user, roleName))
            {
                return OperationResult.Failed($"User {user.Login} is already in role = {roleName}");
            }

            user.Roles.Add(role);
            citizenUserRepository.Save(user);
            return OperationResult.Success();
        }

        public virtual OperationResult RemoveFromRole(CitizenUser user, string roleName)
        {
            if (user == null)
            {
                return OperationResult.Failed("Specified user does not exist.");
            }

            var role = roleRepository.GetRoleByName(roleName);

            if (role == null)
            {
                return OperationResult.Failed("Specified role does not exist.");
            }

            if (!IsInRole(user, roleName))
            {
                return OperationResult.Failed($"User {user.Login} is not in role = {roleName}");
            }

            user.Roles.Remove(role);
            citizenUserRepository.Save(user);
            return OperationResult.Success();
        }
    }
}
