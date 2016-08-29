using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//the game manager for this scene
public class GameManager : MonoBehaviour
{
    public Monster[] arrMonsters;   //an array of monsters in the scene
    public Text DebugText;          //check on archer components

    public bool ArchersSq2;             //toggle this if you want archers in squad 2, false gives infantry
    public bool ArchersSq3;             //toggle this if you want archers in squad 3, false gives infantry

    public Archer[] arrArchersSq2;      //squad 2's archers
    public Archer[] arrArchersSq3;      //squad 3's archers

    public Infantry[] arrInfantrySq2;   //squad 2's infantry
    public Infantry[] arrInfantrySq3;   //squad 3's infantry

    public UnitBehavior squad2Position; //squad 2's positioning
    public UnitBehavior squad3Position; //squad 3's positioning

    int activeNumSq2;                   //squad 2's formation in number
    int activeNumSq3;                   //squad 3's formation in number

    public GameObject ArrowRainPosSq2;  //squad 2's arrow rain position
    public GameObject ArrowRainPosSq3;  //squad 3's arrow rain position

    // Use this for initialization
    void Start()
    {
        Debug.Log("Starting");

        //since the number is the same, just use one of the arrays as a reference
        for (int i = 0; i < arrInfantrySq2.Length; i++)
        {
            arrArchersSq2[i].Init();
            arrArchersSq3[i].Init();
            arrInfantrySq2[i].Init();
            arrInfantrySq3[i].Init();

            Debug.Log("Infantry and archer class initialized");

            //based on toggle of archers, show the infantry accordingly
            if (!ArchersSq2)
            {
                //based on the formation of the previously defined,
                //set the other formation inactive
                if (arrInfantrySq2[i].behaviour.position != squad2Position.position)
                {
                    arrInfantrySq2[i].gameObject.SetActive(false);

                    for (int j = 0; j < arrInfantrySq2[i].men.Length; j++)
                    {
                        arrInfantrySq2[i].men[j].gameObject.SetActive(false);
                    }
                }

                //disable appearance of archers
                arrArchersSq2[i].gameObject.SetActive(false);
                for (int j = 0; j < arrArchersSq2[i].men.Length; j++)
                {
                    arrArchersSq2[i].men[j].gameObject.SetActive(false);
                }
            }
            else
            {
                //based on the formation of the previously defined,
                //set the other formation inactive
                if (arrArchersSq2[i].behaviour.position != squad2Position.position)
                {
                    arrArchersSq2[i].gameObject.SetActive(false);

                    for (int j = 0; j < arrArchersSq2[i].men.Length; j++)
                    {
                        arrArchersSq2[i].men[j].gameObject.SetActive(false);
                    }
                }

                //disable appearance of infantry
                arrInfantrySq2[i].gameObject.SetActive(false);
                for (int j = 0; j < arrInfantrySq2[i].men.Length; j++)
                {
                    arrInfantrySq2[i].men[j].gameObject.SetActive(false);
                }
            }
            if (!ArchersSq3)
            {
                //based on the formation of the previously defined,
                //set the other formation inactive
                if (arrInfantrySq3[i].behaviour.position != squad3Position.position)
                {
                    arrInfantrySq3[i].gameObject.SetActive(false);

                    for (int j = 0; j < arrInfantrySq3[i].men.Length; j++)
                    {
                        arrInfantrySq3[i].men[j].gameObject.SetActive(false);
                    }
                }
                //disable appearance of archers
                arrArchersSq3[i].gameObject.SetActive(false);
                for (int j = 0; j < arrArchersSq3[i].men.Length; j++)
                {
                    arrArchersSq3[i].men[j].gameObject.SetActive(false);
                }
            }
        }
        for (int i = 0; i < arrMonsters.Length; i++)
        {
            //Initialize monster component
            arrMonsters[i].Init();

            Debug.Log("Monster class initialized");

            DebugText.text = "Monster class initialized";
        }
    }

    //************************** Infantry stuff ********************** //

