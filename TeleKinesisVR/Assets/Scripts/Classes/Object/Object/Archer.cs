using UnityEngine;
using System.Collections;

//This class belongs to the archer object
//It inherits from Object class and has access to set and get functions
public class Archer : Object
{
    //An archer has an arrow (or arrows)
    public Arrow projectile;

    //the unit's behaviour
    public UnitBehavior behaviour;

    //this count is used to do calculations per a set number of frames
    //this is to avoid doing needless calculations
    int count = 0;

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

        //initialize the behaviour of archers
        behaviour.setStanceID(0);   //set to idle
        behaviour.setEngagedID(1);  //set to reloading
    }

    //update of the behaviour of archers goes here
    void Update()
    {
        if(count != 5)
        {
            count++;
        }
        //update once every 5 frames
        else if(count == 5)
        {
            UpdateStance();
        }
    }

    //update unit's stance here
    void UpdateStance()
    {
        switch (behaviour.getStanceID())
        {
            case 0:     //idle, do nothing
                break;
            case 1:     //engaged, fight enemy
                CheckEngagedState();
                break;
            case 2:     //advance, move to front point
                break;
            case 3:     //fall back, move to retreat point
                break;
            case 4:     //flee, move to retreat point and delete this game object
                break;
            default:    //idle, do nothing
                break;
        }
    }

    //check the state of engaged
    void CheckEngagedState()
    {
        //determine what to do when engaged
        switch(behaviour.getEngagedID())
        {
            case 0:     //attack

                break;
            case 1:     //reloading
                break;
        }
    }
}
