namespace addScore
{
    class ComboboxItem
    {

        public int event_id { get; set; }
        public string event_date { get; set; }
        public string event_format { get; set; }

        public ComboboxItem(int id, string name, string date)
        {
            event_id = id;
            event_format = name;
            event_date = date;
        }

        public override string ToString()
        {
            return event_date + "　" + event_format;
        }
    }
}
