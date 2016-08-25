using UnityEngine;
using System.Collections;

//This class belongs to the archer object
//It inherits from Object class and has access to set and get functions
public class Archer : Object
{
    //An archer has an arrow (or arrows)
    public Arrow projectile;

    //What else is there?
    //Not too sure. It's a container class after all

    //Initialize the archer parameters here along with projectiles
    public void Init()
    {
        //archer definitions
        setHealth(100);
        setMorale(true);
        setUnitType(1);

        //weapon definitions
        //assumption is made that the object rendered is a block of arrows
        projectile.setWeaponType(1);
        projectile.setFiringRate(0.5f);
        projectile.setAmmoCount(20);
        projectile.setDamage(10);
    }
}
