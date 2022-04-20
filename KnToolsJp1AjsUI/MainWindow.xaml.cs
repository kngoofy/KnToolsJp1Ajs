using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using KnToolsJp1Ajs;

namespace KnToolsJp1AjsUI
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// メイン
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            var holderName = Directory.GetCurrentDirectory();
            Jp1AjsBookName.Text = holderName + "\\" + "Jp1AjsBook.xlsx";
        }

        /// <summary>
        /// ウィンドウ終了
        /// </summary>
        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// HelpのAboutウィンドウ表示
        /// </summary>
        private void OnMenuAbout(object sender, RoutedEventArgs e)
        {
            var _childWindow = new About();
            _childWindow.ShowDialog();
        }

        /// <summary>
        /// クリックされて、ExcelBook ファイルを指定するメソッド
        /// </summary>
        private void Button_Click_SelectJp1AjsBook(object sender, RoutedEventArgs e)
        {
            OpenDocumentJp1AjsBook();
        }

        /// <summary>
        /// ExcelBook ファイルをopenFileDialogにて設定するメソッド
        /// </summary>
        private void OpenDocumentJp1AjsBook()
        {
            try
            {
                // テキストボックスからファイル名 (ファイルパス) を取得
                string fileName = this.Jp1AjsBookName.Text;

                // OpenFileDialog クラスのインスタンスを生成
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.FileName = "Jp1AjsBook.xlsx";
                    openFileDialog.DefaultExt = ".xlsx";
                    openFileDialog.CheckFileExists = false;     //存在しなくも良いを指定

                    // ファイルの種類リストを設定
                    openFileDialog.Filter = "Jp1AjsBook(.xlsx)|*.xlsx";

                    // テキストボックスにファイル名 (ファイルパス) が設定されている場合は
                    // ファイルのディレクトリー (フォルダー) を初期表示する
                    if (fileName != string.Empty)
                    {
                        // FileInfo クラスのインスタンスを生成
                        FileInfo fileInfo = new FileInfo(fileName);
                        // ディレクトリー名 (ディレクトリーパス) を取得
                        string directoryName = fileInfo.DirectoryName;
                        // 存在する場合は InitialDirectory プロパティに設定
                        if (Directory.Exists(directoryName))
                        {
                            openFileDialog.InitialDirectory = directoryName;
                        }
                    }

                    // ダイアログを表示
                    DialogResult dialogResult = openFileDialog.ShowDialog();
                    if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
                    {
                        // キャンセルされたので終了
                        return;
                    }

                    // 選択されたファイル名 (ファイルパス) をテキストボックスに設定
                    Jp1AjsBookName.Text = openFileDialog.FileName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Jp1AjsBookTextBoxへドラッグオーバーのメソッド
        /// </summary>
        private void EhDragOverJp1AjsBookDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Effects = IsSingleFile(args) != null ? System.Windows.DragDropEffects.Copy : System.Windows.DragDropEffects.None;
            args.Handled = true;
        }

        /// <summary>
        /// Jp1Ajs定義のTextBoxへドラッグオーバーのメソッド
        /// </summary>
        private void EhDragOverJp1AjsDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Effects = IsSingleFile(args) != null ? System.Windows.DragDropEffects.Copy : System.Windows.DragDropEffects.None;
            args.Handled = true;
        }

        /// <summary>
        /// ドラッグオーバーしているファイルのシングルファイルかを調べるメソッド
        /// </summary>
        private string IsSingleFile(System.Windows.DragEventArgs args)
        {
            // Check for files in the hovering data object.
            if (args.Data.GetDataPresent(System.Windows.DataFormats.FileDrop, true))
            {
                var fileNames = args.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
                // Check for a single file or folder.
                if (fileNames?.Length is 1)
                {
                    // Check for a file (a directory will return false).
                    if (File.Exists(fileNames[0]))
                    {
                        // At this point we know there is a single file.
                        return fileNames[0];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Jp1AjsBookのTextBoxへのドラッグアンドロップのメソッド
        /// </summary>
        private void EhDropJp1AjsBookDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Handled = true;    // Mark the event as handled, so TextBox's native Drop handler is not called.
            var fileNames = args.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
            Jp1AjsBookName.Text = fileNames[0];
        }

        /// <summary>
        /// Jp1Ajs定義のTextBoxへのドラッグアンドロップのメソッド
        /// </summary>
        private void EhDropJp1AjsDef(object sender, System.Windows.DragEventArgs args)
        {
            args.Handled = true;    // Mark the event as handled, so TextBox's native Drop handler is not called.
            var fileNames = args.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
            tbJp1AjsDefFileName.Text = fileNames[0];
        }


        /// <summary>
        /// Jp1Ajs定義ファイル(Snd)を指定するダイアログを呼び出すメソッド
        /// </summary>
        private void Button_Click_Jp1Ajs(object sender, RoutedEventArgs e)
        {
            OpenDocumentDef(tbJp1AjsDefFileName);
        }

        /// <summary>
        /// Jp1Ajs定義ファイルを指定するダイアログを表示するメソッド
        /// </summary>
        /// <param name="defName">WfpのTextBoxのコントロール</param>
        private void OpenDocumentDef(System.Windows.Controls.TextBox defName)
        {
            try
            {
                // 
                string fileName = defName.Text;

                // OpenFileDialog クラスのインスタンスを生成
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.FileName = System.IO.Path.GetFileName(fileName);
                    openFileDialog.DefaultExt = ".def";
                    openFileDialog.CheckFileExists = true;     //存在しなくてはいけない

                    // ファイルの種類リストを設定
                    openFileDialog.Filter = "HultDefine(.def,*.txt)|*.def;*.txt|すべてのファイル(*.*)|*.*";

                    // テキストボックスにファイル名 (ファイルパス) が設定されている場合は
                    // ファイルのディレクトリー (フォルダー) を初期表示する
                    if (fileName != string.Empty)
                    {
                        // FileInfo クラスのインスタンスを生成
                        FileInfo fileInfo = new FileInfo(fileName);
                        // ディレクトリー名 (ディレクトリーパス) を取得
                        string directoryName = fileInfo.DirectoryName;
                        // 存在する場合は InitialDirectory プロパティに設定
                        if (Directory.Exists(directoryName))
                        {
                            openFileDialog.InitialDirectory = directoryName;
                        }
                    }

                    // ダイアログを表示
                    DialogResult dialogResult = openFileDialog.ShowDialog();
                    if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
                    {
                        // キャンセルされたので終了
                        return;
                    }

                    // 選択されたファイル名 (ファイルパス) をテキストボックスに設定
                    defName.Text = openFileDialog.FileName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Jp1AjsBook を作成するメソッド
        /// </summary>
        private void Button_Click_CreateJp1AjsBook(object sender, RoutedEventArgs e)
        {
            string bookName = Jp1AjsBookName.Text;
            string defName = tbJp1AjsDefFileName.Text;

            // Jp1AjsBookのフォルダは問題ないか？
            FileInfo fileInfo = new FileInfo(bookName);
            if (!Directory.Exists(fileInfo.DirectoryName))
            {
                MessageBox.Show("生成するJp1AjsBookのフォルダ指定を見直して下さい。");
                return;
            }

            //Jp1Ajs定義ファイルは問題ないか？
            if (string.IsNullOrWhiteSpace(defName) || !File.Exists(defName))
            {
                MessageBox.Show("Jp1Ajs定義ファイルを見直して下さい。");
                return;
            }

            //カーソルをくるくるに変える
            this.Cursor = System.Windows.Input.Cursors.Wait;

            //テンプレートJp1AjsBookを生成
            CreateNewTemplateBook.CreateBook(Jp1AjsBookName.Text);

            //Jp1Ajs定義をパースしてUnit定義を組み立てる
            var ajsdef = BuildJp1AjsDef.StreamBuildJp1AjsDefUnits(defName);

            //Jp1Ajs定義をJp1AjsBookのシートに配置
            UpdateBook.UpdateExcelBook(bookName, ajsdef);

            // カーソルを戻す
            this.Cursor = null;
        }


    }

}

