using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CookBook.BL.Model
{
    [DataContract]
    public class Recipe
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int IdCategory { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public List<Ingredient> Ingredients { get; set; }

        [DataMember]
        public List<Step> Steps { get; set; }

        public Recipe(string name, int idCategory, string description, List<Ingredient> ingredients, List<Step> steps)
        {
            Name = name;
            IdCategory = idCategory;
            Description = description;
            Ingredients = ingredients;
            Steps = steps;
        }
    }
}