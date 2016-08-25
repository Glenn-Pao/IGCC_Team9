﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//the game manager for this scene
public class GameManager : MonoBehaviour 
{
    public Archer[] arrArchers;     //an array of archers in the scene
    public Monster[] arrMonsters;   //an array of monsters in the scene
    public Text DebugText;    //check on archer components

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
        }
        for(int i = 0; i < arrMonsters.Length; i++)
        {
            //Initialize monster component
            arrMonsters[i].Init();

            Debug.Log("Monster class initialized");

            DebugText.text = "Monster class initialized";
        }
	}
}
