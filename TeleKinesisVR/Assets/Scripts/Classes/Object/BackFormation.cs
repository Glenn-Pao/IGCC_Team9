using UnityEngine;
using System.Collections;

//the front or back formation script
public class BackFormation : MonoBehaviour {

    GameManager manager;

    [HideInInspector]
    public bool isSeen = false;

    private float elapsed = 0.0f;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (isSeen)
        {
            elapsed += Time.deltaTime;
            if (elapsed > 1.0f)
            {
                isSeen = false;
                elapsed = 0.0f;

                this.transform.FindChild("glow_card").gameObject.SetActive(true);
            }
            else
                return;

            //click detected
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("CLICK DETECTED!");
                manager.squad3Position.position = UnitBehavior.POSITIONS.BACK;
            }
        }

        
	}

    public void Targeted()
    {
        isSeen = true;

        this.transform.FindChild("glow_card").gameObject.SetActive(false);
    }
}
