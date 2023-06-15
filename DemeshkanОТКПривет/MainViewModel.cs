using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemeshkanОТКПривет
{
    public class MainViewModel
    {
        //public bool EnabledMianPage = true;
        public ObservableCollection<Clients> ClientsList = new ObservableCollection<Clients>(DemeshkanOTKprogEntities1.GetContext().Clients.ToList());
        public ObservableCollection<ServicesViewModel> listServicesViemodel { get; set; } = new ObservableCollection<ServicesViewModel>();
        public ServicesViewModel SelectedElement { get; set; }
    }

    public class ServicesViewModel
    {
        public List<Services> ManyService { get; set; } = DemeshkanOTKprogEntities1.GetContext().Services.ToList();
        public Services selectedService { get; set; } = DemeshkanOTKprogEntities1.GetContext().Services.ToList().First();
    }

}
