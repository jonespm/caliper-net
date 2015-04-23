﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImsGlobal.Caliper.Util;
using Newtonsoft.Json;
using NodaTime;

namespace ImsGlobal.Caliper.Events {
	using ImsGlobal.Caliper.Entities.Agent;
	using ImsGlobal.Caliper.Entities.Foaf;
	using ImsGlobal.Caliper.Entities.W3c;

	/// <summary>
	/// Base class for all Caliper events.
	/// </summary>
	public abstract class Event {
		// ------ Core Properties ------

		/// <summary>
		/// Required - JSON-LD context for the CaliperEvent
		/// </summary>
		[JsonProperty( "@context", Order = 1 )]
		public EventContext Context { get; set; }

		/// <summary>
		/// Required - Type of the CaliperEvent
		/// </summary>
		[JsonProperty( "@type", Order = 2 )]
		public EventType Type { get; set; }

		/// <summary>
		/// Required - Agent (User, System) that performed the action
		/// </summary>
		[JsonProperty( "actor", Order = 3 )]
		public IAgent Actor { get; set; }

		/// <summary>
		/// Required - Action performed by the agent - from Metric Profile
		/// </summary>
		[JsonProperty( "action", Order = 4 )]
		public Action Action { get; protected set; }

		/// <summary>
		/// Required - "Activity Context" - from Metric Profile
		/// </summary>
		[JsonProperty( "object", Order = 5 )]
		public dynamic Object { get; set; }

		/// <summary>
		/// Optional - "target" - from Metric Profile
		/// </summary>
		[JsonProperty( "target", Order = 6 )]
		public dynamic Target { get; set; }

		/// <summary>
		/// Optional - entity "generated" as result of action - from Metric Profile
		/// </summary>
		[JsonProperty( "generated", Order = 7 )]
		public dynamic Generated { get; set; }

		/// <summary>
		/// Required - time that the event was started at
		/// </summary>
		[JsonProperty( "startedAtTime", Order = 8 )]
		public Instant? StartedAt { get; set; }

		/// <summary>
		/// An optional time that the event ended at
		/// </summary>
		[JsonProperty( "endedAtTime", Order = 9 )]
		public Instant? EndedAt { get; set; }

		/// <summary>
		/// Optional - duration of the event
		/// </summary>
		[JsonProperty( "duration", Order = 10 )]
		public Period Duration { get; set; }

		// ------ Contextual Properties ------

		/// <summary>
		/// EdApp context
		/// </summary>
		[JsonProperty( "edApp", Order = 11 )]
		public SoftwareApplication EdApp { get; set; }

		/// <summary>
		/// Group context
		/// </summary>
		[JsonProperty( "group", Order = 12 )]
		public IOrganization Group { get; set; }

	}

}
