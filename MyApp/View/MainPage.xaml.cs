using System.Timers;
namespace MyApp.View;

public partial class MainPage : ContentPage
{
    MainViewModel viewModel;
    public MainPage(MainViewModel viewModel)
	{
        this.viewModel = viewModel;
        InitializeComponent();
        BindingContext= viewModel;
        StartClock();

    }

    protected override void OnDisappearing()
    {
        viewModel.ClosingPort();
    }

    protected override void OnAppearing() // refresh page apres nouvel ajout 
    {
        base.OnAppearing();

        // Rafraîchir les données lorsque la page apparaît
        if (BindingContext is MainViewModel viewModel)
        {
            viewModel.LoadJSONCommand.Execute(null); // Commande pour recharger les données 
        }
    }


    private void StartClock()
    {
        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            // Met à jour le texte du label avec l'heure actuelle sur le thread UI
            clockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            return true;  
        });
    }

}