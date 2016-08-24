using UnityEngine;
using System.Collections;

public class UnitClass : MonoBehaviour {
    UnitBehavior behavior;

    public int Ammunition;
    public int Health;
    bool Morale = true;
    int Difficulty = 4;
    int Value;
    public int UnitType;
    Unit Units = Unit.PIKEMAN; 

    enum Unit
    {
        PIKEMAN,
        ARCHER,
        BALLISTA,
        MONSTER
    }


	// Use this for initialization
	void Start () {
        SetDifficulty( Value);
  

	
	}
	
	// Update is called once per frame
	void Update () {

if(Difficulty == 4 && Health <= 75 ){ Morale = false; }


else if (Difficulty == 3 && Health <= 60) { Morale = false; }
      

else if (Difficulty == 2 && Health <= 45){ Morale = false; }
    

else if (Difficulty == 1 && Health <= 25){ Morale = false; }
   


        if (Morale == false)
        {
            behavior.setStance(behavior.Soldier);
            return;
        }

	
	}

   void SetDifficulty(int value)
    {
        Difficulty = value;


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

    public void SetUnit()
    {

    }

    public void setUnitType(Unit unit)
    {
   this.Units = unit; 
    }
    public Unit SetUnitType(int Type)
    {
        switch (Type)
        {
            case 0:
                {
                    return Unit.PIKEMAN;
                }
            case 1:
                {
                    return Unit.ARCHER;
                }
            case 2:
                {
                    return Unit.BALLISTA;
                }
            case 3:
                {
                    return Unit.MONSTER;
                }
            default:
                { return 0; }
        }
    }
}
