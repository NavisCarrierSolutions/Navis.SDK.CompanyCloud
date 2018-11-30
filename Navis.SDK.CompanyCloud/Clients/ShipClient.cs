using Navis.SDK.CompanyCloud.Core;
using Navis.SDK.CompanyCloud.Model.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Navis.SDK.CompanyCloud.Clients
{
    public class ShipClient : ApiWrapper
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ShipClient"/> class.
        /// </summary>
        /// <param name="tokenProvider">Provides the user's JWT token when requested.</param>
        /// <param name="ncsSettings">The NCS settings to use for this client.</param>
        public ShipClient(ITokenProvider tokenProvider, INcsSettings ncsSettings) : base(tokenProvider, ncsSettings)
        {
        }

        /// <summary>
        /// Returns the ship that matches the specific identifier.
        /// </summary>
        /// <param name="identifier">The ship identifier which can be imo or Uid.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<DTO.Query.Ship> GetByIdAsync(string identifier,
            CancellationToken cancellationToken)
        {
            var route = $"/v1/ships/{identifier}";
            var result = await GetObjectAsync<DTO.Query.Ship>(null, null,
                route, null, cancellationToken);
            return result;
        }

        /// <summary>
        /// Returns all ships.
        /// </summary>
        /// <param name="page">The page number of the query. (Optional. Default: 0)</param>
        /// <param name="pageSize">The page size of the query. (Optional. Default: 20)</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<PagedResult<DTO.Query.Ship>> GetAllAsync(int page = 0, int pageSize = 20, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var route = $"/v1/ships?page={page}&pageSize={pageSize}";
            var result = await GetObjectAsync<PagedResult<DTO.Query.Ship>>(null, null,
                route, null, cancellationToken);
            return result;
        }

        /// <summary>
        /// Updates the specified ship.
        /// </summary>
        /// <param name="identifier">The ship identifier which can be imo or Uid.</param>
        /// <param name="ship">The ship.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<DTO.Query.Ship> PutAsync(string identifier, DTO.Post.Ship ship, 
            CancellationToken cancellationToken)
        {
            var route = $"/v1/ships/{identifier}";
            var result = await PutObjectAsync<DTO.Query.Ship, DTO.Post.Ship>(ship, null, null,
                route, cancellationToken);
            return result;
        }

        /// <summary>
        /// Creates a new ship.
        /// </summary>
        /// <param name="ship">The ship.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<DTO.Query.Ship> PostAsync(DTO.Post.Ship ship,
            CancellationToken cancellationToken)
        {
            const string route = "/v1/ships";
            var result = await PostObjectAsync<DTO.Query.Ship, DTO.Post.Ship>(ship, null, null,
                route, cancellationToken);
            return result;
        }

        /// <summary>
        /// Deletes the ship with the specific identifier.
        /// </summary>
        /// <param name="identifier">The ship identifier which can be imo or Uid.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other
        /// objects or threads to receive notice of cancellation.</param>
        /// <exception cref="HttpException">A server side error occurred.</exception>
        public async Task<DTO.Query.Ship> DeleteAsync(string identifier,
            CancellationToken cancellationToken)
        {
            var route = $"/v1/ships/{identifier}";
            var result = await DeleteObjectAsync<DTO.Query.Ship>(null, null,
                route, cancellationToken);
            return result;
        }
    }
}
