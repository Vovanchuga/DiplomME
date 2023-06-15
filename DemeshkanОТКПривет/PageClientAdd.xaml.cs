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
using System.Windows.Shapes;

namespace DemeshkanОТКПривет
{
    /// <summary>
    /// Логика взаимодействия для PageClientAdd.xaml
    /// </summary>
    public partial class PageClientAdd : Window
    {
        private Clients cl = new Clients();
        private MainViewModel MainVM;
        public PageClientAdd(MainViewModel mv)
        {
            InitializeComponent();
            DataContext = cl;
            MainVM = mv;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
      
            if (string.IsNullOrEmpty(cl.SurName))
                errors.AppendLine("Укажите фамилию");
            if (string.IsNullOrEmpty(cl.FirstName))
                errors.AppendLine("Укажите имя");
            if (cl.Telephone > 99999999999 || cl.Telephone < 10000000000)
                errors.AppendLine("Укажите номер телефона");
            if (string.IsNullOrEmpty(cl.Email))
                errors.AppendLine("Укажите электронную почту");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            DemeshkanOTKprogEntities1.GetContext().Clients.Add(cl);
            try
            {
                DemeshkanOTKprogEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                MainVM.ClientsList.Add(cl);
                DemeshkanOTKprogEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                Close();
            }
            catch
            {
                MessageBox.Show("Не сохранено");
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0) || TelepTxt.Text.Length > 11){
                e.Handled = true;
            }
        }
    }
}
