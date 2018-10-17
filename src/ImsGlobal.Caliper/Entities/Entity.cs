using System.Collections.Generic;

using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Entities {

	/// <summary>
	/// Default base class for Caliper entities.
	/// </summary>
	public class Entity : IEntity {

		public Entity( string id )
		{
            this.Id = id;
            this.Type = EntityType.Entity;
            this.Context = CaliperContext.Context.Value;
		}

		[JsonProperty( "@context", Order = 0 )]
		public string Context { get; set; }

        [JsonProperty("id", Order = 1)]
        public string Id { get; set; }

        [JsonProperty("type", Order = 2)]
        public IType Type { get; set; }

        [JsonProperty( "name", Order = 3 )]
		public string Name { get; set; }

		[JsonProperty( "description", Order = 4 )]
		public string Description { get; set; }

		[JsonProperty( "extensions", Order = 51 )]
		public object Extensions { get; set; }

		[JsonProperty( "dateCreated", Order = 52 )]
		public Instant? DateCreated { get; set; }

		[JsonProperty( "dateModified", Order = 53 )]
		public Instant? DateModified { get; set; }

        [JsonIgnore]
        public bool HideCaliperContext { get; set; }

        public bool ShouldSerializeContext()
        {
            return !HideCaliperContext;
        }
    }

}
