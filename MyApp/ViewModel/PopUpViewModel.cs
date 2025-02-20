using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    public partial class PopUpViewModel : BaseViewModel
    {
        [ObservableProperty]
        string texte = "popup !";

        public PopUpViewModel()
        {

        }
    }
}

/*public ObservableCollection<string> MyObservableBorn { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> MyObservableAge { get; } = new ObservableCollection<string>();
        [ObservableProperty]
        private string? iNGDescription;

        [ObservableProperty]
        private string? iNGInf;

        [ObservableProperty]
        private string? iNGAge;

        [ObservableProperty]
        private string[]? ages;*/
