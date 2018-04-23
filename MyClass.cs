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

    }
}
