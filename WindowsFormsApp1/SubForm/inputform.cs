using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class InputForm : Form
    {
        public string result;
        private const int TLPSize = 180;

        TableLayoutPanel tlp = new TableLayoutPanel();
        Button[] numberBtn = new Button[9];

        //コンストラクタ
        public InputForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            int TLPSize_real = (TLPSize / 3) * 3;
            SetClientSizeCore(TLPSize_real, TLPSize_real);
            tlp.Size = new Size(TLPSize_real, TLPSize_real);

            Controls.Add(tlp);

            for (int i = 0; i < 3; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, (float)(TLPSize / 3)));
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, (float)(TLPSize / 3)));
            }

            for (int i = 0; i < 9; i++)
            {
                numberBtn[i] = new Button();
                numberBtn[i].Font = MainForm.buttonFont;
                numberBtn[i].Text = (i + 1).ToString();
                numberBtn[i].Dock = DockStyle.Fill;
                numberBtn[i].Margin = new Padding(0);
                numberBtn[i].Click += ClicknumberBtn;
                tlp.Controls.Add(numberBtn[i], i % 3, i / 3);
            }
        }
        private void ClicknumberBtn(object sender, EventArgs e)
        {
            result = ((Button)sender).Text;
            Close();
        }
    }
}