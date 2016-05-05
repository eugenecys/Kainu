using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SixenseHand))]

public class HandController : MonoBehaviour {

    public enum Side
    {
        Left,
        Right
    }

    public Side side;

    private SixenseHand sxHand;

    #region UnityDefaults

    void Awake ()
    {
        sxHand = GetComponent<SixenseHand>();
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    #endregion

    #region Kainu_Interactions

    void grab()
    {

    }

    void throwObject(Fetchable fObj, Vector3 vect)
    {

    }

    #endregion
}
