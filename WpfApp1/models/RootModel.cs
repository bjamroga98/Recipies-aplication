using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.models
{   
    /// <summary>
    /// Root model
    /// </summary>
    public class RootModel
    {
        public string title { get; set; }
        public double version { get; set; }
        public string href { get; set; }
        public List<RecipeModel> results { get; set; }
    }
}
