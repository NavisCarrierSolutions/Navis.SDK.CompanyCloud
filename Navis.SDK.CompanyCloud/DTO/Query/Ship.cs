using System;

namespace Navis.SDK.CompanyCloud.DTO.Query
{
    public class Ship
    {
        /// <summary>
        /// Unique identifier of ship.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Guid Uid { get; set; }

        /// <summary>
        /// IMO number of ship.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("imo", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Imo { get; set; }

        /// <summary>
        /// Default name of ship.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("defaultName", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DefaultName { get; set; }

        /// <summary>
        /// Converts this <see cref="Ship"/> instance to json.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Creates a <see cref="Ship"/> instance out of the specified json.
        /// </summary>
        /// <param name="data">Json data to deserialize <see cref="Ship"/> instance from.</param>
        public static Ship FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Ship>(data);
        }
    }
}