    //Infantry attack
    void AttackMonsterInfantrySq2()
    {
        //set the target to the monster
        for (int i = 0; i < arrInfantrySq2[activeNumSq2].swords.Length; i++)
        {
            arrInfantrySq2[activeNumSq2].swords[i].transform.position = Vector3.MoveTowards(arrInfantrySq2[activeNumSq2].swords[i].transform.position, arrMonsters[0].transform.position, Time.deltaTime * 150);
        }
    }
    //for squad 3 to attack the monster
    void AttackMonsterInfantrySq3()
    {
        //set the target to the monster
        for (int i = 0; i < arrInfantrySq3[activeNumSq3].swords.Length; i++)
        {
            arrInfantrySq3[activeNumSq3].swords[i].transform.position = Vector3.MoveTowards(arrInfantrySq3[activeNumSq3].swords[i].transform.position, arrMonsters[0].transform.position, Time.deltaTime * 150);
        }
    }
    //check the status of infantry unit here
    void CheckInfantryStatusSq2()
    {
        //check which is the currently active formation
        for (int i = 0; i < arrInfantrySq2.Length; i++)
        {
            if (arrInfantrySq2[i].gameObject.activeInHierarchy)
            {
                activeNumSq2 = i;
                break;
            }
        }

        //Debug.Log(arrInfantry[activeNumSq2].behaviour.stance.ToString());

        switch (arrInfantrySq2[activeNumSq2].behaviour.stance)
        {
            case UnitBehavior.UNIT_STANCE.IDLE:     //idle, do nothing
                arrInfantrySq2[activeNumSq2].behaviour.stance = UnitBehavior.UNIT_STANCE.ENGAGED;  //engage the enemy for now
                break;
            case UnitBehavior.UNIT_STANCE.ENGAGED:  //engaged, check if atk or reload
                CheckEngagedInfantryStatusSq2();
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
    //check the status of infantry unit here
    void CheckInfantryStatusSq3()
    {
        //check which is the currently active formation
        for (int i = 0; i < arrInfantrySq3.Length; i++)
        {
            if (arrInfantrySq3[i].gameObject.activeInHierarchy)
            {
                activeNumSq3 = i;
                break;
            }
        }

        //Debug.Log(arrInfantry[activeNumSq2].behaviour.stance.ToString());

        switch (arrInfantrySq3[activeNumSq3].behaviour.stance)
        {
            case UnitBehavior.UNIT_STANCE.IDLE:     //idle, do nothing
                arrInfantrySq3[activeNumSq3].behaviour.stance = UnitBehavior.UNIT_STANCE.ENGAGED;  //engage the enemy for now
                break;
            case UnitBehavior.UNIT_STANCE.ENGAGED:  //engaged, check if atk or reload
                CheckEngagedInfantryStatusSq3();
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
    //checks the infantry status when engaged
    void CheckEngagedInfantryStatusSq2()
    {
        switch (arrInfantrySq2[activeNumSq2].behaviour.engage)
        {
            case UnitBehavior.ENGAGED_STATE.ATTACK:     //attack the enemy
                //DebugText.text = "Archer Attack";
                AttackMonsterInfantrySq2();
                arrInfantrySq2[activeNumSq2].InfantryAttack();
                break;
            case UnitBehavior.ENGAGED_STATE.RELOADING:  //reload the weapon
                DebugText.text = "Archer Reloading";
                arrInfantrySq2[activeNumSq2].InfantryReloading();
                break;
            default:
                arrInfantrySq2[activeNumSq2].InfantryReloading();
                break;
        }
    }
    //checks the infantry status when engaged
    void CheckEngagedInfantryStatusSq3()
    {
        switch (arrInfantrySq3[activeNumSq3].behaviour.engage)
        {
            case UnitBehavior.ENGAGED_STATE.ATTACK:     //attack the enemy
                //DebugText.text = "Archer Attack";
                AttackMonsterInfantrySq3();
                arrInfantrySq3[activeNumSq3].InfantryAttack();
                break;
            case UnitBehavior.ENGAGED_STATE.RELOADING:  //reload the weapon
                DebugText.text = "Archer Reloading";
                arrInfantrySq3[activeNumSq3].InfantryReloading();
                break;
            default:
                arrInfantrySq3[activeNumSq3].InfantryReloading();
                break;
        }
    }
    //update the infantry status
    void CheckInfantryStatus()
    {
        //check which squads are active
        if (!ArchersSq2)
        {
            //check which is the currently active formation
            for (int i = 0; i < arrInfantrySq2.Length; i++)
            {
                if (arrInfantrySq2[i].gameObject.activeInHierarchy)
                {
                    activeNumSq2 = i;
                    break;
                }
            }
            switch (arrInfantrySq2[activeNumSq2].behaviour.stance)
            {
                case UnitBehavior.UNIT_STANCE.IDLE:     //idle, do nothing
                    arrInfantrySq2[activeNumSq2].behaviour.stance = UnitBehavior.UNIT_STANCE.ENGAGED;  //engage the enemy for now
                    break;
                case UnitBehavior.UNIT_STANCE.ENGAGED:  //engaged, check if atk or reload
                    CheckEngagedInfantryStatusSq2();
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
        if (!ArchersSq3)
        {
            //check which is the currently active formation
            for (int i = 0; i < arrInfantrySq3.Length; i++)
            {
                if (arrInfantrySq3[i].gameObject.activeInHierarchy)
                {
                    activeNumSq3 = i;
                    break;
                }
            }
            switch (arrInfantrySq3[activeNumSq3].behaviour.stance)
            {
                case UnitBehavior.UNIT_STANCE.IDLE:     //idle, do nothing
                    arrInfantrySq3[activeNumSq3].behaviour.stance = UnitBehavior.UNIT_STANCE.ENGAGED;  //engage the enemy for now
                    break;
                case UnitBehavior.UNIT_STANCE.ENGAGED:  //engaged, check if atk or reload
                    CheckEngagedInfantryStatusSq3();
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
    }
    //************************** Infantry stuff ********************** //

    //************************** Archer stuff ********************** //
    //archer attack, squad 2
    void MoveToMonsterSq2()
    {
        //set the target to the monster
        for (int i = 0; i < arrArchersSq2[activeNumSq2].projectiles.Length; i++)
        {
            if (arrArchersSq2[activeNumSq2].projectiles[i].hitArrowRain)
            {
                arrArchersSq2[activeNumSq2].projectiles[i].transform.position = Vector3.MoveTowards(arrArchersSq2[activeNumSq2].projectiles[i].transform.position, arrMonsters[0].transform.position, Time.deltaTime * 150);
            }
            //move to arrow rain high position first
            else
            {
                arrArchersSq2[activeNumSq2].projectiles[i].transform.position = Vector3.MoveTowards(arrArchersSq2[activeNumSq2].projectiles[i].transform.position, ArrowRainPosSq2.transform.position, Time.deltaTime * 150);
            }
        }
    }
    //archer attack, squad 3
    void MoveToMonsterSq3()
    {
        //set the target to the monster
        for (int i = 0; i < arrArchersSq3[activeNumSq3].projectiles.Length; i++)
        {
            if (arrArchersSq3[activeNumSq3].projectiles[i].hitArrowRain)
            {
                arrArchersSq3[activeNumSq3].projectiles[i].transform.position = Vector3.MoveTowards(arrArchersSq3[activeNumSq3].projectiles[i].transform.position, arrMonsters[0].transform.position, Time.deltaTime * 150);
            }
            //move to arrow rain high position first
            else
            {
                arrArchersSq3[activeNumSq3].projectiles[i].transform.position = Vector3.MoveTowards(arrArchersSq3[activeNumSq3].projectiles[i].transform.position, ArrowRainPosSq3.transform.position, Time.deltaTime * 150);
            }
        }
    }
    //checks the archer status when engaged
    void CheckEngagedArcherStatusSq2()
    {
        switch (arrArchersSq2[activeNumSq2].behaviour.engage)
        {
            case UnitBehavior.ENGAGED_STATE.ATTACK:     //attack the enemy
                DebugText.text = "Archer Attack";
                MoveToMonsterSq2();
                arrArchersSq2[activeNumSq2].ArcherAttack();
                break;
            case UnitBehavior.ENGAGED_STATE.RELOADING:  //reload the weapon
                DebugText.text = "Archer Reloading";
                arrArchersSq2[activeNumSq2].ArcherReloading();
                break;
            default:
                arrArchersSq2[activeNumSq2].ArcherReloading();
                break;
        }
    }
    void CheckEngagedArcherStatusSq3()
    {
        switch (arrArchersSq3[activeNumSq3].behaviour.engage)
        {
            case UnitBehavior.ENGAGED_STATE.ATTACK:     //attack the enemy
                DebugText.text = "Archer Attack";
                MoveToMonsterSq3();
                arrArchersSq3[activeNumSq3].ArcherAttack();
                break;
            case UnitBehavior.ENGAGED_STATE.RELOADING:  //reload the weapon
                DebugText.text = "Archer Reloading";
                arrArchersSq3[activeNumSq3].ArcherReloading();
                break;
            default:
                arrArchersSq3[activeNumSq3].ArcherReloading();
                break;
        }
    }
    //check the status of archer unit here
    void CheckArcherStatus()
    {
        //check which squads are active
        if(ArchersSq2)
        {
            //check which is the currently active formation
            for (int i = 0; i < arrArchersSq2.Length; i++)
            {
                if (arrArchersSq2[i].gameObject.activeInHierarchy)
                {
                    activeNumSq2 = i;
                    break;
                }
            }
            switch (arrArchersSq2[activeNumSq2].behaviour.stance)
            {
                case UnitBehavior.UNIT_STANCE.IDLE:     //idle, do nothing
                    arrArchersSq2[activeNumSq2].behaviour.stance = UnitBehavior.UNIT_STANCE.ENGAGED;  //engage the enemy for now
                    break;
                case UnitBehavior.UNIT_STANCE.ENGAGED:  //engaged, check if atk or reload
                    CheckEngagedArcherStatusSq2();
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
        if(ArchersSq3)
        {
            //check which is the currently active formation
            for (int i = 0; i < arrArchersSq3.Length; i++)
            {
                if (arrArchersSq3[i].gameObject.activeInHierarchy)
                {
                    activeNumSq3 = i;
                    break;
                }
            }
            switch (arrArchersSq3[activeNumSq3].behaviour.stance)
            {
                case UnitBehavior.UNIT_STANCE.IDLE:     //idle, do nothing
                    arrArchersSq3[activeNumSq3].behaviour.stance = UnitBehavior.UNIT_STANCE.ENGAGED;  //engage the enemy for now
                    break;
                case UnitBehavior.UNIT_STANCE.ENGAGED:  //engaged, check if atk or reload
                    CheckEngagedArcherStatusSq3();
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
    }
    //************************** Archer stuff ********************** //
    void Update()
    {
        CheckArcherStatus();        //update archer status
        CheckInfantryStatus();      //update infantry status
    }
}
