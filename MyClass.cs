using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace addScore {
    partial class Form1 {
        private static string connection_path = Properties.Settings.Default.connection_path;
        private static string connstr = Properties.Settings.Default.connstr;
        private static string url = Properties.Settings.Default.url;

      
        private void Get_tournament_data(string queryString) {
            ComboboxItem comboboxItem;

            List<List<string>> tournament_list = Access_command(queryString);
            foreach (List<string> _tournament_list in tournament_list) {
                int tournamentId = Int32.Parse(_tournament_list[0]);
                string formatCode = _tournament_list[1];
                string startDate = _tournament_list[2];

                comboboxItem = new ComboboxItem(tournamentId, formatCode, startDate);
                comboBox1.Items.Add(comboboxItem);
            }
        }
        private void Send_query(string queryString) {
            var connection_mysql = new MySqlConnection(connstr);
            connection_mysql.Open();
            MySqlCommand cmd = new MySqlCommand(queryString, connection_mysql);
            MySqlDataReader reader = cmd.ExecuteReader();
            connection_mysql.Close();
        }
        private void Updata_data() {
            string queryString = "SELECT [MatchId],[TableNumber] FROM [Match] WHERE RoundId =(SELECT Max([RoundId]) FROM [Round] WHERE [TournamentId]=" + select_id + ")";
            List<List<string>> tournament_list = Access_command(queryString);
            List<TeamMatchResult_item> TeamMatchResult_list = Get_TeamMatchResult();
            List<db_table_state_item> Get_db_table_state_list = Get_db_table_state();

            foreach (List<string> _tournament_list in tournament_list) {
                string MatchId = _tournament_list[0];
                string TableNumber = _tournament_list[1];
                object GameWins = TeamMatchResult_list.Find(x => x.MatchId == Int32.Parse(MatchId));
                string con = "end";
                if (GameWins.ToString() == "-1") {
                    //covを上書きしないようにする
                    con = Get_db_table_state_list.Find(x => x.num == Int32.Parse(TableNumber)).ToString();
                }
                Send_query("UPDATE db_table_state SET state=\"" + con.ToString() + "\" WHERE num = " + TableNumber);
            }

            Api_call("update");

            DateTime dtNow = DateTime.Now;
            autotime_lbl.Text = dtNow.Hour.ToString() + ":" + dtNow.Minute.ToString() + " :" + dtNow.Second.ToString();
        }
        private void Api_call(String mode) {
            try {
                var client = new HttpClient();
                var json = "{}";//ダミー
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                client.PostAsync(url + mode, content);//非同期…
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void All_reset() {
            Api_call("lock");

            Send_query("DELETE FROM db_table");
            Send_query("DELETE FROM db_table_state");
            Send_query("DELETE FROM db_table_who");
            //マッチからテーブルナンバーと組み合わせを取得
            string queryString = "SELECT [MatchId],[TableNumber] FROM [Match] WHERE RoundId =(SELECT Max([RoundId]) FROM [Round] WHERE [TournamentId]=" + select_id + ")";
            List<List<string>> newround_list = Access_command(queryString);
            List<TeamMatchResult_item> TeamMatchResult_list = Get_TeamMatchResult();
            List<Team_item> Team_list = Get_Team();

            foreach (List<string> _newround_list in newround_list) {
                string TableNumber = _newround_list[1];
                string MatchId = _newround_list[0];

                List<string> gplist = Get_p(TeamMatchResult_list, Team_list, MatchId);
                object p_name = gplist[0];
                object p2_name = gplist[1];

                Send_query("INSERT INTO db_table VALUES(" + TableNumber + ",\"" + p_name + "\",\"" + p2_name + "\");");
                Send_query("INSERT INTO db_table_state VALUES(" + TableNumber + ",\"nor\",0);");
            }

            //現在のラウンド数　foreachである必要は無い
            string queryString_round = "SELECT [Number] FROM [Round] WHERE [TournamentId]=" + select_id + "";
            List<List<string>> roundnum_list = Access_command(queryString_round);
            foreach (List<string> num in roundnum_list) {
                round_lbl.Text = num[0].ToString();
                now_round = Int32.Parse(num[0]);

                Send_query("INSERT INTO db_round(round_num) VALUES(" + now_round + ");");
            }
            Api_call("reset");
        }
    }
}
