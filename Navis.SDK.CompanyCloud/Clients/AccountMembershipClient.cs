using Navis.SDK.CompanyCloud.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Navis.SDK.CompanyCloud.Clients
{
    public class AccountMembershipClient : ApiWrapper
    {
        /// <summary>
        /// Creates a new instance of the <see cref="AccountMembershipClient"/> class.
        /// </summary>
        /// <param name="tokenProvider">Provides the user's JWT token when requested.</param>
        /// <param name="ncsSettings">The NCS settings to use for this client.</param>
        public AccountMembershipClient(ITokenProvider tokenProvider, INcsSettings ncsSettings) : base(tokenProvider, ncsSettings)
        {
        }

        /// <summary>
        /// Returns the actual (valid) account membership linked to an account of the current user.
        /// </summary>
        /// <param name="accountIdentifier">The account identifier which can be domain or Uid.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <param name="appIdentifier">App identifier to fetch only app-related features</param>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<DTO.Query.AccountMembership> GetByIdAsync(string accountIdentifier,
            CancellationToken cancellationToken, string appIdentifier = null)
        {
            const string route = "/v1/membership";
            var result = await GetObjectAsync<DTO.Query.AccountMembership>(accountIdentifier, null,
                route, cancellationToken, appIdentifier);
            return result;
        }
    }
}
