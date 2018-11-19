using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Navis.SDK.CompanyCloud.Model.Enums
{
    public enum ReleaseLevels
    {
        /// <summary>
        /// Alpha
        /// </summary>
        [EnumMember(Value = "alpha")]
        [JsonProperty(PropertyName = "alpha")]
        Alpha = 0,

        /// <summary>
        /// Beta
        /// </summary>
        [EnumMember(Value = "beta")]
        [JsonProperty(PropertyName = "beta")]
        Beta = 1,

        /// <summary>
        /// Release candidate.
        /// </summary>
        [EnumMember(Value = "releaseCandidate")]
        [JsonProperty(PropertyName = "releaseCandidate")]
        ReleaseCandidate = 2,

        /// <summary>
        /// General available.
        /// </summary>
        [EnumMember(Value = "generalAvailable")]
        [JsonProperty(PropertyName = "generalAvailable")]
        GeneralAvailable = 3
    }
}