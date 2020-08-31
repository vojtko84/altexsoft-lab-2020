﻿using System;

namespace CookBook.BL.Model
{
    [Serializable]
    public class Ingredient
    {
        public string Name { get; set; }

        public double Amount { get; set; }
    }
}