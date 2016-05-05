using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class ThrowingToy : MonoBehaviour, Fetchable, Interactable {

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

    public void setVelocity(Vector3 vect)
    {
        rb.velocity = vect;
    }

    #endregion
}
