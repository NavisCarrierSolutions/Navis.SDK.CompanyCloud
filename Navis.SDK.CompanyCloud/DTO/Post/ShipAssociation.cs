using System;
using Navis.SDK.CompanyCloud.Model.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Navis.SDK.CompanyCloud.DTO.Post
{
    public class ShipAssociation
    {
        /// <summary>
        /// IMO number of ship.
        /// </summary>
        [JsonProperty("imo", Required = Required.Default,
            NullValueHandling = NullValueHandling.Ignore)]
        public int? Imo { get; set; }

        /// <summary>
        /// Name of vessel.
        /// </summary>
        [JsonProperty("vesselName", Required = Required.Default,
            NullValueHandling = NullValueHandling.Ignore)]
        public string VesselName { get; set; }

        /// <summary>
        /// Role type.
        /// </summary>
        [JsonProperty("role", Required = Required.Default,
            NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public RoleOptions? Role { get; set; }

        /// <summary>
        /// From when on the ship association will be valid.
        /// </summary>
        [JsonProperty("validFrom", Required = Required.Default,
            NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ValidFrom { get; set; }

        /// <summary>
        /// Until when the ship association will be valid.
        /// </summary>
        [JsonProperty("validUntil", Required = Required.Default,
            NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ValidUntil { get; set; }

        /// <summary>
        /// Unique ID of ship association.
        /// </summary>
        [JsonProperty("uid", Required = Required.Default,
            NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Uid { get; set; }

        /// <summary>
        /// Converts this <see cref="ShipAssociation"/> instance to json.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Creates a <see cref="ShipAssociation"/> instance out of the specified json.
        /// </summary>
        /// <param name="data">Json data to deserialize <see cref="ShipAssociation"/> instance from.</param>
        public static ShipAssociation FromJson(string data)
        {
            return JsonConvert.DeserializeObject<ShipAssociation>(data);
        }
    }
}