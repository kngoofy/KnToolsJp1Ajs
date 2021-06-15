using System;
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
    public partial class Form1 : Form
    {
        // Default System一覧 ブックを作成するSystemをチェック
        Dictionary<string, bool> _dict = new Dictionary<string, bool>();

        public Form1()
        {
            InitializeComponent();
            checkBoxAzNavel.Checked = _dict["AzNavel"] = true;
            checkBoxfBase.Checked = _dict["fBase"] = true;
            checkBoxDerico.Checked = _dict["Derico"] = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "jp1def (*.def)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //
                    filePath = openFileDialog.FileName;
                }
            }
            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);

            //
            var makebook = new AdapterMain();
            var file = filePath.Replace(@"\\", @"\");
            textBox1.Text = file;
            makebook.MakeJp1DefBookAdapter(file);

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
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            for (int i = 0; i < files.Length; i++)
            {
                string fileName = files[i];
                textBox1.Text = fileName;
            }

            var makebook = new AdapterMain();
            var file = textBox1.Text.Replace(@"\\", @"\");
            textBox1.Text = file;
            makebook.MakeJp1DefBookAdapter(file);

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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxAzNavel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "jp1def (*.def)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //
                    filePath = openFileDialog.FileName;
                }
            }
            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);

            //
            var makebook = new AdapterMain();
            var file = filePath.Replace(@"\\", @"\");
            textBox1.Text = file;
            makebook.MakeJp1DefBookAdapter(file);

        }
    }
}
