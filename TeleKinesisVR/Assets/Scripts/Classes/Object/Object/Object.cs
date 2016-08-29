using UnityEngine;
using System.Collections;


//This is the mother class for ALL objects in the scene to inherit from
//There should be no direct change in here
public class Object : MonoBehaviour 
{
    //an enumeration to identify the unit types
    protected enum UNIT_TYPE
    {
        UNKNOWN = 0,
        ARCHER,
        MONSTER,
        NUM_UNITS,
    };

    public int health;                 //health of object
    public bool morale = true;         //morale of object. Set this to true by default.
    private UNIT_TYPE unitType;        //the unit type of the object
    protected int unitIDNum;           //the unit ID number of the object.

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

    //set the unit type of this object
    public void setUnitType(int unitIDNum)
    {
        this.unitIDNum = unitIDNum;

        //based on the ID Number provided, determine the unit type
        switch(unitIDNum)
        {
            case 0:     //unknown
                unitType = UNIT_TYPE.UNKNOWN;
                break;
            case 1:     //archer
                unitType = UNIT_TYPE.ARCHER;
                break;
            case 2:     //monster
                unitType = UNIT_TYPE.MONSTER;
                break;
            default:    //default is set as archer
                unitType = UNIT_TYPE.ARCHER;
                break;
        }
    }

    //get the unit type of this object
    public int getUnitType()
    {
        return unitIDNum;
    }
}
