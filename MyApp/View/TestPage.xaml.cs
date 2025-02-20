namespace MyApp.View;

public partial class TestPage : ContentPage
{
    TestViewModel viewModel;

    public TestPage(TestViewModel viewModel)
    {
        this.viewModel = viewModel;
        InitializeComponent();
        BindingContext = viewModel;
    }
}

/*namespace MyApp.View;

public partial class TestPage : ContentPage
{
    TestViewModel viewModel;

    public TestPage(TestViewModel viewModel)
    {
        this.viewModel = viewModel;
        InitializeComponent();
        BindingContext = viewModel;
    }
}*/

