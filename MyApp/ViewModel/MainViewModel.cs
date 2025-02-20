using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using CommunityToolkit.Maui.Core;


namespace MyApp.ViewModel;

public partial class MainViewModel : BaseViewModel
{
 
    public ObservableCollection<Feline> MyObservableFelines { get; } = new();


    private readonly IPopupService popupService;

    DeviceOrientationService myScanner;

    [ObservableProperty]
    string? codeBar;
 
    public MainViewModel(IPopupService popupService)
    {
        this.myScanner = new(); //CONFIGURATION DU SCANNER
        myScanner.ConfigureScanner(true);
        myScanner.SerialBuffer.Changed += OnBarCodeScanned;
        AddRandomElements();
        this.popupService = popupService;
        //date = DateTime.ParseExact("06071999", "ddMMyyyy", CultureInfo.InvariantCulture);

    }
    

    [RelayCommand]
    public void ClosingPort()
    {
        myScanner.ConfigureScanner(false);
    }

    private void OnBarCodeScanned(object sender, EventArgs args)
    {
        DeviceOrientationService.QueueBuffer MyLocalBuffer = (DeviceOrientationService.QueueBuffer)sender;
        CodeBar = MyLocalBuffer.Dequeue().ToString();
    }
    /* partial void OnINGInfoChanged(string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Ages = value.Split('/'); // INFOS[]
                MyObservableBorn.Clear();
                MyObservableAge.Clear();
                for (int i = 0; i < Ages.Length; i++)
                {
                    var parts = ages[i].Split('*');
                    var bornPart = parts[0];
                    var agePart = parts[1];
                    MyObservableBorn.Add(bornPart);
                    MyObservableAge.Add(agePart);}
                // Update selected stock index to point to the last stock entry
                UpdateChart();}
            else
            {
                Ages = Array.Empty<string>();
                MyObservableBorn.Clear();
                MyObservableAge.Clear();
                MyObservableChart = null;
            }
        }*/

