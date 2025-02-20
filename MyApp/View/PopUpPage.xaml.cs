using CommunityToolkit.Maui.Views;

namespace MyApp.View;

public partial class PopUpPage : Popup
{
	PopUpViewModel viewModel;
    public PopUpPage(PopUpViewModel viewModel)
    {
        this.viewModel = viewModel;
        InitializeComponent();
        BindingContext = viewModel;
    }

void OnOKButtonClicked(object? sender, EventArgs e) => Close();
}