using System;
using System.Collections.ObjectModel;

namespace Navis.SDK.CompanyCloud.DTO.Query
{
    public class AccountMembership
    {
        /// <summary>
        /// Account.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("account", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AccountShort Account { get; set; }

        /// <summary>
        /// User
        /// </summary>
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public UserShort User { get; set; }

        /// <summary>
        /// Features
        /// </summary>
        [Newtonsoft.Json.JsonProperty("features", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ObservableCollection<Feature> Features { get; set; }

        /// <summary>
        /// Apps
        /// </summary>
        [Newtonsoft.Json.JsonProperty("apps", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ObservableCollection<UserApp> Apps { get; set; }

        /// <summary>
        /// From when on the membership will be valid.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("validFrom", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime? ValidFrom { get; set; }

        /// <summary>
        /// Until when the membership will be valid.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("validUntil", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime? ValidUntil { get; set; }

        /// <summary>
        /// Unique ID of account membership.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Guid? Uid { get; set; }

        /// <summary>
        /// Converts this <see cref="AccountMembership"/> instance to json.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Creates a <see cref="AccountMembership"/> instance out of the specified json.
        /// </summary>
        /// <param name="data">Json data to deserialize <see cref="AccountMembership"/> instance from.</param>
        /// <returns></returns>
        public static AccountMembership FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AccountMembership>(data);
        }
    }
}
