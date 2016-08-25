using UnityEngine;
using System.Collections;

public class UnitBehavior : MonoBehaviour {

 public   Stance Soldier = Stance.IDLE;
    AttackType SoldierAttack = AttackType.IDLE;
   public int Types = 0;


    public enum Stance
    {
        COMBAT,
        MOVE,
        RETREAT,
        FLEE,
        IDLE
    };
    public enum AttackType
    {
        MELEE,
        RANGED,
        IDLE
    };



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        switch(Soldier)
        {  
            case Stance.IDLE:
        {
            break;
        }

            case Stance.COMBAT:
        {
            if (SoldierAttack == AttackType.MELEE)
            { 
                // Soldiers do Melee attack
                Soldier = Stance.IDLE;
                break;
                 
            }

            else if (SoldierAttack == AttackType.RANGED)
            {
                //Soldier do Ranged attack
                Soldier = Stance.IDLE;
                break;
            }
            else
            {
                Soldier = Stance.IDLE;
                break;
            }
            
        }
            case Stance.MOVE:
        {

            //if(waypoint == current position)
            Soldier = Stance.IDLE; 

            break;
        }
            case Stance.RETREAT:
        {

            //if(current position == waypoint[i-1])
            Soldier = Stance.IDLE;

            break;
        }
            case Stance.FLEE:
        {
            //if(current position == fleePosition)
            //Delete unit

            break;
        }

    }
      

	
	}
       
    public void setStance(Stance Soldier)
    {
        this.Soldier = Soldier;
    }
    Stance getStance()
    {
        return Soldier;
    }


    public void setAttackType(AttackType SoldierAttack)
    {
        this.SoldierAttack = SoldierAttack;
    }
    AttackType GetAttackType()
    { 
        return SoldierAttack;
    }


    void ChangeStance(Stance Soldier)
    {
        //get the current stance of soldier
        Soldier = getStance();

        switch (Soldier)
        {
         
        }
    }

  public  Stance SetStance(int Type)
    {
           switch(Type)
           {
               case 0:
                   { Soldier = Stance.COMBAT;
                   return Soldier;
                   }
               case 1:
                   { Soldier = Stance.MOVE;
                   return Soldier;
                   }
               case 2:
                   {
                       Soldier = Stance.RETREAT;
                   return Soldier;
                   }
               case 3:
                   {
                       Soldier = Stance.FLEE;
                   return Soldier;
                   }

               default:
                   {
                       Soldier = Stance.IDLE;
                       return Soldier;
                   }
                   
        
                 
                  
           }

    }
    public AttackType SetAttackType(int Type)
    {
        switch(Type)
        {
            case 0:
                {
                    SoldierAttack = AttackType.MELEE;
                    return SoldierAttack;
                }
            case 1:
                {
                    SoldierAttack = AttackType.RANGED;
                    return SoldierAttack;

                }
            default:
                {
                    SoldierAttack = AttackType.IDLE;
                    return SoldierAttack;
                }
        }

    }
}
