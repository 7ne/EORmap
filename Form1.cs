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
            All_reset();
        }

    }
}
