using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SpikeMarkLogViewer;

namespace SpikeMarkLogViewerSL
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            grdLog.ItemsSource = Log.Instance.Items;
        }

        private void btnOpenLog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Log Files (.log)|*.log|All Files (*.*)|*.*";
            dlg.FilterIndex = 1;

            bool? userClickedOK = dlg.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                grdLog.ItemsSource = null;
                // Open the selected file to read.
                System.IO.Stream fileStream = dlg.File.OpenRead();
                using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                {
                    try
                    {
                        Log.Instance.InitializeFromStream(reader);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error reading this log file. { " + ex.StackTrace + " }");
                    }
                }
                fileStream.Close();
                grdLog.ItemsSource = Log.Instance.Items;
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchPhrase = txtSearch.Text.ToLower();
            grdLog.ItemsSource = null;
            if (searchPhrase.Equals(string.Empty))
            {
                grdLog.ItemsSource = Log.Instance.Items;
                return;
            }
                

            var foundItems = from item in Log.Instance.Items
                             where (item.Source.ToLower().Contains(searchPhrase) |
                                 item.Message.ToLower().Contains(searchPhrase) | 
                                 item.MessageLevel.ToLower().Contains(searchPhrase))
                             select item;
            
            grdLog.ItemsSource = foundItems;
        }
    }
}
