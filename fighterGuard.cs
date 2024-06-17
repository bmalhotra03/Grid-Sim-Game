// Author: Brij Malhotra
// Filename: fighterGuard.cs
// Version: Version 1
// Description: This is the class definition and implementation of the fighterGuard child object

// Class invariant: 
//      Same as fighter invariant except that the constructor takes in a guard object that sets up the object
//      as part of a multiply inherited class structure. Objects can now block incoming attacks due to the cross
//      product functionality. The block functionality is based on the type of guard object passed through.

using fighterClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P5
{
    public class fighterGuard : fighter
    {
        Guard shield;
        public fighterGuard(int r, int c, int[] art, Guard obj) : base(r, c, art)
        {
            shield = obj;
        }

        protected override void shoot()
        {
            shield.shieldDown();
            base.shoot();
        }

        protected override void hit()
        {
            shield.shieldUp();

            if (!shield.block(artillery.Count()))
            {
                base.hit();
            }
        }

        public override void move(int x, int y)
        {
            shield.shieldDown();
            base.move(x, y);
        }
    }
}

// Implementation invariant:
//      The guard object that is passed through decides what sort of block shall be used. Rest applies to the fighter invariant.