namespace ImsGlobal.Caliper.Events.Search
{
    public class SearchEvent : Event
    {

        public SearchEvent(string id, Action action)
            : base(id)
        {
            this.Context = CaliperContext.SearchProfileExtension;
            this.Type = EventType.Search;
            this.Action = action;
        }
    }
}
