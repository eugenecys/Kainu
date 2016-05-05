using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class ThrowingToy : MonoBehaviour, Fetchable, Throwable {

    Rigidbody rb;

    #region Unity_Defaults
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        
    }

    #endregion

    #region Throwing_Mechanics

    public void setThrow(Vector3 vect)
    {
        rb.velocity = vect;
    }

    #endregion
}
