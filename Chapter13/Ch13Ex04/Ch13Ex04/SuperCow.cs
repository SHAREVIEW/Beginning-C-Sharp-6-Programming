﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13Ex04
{
    public class SuperCow : Cow
    {
        //public SuperCow(string newName) : base(newName) { }

        public void Fly()
        {
            Console.WriteLine($"{name} is flying!");
        }
        public override void MakeANoise()
        {
            Console.WriteLine($"{name} says 'here I come to save the day!'");
        }
    }
}
