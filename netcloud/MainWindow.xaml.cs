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
using Meting4Net;
using Microsoft.Win32;



namespace netcloud
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //定义音乐的类
        public class MusicFile
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }
        }

        //读取文件的方法
        public void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "选择音乐文件";
                openFileDialog.Filter = "所有文件 (*.*)|*.*"; // 你可以根据需要设置文件过滤条件

                // 显示打开文件对话框
                if (openFileDialog.ShowDialog() == true)
                {
                    // 获取用户选择的文件路径
                    string filePath = openFileDialog.FileName;



                MusicFile musicFile = new MusicFile
                {
                    FileName = System.IO.Path.GetFileName(filePath),
                    FilePath = filePath
                };

                //添加到musicList 的 listbox控件。
                musicList.Items.Add(musicFile);

                // 在这里可以进行文件的读取或其他操作
                // 例如，可以将文件路径显示在文本框中
                // txtFilePath.Text = filePath;

                // 读取文件内容（以文本文件为例）
                try
                    {
                        using (StreamReader reader = new StreamReader(filePath))
                        {
                            string content = reader.ReadToEnd();
                            // 处理文件内容，例如显示在文本框中
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("读取文件时出错: " + ex.Message);
                    }
                }
            

        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            // 检查ListBox是否有选中的音乐文件



              if (musicList.SelectedItem is MusicFile selectedMusicFile)




          {
            // 设置MediaElement的源为选中的音乐文件路径
               mediaPlayer.Source = new Uri(selectedMusicFile.FilePath, UriKind.Absolute);
              mediaPlayer.Play();

             }
             else
            {
                  if (mediaPlayer.CanPause)
                     mediaPlayer.Pause();
               }

           


        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            // 关闭应用程序
            Application.Current.Shutdown();
        }
        private void Minibtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState=WindowState.Minimized;
        }
        private void Maxbtn_Click(object sender, RoutedEventArgs e)
        {
            // 如果当前窗口是最大化状态，则还原窗口
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
            else
            {
                // 如果当前窗口不是最大化状态，则最大化窗口
                WindowState = WindowState.Maximized;
            }
        }

    }
}
