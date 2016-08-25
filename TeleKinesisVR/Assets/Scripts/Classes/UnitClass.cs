using UnityEngine;
using System.Collections;

public class UnitClass : MonoBehaviour {
    UnitBehavior behavior;

    public int Ammunition;
    public int Health;
    bool Morale = true;
    int Difficulty = 4;
   public Unit Units = Unit.PIKEMAN; 

   public enum Unit
    {
        PIKEMAN,
        ARCHER,
        BALLISTA,
        MONSTER
    }



	// Use this for initialization
	void Start () {
  

	
	}
	
	// Update is called once per frame
	void Update () {

if(Difficulty == 4 && Health <= 75 ){ Morale = false; }


   


        if (Morale == false)
        {
            behavior.setStance(behavior.Soldier);
            return;
        }

	
	}

   public int ReduceHealth(int Reduce)
    {
        Health -=Reduce;
        return Health;
    }

    public int ReduceAmmunition(int Ammunit)
   {
       Ammunition -= Ammunit;
       return Ammunition;
   }


}
