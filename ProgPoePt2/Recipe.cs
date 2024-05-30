using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgPoePt2
{
    public class Recipe
    {
        public string name { get; set; }

        public List<String> steps { get; set; }
        public List<Ingrediant> Ingrediants { get; set; }
        public List<Ingrediant> BackUpIngrediants { get; set; }

        public Recipe()
        {
            Ingrediants = new List<Ingrediant>();
            BackUpIngrediants = new List<Ingrediant>();
        }
    }

}


