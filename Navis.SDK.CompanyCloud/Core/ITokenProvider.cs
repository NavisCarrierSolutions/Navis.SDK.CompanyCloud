namespace Navis.SDK.CompanyCloud.Core
{
    public interface ITokenProvider
    {
        /// <summary>
        /// Gets the jwt token of the current user.
        /// </summary>
        /// <returns></returns>
        string GetJwtToken();
    }
}
