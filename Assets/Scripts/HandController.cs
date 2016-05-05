using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SixenseHand))]

public class HandController : MonoBehaviour {

    public enum Side
    {
        Left,
        Right
    }

    public Side side;

    private SixenseHand sxHand;
    private List<EventManager.GameEvent> pEvents;

    #region UnityDefaults

    void Awake ()
    {
        sxHand = GetComponent<SixenseHand>();
        pEvents = new List<EventManager.GameEvent>();
        initObjectInteractions();
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        foreach(EventManager.GameEvent pEvent in pEvents)
        {
            pEvent(); 
        }

    }

    #endregion

    #region Object_Interactions
    

    void initObjectInteractions()
    {
        pEvents.Add(pollPos);
    }

    void pollPos()
    {

    }

    void grab()
    {

    }

    void throwObject(Fetchable fObj, Vector3 vect)
    {

    }



    #endregion
}
