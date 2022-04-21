using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KnToolsJp1Ajs;
using System.Net.Http;

namespace KnToolsJp1AjsForms
{
    /// <summary>
    /// JP1AJS ブック作成ツール forms アプリ
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// メイン
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        //ピクチャをクリックするとOpenFileDialogを出して、AJS定義ファイルを指定後ブック作成
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            //var fileContent = string.Empty;
            //var holderName = Directory.GetCurrentDirectory();
            string filePath;//= string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "JP1AJS定義のファイルを開く";
                openFileDialog.InitialDirectory = @"c:\";
                openFileDialog.Filter = "jp1def (*.def)|*.def|text (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    textBox1.Text = filePath;
                    var bookPath = Path.GetDirectoryName(filePath) + @"\"
                        + Path.GetFileNameWithoutExtension(filePath) + ".xlsx";
                    CreateBookFromForms.CreateBookFromFilePath(filePath, bookPath);
                    //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
                }
            }
        }

        private  void Button1_Click(object sender, EventArgs e)
        {
            
        }

        //JP1AJSのAJSPRINT出力形式ファイルをドロップしたときのブック作成処理実行
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            //
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            Array.Sort(filePaths);
            textBox1.Text = "";
            for (int i = 0; i < filePaths.Length; i++)
            {
                string filePath = filePaths[i];
                textBox1.Text += Path.GetFileName(filePath) + ";";
                var bookPath = Path.GetDirectoryName(filePath) + @"\"
                         + Path.GetFileNameWithoutExtension(filePath) + ".xlsx";
                CreateBookFromForms.CreateBookFromFilePath(filePath, bookPath);
            }

        }

        //JP1AJSのAJSPRINT出力形式ファイルをドロップしたときのチェック
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckBoxAzNavel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        { 
        }


    }
}
