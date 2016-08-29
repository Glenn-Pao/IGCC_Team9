using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//this is the weapon class
//it is constructed with the intention of plugging it into another game object independent of the object class

public class WeaponClass : MonoBehaviour 
{
    //an enumeration to track the types of weapons available in the game
    enum WEAPON_TYPE
    {
        SOLDIER_MELEE = 0,
        SOLDIER_RANGE,
        MONSTER_BITE,
        MONSTER_SWEEP,
        MONSTER_ACID,
        NUM_WEAPON_TYPES,
    };
    private WEAPON_TYPE type;           //the type of weapon it is
    private int weaponIDNum;            //the ID Number to determine what weapon it is
    public float firingRate;             //the firing rate of the weapon. in simpler terms, cooldown before next attack
    public int ammoCount;              //the number of ammo available. melee weapons do not have this component
    public int damage;                 //the damage this weapon deals if it hits

    //set the weapon type based on ID num
    public void setWeaponType(int weaponIDNum)
    {
        this.weaponIDNum = weaponIDNum;

        switch(weaponIDNum)
        {
            case 0:         //melee
                type = WEAPON_TYPE.SOLDIER_MELEE;
                break;
            case 1:         //range
                type = WEAPON_TYPE.SOLDIER_RANGE;
                break;
            case 2:         //monster bite (head)
                type = WEAPON_TYPE.MONSTER_BITE;
                break;
            case 3:         //monster sweep (tail)
                type = WEAPON_TYPE.MONSTER_SWEEP;
                break;
            case 4:         //monster acid (spit)
                type = WEAPON_TYPE.MONSTER_ACID;
                break;
            default:        //melee
                type = WEAPON_TYPE.SOLDIER_MELEE;
                break;
        }
    }

    //get the weapon type's ID Number
    public int getWeaponID()
    {
        return weaponIDNum;
    }

    //set the firing rate of weapon
    public void setFiringRate(float firingRate)
    {
        this.firingRate = firingRate;
    }

    //get the firing rate of weapon
    public float getFiringRate()
    {
        return firingRate;
    }

    //set the ammo count of weapon
    public void setAmmoCount(int ammoCount)
    {
        this.ammoCount = ammoCount;
    }

    //get the ammo count of weapon
    public int getAmmoCount()
    {
        return ammoCount;
    }

    //set the damage power of this weapon
    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    //get the damage power of this weapon
    public int getDamage()
    {
        return damage;
    }
}
