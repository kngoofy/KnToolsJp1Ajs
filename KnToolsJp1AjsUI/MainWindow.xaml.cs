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
using Path = System.IO.Path;

using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;

namespace KnToolsJp1AjsUI
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        /// <summary>
        /// メイン
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            var holderName = Directory.GetCurrentDirectory();
            tbJp1AjsBookName.Text = holderName + "\\" + "Jp1AjsBook.xlsx";
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
            //OpenFileDialogを開いて生成するExcelBookを指定
            var file = tbJp1AjsBookName.Text;
            file = MyOpenFileDialog(file, ".xlsx", "Jp1AjsBook(.xlsx)|*.xlsx", false);

            //指定された場合テキストボックスにセット
            if (!string.IsNullOrWhiteSpace(file)) tbJp1AjsBookName.Text = file;
        }

        /// <summary>
        /// Jp1Ajs定義ファイルを指定するダイアログを呼び出すメソッド
        /// </summary>
        private void Button_Click_Jp1Ajs(object sender, RoutedEventArgs e)
        {
            //OpenDocumentDef(tbJp1AjsDefFileName);

            //OpenFileDialogを開いてJp1Ajs定義ファイルを指定
            var file = tbJp1AjsDefFileName.Text;
            file = MyOpenFileDialog(file, ".def", "HultDefine(.def,*.txt)|*.def;*.txt|すべてのファイル(*.*)|*.*", true);

            //指定された場合テキストボックスにセット
            if (!string.IsNullOrWhiteSpace(file)) tbJp1AjsDefFileName.Text = file;

        }

        /// <summary>
        /// ExcelBook ファイルをopenFileDialogにて設定するメソッド
        /// </summary>
        private string MyOpenFileDialog(string fileName, string defaultExt, string filter, bool checkFileExists)
        {
            // OpenFileDialog クラスのインスタンスを生成
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                //Default ファイル名
                FileName = fileName,

                //Default ファイルの種類
                DefaultExt = defaultExt,

                //ファイルの種類リストを設定
                Filter = filter,

                //存在しないといけないか？を指定
                CheckFileExists = checkFileExists
            };

            // テキストボックスにファイル名 (ファイルパス) が設定されている場合は
            // ファイルのディレクトリー (フォルダー) を初期表示する
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                // 存在する場合は InitialDirectory プロパティに設定
                string fileDir = Path.GetDirectoryName(fileName);
                if (Directory.Exists(fileDir))
                {
                    openFileDialog.InitialDirectory = fileDir;
                }
            }

            // ダイアログを表示
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.Cancel)
            {
                // キャンセルされたので終了
                return "";
            }

            // 選択されたファイル名 (ファイルパス) をテキストボックスに設定
            return openFileDialog.FileName;
        }

        /// <summary>
        /// Jp1AjsBookのTextBoxへドラッグオーバーのメソッド
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
            tbJp1AjsBookName.Text = fileNames[0];
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
        /// Jp1AjsBook を作成するメソッド
        /// </summary>
        private async void Button_Click_CreateJp1AjsBook(object sender, RoutedEventArgs e)
        {
            //変数に
            string book = tbJp1AjsBookName.Text;

            if (string.IsNullOrWhiteSpace(book))
            {
                //MessageBox.Show("生成するJp1AjsBookを指定して下さい。");
                tbJp1AjsBookName.Focusable = true;
                _ = tbJp1AjsBookName.Focus();
                await DialogHost.Show(new MyMsgBox("生成するJp1AjsBookを指定して下さい。"));
                return;
            }

            string bookDir = Path.GetDirectoryName(book);
            string def = tbJp1AjsDefFileName.Text;

            //生成するJp1AjsBookのフォルダは問題ないのか？
            //FileInfo fileInfo = new FileInfo(bookName);
            if (!Directory.Exists(bookDir))
            {
                //MessageBox.Show("指定したJp1AjsBookのフォルダを見直して下さい。");
                tbJp1AjsBookName.Focusable = true;
                _ = tbJp1AjsBookName.Focus();
                await DialogHost.Show(new MyMsgBox("指定したJp1AjsBookのフォルダを見直して下さい。"));
                return;
            }

            //Jp1Ajs定義ファイルは問題ないかのか？
            if (string.IsNullOrWhiteSpace(def) || !File.Exists(def))
            {
                //MessageBox.Show("指定した元となるJp1Ajs定義ファイルを見直して下さい。");
                tbJp1AjsDefFileName.Focusable = true;
                _ = tbJp1AjsDefFileName.Focus();
                await DialogHost.Show(new MyMsgBox("指定した元となるJp1Ajs定義ファイルを見直して下さい。"));
                return;
            }

            //カーソルを待ちに変える
            Cursor = System.Windows.Input.Cursors.Wait;

            //テンプレートJp1AjsBookを生成
            _ = CreateNewTemplateBook.CreateBook(book);

            //Jp1Ajs定義をパースしてUnit定義を組み立てる
            KnToolsJp1Ajs.Jp1AjsDef.AjsDef ajsdef = BuildJp1AjsDef.StreamBuildJp1AjsDefUnits(def);

            //Jp1Ajs定義をJp1AjsBookのシートに配置
            _ = UpdateBook.UpdateExcelBook(book, ajsdef);

            //カーソルを戻す
            Cursor = null;
        }

        /// <summary>
        /// ドラグオーバーされた時の処理
        /// </summary>
        private void EhDragOverDropApple(object sender, System.Windows.DragEventArgs args)
        {
            args.Effects = System.Windows.DragDropEffects.Copy;
            args.Handled = true;
        }

        /// <summary>
        /// ドラグアンドドロップされたJp1Ajs定義ファイルで、Jp1AjsBookを作成する
        /// </summary>
        private void EhDropDropApple(object sender, System.Windows.DragEventArgs args)
        {
            //ドロップされたJp1Ajs定義ファイルの配列
            var fileNames = args.Data.GetData(System.Windows.DataFormats.FileDrop, true) as string[];
            args.Handled = true;    // Mark the event as handled

            //カーソルを待ちに変える
            Cursor = System.Windows.Input.Cursors.Wait;

            //ドロップされたJp1Ajs定義ファイルで、同じディレクトリにJp1AjsBookを作成する
            foreach (var file in fileNames)
            {
                //作成するJp1AjsBookファイル名を組み立て
                var path = Path.GetDirectoryName(file);
                var name = Path.GetFileNameWithoutExtension(file);
                var book = path + @"\" + name + ".xlsx";

                //テンプレートJp1AjsBookを生成
                CreateNewTemplateBook.CreateBook(book);

                //Jp1Ajs定義をパースしてUnit定義を組み立てる
                KnToolsJp1Ajs.Jp1AjsDef.AjsDef ajsdef = BuildJp1AjsDef.StreamBuildJp1AjsDefUnits(file);

                //Jp1Ajs定義をJp1AjsBookのシートに配置
                UpdateBook.UpdateExcelBook(book, ajsdef);

            }
            //カーソルを戻す
            Cursor = null;
        }

    }

}

