﻿using MahApps.Metro.Controls;
using System.Windows;
using System;
using Microsoft.Win32;
using System.IO;

namespace noty
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void LoadButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                Filter = "Text file | *.txt",
                Title = "File load",
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    TextArea.Text = File.ReadAllText(dialog.FileName, System.Text.Encoding.GetEncoding("UTF-8"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                FileName = "note.txt",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                Filter = "Text file | *.txt",
                Title = "File save",
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllText(dialog.FileName, TextArea.Text, System.Text.Encoding.GetEncoding("UTF-8"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
