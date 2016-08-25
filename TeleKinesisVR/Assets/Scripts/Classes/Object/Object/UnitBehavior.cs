using UnityEngine;
using System.Collections;
using System.IO;

//This is the behaviour of the objects in the entire world space
//We'll use some flags to change the state of the object
public class UnitBehavior : MonoBehaviour
{
    //an enumeration to track the unit's current stance in battle
    //this includes the monsters except that it doesn't use everything here
    enum UNIT_STANCE
    {
        IDLE = 0,
        ENGAGED,
        ADVANCE,
        FALL_BACK,
        FLEE,
        NUM_UNIT_STANCES
    };

    //an enumeration to check on the units when in engaged state
    enum ENGAGED_STATE
    {
        ATTACK = 0,
        RELOADING,
        NUM_ENGAGED_STATES
    };

    private UNIT_STANCE stance;             //the actual stance of soldiers/monsters
    private int stanceID;                   //the ID to stance of soldiers/monsters

    private ENGAGED_STATE engage;           //the engaged state of soldiers/monsters
    private int engagedID;                   //the ID to engaged state of soldiers/monsters

    //set the stance type based on its ID
    public void setStanceID(int stanceID)
    {
        this.stanceID = stanceID;

        switch (stanceID)
        {
            case 0:     //idle
                stance = UNIT_STANCE.IDLE;
                break;
            case 1:     //engaged
                stance = UNIT_STANCE.ENGAGED;
                break;
            case 2:     //advance
                stance = UNIT_STANCE.ADVANCE;
                break;
            case 3:     //fall back
                stance = UNIT_STANCE.FALL_BACK;
                break;
            case 4:     //flee
                stance = UNIT_STANCE.FLEE;
                break;
            default:    //idle
                stance = UNIT_STANCE.IDLE;
                break;
        }
    }

    //get the stance type based on its ID
    public int getStanceID()
    {
        return stanceID;
    }

    //set the engaged stance type based on its ID
    public void setEngagedID(int engagedID)
    {
        this.engagedID = engagedID;

        switch (engagedID)
        {
            case 0:     //attack
                engage = ENGAGED_STATE.ATTACK;
                break;
            case 1:     //reloading. or cooldown for that matter
                engage = ENGAGED_STATE.RELOADING;
                break;
            default:    //reloading
                engage = ENGAGED_STATE.RELOADING;
                break;
        }
    }

    //get the stance type based on its ID
    public int getEngagedID()
    {
        return engagedID;
    }

}

           

    
