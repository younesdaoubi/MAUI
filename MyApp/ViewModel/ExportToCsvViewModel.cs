using CommunityToolkit.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.ViewModel
{
    public partial class ExportToCsvViewModel : BaseViewModel
    {
        public ObservableCollection<Feline> MyObservableFelines { get; } = new();

        [ObservableProperty]
        private bool isNameChecked;
        [ObservableProperty]
        private bool isDescriptionChecked;

        [ObservableProperty]
        private bool isOriginChecked;

        [ObservableProperty]
        private bool isIdChecked;

        [RelayCommand]
        public async Task ExportCSV()
        {
            IsBusy = true;

            var selectedProperties = new List<string>();
            if (IsNameChecked) selectedProperties.Add("Name");
            if (IsDescriptionChecked) selectedProperties.Add("Description");
            if (IsOriginChecked) selectedProperties.Add("Origin");
            if (IsIdChecked) selectedProperties.Add("Id");

            var csvContent = GenerateCSVContent(Globals.MyFelines, selectedProperties);

            var fileName = "Export.csv";
            var tempFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
            await File.WriteAllTextAsync(tempFilePath, csvContent);

            var fileBytes = await File.ReadAllBytesAsync(tempFilePath);
            var stream = new MemoryStream(fileBytes);
            var fileSaverResult = await FileSaver.Default.SaveAsync(fileName, stream, CancellationToken.None);

            if (!fileSaverResult.IsSuccessful)
            {
                await Shell.Current.DisplayAlert("Export", "Export failed..", "OK");
            }

            IsBusy = false;
        }

        public string GenerateCSVContent(IEnumerable<Feline> felines, List<string> selectedProperties)
        {
            StringBuilder csvContent = new StringBuilder();

            csvContent.AppendLine(string.Join(",", selectedProperties));

            foreach (var feline in felines)
            {
                var values = selectedProperties.Select(prop =>
                {
                    return prop switch
                    {
                        "Name" => feline.Name,
                        "Description" => feline.Description,
                        "Origin" => feline.Origin,
                        "Code" => feline.Code,
                        _ => string.Empty,
                    };
                });

                csvContent.AppendLine(string.Join(",", values));
            }

            return csvContent.ToString();
        }
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
                UpdateInfos(currentQuantity);
                UpdateGlobalList();
                JSONServices.SetFeliness(); // Save the updated list
            }
        }
    }*/


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
        });
    }
}
*/