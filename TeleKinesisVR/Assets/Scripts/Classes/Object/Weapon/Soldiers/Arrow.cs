using UnityEngine;
using System.Collections;

//This is the class that identifies the weapon used by archers
public class Arrow : WeaponClass 
{
    public bool hit = false;

    public void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.tag == "Enemy")
        {
            Debug.Log(hit);
            hit = true;
        }
    }
}
