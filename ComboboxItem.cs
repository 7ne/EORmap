namespace addScore
{
    class Team_item {
    public int TeamId { get; set; }
    public string Name { get; set; }

    public Team_item() {
        TeamId = 0;
        Name = "";
    }
    public override string ToString() {
        return Name;
    }
}

class db_table_state_item {
    public int num { get; set; }
    public string state { get; set; }
    public int time { get; set; }

    public db_table_state_item(){
        num = 0;
        state = "";
        time = 0;
    }
    public override string ToString(){
        return state;
    }
}

class TeamMatchResult_item {
    public int TeamId { get; set; }
    public int GameWins { get; set; }
    public int MatchId { get; set; }

    public TeamMatchResult_item(){
        TeamId = 0;
        GameWins = 0;
        MatchId = 0;
    }
    public override string ToString(){
        return GameWins.ToString();
    }
}

class PlayerItem {
    public string player_name { get; set; }
    public string player2_name { get; set; }
    public int input_condition { get; set; }

    public PlayerItem() {
        player_name = "";
        player2_name = "";
        input_condition = 0;
    }
}

class ComboboxItem {
    public int event_id { get; set; }
    public string event_date { get; set; }
    public string event_format { get; set; }

    public ComboboxItem(int id, string name, string date) {
        event_id = id;
        event_format = name;
        event_date = date;
    }

    public override string ToString() {
        return event_date + "　" + event_format;
    }
}

}
