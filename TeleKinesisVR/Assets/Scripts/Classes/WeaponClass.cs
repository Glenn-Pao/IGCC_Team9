using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponClass : MonoBehaviour {
    public int Range;
    public int RateOfFire;
    int MaterialID;
    Dictionary<int, Dictionary<string, int>> Materials;
	// Use this for initialization
	void Start () {
      Materials[1]["Iron"] = 5;
      Materials[2]["Steel"] = 8;
      Materials[3]["ForgedSteel"] = 10;
      Materials[4]["Mithril"] = 15;


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    

  



   
}
