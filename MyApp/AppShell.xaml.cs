namespace MyApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));

            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("FormPage", typeof(FormPage));
            Routing.RegisterRoute(nameof(DbPage), typeof(DbPage));
            Routing.RegisterRoute(nameof(ChartsPage), typeof(ChartsPage));
 

 



        }
    }
}
