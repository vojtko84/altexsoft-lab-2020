using System;
using System.Collections.Generic;

namespace CookBook.BL.Model
{
    [Serializable]
    public class Recipe
    {
        public string Name { get; set; }

        public int IdCategory { get; set; }

        public string Description { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Step> Steps { get; set; }
    }
}