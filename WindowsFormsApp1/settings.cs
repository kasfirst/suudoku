using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        FlowLayoutPanel flp1 = new FlowLayoutPanel();
        TableLayoutPanel tlp1 = new TableLayoutPanel();
        Button[] numberBtn = new Button[81];
        Button dummyBtn = new Button();
        Button newBtn = new Button();
        Button kensyoBtn = new Button();
        Button kensyoCnacelBtn = new Button();
        Button solveBtn = new Button();
        Button hintBtn = new Button();

        private void Form1_load(object sender, EventArgs e)
        {
            int[] btn_position = { 0, 1, 2, 4, 5, 6, 8, 9, 10 };

            Text = "数独";

            for (int i = 0; i < 3; i++)
            {
                tlp1.RowStyles.Add(new RowStyle(SizeType.Percent, 11f));
                tlp1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11f));
            }
            tlp1.RowStyles.Add(new RowStyle(SizeType.Percent, .5f));
            tlp1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, .5f));
            for (int i = 0; i < 3; i++)
            {
                tlp1.RowStyles.Add(new RowStyle(SizeType.Percent, 11f));
                tlp1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11f));
            }
            tlp1.RowStyles.Add(new RowStyle(SizeType.Percent, .5f));
            tlp1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, .5f));
            for (int i = 0; i < 3; i++)
            {
                tlp1.RowStyles.Add(new RowStyle(SizeType.Percent, 11f));
                tlp1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11f));
            }
            tlp1.Size = new Size(TLPSize, TLPSize);

            for (int i = 0; i < 81; i++)
            {
                numberBtn[i] = new Button();
                numberBtn[i].Text = "";
                numberBtn[i].Dock = DockStyle.Fill;
                numberBtn[i].Margin = new Padding(0);
                numberBtn[i].Font = buttonFont;
                numberBtn[i].Click += ClicknumberBtn;
                tlp1.Controls.Add(numberBtn[i], btn_position[i % 9], btn_position[i / 9]);
            }
            SetClientSizeCore(TLPSize + FLPWidth, TLPSize);

            Controls.Add(tlp1);

            flp1.Width = FLPWidth;
            flp1.Dock = DockStyle.Right;
            flp1.FlowDirection = FlowDirection.BottomUp;

            Controls.Add(flp1);

            dummyBtn.Size = new Size(flp1.Width, 0);



            kensyoBtn.AutoSize = true;
            kensyoBtn.Font = buttonFont;
            kensyoBtn.Text = "検証";
            kensyoBtn.Width = (int)(flp1.Width * 0.9);
            kensyoBtn.Anchor = AnchorStyles.None;
            kensyoBtn.Click += Kensyo_Click;

            kensyoCnacelBtn.AutoSize = true;
            kensyoCnacelBtn.Font = buttonFont;
            kensyoCnacelBtn.Text = "検証解除";
            kensyoCnacelBtn.Width = (int)(flp1.Width * 0.8);
            kensyoCnacelBtn.Anchor = AnchorStyles.None;
            kensyoCnacelBtn.Enabled = false;
            kensyoCnacelBtn.Click += Kensyo_Cancel_Click;

            hintBtn.AutoSize = true;
            hintBtn.Font = buttonFont;
            hintBtn.Text = "ヒント";
            hintBtn.Width = (int)(flp1.Width * 0.8);
            hintBtn.Anchor = AnchorStyles.None;
            hintBtn.Enabled = false;
            hintBtn.Click += New_Click;

            solveBtn.AutoSize = true;
            solveBtn.Font = buttonFont;
            solveBtn.Text = "実行";
            solveBtn.Width = (int)(flp1.Width * 0.8);
            solveBtn.Anchor = AnchorStyles.None;
            solveBtn.Enabled = false;
            solveBtn.Click += Solve_Click;

            newBtn.AutoSize = true;
            newBtn.Font = buttonFont;
            newBtn.Text = "新規入力";
            newBtn.Width = (int)(flp1.Width * 0.9);
            newBtn.Anchor = AnchorStyles.None;
            newBtn.Click += New_Click;




            flp1.Controls.Add(dummyBtn);
            flp1.Controls.Add(newBtn);
            flp1.Controls.Add(solveBtn);
            flp1.Controls.Add(hintBtn);
            flp1.Controls.Add(kensyoCnacelBtn);
            flp1.Controls.Add(kensyoBtn);
        }
    }
}