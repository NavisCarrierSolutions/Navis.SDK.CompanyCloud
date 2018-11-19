using Navis.SDK.CompanyCloud.Model.Enums;

namespace Navis.SDK.CompanyCloud.DTO.Query
{
    public class Feature
    {
        /// <summary>
        /// Feature key.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }

        /// <summary>
        /// Feature name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Feature description.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Feature area.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("featureArea", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FeatureArea { get; set; }

        /// <summary>
        /// Unique feature ID.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid Uid { get; set; }

        /// <summary>
        /// Release level of feature.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("releaseLevel", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ReleaseLevels ReleaseLevel { get; set; }

        /// <summary>
        /// Converts this <see cref="Feature"/> instance to json.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Creates a <see cref="Feature"/> instance out of the specified json.
        /// </summary>
        /// <param name="data">Json data to deserialize <see cref="Feature"/> instance from.</param>
        public static Feature FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Feature>(data);
        }
    }
}
