using System.Collections.ObjectModel;

namespace MyApp.ViewModel;


public partial class DbViewModel : BaseViewModel
{


    DataAccessService MyDBDevice;

    public ObservableCollection<Feline> MyObservableFelines { get; } = new();
    public ObservableCollection<FelineCollector> MyObservableFelineCollectors { get; } = new();

    DataAccessService myDBService;
    public DbViewModel(DataAccessService myDBService)
    {
        MyDBDevice = myDBService;

        FelineCollector collector1 = new FelineCollector { Name = "john" };
        FelineCollector collector2 = new FelineCollector { Name = "clara" };

        MyDBDevice.FelineCollectors.Add(collector1);
        MyDBDevice.FelineCollectors.Add(collector2);
        //MyDBDevice.SaveChanges();

        MyObservableFelineCollectors.Add(collector1);
        MyObservableFelineCollectors.Add(collector2);

        Feline feline1 = new Feline { Name = "Cheetah", Origin = "Africa", TopSpeed = 120.0, Id=2/*, FelineCollectorId = 1*/ /*,Id = Guid.NewGuid().ToString()*/ };
        Feline feline2 = new Feline { Name = "Cheetah", Origin = "Africa", TopSpeed = 30.0,Id = 5/*, FelineCollectorId = 1*/};

        MyObservableFelines.Add(feline1);
        MyObservableFelines.Add(feline2);

        /*foreach (var f in Globals.MyFelines) 
        {
            MyObservableFelines.Add(f);
            myDBService.Felines.Add(f);
        }*/

        MyDBDevice.Felines.Add(feline1);
        MyDBDevice.Felines.Add(feline2);

        //MyDBDevice.SaveChanges();



        /*List <WorkerModel> list1 = myDBService.Workers.Where(lapin => lapin.Name.Contains("work")).ToList(); 
        foreach(var item in list1)
        {
            MyObservableWorkers.Add(item);
        }*/
        
    }



    [RelayCommand]
    private async Task Save()
    {
        MyDBDevice.SaveChanges();


        List<Feline> felines = MyDBDevice.Felines.ToList();
        foreach (var feline in felines)
        {
            MyObservableFelines.Add(feline);
        }

        List<FelineCollector> collectors = MyDBDevice.FelineCollectors.ToList();
        foreach (var collector in collectors)
        {
            MyObservableFelineCollectors.Add(collector);
        }
    }

}

/*public ObservableCollection<ING> MyObservableING { get; } = new();
        public INGViewModel()
        {
            Task.Run(async () => await LoadDataAsync());
        }
        private async Task LoadDataAsync()
        {
            var felineList = await JSONServices.GetFelineAsync();
            MyObservableING.Clear();
            foreach (var feline in felineList)
            {
                MyObservableING.Add(feline);
            }
        }*/

 