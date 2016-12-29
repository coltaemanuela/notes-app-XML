using System;
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
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;


namespace Draft_3_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Timestamp.Content = DateTime.Now;
        }

        private void BiggerFont_Click(object sender, RoutedEventArgs e)
        {
             
            Write.Selection.ApplyPropertyValue(Inline.FontSizeProperty, FontSize + 3);
        } 

        private void Bold_Click(object sender, RoutedEventArgs e)
        {
             Write.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
         }

        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            Write.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
      
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveNotice = new SaveFileDialog();
     
            //  File.WriteAllText(saveNotice.FileName, this.Write.DataContext.ToString());
            saveNotice.DefaultExt = ".txt";

            if (saveNotice.ShowDialog() == true)
            {
                FileStream fs = File.OpenWrite(saveNotice.FileName);
                try
                {
                    
                    System.Windows.Markup.XamlWriter.Save(Write.Document, fs);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error");
                       
                }
                finally
                {
                    fs.Close();
                }
            }
                    
               
        }

        private void SmallerFont_Click(object sender, RoutedEventArgs e)
        {
           // Write.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, FontSize-=2);
            Write.Selection.ApplyPropertyValue(Inline.FontSizeProperty, FontSize - 3);
            
        }

        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            Write.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
           
        }

        private void TextColor_Click(object sender, RoutedEventArgs e) //highlight text selectat
        {
            Write.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush (Colors.Yellow));
            
        }
    }
}
