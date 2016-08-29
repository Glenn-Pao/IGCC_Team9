using UnityEngine;
using System.Collections;

//This class belongs to the archer object
//It inherits from Object class and has access to set and get functions
//This archer class accounts for 1 entire squad at 1 formation
public class Archer : Object
{   
    //An array of men under this middle man archer
    public Men[] men;

    //An array of projectiles by other dummy archer positions
    public Arrow[] projectiles;

    //the unit's behaviour
    public UnitBehavior behaviour;

    //projectile's start position
    public Vector3[] startPosition;

    //firing rate stated by designer
    protected float startFiringRate;

    //to track the number of hits. it should be the same number as projectiles
    int hitcount = 18;

    //Initialize the archer's unit ID and projectile ID
    public void Init()
    {
        unitType = UNIT_TYPE.ARCHER;

        //initialize the projectile's positions, ammo count, etc
        for (int i = 0; i < projectiles.Length; i++)
        {
            startPosition[i] = projectiles[i].transform.position;
            projectiles[i].setAmmoCount(projectiles[0].getAmmoCount());
            projectiles[i].setFiringRate(projectiles[0].getFiringRate());
            projectiles[i].setDamage(projectiles[0].getDamage());
        }

        //initialize the firing rate based on designer's definition
        startFiringRate = projectiles[0].getFiringRate();

        //initialize the behaviour of archers
        behaviour.stance = UnitBehavior.UNIT_STANCE.IDLE;
        behaviour.engage = UnitBehavior.ENGAGED_STATE.RELOADING;
    }

    public float getStartFR()
    {
        return startFiringRate;
    }

    //attack when shots have been reloaded
    public void ArcherAttack()
    {
        for(int i = 0; i < projectiles.Length; i++)
        {
            //check that all game objects are false then enter reload state
            if (projectiles[i].gameObject.activeInHierarchy && projectiles[i].hit)
            {
                projectiles[i].gameObject.SetActive(false);
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
    //reload when archer have fired their shots
    public void ArcherReloading()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            //countdown the timer using last man's arrow as a reference
            projectiles[i].setFiringRate(projectiles[projectiles.Length-1].getFiringRate() - Time.deltaTime);

            //reset the instance of each object
            if (!projectiles[i].gameObject.activeInHierarchy)
            {
                projectiles[i].gameObject.SetActive(true);
                projectiles[i].transform.position = startPosition[i];
                projectiles[i].hit = false;
                projectiles[i].hitArrowRain = false;
                projectiles[i].setAmmoCount(projectiles[i].getAmmoCount() - 1);
            }
            //when finished reloading and there is ammo to fire
            if (projectiles[i].getFiringRate() < 0.0f)
            {
                if (projectiles[i].getAmmoCount() != 0)
                {
                    projectiles[i].setFiringRate(getStartFR());
                    behaviour.engage = UnitBehavior.ENGAGED_STATE.ATTACK;   //set to attack
                }
                else
                {
                    //enter flee state
                    behaviour.stance = UnitBehavior.UNIT_STANCE.FLEE;
                }
            }   
        }
        
    }
}
