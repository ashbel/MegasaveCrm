using Megasave.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Megasave.Web.Context
{
    public class CustomUserManager : UserManager<Users>
    {
        public CustomUserManager(IUserStore<Users> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<Users> passwordHasher,
            IEnumerable<IUserValidator<Users>> userValidators,
            IEnumerable<IPasswordValidator<Users>> passwordValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
            IServiceProvider services, ILogger<UserManager<Users>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        private IUserRoleStore<Users> GetUserRoleStore()
        {
            var cast = Store as IUserRoleStore<Users>;
            if (cast == null)
            {
                throw new NotSupportedException();
            }
            return cast;
        }

        public override async Task<IdentityResult> AddToRoleAsync(Users user, string role)
        {
            ThrowIfDisposed();
            var userRoleStore = GetUserRoleStore();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var normalizedRole = NormalizeName(role);
            //if (await userRoleStore.IsInRoleAsync(user, normalizedRole, CancellationToken))
            //{
            //    return UserAlreadyInRoleError(role);
            //}
            await userRoleStore.AddToRoleAsync(user, role, CancellationToken);
            return await UpdateUserAsync(user);
            //return base.AddToRoleAsync(user, role);
        }
    }
}