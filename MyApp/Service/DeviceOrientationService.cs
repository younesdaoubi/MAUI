using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service;

public partial class DeviceOrientationService
{
    // coté générique du projet

    public QueueBuffer SerialBuffer = new(); // déclaré ici afin d'avoir une portée sur tout le projet

    public partial void ConfigureScanner(bool connect);


    public class QueueBuffer:Queue
    {

        public event EventHandler? Changed;

        public override void Enqueue(object? obj)
        {
            base.Enqueue(obj);
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }
   
}
