using Newtonsoft.Json;

namespace ImsGlobal.Caliper {
	using ImsGlobal.Caliper.Util;

	[JsonConverter( typeof( JsonValueConverter<CaliperContext> ) )]
	public sealed class CaliperContext : IJsonValue {

		public static readonly CaliperContext Context = new CaliperContext( "http://purl.imsglobal.org/ctx/caliper/v1p1" );
        public static readonly CaliperContext SearchProfileExtension = new CaliperContext("http://purl.imsglobal.org/ctx/caliper/v1p1/SearchProfile-extension");

        public CaliperContext() {}

		public CaliperContext( string value ) {
			this.Value = value;
		}

		public string Value { get; set; }
	}

}