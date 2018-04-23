using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace addScore {
    public partial class Form1 : Form {

        private int select_id = 0;
        private int now_round = 0;

        public Form1() {
            InitializeComponent();

            //大会情報取得
            string queryString = "SELECT TournamentId,FormatCode,StartDate FROM [Tournament]";
            Get_tournament_data(queryString);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox1.SelectedIndex != -1) {
                ComboboxItem combobox_item;
                combobox_item = (ComboboxItem)comboBox1.SelectedItem;
                select_id = combobox_item.event_id;
            }
        }

        private void AutostartBtn_Click(object sender, EventArgs e) {
            //自動更新開始
            if (select_id == 0) {
                MessageBox.Show("トーナメントを選択してください。");
                return;
            }
            timer1.Enabled = true;
            Autoload_lbl.Text = "自動更新：オン";
        }

        private void AutoendBtn_Click(object sender, EventArgs e) {
            //自動更新終了
            timer1.Enabled = false;
            Autoload_lbl.Text = "自動更新：オフ";

        }

        private void Update_button_ClickAsync(object sender, EventArgs e) {
            if (select_id == 0) {
                MessageBox.Show("トーナメントを選択してください。");
                return;
            }
            Updata_data();
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            Updata_data();
        }

        private void ResetBtn_Click(object sender, EventArgs e) {
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
