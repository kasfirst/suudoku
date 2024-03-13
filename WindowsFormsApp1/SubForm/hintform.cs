using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class HintForm : Form
    {
        private const int CellSize = 50; // セルのサイズ
        private const int PanelSize = 9; // パネルのサイズ

        public HintForm(List<int>[,] possible_numbers)
        {
            InitializeComponent();
            CreateSudokuPanel(possible_numbers);
        }
        private void CreateSudokuPanel(List<int>[,] possible_numbers)
        {
            // 数独パネルのテキストボックスを動的に作成する
            for (int row = 0; row < PanelSize; row++)
            {
                for (int col = 0; col < PanelSize; col++)
                {
                    TextBox textBox = new TextBox();
                    textBox.ReadOnly = true; // 読み取り専用
                    textBox.Multiline = true; // 複数行入力を許可
                    textBox.ScrollBars = ScrollBars.None; // スクロールバーを非表示に設定
                    textBox.Font = new Font("Arial", 9f); // フォント設定
                    textBox.TextAlign = HorizontalAlignment.Center; // 中央揃え
                    textBox.Size = new Size(CellSize, CellSize); // サイズ設定
                    textBox.Location = new Point(col * CellSize, row * CellSize); // 位置設定

                    // 数独の可能な数字をテキストボックスに表示する
                    string text = "";
                    int count = 0;
                    if (possible_numbers[row,col] != null)
                    {
                        foreach (int number in possible_numbers[row, col])
                        {
                            text += number.ToString() + " ";
                            if (count % 3 == 2)
                            {
                                text += "\r\n";
                            }
                            count++;
                        }
                    }
                    textBox.Text = text.Trim(); // 末尾の空白を除去
                    textBox.Enabled = false;

                    this.Controls.Add(textBox); // フォームに追加
                }
            }
        }

        public void UpdateContent(List<int>[,] possible_numbers)
        {
            
            // フォーム内のテキストボックスの数を数える変数
            int textBoxCount = 0;

            // 数独パネルのテキストボックスを動的に作成する
            for (int row = 0; row < PanelSize; row++)
            {
                for (int col = 0; col < PanelSize; col++)
                {
                    // フォーム内のテキストボックスを取得
                    TextBox textBox = this.Controls[textBoxCount] as TextBox;
                    textBox.Enabled = true;
                    // 数独の可能な数字をテキストボックスに表示する
                    string text = "";
                    int count = 0;
                    if (possible_numbers[row, col] != null)
                    {
                        foreach (int number in possible_numbers[row, col])
                        {
                            text += number.ToString() + " ";
                            if (count % 3 == 2)
                            {
                                text += "\r\n";
                            }
                            count++;

                        }
                    }
                    textBox.Text = text.Trim(); // 末尾の空白を除去
                    textBox.Enabled = false;
                    //次のテキストボックスに移動
                    textBoxCount++;

                }
            }
        }
    }
}
