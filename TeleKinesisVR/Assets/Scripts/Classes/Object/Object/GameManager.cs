using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//the game manager for this scene
public class GameManager : MonoBehaviour 
{
    public Archer[] arrArchers;     //an array of archers in the scene
    public Monster[] arrMonsters;   //an array of monsters in the scene
    public Text DebugText;    //check on archer components

    public UnitBehavior squad3Position;

    int activeNum;                  //the formation that is active in numeric number

	// Use this for initialization
	void Start () 
    {
        Debug.Log("Starting");
        
        for(int i = 0; i < arrArchers.Length; i++)
        {
            //Initialize archer stuff using the Init function
            arrArchers[i].Init();

            Debug.Log("Archer class initialized");

            DebugText.text = "Archer class initialized";

            //based on the formation of the previously defined,
            //set the other formation inactive
            if (arrArchers[i].behaviour.position != squad3Position.position)
            {
                arrArchers[i].gameObject.SetActive(false);

                for (int j = 0; j < arrArchers[i].men.Length; j++)
                {
                    arrArchers[i].men[j].gameObject.SetActive(false);
                }
            }
        }
        for(int i = 0; i < arrMonsters.Length; i++)
        {
            //Initialize monster component
            arrMonsters[i].Init();

            Debug.Log("Monster class initialized");

            DebugText.text = "Monster class initialized";
        }
	}

    void MoveToMonster()
    {
        //set the target to the monster
        for(int i = 0; i < arrArchers[activeNum].projectiles.Length; i++)
        {
            arrArchers[activeNum].projectiles[i].transform.position = Vector3.MoveTowards(arrArchers[activeNum].projectiles[i].transform.position, arrMonsters[0].transform.position, Time.deltaTime * 150);
        }
        
    }

    //checks the archer status when engaged
    void CheckEngagedArcherStatus()
    {
        Debug.Log(arrArchers[activeNum].behaviour.engage.ToString());
        switch(arrArchers[activeNum].behaviour.engage)
        {
            case UnitBehavior.ENGAGED_STATE.ATTACK:     //attack the enemy
                MoveToMonster();
                arrArchers[activeNum].ArcherAttack();
                break;
            case UnitBehavior.ENGAGED_STATE.RELOADING:  //reload the weapon
                arrArchers[activeNum].ArcherReloading();
                break;
            default:
                arrArchers[activeNum].ArcherReloading();
                break;
        }
    }
    //check the status of archer unit here
    void CheckArcherStatus()
    {
        //check which is the currently active formation
        for (int i = 0; i < arrArchers.Length; i++)
        {
            if(arrArchers[i].gameObject.activeInHierarchy)
            {
                activeNum = i;
                break;
            }
        }

        Debug.Log(arrArchers[activeNum].behaviour.stance.ToString());

        switch(arrArchers[activeNum].behaviour.stance)
        {
            case UnitBehavior.UNIT_STANCE.IDLE:     //idle, do nothing
                arrArchers[activeNum].behaviour.stance = UnitBehavior.UNIT_STANCE.ENGAGED;  //engage the enemy for now
                break;
            case UnitBehavior.UNIT_STANCE.ENGAGED:  //engaged, check if atk or reload
                CheckEngagedArcherStatus();
                break;
            case UnitBehavior.UNIT_STANCE.ADVANCE:  //advance to forward position
                break;
            case UnitBehavior.UNIT_STANCE.FALL_BACK://fall back to backward position
                break;
            case UnitBehavior.UNIT_STANCE.FLEE:     //go back to backward position and derender once reached
                break;
            default:                                //idle, do nothing
                break;
        }
    }
    void Update()
    {
        //Debug.Log(arrMonsters[0].transform.position);

        CheckArcherStatus();
    }
}
