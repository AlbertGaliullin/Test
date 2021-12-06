using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Client.ServiceReference1.IServiceCallback
    {  
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        ServiceReference1.ServiceClient client;
        BindingList<DOC> T;
        private void B_Click_1(object sender, RoutedEventArgs e)
            {

            client = new ServiceReference1.ServiceClient(new System.ServiceModel.InstanceContext(this));
            client.RetDoc();
                
            }

        public void InfRet(string text)
        {
            T = new BindingList<DOC>();
            string[] t1 = text.Split(';');
            string[] t2;
            foreach (string elem in t1)
            { t2 = elem.Split(',');
                T.Add(new DOC(t2[0], t2[1], t2[2]));
            }
            DG.ItemsSource = T;
        }
    }
   
    class DOC
    { 
        public string dateTime { get; set; }
        public string number { get; set; }
        public string dateTimeLastUpdate { get; set; }

        public DOC(string s1, string s2, string s3)
        {
            dateTime = s1;
            number = s2;
            dateTimeLastUpdate = s3;
        }
    }
}
