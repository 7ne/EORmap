using System;
using System.Data.OleDb;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace addScore {
    partial class Form1 {
        private List<List<string>> Access_command(string queryString) {
            List<List<string>> return_list = new List<List<string>>();
            try {
                using (OleDbConnection connection = new OleDbConnection(connection_path)) {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        List<string> in_list = new List<string>();

                        for (int i = 0; i < reader.FieldCount; i++) {
                            in_list.Add(reader.GetValue(i).ToString());
                        }

                        return_list.Add(in_list);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            return return_list;
        }
        private List<TeamMatchResult_item> Get_TeamMatchResult() {
            string queryString = "SELECT [TeamId],[GameWins],[MatchId] FROM [TeamMatchResult]";
            List<TeamMatchResult_item> return_list = new List<TeamMatchResult_item>();
            try {
                using (OleDbConnection connection = new OleDbConnection(connection_path)) {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        return_list.Add(new TeamMatchResult_item() { TeamId = reader.GetInt32(0), GameWins = reader.GetInt32(1), MatchId = reader.GetInt32(2) });
                    }
                    connection.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return return_list;
        }
        private List<Team_item> Get_Team() {
            string queryString = "SELECT [Name],[TeamId] FROM [Team]";
            List<Team_item> return_list = new List<Team_item>();
            try {
                using (OleDbConnection connection = new OleDbConnection(connection_path)) {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        return_list.Add(new Team_item() { TeamId = reader.GetInt32(1), Name = reader.GetString(0) });
                    }
                    connection.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return return_list;
        }
        private List<db_table_state_item> Get_db_table_state() {
            string queryString = "SELECT num,state,time FROM db_table_state";
            var connection_mysql = new MySqlConnection(connstr);
            connection_mysql.Open();
            MySqlCommand cmd = new MySqlCommand(queryString, connection_mysql);
            MySqlDataReader reader = cmd.ExecuteReader();
            List<db_table_state_item> return_list = new List<db_table_state_item>();
            while (reader.Read()) {
                return_list.Add(new db_table_state_item() { num = Int32.Parse(reader.GetString(0)), state = reader.GetString(1), time = Int32.Parse(reader.GetString(2)) });
            }
            return return_list;
        }
        private List<string> Get_p(List<TeamMatchResult_item> TeamMatchResult_list, List<Team_item> Team_list, string MatchId) {
            List<string> return_list = new List<string>();
            object p_name = null;
            object p2_name = null;
            //TeamID2個
            List<TeamMatchResult_item> result = TeamMatchResult_list.FindAll(x => x.MatchId == Int32.Parse(MatchId));
            foreach (TeamMatchResult_item aPart in result) {
                int TeamId = aPart.TeamId;
                //プレイヤー名の取得
                if (p_name == null) { p_name = Team_list.Find(x => x.TeamId == TeamId); }
                else { p2_name = Team_list.Find(x => x.TeamId == TeamId); }
            }
            return_list.Add(p_name.ToString());
            return_list.Add(p2_name.ToString());
            return return_list;
        }

    }
}
