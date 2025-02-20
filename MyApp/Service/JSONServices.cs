using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
namespace MyApp.Service;

public class JSONServices
{
    public async Task GetFelines()
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "felines.json");

        try
        {
            using var stream = File.Open(filePath, FileMode.Open);

            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            Globals.MyFelines = JsonSerializer.Deserialize<List<Feline>>(contents);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("JSON load Error!", ex.Message, "OK");
        }
    }

    public async Task SetFelines()
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "felines.json");

        try
        {
            if (File.Exists(filePath)) File.Delete(filePath);
            using FileStream fileStream = File.Create(filePath);

            await JsonSerializer.SerializeAsync(fileStream, Globals.MyFelines);
            await fileStream.DisposeAsync();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("JSON save Error!", ex.Message, "OK");
        }
    }

    public static async Task<List<Feline>> GetFelineAsync()
    {
         //string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "felin.json");
         
        try
        {
            //using var stream = File.Open(filePath, FileMode.Open);
            using var stream = await FileSystem.OpenAppPackageFileAsync("felin.json");

            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();

            // Options pour ignorer la casse lors de la désérialisation
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // Désérialisation avec les options spécifiées
            var bdList = JsonSerializer.Deserialize<List<Feline>>(contents, options);
            Globals.MyFelines = bdList ?? new List<Feline>();

            return bdList ?? new List<Feline>();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("JSON load Error!", ex.Message, "OK");
            return new List<Feline>(); // Retourne une liste vide en cas d'erreur

            Globals.MyFelines = new List<Feline>();

        }
    }


 

    public static async Task SetFeliness()
    {
         string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "gg.json");

        try
        {
            // If the file already exists, delete it
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

             using FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            // Serialize the global list to the file
            await JsonSerializer.SerializeAsync(fileStream, Globals.MyFelines);

            // Ensure the stream is properly disposed
            await fileStream.DisposeAsync();

            await Shell.Current.DisplayAlert("Success", "créé", "OK");

        }
        catch (Exception ex)
        {
            // Display an error message if there is a problem
            await Shell.Current.DisplayAlert("JSON save Error!", ex.Message, "OK");
        }
    }


}




 