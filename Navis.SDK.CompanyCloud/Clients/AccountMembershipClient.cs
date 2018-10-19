using System.Threading;
using System.Threading.Tasks;
using Navis.SDK.CompanyCloud.Core;

namespace Navis.SDK.CompanyCloud.Clients
{
    public class AccountMembershipClient : ApiWrapper
    {
        /// <summary>
        /// Creates a new instance of the <see cref="AccountMembershipClient"/> class.
        /// </summary>
        /// <param name="bearerToken">JWT Authorization header using the Bearer scheme.</param>
        public AccountMembershipClient(string bearerToken) : base(bearerToken)
        {
        }

        /// <summary>
        /// Returns the actual (valid) account membership linked to an account of the current user.
        /// </summary>
        /// <param name="accountIdentifier">The account identifier which can be domain or Uid.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<DTO.Query.AccountMembership> GetByIdAsync(string accountIdentifier,
            CancellationToken cancellationToken)
        {
            const string route = "/v1/membership";
            var result = await GetObjectAsync<DTO.Query.AccountMembership>(accountIdentifier, null,
                route, cancellationToken);
            return result;
        }
    }
}
