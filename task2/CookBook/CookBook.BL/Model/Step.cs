using System.Runtime.Serialization;

namespace CookBook.BL.Model
{
    [DataContract]
    public class Step
    {
        [DataMember]
        public int Number { get; set; }

        [DataMember]
        public string Instruction { get; set; }

        public Step(int number, string instruction)
        {
            Number = number;
            Instruction = instruction;
        }
    }
}