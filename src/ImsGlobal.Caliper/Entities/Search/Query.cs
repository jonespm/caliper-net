using Newtonsoft.Json;

namespace ImsGlobal.Caliper.Entities.Search
{
    using ImsGlobal.Caliper.Entities.Agent;

    public class Query : Entity
    {
        public Query(string id)
            : base(id)
        {
            this.Context = CaliperContext.SearchProfileExtension.Value;
            this.Type = EntityType.Query;
        }

        [JsonProperty("creator", Order = 14)]
        public Person Creator { get; set; }

        [JsonProperty("searchTarget", Order = 15)]
        public Entity SearchTarget { get; set; }

        [JsonProperty("searchTerms", Order = 16)]
        public string SearchTerms { get; set; }
    }
}
