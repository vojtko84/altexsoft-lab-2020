using System.Runtime.Serialization;

namespace CookBook.BL.Model
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}