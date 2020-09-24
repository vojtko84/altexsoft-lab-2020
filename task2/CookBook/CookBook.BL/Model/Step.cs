using System;

namespace CookBook.BL.Model
{
    [Serializable]
    public class Step
    {
        public int Number { get; set; }

        public string Instruction { get; set; }
    }
}