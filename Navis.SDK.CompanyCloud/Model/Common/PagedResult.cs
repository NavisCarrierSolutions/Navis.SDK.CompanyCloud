namespace Navis.SDK.CompanyCloud.Model.Common
{
    public class PagedResult<T>
    {
        /// <summary>
        /// Current page.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("page", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Page { get; set; }

        /// <summary>
        /// Total number of pages.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("pageCount", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PageCount { get; set; }

        /// <summary>
        /// Size of a page.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PageSize { get; set; }

        /// <summary>
        /// Total item count.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("totalCount", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? TotalCount { get; set; }

        /// <summary>
        /// Observable collection of items.
        /// </summary>
        [Newtonsoft.Json.JsonProperty("items", Required = Newtonsoft.Json.Required.Default,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.ObjectModel.ObservableCollection<T> Items { get; set; }

        /// <summary>
        /// Converts this <see cref="PagedResult{T}"/> instance to json.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Creates a <see cref="PagedResult{T}"/> instance out of the specified json.
        /// </summary>
        /// <param name="data">Json data to deserialize <see cref="PagedResult{T}"/> instance from.</param>
        public static PagedResult<T> FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PagedResult<T>> (data);
        }
    }
}
