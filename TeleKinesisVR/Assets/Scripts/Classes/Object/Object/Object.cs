using UnityEngine;
using System.Collections;


//This is the mother class for ALL objects in the scene to inherit from
//There should be no direct change in here
public class Object : MonoBehaviour 
{
    //an enumeration to identify the unit types
    public enum UNIT_TYPE
    {
        INFANTRY = 0,
        ARCHER,
        MONSTER,
        NUM_UNITS,
    };

    public int health;                 //health of object
    public bool morale = true;         //morale of object. Set this to true by default.
    public UNIT_TYPE unitType;         //the unit type of the object

    //set the health of this object
    public void setHealth(int health)
    {
        this.health = health;
    }

    //get the health of this object
    public int getHealth()
    {
        return health;
    }

    //set the Morale of this object
    public void setMorale(bool morale)
    {
        this.morale = morale;
    }

    //get the morale of this object
    public bool getMorale()
    {
        return morale;
    }
}
