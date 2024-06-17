// Author: Brij Malhotra
// Filename: skipGuard.cs
// Version: Version 1
// Description: This is the class definition and implementation of the skipGuard class

// Class invariant: 
//      Check Guard invariant. The only difference is that the block functionality
//      works on an offset of the integer provided as the parameter.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    public class skipGuard : Guard
    {
        private readonly int k;
        public skipGuard(int[] s) : base(s)
        {
            k = numShields / 2;
        }

        public override bool block(int x)
        {
            return base.block(x+k % shield.Count());
        }
    }
}


// Implementation invariant:
//      The block functionality now works with an offset k that is derived from the number of shields.
//      Block will choose what shield to use based on the offset and integer provided in the block function.