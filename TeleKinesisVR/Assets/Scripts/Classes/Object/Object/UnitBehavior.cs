using UnityEngine;
using System.Collections;
using System.IO;

//This is the behaviour of the objects in the entire world space
//We'll use some flags to change the state of the object
public class UnitBehavior : MonoBehaviour
{
    //an enumeration to track the unit's current stance in battle
    //this includes the monsters except that it doesn't use everything here
    public enum UNIT_STANCE
    {
        IDLE = 0,
        ENGAGED,
        ADVANCE,
        FALL_BACK,
        FLEE,
        NUM_UNIT_STANCES
    };

    //an enumeration to check on the units when in engaged state
    public enum ENGAGED_STATE
    {
        ATTACK = 0,
        RELOADING,
        NUM_ENGAGED_STATES
    };

    //an enumaration to check which position it currently is at
    public enum POSITIONS
    {
        FRONT = 0,
        BACK,
        NUM_POSITIONS
    };

    public UNIT_STANCE stance;             //the actual stance of soldiers/monsters
    public ENGAGED_STATE engage;           //the engaged state of soldiers/monsters
    public POSITIONS position;             //the current position of soldiers/monsters
}

           

    
