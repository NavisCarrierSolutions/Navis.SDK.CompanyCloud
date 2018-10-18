namespace Navis.SDK.CompanyCloud.DTO.Post
{
    public class Ship
    {
        /// <summary>
        /// Unique identifier of ship.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("uid", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Uid { get; set; }

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
    }
}
