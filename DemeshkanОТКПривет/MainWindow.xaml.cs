using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

namespace DemeshkanОТКПривет
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel MainViewModel { get; } = new MainViewModel();
        private ObservableCollection<MainViewModel> colect { get; } = new ObservableCollection<MainViewModel>();
        private Order  ord = new Order();
        private Services ser = new Services();
        private List<Services> ServList = new List<Services>();
        private List<Order> OrdList = new List<Order>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ord;


            ServDataGrid.DataContext = MainViewModel;
            //ServDataGrid.SelectedItem = ser;
            Serv.ItemsSource = DemeshkanOTKprogEntities1.GetContext().Services.ToList();
            CBClient.DataContext = ord;
            CBClient.ItemsSource = MainViewModel.ClientsList;
            MainViewModel.listServicesViemodel.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectChng);
            OrderDate.Text = DateTime.Today.ToString();
            ord.StartDate = DateTime.Today;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            //ServList = ServDataGrid.DataContext as List<Services>;

            /*if (ord.Client == null || ord.Client < 1)
                errors.AppendLine("Укажите Клиента");*/
            if (string.IsNullOrEmpty(ord.LaboratoryVesselId))
                errors.AppendLine("Укажите номер посуды");
            /*if (ord.Service == null || ord.Service < 1)
                errors.AppendLine("Укажите услугу");*/
            if (ord.StartDate == null || ord.StartDate < DateTime.Today || ord.StartDate > DateTime.Today.AddDays(1))
                errors.AppendLine("Укажите дату закза");
            if (ord.Price < 0)
                errors.AppendLine("Укажите цену заказа");
            if (MainViewModel.listServicesViemodel.Count > DemeshkanOTKprogEntities1.GetContext().Services.ToList().Count)
            {
                errors.AppendLine("Удалите дубликаты услуг");
            }

            var newLsit = MainViewModel.listServicesViemodel;
            foreach (var serviceItem in DemeshkanOTKprogEntities1.GetContext().Services.ToList())
            {
                int countServices = 0;
                foreach (var vm in newLsit)
                {
                    if (vm.selectedService == serviceItem)
                    {
                        countServices++;
                    }
                }
                if (countServices > 1)
                {
                    errors.AppendLine("Удалите дубликаты услуг");
                    break;
                }
                countServices = 0;
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                DemeshkanOTKprogEntities1.GetContext().Order.Add(ord);
                try
                {
                    DemeshkanOTKprogEntities1.GetContext().SaveChanges();
                    foreach (var s in MainViewModel.listServicesViemodel)
                    {
                        if (s == null)
                            continue;
                        ord.Services.Add(s.selectedService);
                    }
                }
                catch
                {
                    MessageBox.Show("Нет заказа");
                }

            }

            try
            {
                DemeshkanOTKprogEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch
            {
                MessageBox.Show("Не сохранено");
            }
        }
        PageClientAdd PgClientAdd;
        private void AddNewClient_Click(object sender, RoutedEventArgs e)
        {
            if (PgClientAdd == null)
            {
                PgClientAdd = new PageClientAdd(MainViewModel);
                PgClientAdd.Show();
            }
            else if (!PgClientAdd.IsVisible)
            {
                PgClientAdd = null;
                PgClientAdd = new PageClientAdd(MainViewModel);
                PgClientAdd.Show();
            }
        }

        private void CBClient_DropDownOpened(object sender, EventArgs e)
        {

        }
        private void CollectChng(object sender, NotifyCollectionChangedEventArgs e)
        {
            ord.Price = 0;
            foreach (var item in MainViewModel.listServicesViemodel)
            {
                ord.Price += item.selectedService.Price;
            }
            OrederPrice.Text = ord.Price.ToString() + ",00 руб.";
        }

        private void ServDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            //ord.Price = 0;  
            ComboBox comboBox = e.EditingElement as ComboBox;

            if (comboBox != null && e.EditingElement != e.Row.Item)
            {
                var selectedValue = comboBox.SelectedItem as Services;
                ord.Price -= (e.Row.Item as ServicesViewModel).selectedService.Price;
                ord.Price += selectedValue.Price;
            }
            OrederPrice.Text = ord.Price.ToString() + ",00 руб.";
        }
    }
}
