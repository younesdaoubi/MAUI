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

        // Rafra�chir les donn�es lorsque la page appara�t
        if (BindingContext is MainViewModel viewModel)
        {
            viewModel.LoadJSONCommand.Execute(null); // Commande pour recharger les donn�es 
        }
    }


    private void StartClock()
    {
        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            // Met � jour le texte du label avec l'heure actuelle sur le thread UI
            clockLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            return true;  
        });
    }

}