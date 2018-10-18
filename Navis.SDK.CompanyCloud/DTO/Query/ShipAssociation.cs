namespace Navis.SDK.CompanyCloud.DTO.Query
{
    public class ShipAssociation
    {
        /// <summary>
        /// IMO number of associated ship.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("imo", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Imo { get; set; }

        /// <summary>
        /// Name of associated ship.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vesselName", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VesselName { get; set; }

        /// <summary>
        /// Type of associated role.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("role", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Role { get; set; }

        /// <summary>
        /// From when on the association will be valid.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("validFrom", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime? ValidFrom { get; set; }

        /// <summary>
        /// Until when the association will be valid.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("validUntil", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime? ValidUntil { get; set; }

        /// <summary>
        /// Unique id of the association.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? Uid { get; set; }

        /// <summary>
        /// Converts this <see cref="ShipAssociation"/> instance to json.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Creates a <see cref="ShipAssociation"/> instance out of the specified json.
        /// </summary>
        /// <param name="data">Json data to deserialize <see cref="ShipAssociation"/> instance from.</param>
        /// <returns></returns>
        public static ShipAssociation FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ShipAssociation>(data);
        }

    }
}
