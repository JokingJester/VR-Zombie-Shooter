using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunClip : MonoBehaviour
{
    public float ammoCount = 8;
    public Belt belt;
    public bool grabbed;

    private void Awake()
    {
        belt = GameObject.Find("Clip Visual").GetComponent<Belt>();
    }

    public void RemoveClip()
    {
        if(grabbed == false)
        {
            grabbed = true;
            belt.RemoveClip();
        }
        //if select exit is called and gun still has ammo
        //set it back
    }

}
