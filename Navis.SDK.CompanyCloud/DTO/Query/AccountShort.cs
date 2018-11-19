using System;

namespace Navis.SDK.CompanyCloud.DTO.Query
{
    public class AccountShort
    {
        /// <summary>
        /// Name of the account.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Domain of the account.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("domain", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Domain { get; set; }

        /// <summary>
        /// Unique ID of the account.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Guid Uid { get; set; }

        /// <summary>
        /// Converts this <see cref="AccountShort"/> instance to json.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Creates a <see cref="AccountShort"/> instance out of the specified json.
        /// </summary>
        /// <param name="data">Json data to deserialize <see cref="AccountShort"/> instance from.</param>
        public static AccountShort FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AccountShort>(data);
        }
    }
}
