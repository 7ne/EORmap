namespace addScore{
    class TeamMatchResult_item{

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
}
