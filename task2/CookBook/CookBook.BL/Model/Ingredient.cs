using System.Runtime.Serialization;

namespace CookBook.BL.Model
{
    [DataContract]
    public class Ingredient
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Amount { get; set; }

        public Ingredient(string name, double amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}