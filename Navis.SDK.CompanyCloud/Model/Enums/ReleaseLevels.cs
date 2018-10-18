using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Navis.SDK.CompanyCloud.Model.Enums
{
    public enum ReleaseLevels
    {
        /// <summary>
        /// General available.
        /// </summary>
        [EnumMember(Value = "generalAvailable")]
        [JsonProperty(PropertyName = "generalAvailable")]
        GeneralAvailable = 0,

        /// <summary>
        /// Release candidate.
        /// </summary>
        [EnumMember(Value = "releaseCandidate")]
        [JsonProperty(PropertyName = "releaseCandidate")]
        ReleaseCandidate = 1,

        /// <summary>
        /// Beta
        /// </summary>
        [EnumMember(Value = "beta")]
        [JsonProperty(PropertyName = "beta")]
        Beta = 2,

        /// <summary>
        /// Alpha
        /// </summary>
        [EnumMember(Value = "alpha")]
        [JsonProperty(PropertyName = "alpha")]
        Alpha = 3,
    }
}
