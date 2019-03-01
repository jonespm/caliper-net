using System;
using System.Collections.Generic;
using System.Linq;
using ImsGlobal.Caliper.Util;
using Newtonsoft.Json.Linq;
using NUnit.Framework;


namespace ImsGlobal.Caliper.Tests.SimpleHelpers {

	internal static class JsonAssertions {

		static JsonAssertions() {
		}

		public static void AssertSameObjectJson(object obj, string eventReferenceFile, bool clean) {

			var eventJObject = JsonSerializeUtils.toJobject( obj );
			if (clean) eventJObject = JsonSerializeUtils.clean( eventJObject );

			var refJsonString = TestUtils.LoadReferenceJsonFixture( eventReferenceFile );
			var refJObject = JObject.Parse(refJsonString);

			bool equals = JToken.DeepEquals( refJObject, eventJObject );

			if ( !equals ) {
				var jdp = new JsonDiffPatchDotNet.JsonDiffPatch();
				JToken patch = jdp.Diff( eventJObject, refJObject );
				Console.WriteLine( "diff:" );
				Console.WriteLine( patch );
				Console.WriteLine( "fixture:" );
				Console.WriteLine( refJObject );
				Console.WriteLine( "created:" );
				Console.WriteLine( eventJObject );

			}

			Assert.True(equals);

		}

		public static void AssertSameObjectJson( object obj, string eventReferenceFile ) {
			AssertSameObjectJson( obj, eventReferenceFile, true );
		}

		/// <summary>
		/// Reduce the objects selected by the given JPath query strings to properties 
		/// whose values are the id of the object.
		/// </summary>
		public static JObject coerce(object input, string[] select) {

			var jobj = JsonSerializeUtils.toJobject( input );

			foreach ( string query in select ) {
				IEnumerable<JToken> tokens = jobj.SelectTokens(query).ToList();

				foreach ( JToken tok in tokens ) {
					var obj = tok as JObject;
					if (obj != null) {
						tok.Parent.Replace(
							new JProperty(( (JProperty)obj.Parent ).Name,
							obj.GetValue( "id" ).ToString())
						);
					}
				}
			}
			return jobj;
		}
	}
}
