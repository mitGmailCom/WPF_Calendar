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

namespace WPF_Calendar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calendar calendar;
        enum Mounth { декабрь = 12, январь = 1, февраль, март, апрель, май, июнь, июль, август, сентябрь, октябрь, ноябрь };
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            calendar = new Calendar();
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            lstView.Items.Clear();
            TreeViewItem tmpTrItem = new TreeViewItem();
            if (tmpTrItem != null)
                tmpTrItem = null;
            tmpTrItem = sender as TreeViewItem;
            foreach (Mounth item in Enum.GetValues(typeof(Mounth)))
            {
                if (item.ToString() == (tmpTrItem.Header.ToString()).ToLower())
                {
                    DateTime tDt = new DateTime(DateTime.Now.Year, (int)item, 1);
                    calendar.DisplayDate = tDt;
                    ListViewItem listVItem = new ListViewItem();
                    listVItem.Content = calendar;
                    lstView.Items.Add(listVItem);
                }
            }
        }
    }
}
