using UnityEngine;
using System.Collections;

//This class belongs to the monster object
//It inherits from Object class and has access to set and get functions
public class Monster : Object
{
    //the definition of weapons that the monster will use
    //Bite attack
    public BiteAttack bite;

    //Tail sweep attack
    public TailAttack sweep;

    //Acid spit attack
    public AcidAttack acid;

    public void Init()
    {
        //monster definitions
        setHealth(1000);
        setMorale(true);
        setUnitType(2);

        //weapon definitions

        //Bite attack
        bite.setWeaponType(2);
        bite.setFiringRate(5.0f);      
        bite.setAmmoCount(0);
        bite.setDamage(40);

        //Sweep attack
        sweep.setWeaponType(3);
        sweep.setFiringRate(4.0f);
        sweep.setAmmoCount(0);
        sweep.setDamage(30);

        //Acid attack
        acid.setWeaponType(4);
        acid.setFiringRate(3.0f);
        acid.setAmmoCount(0);
        acid.setDamage(20);
    }

}
