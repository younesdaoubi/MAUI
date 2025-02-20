using System.Collections.ObjectModel;

namespace MyApp.ViewModel
{
    public partial class FormViewModel : BaseViewModel
    {
        public ObservableCollection<Feline> MyObservableFelines { get; } = new();

        [ObservableProperty]
        public Feline newFeline;  

        DeviceOrientationService myScanner;

        public FormViewModel()
        {
           
            newFeline = new Feline();
        }

        [RelayCommand]
        public async Task SaveFeline()
        {
            if (string.IsNullOrWhiteSpace(NewFeline.Code) ||
                string.IsNullOrWhiteSpace(NewFeline.Name) ||
                string.IsNullOrWhiteSpace(NewFeline.Description) ||
                string.IsNullOrWhiteSpace(NewFeline.Origin) ||
                NewFeline.Weight == null ||
                NewFeline.TopSpeed == null ||
                NewFeline.LifeExpectancy == null)
            {
                return;
            }


            NewFeline.Picture = "lion.jpg";

            JSONServices MyService = new();
            Globals.MyFelines.Add(NewFeline);
            MyObservableFelines.Add(NewFeline);

            await MyService.SetFelines();

            IsBusy = false;


            await Shell.Current.Navigation.PopAsync();
           
        }


    }
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