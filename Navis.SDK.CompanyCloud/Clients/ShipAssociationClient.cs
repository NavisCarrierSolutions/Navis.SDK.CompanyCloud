using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Navis.SDK.CompanyCloud.Core;
using Navis.SDK.CompanyCloud.Model.Common;

namespace Navis.SDK.CompanyCloud.Clients
{
    public class ShipAssociationClient : ApiWrapper
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ShipAssociationClient"/> class.
        /// </summary>
        /// <param name="tokenProvider">Provides the user's JWT token when requested.</param>
        /// <param name="ncsSettings">The NCS settings to use for this client.</param>
        public ShipAssociationClient(ITokenProvider tokenProvider, INcsSettings ncsSettings) : base(tokenProvider, ncsSettings)
        {
        }

        /// <summary>
        /// Returns all associations between ships and an domain specific user account.
        /// </summary>
        /// <param name="accountIdentifier">The account identifier which can be domain or Uid.</param>
        /// <param name="page">The page number of the query. (Optional. Default: 0)</param>
        /// <param name="pageSize">The page size of the query. (Optional. Default: 20)</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<PagedResult<DTO.Query.ShipAssociation>> GetAllAsync(string accountIdentifier, 
            int page = 0, int pageSize = 20, CancellationToken cancellationToken = default(CancellationToken))
        {
            var route = $"/v1/shipAssociations?page={page}&pageSize={pageSize}";
            var result = await GetObjectAsync<PagedResult<DTO.Query.ShipAssociation>>(accountIdentifier, null, 
                route, cancellationToken);
            return result;
        }

        /// <summary>
        /// Returnes all associations between ship with target imo and an domain specific user account.
        /// </summary>
        /// <param name="imo">IMO number of ship</param>
        /// <param name="accountIdentifier">The account identifier which can be domain or Uid.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<ObservableCollection<DTO.Query.ShipAssociation>> GetByImoAsync(int imo, string accountIdentifier,
            CancellationToken cancellationToken)
        {
            var route = $"/v1/shipAssociations/{imo}";
            var result = await GetObjectAsync<ObservableCollection<DTO.Query.ShipAssociation>>(accountIdentifier, null,
                route, cancellationToken);
            return result;
        }

        /// <summary>Creates a new ship association under specific domain.</summary>
        /// <param name="shipAssociation">The ship association.</param>
        /// <param name="accountIdentifier">The account identifier which can be domain or Uid.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<DTO.Query.ShipAssociation> PostAsync(DTO.Post.ShipAssociation shipAssociation, string accountIdentifier,
            CancellationToken cancellationToken)
        {
            const string route = "/v1/shipAssociations";
            var result = await PostObjectAsync<DTO.Query.ShipAssociation, DTO.Post.ShipAssociation>(shipAssociation, 
                accountIdentifier, null, route, cancellationToken);
            return result;
        }
    }
}
