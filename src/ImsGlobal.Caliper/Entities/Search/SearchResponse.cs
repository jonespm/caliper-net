using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Search
{
    using ImsGlobal.Caliper.Entities.Agent;
    using System.Collections.Generic;

    public class SearchResponse : Entity
    {
        public SearchResponse(string id)
            : base(id)
        {
            this.Type = EntityType.SearchResponse;
        }

        [JsonProperty("searchProvider", Order = 14)]
        public SoftwareApplication SearchProvider { get; set; }

        [JsonProperty("searchTarget", Order = 15)]
        public Entity SearchTarget { get; set; }

        [JsonProperty("query", Order = 16)]
        public Query Query { get; set; }

        [JsonProperty("searchResultsItemCount", Order = 17)]
        public int SearchResultsItemCount { get; set; }

        [JsonProperty("searchResults", Order = 18)]
        public IList<Entity> SearchResults { get; set; }
    }
}
