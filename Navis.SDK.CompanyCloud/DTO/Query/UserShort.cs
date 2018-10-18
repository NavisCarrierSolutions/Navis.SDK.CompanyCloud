namespace Navis.SDK.CompanyCloud.DTO.Query
{
    public class UserShort
    {
        /// <summary>
        /// Email address of user.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// Unique user ID.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? Uid { get; set; }

        /// <summary>
        /// Converts this <see cref="UserShort"/> instance to json.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Creates a <see cref="AccountShort"/> instance out of the specified json.
        /// </summary>
        /// <param name="data">Json data to deserialize <see cref="UserShort"/> instance from.</param>
        public static UserShort FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserShort>(data);
        }
    }
}
