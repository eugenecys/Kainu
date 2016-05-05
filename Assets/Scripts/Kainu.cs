using UnityEngine;
using System.Collections;
using System;

public class Kainu : Singleton<Kainu>, Commandable {

    public void fetch(Fetchable fObj)
    {
        //Visually track fObj, gradual spherical interpolation to path plot until fObj hits ground
    }

    #region Movement_mechanics

    public void move(Vector3 _position)
    {
        //Moves to specified position through spherical interpolation of path plots
        desination = _position;
    }

    private float turningStrength = 0.08f;
    private Vector3 desination;
    
    //TODO: Add updating heading vector when turning 

    private Vector3 getHeadingVector()
    {
        Vector3 bodyDirection = transform.forward;
        Vector3 targetDirection = desination;
        return (1 - turningStrength) * bodyDirection + turningStrength * desination;
    }

    #endregion

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
