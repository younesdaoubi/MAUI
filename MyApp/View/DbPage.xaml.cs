namespace MyApp.View;

public partial class DbPage : ContentPage
{
    DbViewModel viewModel;
    public DbPage(DbViewModel viewModel)
    {
        this.viewModel = viewModel;
        InitializeComponent();
        BindingContext = viewModel;
    }
}
