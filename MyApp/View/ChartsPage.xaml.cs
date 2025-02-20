namespace MyApp.View;

public partial class ChartsPage : ContentPage
{
    /*public ChartsPage()
    {
        InitializeComponent();
    }*/

   ChartsViewModel viewModel;
    public ChartsPage(ChartsViewModel viewModel)
        {
            this.viewModel = viewModel;
            InitializeComponent();
            BindingContext = new ChartsViewModel();
        }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        BindingContext = null;
        viewModel.RefreshPage();
        BindingContext = viewModel;
    }


}

