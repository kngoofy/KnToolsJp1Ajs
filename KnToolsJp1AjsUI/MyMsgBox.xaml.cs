﻿using System;
using System.Collections.Generic;
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

namespace KnToolsJp1AjsUI
{
    /// <summary>
    /// MyMsgBox.xaml の相互作用ロジック
    /// </summary>
    public partial class MyMsgBox : UserControl
    {
        public MyMsgBox(string message)
        {
            InitializeComponent();

            //メッセージをテキストボックスへ反映
            txtMessage.Text = message;

        }
    }
}
