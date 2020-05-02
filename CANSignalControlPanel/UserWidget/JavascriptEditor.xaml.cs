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
using ICSharpCode.AvalonEdit;
namespace CANSignalControlPanel.UserWidget {
    /// <summary>
    /// JavascriptEditor.xaml 的交互逻辑
    /// </summary>
    public partial class JavascriptEditor : UserControl {
        public JavascriptEditor() {
            InitializeComponent();
        }
        public string code { 
            get{
                return textEditor.Text;
            }
            set{
                textEditor.Text = value;
            }
        }
        public bool lineWarp {
            get {
                return textEditor.WordWrap;
            }
            set {
                textEditor.WordWrap = value;
            }
        }
        public bool lineNumber {
            get {
                return textEditor.ShowLineNumbers;
            }
            set {
                textEditor.ShowLineNumbers = value;
            }
        }

    }
}