    [RelayCommand]
    private async Task AddRandomElements()
    {
        IsBusy = true;

        JSONServices MyService = new();

        // Création d'une nouvelle instance de Feline pour chaque ajout
        var felines = new List<Feline>
    {
        new Feline { Code = "5400113553212", Name = "Lion", Weight = 190, TopSpeed = 80, LifeExpectancy = 14, Description = "Roi de la savane africaine.", Origin = "Africa", Picture = "lion.jpg" },
        new Feline { Code = "8036113553212", Name = "Tigre", Weight = 220, TopSpeed = 65, LifeExpectancy = 17, Description = "Majestueux prédateur des forêts tropicales.", Origin = "Asia", Picture = "tigre.jpg" },
        new Feline { Code = "5085113553212", Name = "Léopard", Weight = 60, TopSpeed = 58, LifeExpectancy = 17, Description = "Félin tacheté, agile et gracieux.", Origin = "Africa", Picture = "leopard.jpg" },
        new Feline { Code = "1209613553212", Name = "Guépard", Weight = 10.4, TopSpeed = 112, LifeExpectancy = 12, Description = "Le mammifère terrestre le plus rapide.", Origin = "Africa", Picture = "guepard.jpg" },
        new Feline { Code = "7529113553212", Name = "Jaguar", Weight = 10.4, TopSpeed = 80, LifeExpectancy = 12, Description = "Prédateur puissant de la jungle amazonienne.", Origin = "America", Picture = "jaguar.jpg" },
        new Feline { Code = "295413553212", Name = "Lynx", Weight = 10.4, TopSpeed = 55, LifeExpectancy = 15, Description = "Félin au pelage épais, adapté aux climats froids.", Origin = "Europe", Picture = "lynx.jpg" },
        new Feline { Code = "5476113553212", Name = "Ocelot", Weight = 12, TopSpeed = 40, LifeExpectancy = 14, Description = "Petit félin tacheté au pelage luxueux.", Origin = "America", Picture = "ocelot.jpg" },
        new Feline { Code = "0980113553212", Name = "Puma", Weight = 60, TopSpeed = 72.5, LifeExpectancy = 13, Description = "Solitaire et agile, il règne sur les montagnes.", Origin = "America", Picture = "puma.jpg" }
    };

        foreach (var feline in felines)
        {
            Globals.MyFelines.Add(feline);
            MyObservableFelines.Add(feline);
        }

        await MyService.SetFelines();

        IsBusy = false;
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


    [RelayCommand]
    private async Task AddElement()
    {

        // Naviguer vers la page d'ajout 
        await Shell.Current.GoToAsync("FormPage", true);

    }

    [RelayCommand]
    private async Task DisplayCharts()
    {
        //await Shell.Current.Navigation.PushAsync(new ChartsPage());
        await Shell.Current.GoToAsync("ChartsPage", true);
     }

    [RelayCommand]
    private async Task Test()
    {
        IsBusy = true;

        //await Shell.Current.GoToAsync("TestPage", true);
        var viewModel = new TestViewModel();
        await Shell.Current.Navigation.PushAsync(new TestPage(viewModel));
        IsBusy = false;


    }
    /* private void augAge()
        {
            if (int.TryParse(INGAge, out int currentAge))
            {
                currentAge++;
                INGAge = currentAge.ToString();
                UpdateInfos(currentAge);
                UpdateGlobalList();
                JSONServices.SetFeliness(); // Save the updated list
            }
        }
        private void UpdateInfos(int currentAge)
        {
            var currentBorn = DateTime.Now.ToString("ddMMyyyy");
            var newAgeEntry = $"{currentBorn}_{currentAge}";
            var newInfos = string.IsNullOrEmpty(INGInfo)
                ? new List<string> { newAgeEntry }
                : INGInfo.Split('/').ToList();
            newInfos.Add(newAgeEntry);
            INGinfo = string.Join("/", newInfos);
            UpdateChart();
        }*/

    [RelayCommand]
    private async Task DBCall()
    {
       
        IsBusy = true;

        await Shell.Current.GoToAsync("DbPage", true);

        IsBusy = false;

}

    [RelayCommand]
    void PopUp()
    {
        this.popupService.ShowPopup<PopUpViewModel>();
    }

   
    [RelayCommand]
        private async Task ExportToCsv()
        {
            var viewModelExportToCsv = new ExportToCsvViewModel(); // Assurez-vous d'instancier correctement le ViewModel
            await Shell.Current.Navigation.PushAsync(new ExportToCsv(viewModelExportToCsv));
        }


    [RelayCommand]
        private async Task GoToDetails(Feline selectedFeline)
        {
            IsBusy = true;
            try
            {
                await Shell.Current.GoToAsync("DetailsPage", true, new Dictionary<string, object>
                {
                    { "SelectedAnimal", selectedFeline.Name },
                    { "SelectedOrigin", selectedFeline.Origin },
                    { "SelectedTopSpeed", selectedFeline.TopSpeed.ToString() },
                    { "SelectedWeight", selectedFeline.Weight.ToString() },
                    { "SelectedLifeExpectancy", selectedFeline.LifeExpectancy.ToString() },
                    { "SelectedDescription", selectedFeline.Description },
                    { "SelectedPicture", selectedFeline.Picture }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Navigation error: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    /* private void UpdateGlobalList()
         {
              var existingEntry = Globals.MyING.FirstOrDefault(i => i.Title == INGTitle); // tout le reste en dess sauf le nom ou titre ici
             if (existingEntry != null)
             {
                 existingEntry.Code = INGCode;
                 existingEntry.Description = INGDescription;
                 existingEntry.Info = INGInfo;
                 existingEntry.Age = int.Parse(INGAge);
             }
             else
             {
                 Globals.MyING.Add(new ING
                 {
                     Code = INGCode,
                     Description = INGDescription,
                     Info = INGInfo, // prop model pas tab
                     Age = int.Parse(INGAge)
                 }) ;
             }
         }*/


    [RelayCommand]
        private async Task LoadJSON()
        {
            IsBusy = true;
            JSONServices MyService = new();

            await MyService.GetFelines();
            MyObservableFelines.Clear();

            foreach (var feline in Globals.MyFelines)
            {
                MyObservableFelines.Add(feline);
            }

            IsBusy = false;
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