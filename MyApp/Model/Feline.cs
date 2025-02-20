using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model

{
    public class Feline
    {
        public int Id {  get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Origin { get; set; }
        public double? Weight { get; set; }
        public double? TopSpeed { get; set; }
        public int? LifeExpectancy { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }

        public int? FelineCollectorId { get; set; }
        public FelineCollector? MyFelineCollector { get; set; }
 

    }
    public class FelineCollector
    {
        public int Id_Collector { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Feline>? MyFelines { get; set; }
    }
}
