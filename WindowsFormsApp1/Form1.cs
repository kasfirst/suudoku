using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private const int TLPSize = 400;
        private const int FLPWidth = 150;
        public static Font buttonFont = new Font("游ゴシック", 12);
        private readonly int[] box_start = { 0, 3, 6, 27, 30, 33, 54, 57, 60 };
        private readonly int[] box_offset = { 0, 1, 2, 9, 10, 11, 18, 19, 20 };

        int[] kazu = new int[81];

        public Form1()
        {
            Load += Form1_load;
        }
        private void ClicknumberBtn(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "")
            {
                InputForm input = new InputForm();
                int Form1_x = Left;
                int Form1_y = Top;
                int x_min = ((Button)sender).Left;
                int y_min = ((Button)sender).Top;
                int width_half = ((Button)sender).Width / 2;

                input.Left = Form1_x + x_min + width_half;
                input.Top = Form1_y + y_min + width_half;
                input.StartPosition = FormStartPosition.Manual;
                input.ShowDialog();

                ((Button)sender).Text = input.result;
                input.Dispose();
            }
            else
            {
                ((Button)sender).Text = "";
            }
        }
        private void Kensyo_Click(object sender, EventArgs e)
        {
            int d;
            for (int i = 0; i < 81; i++)
            {
                int.TryParse(numberBtn[i].Text, out d);
                kazu[i] = d;
            }
            string kensyo = Kensyo_do();
            if (kensyo == "")
            {
                solveBtn.Enabled = true;
                kensyoBtn.Enabled = false;
                kensyoCnacelBtn.Enabled = true;
                hintBtn.Enabled = true;
                foreach (Button btn in numberBtn)
                {
                    btn.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show(kensyo, "結果"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Kensyo_Cancel_Click(object sender, EventArgs e)
        {
            int d;
            for (int i = 0; i < 81; i++)
            {
                int.TryParse(numberBtn[i].Text, out d);
                kazu[i] = d;
            }
            
            solveBtn.Enabled = false;
            kensyoBtn.Enabled = true;
            kensyoCnacelBtn.Enabled = false;
            hintBtn.Enabled = false;
            foreach (Button btn in numberBtn)
            {
                btn.Enabled = true;
            }
        }

        private string Kensyo_do()
        {
            int[] box_test = new int[9];
            int[] row_test = new int[9];
            int[] col_test = new int[9];

            for (int i = 0; i < 9; i++)
            {
                for (int ii = 0; ii < 9; ii++)
                {
                    box_test[ii] = kazu[box_start[i] + box_offset[ii]];
                    row_test[ii] = kazu[i * 9 + ii];
                    col_test[ii] = kazu[i + ii * 9];
                }
                if (box_test.Where(c => c > 0).Count() != box_test.Where(c => c > 0).Distinct().Count())
                {
                    return "ボックスの中に重複する数字があります。";
                }
                if (row_test.Where(c => c > 0).Count() != row_test.Where(c => c > 0).Distinct().Count())
                {
                    return "横列に重複する数字があります。";
                }
                if (col_test.Where(c => c > 0).Count() != col_test.Where(c => c > 0).Distinct().Count())
                {
                    return "縦列に重複する数字があります。";
                }
            }
            return "";
        }
        private void New_Click(object sender, EventArgs e)
        {
            foreach (Button btn in numberBtn)
            {
                btn.Enabled = true;
                btn.Text = "";
            }
            kensyoBtn.Enabled = true;
            kensyoCnacelBtn.Enabled = false;
            solveBtn.Enabled = false;
            hintBtn.Enabled = false;
        }
        private void Solve_Click(object sender, EventArgs e)
        {
            solveBtn.Enabled = false;
            newBtn.Enabled = false;

            if (Try())
            {
                for (int i = 0; i < 81; i++)
                {
                    numberBtn[i].Text = kazu[i].ToString();
                }
                foreach (Button btn in numberBtn)
                {
                    btn.Enabled = true;
                }
                kensyoBtn.Enabled = true;
                kensyoCnacelBtn.Enabled = false;
                newBtn.Enabled = true;
                hintBtn.Enabled = false;
            }
        }
        private bool Try()
        {
            int blank_position = Array.IndexOf(kazu, 0);
            if (blank_position == -1) return true;

            for (int i = 1; i < 10; i++)
            {
                if (!(IsOK(blank_position, i, kazu))) continue;
                kazu[blank_position] = i;
                if (Try()) return true;
                kazu[blank_position] = 0;
            }
            return false;
        }
        private bool IsOK(int blk_position, int try_numnber, int[] _kazu)
        {
            int row_index = blk_position / 9;
            int col_index = blk_position % 9;
            int box_index = (row_index / 3) * 3 + col_index / 3;
            for (int i = 0; i < 9; i++)
            {
                if (_kazu[row_index * 9 + i] == try_numnber) return false;
                if (_kazu[col_index + i * 9] == try_numnber) return false;
                if (_kazu[box_start[box_index] + box_offset[i]] == try_numnber) return false;
            }
            return true;
        }
    }
}