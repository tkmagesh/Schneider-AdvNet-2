using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
            _cancellationTokenSource = new CancellationTokenSource();
            
            isCancelled = false;
            tbStatus.Text = "Work Started at " + DateTime.Now.ToLongTimeString();
            _task = new Task<DateTime>(doWork,_cancellationTokenSource.Token);
            _task.ContinueWith(UpdateCompletion
                ,TaskScheduler.FromCurrentSynchronizationContext());
            _task.Start();

            
            
        }

        private void UpdateCompletion(Task<DateTime> t)
        {

            try
            {
                tbStatus.Text = "Task completed at " +  t.Result.ToLongTimeString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                if (t.IsCanceled)
                    tbStatus.Text = "Task cancelled";
            }
            //Debug.WriteLine("Work completed");
        }

        private DateTime doWork()
        {
            for (int i = 0; i < 40000; i++)
            {
                if (_cancellationTokenSource.IsCancellationRequested)
                   _cancellationTokenSource.Token.ThrowIfCancellationRequested();
                for (int j = 0; j < 1000; j++)
                {
                    for (int k = 0; k < 100; k++)
                    {
                        
                    }
                }
            }
            return DateTime.Now;
        }

        private bool isCancelled = false;
        private CancellationTokenSource _cancellationTokenSource;
        private Task<DateTime> _task;

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSource.Cancel();
            //isCancelled = true;
        }
    }
}
