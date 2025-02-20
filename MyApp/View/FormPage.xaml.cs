namespace MyApp.View;

public partial class FormPage : ContentPage
{
    FormViewModel viewModel;

    public FormPage(FormViewModel viewModel)
    {
        this.viewModel = viewModel;
        InitializeComponent();
        BindingContext = viewModel;

    }

 
}