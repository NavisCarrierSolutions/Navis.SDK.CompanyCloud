using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Navis.SDK.CompanyCloud.Model.Enums
{
    public enum RoleOptions
    {
        /// <summary>
        /// Undefined role.
        /// </summary>
        [EnumMember(Value = "undefined")]
        [JsonProperty(PropertyName = "undefined")]
        Undefined = 0,

        /// <summary>
        /// Owner role.
        /// </summary>
        [EnumMember(Value = "owner")]
        [JsonProperty(PropertyName = "owner")]
        Owner = 1,

        /// <summary>
        /// Manager role.
        /// </summary>
        [EnumMember(Value = "manager")]
        [JsonProperty(PropertyName = "manager")]
        Manager = 2,

        /// <summary>
        /// Charter role.
        /// </summary>
        [EnumMember(Value = "charter")]
        [JsonProperty(PropertyName = "charter")]
        Charter = 3,
    }
}
