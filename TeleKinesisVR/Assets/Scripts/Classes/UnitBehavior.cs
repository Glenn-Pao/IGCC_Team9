using UnityEngine;
using System.Collections;
using System.IO;

public class UnitBehavior : MonoBehaviour {
    UnitClass UnitC;
   public Stance Soldier = Stance.IDLE;
   public int Types = 0;
   float elap;
   int ChangeCounter = 0;
   int CurrentChange = 0;

    public enum Stance
    {
        COMBAT,
        MOVE,
        RETREAT,
        FLEE,
        IDLE
    };


	// Use this for initialization
	void Start () {
        Debug.Log(Soldier);

	
	}
	
	// Update is called once per frame
	void Update () 
    {
        elap += Time.deltaTime;

    if(elap < 3.0f && Soldier != Stance.COMBAT )
    { Soldier = Stance.COMBAT;  }
    if (elap > 3.0f && Soldier == Stance.COMBAT)
    { Soldier = Stance.RETREAT; }

    if(Soldier == Stance.IDLE)
        { return; }
 
     
        //Poor Working Change Stance
        switch(Soldier)
        {  case Stance.IDLE:
                { break; }

            case Stance.COMBAT:
        {      
                // Soldiers do Melee attack
                if (elap < 6.5f) {
                    break; 
                }
                elap = 0.0f;
                Soldier = Stance.IDLE;
                //CurrentChange++;

                break;
        }
            case Stance.MOVE:
        {
            //if(waypoint == current position)
            Soldier = Stance.IDLE;
            CurrentChange++;

            break;
        }
            case Stance.RETREAT:
        {

            //if(current position == waypoint[i-1])
           
            elap = 0.0f;
            Soldier = Stance.IDLE;
            //CurrentChange++;

            break;
        }
            case Stance.FLEE:
        {
            //if(current position == fleePosition)
            //Delete unit

            break;
        }

        } if (ChangeCounter == CurrentChange)
        { return; }
        ChangeCounter = CurrentChange;
        Debug.Log(Soldier);
        Debug.Log(elap);
        Debug.Log(ChangeCounter);

	}
       
    public void setStance(Stance Soldier)
    { this.Soldier = Soldier; }
    Stance getStance()
    { return Soldier; }
    }

           

    
