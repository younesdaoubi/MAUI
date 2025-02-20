namespace MyApp.View
{
    public partial class ExportToCsv : ContentPage
    {
        ExportToCsvViewModel viewModel;

        public ExportToCsv(ExportToCsvViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            this.viewModel = viewModel;
        }
    }
}
