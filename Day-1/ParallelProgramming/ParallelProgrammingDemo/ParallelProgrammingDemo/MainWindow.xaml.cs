using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ParallelProgrammingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tbStatus.Text = "Work Started";
            var task = new Task<DateTime>(doWork);
            task.ContinueWith((t) => tbStatus.Text = "Work Completed at " + t.Result.ToLongTimeString()
                ,TaskScheduler.FromCurrentSynchronizationContext());
            task.Start();

            
            
        }

        private void UpdateCompletion(Task<DateTime> t)
        {
            tbStatus.Text = "Work Completed at " + t.Result.ToLongTimeString();
            //Debug.WriteLine("Work completed");
        }

        private DateTime doWork()
        {
            for (int i = 0; i < 40000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    for (int k = 0; k < 100; k++)
                    {
                        
                    }
                }
            }
            return DateTime.Now;
        }
    }
}
