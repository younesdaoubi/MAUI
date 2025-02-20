using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyApp.ViewModel
{
    public partial class TestViewModel : ObservableObject
    {
        // Propriété observable pour le compteur
        [ObservableProperty]
        private int counter;

        // Commande pour incrémenter le compteur
        [RelayCommand]
        private void IncrementCounter()
        {
            Counter++;
        }
    }
}


