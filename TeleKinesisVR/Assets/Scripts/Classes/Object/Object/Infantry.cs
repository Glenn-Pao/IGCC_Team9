using UnityEngine;
using System.Collections;

//This class belongs to the infantry object
//It inherits from Object class and has access to set and get functions
//This archer class accounts for 1 entire squad at 1 formation
public class Infantry : Object
{
    //An array of men under this middle man infantry
    public Men[] men;

    //An array of projectiles by other dummy archer positions
    public Sword[] swords;

    //the unit's behaviour
    public UnitBehavior behaviour;

    //sword's start position
    public Vector3[] startPosition;

    //reference man's position
    //public Vector3[] middleManPos;

    //the time taken to do another round of attack, may be stated by designer
    protected float startCooldownTiming;

    //to track the number of hits. it should be the same number as units
    int hitcount = 18;

	//Initialize the infantry's unit ID
    public void Init()
    {
        unitType = UNIT_TYPE.INFANTRY;

        //initialize the projectile's positions, ammo count, etc
        for (int i = 0; i < swords.Length; i++)
        {
            startPosition[i] = swords[i].transform.position;
            swords[i].setFiringRate(swords[0].getFiringRate());
            swords[i].setDamage(swords[0].getDamage());

            //initialize middle man's position as reference for advance during reload
            //middleManPos[i].Set(this.transform.position.x, men[i].transform.position.y, men[i].transform.position.z);
        }
        //initialize the firing rate based on designer's definition
        startCooldownTiming = swords[9].getFiringRate();

        //initialize the behaviour of archers
        behaviour.stance = UnitBehavior.UNIT_STANCE.IDLE;
        behaviour.engage = UnitBehavior.ENGAGED_STATE.RELOADING;
    }
    public float getStartFR()
    {
        return startCooldownTiming;
    }

    //attack when unit is either hit or when cool down timing is null
    public void InfantryAttack()
    {
        if(behaviour.position == UnitBehavior.POSITIONS.BACK)
        {
            //do nothing as enemy is out of range
            return;
        }
        else if(behaviour.position == UnitBehavior.POSITIONS.FRONT)
        {
            for (int i = 0; i < swords.Length; i++)
            {
                //check that all game objects are false then enter reload state
                if (swords[i].gameObject.activeInHierarchy && swords[i].hit)
                {
                    swords[i].gameObject.SetActive(false);
                    hitcount--;
                }

                if (hitcount < 0)
                {
                    //reloading
                    behaviour.engage = UnitBehavior.ENGAGED_STATE.RELOADING;
                    hitcount = 18;
                }
            }
        }
    }

    //cool down is triggered after a single round of attack
    public void InfantryReloading()
    {
        for (int i = 0; i < swords.Length; i++)
        {
            //countdown the timer using last man's arrow as a reference
            swords[i].setFiringRate(swords[swords.Length - 1].getFiringRate() - Time.deltaTime);

            if(!swords[i].gameObject.activeInHierarchy)
            {
                swords[i].gameObject.SetActive(true);
                swords[i].transform.position = startPosition[i];
                swords[i].hit = false;
            }

            //when finished reloading and there is ammo to fire
            if (swords[i].getFiringRate() < 0.0f)
            {
                swords[i].setFiringRate(getStartFR());
                behaviour.engage = UnitBehavior.ENGAGED_STATE.ATTACK;   //set to attack
            }
        }

    }
}
