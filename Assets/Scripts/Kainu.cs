using UnityEngine;
using System.Collections;
using System;

public class Kainu : Singleton<Kainu>, Commandable {

    public void fetch(Fetchable fObj)
    {
        //Visually track fObj, gradual spherical interpolation to path plot until fObj hits ground
    }

    public void move(Vector3 _position)
    {
        //Moves to specified position through spherical interpolation of path plots
    }
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
