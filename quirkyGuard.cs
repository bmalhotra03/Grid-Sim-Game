// Author: Brij Malhotra
// Filename: quirkyGuard.cs
// Version: Version 1
// Description: This is the class definition and implementation of the quirkyGuard class

// Class invariant: 
//       Same as Guard invariant. Only difference is that the block functionality chooses the shield to be used arbitrarily. 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    public class quirkyGuard : Guard
    {
        public quirkyGuard(int[] s) : base (s) 
        {

        }

        public override bool block(int x)
        {
            Random rnd = new Random();
            int num = rnd.Next(1, numShields);
            return base.block(num);
        }
    }
}

// Implementation invariant:
//      The only difference is that a random number generator chooses what index of shield to be used