namespace addScore
{
    class PlayerItem
    {
        public string player_name { get; set; }
        public string player2_name { get; set; }
        public int input_condition { get; set; }

        public PlayerItem()
        {
            player_name = "";
            player2_name = "";
            input_condition = 0;
        }
    }
}
