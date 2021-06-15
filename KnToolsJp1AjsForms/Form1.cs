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

namespace KnToolsJp1AjsForms
{
    /// <summary>
    /// JP1AJS ブック作成ツール forms アプリ
    /// </summary>
    public partial class Form1 : Form
    {
        // Default System一覧 ブックを作成するSystemをチェック
        Dictionary<string, bool> _dict = new Dictionary<string, bool>();

        //コンストラクタ
        public Form1()
        {
            InitializeComponent();
            checkBoxAzNavel.Checked = _dict["AzNavel"] = true;
            checkBoxfBase.Checked = _dict["fBase"] = true;
            checkBoxDerico.Checked = _dict["Derico"] = true;
        }

        //ピクチャをクリックするとOpenFileDialogを出して、AJS定義ファイルを指定後ブック作成
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "JP1AJS定義のファイルを開く";
                openFileDialog.InitialDirectory = @"c:\";
                openFileDialog.Filter = "jp1def (*.def)|*.txt|All files (*.*)|*.*";
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

        private void button1_Click(object sender, EventArgs e)
        {
            _dict["AzNavel"] = checkBoxAzNavel.Checked;
            _dict["fBase"] = checkBoxfBase.Checked;
            _dict["Derico"] = checkBoxDerico.Checked;
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
                textBox1.Text += Path.GetFileName(filePath)+";";
                var bookPath = Path.GetDirectoryName(filePath) + @"\"
                         + Path.GetFileNameWithoutExtension(filePath) + ".xlsx";
                CreateBookFromForms.CreateBookFromFilePath(filePath, bookPath);
            }

            //var makebook = new AdapterMain();
            //var file = textBox1.Text.Replace(@"\\", @"\");
            //textBox1.Text = file;
            //makebook.MakeJp1DefBookAdapter(file);
            //CreateBookFromForms.CreateBookFromFilePath(file, null);
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

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxAzNavel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
}
