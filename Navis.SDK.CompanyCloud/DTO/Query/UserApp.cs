using System;
using Navis.SDK.CompanyCloud.Model.Enums;

namespace Navis.SDK.CompanyCloud.DTO.Query
{
    public class UserApp
    {
        /// <summary>
        /// App name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// URL of app.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("appUrl", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AppUrl { get; set; }

        /// <summary>
        /// URL of app icon.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("iconUrl", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IconUrl { get; set; }

        /// <summary>
        /// Release level of app.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("releaseLevel", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ReleaseLevels ReleaseLevel { get; set; }

        /// <summary>
        /// Unique identifier of app.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Guid Uid { get; set; }

        /// <summary>
        /// Converts this <see cref="UserApp"/> instance to json.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Creates a <see cref="UserApp"/> instance out of the specified json.
        /// </summary>
        /// <param name="data">Json data to deserialize <see cref="UserApp"/> instance from.</param>
        public static UserApp FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserApp>(data);
        }
    }
}
