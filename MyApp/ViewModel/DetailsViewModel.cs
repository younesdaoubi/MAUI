using CommunityToolkit.Mvvm.ComponentModel;
using Microcharts;
using SkiaSharp;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;

namespace MyApp.ViewModel
{
    [QueryProperty(nameof(AnimalName), "SelectedAnimal")]
    [QueryProperty(nameof(AnimalOrigin), "SelectedOrigin")]
    [QueryProperty(nameof(AnimalTopSpeed), "SelectedTopSpeed")]
    [QueryProperty(nameof(AnimalWeight), "SelectedWeight")]
    [QueryProperty(nameof(AnimalLifeExpectancy), "SelectedLifeExpectancy")]
    [QueryProperty(nameof(AnimalDescription), "SelectedDescription")]
    [QueryProperty(nameof(AnimalPicture), "SelectedPicture")]

    public partial class DetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? animalName;

        [ObservableProperty]
        private string? animalOrigin;

        [ObservableProperty]
        private string? animalTopSpeed;

        [ObservableProperty]
        private string? animalWeight;

        [ObservableProperty]
        private string? animalLifeExpectancy;

        [ObservableProperty]
        private string? animalDescription;
        [ObservableProperty]
        private string? animalPicture;



        /*public ObservableCollection<ING> MyObservableING { get; } = new();
        public INGViewModel()
        {
            Task.Run(async () => await LoadDataAsync());
        }
        private async Task LoadDataAsync()
        {
            var felineList = await JSONServices.GetFelineAsync();
            MyObservableING.Clear();
            foreach (var feline in felineList)
            {
                MyObservableING.Add(feline);
            }
        }*/

    }
}
/*public ICommand AugAgeCommand => new Command(augAge);    // fonctionne mais pas top
    public ICommand DimAgeCommand => new Command(dimAge);    // fonctionne mais pas top
    private void dimAge()
    {
        if (int.TryParse(INGAge, out int currentAge))
        {
            if (currentAge > 0)
            {
                currentAge--;
                INGAge = currentAge.ToString();
                UpdateInfos(currentAge);
                UpdateGlobalList();
                JSONServices.SetFeliness(); // Save the updated list
            }
        }
    }*/