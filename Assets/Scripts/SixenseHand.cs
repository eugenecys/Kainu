
//
// Copyright (C) 2013 Sixense Entertainment Inc.
// All Rights Reserved
//

using UnityEngine;
using System.Collections;

public class SixenseHand : MonoBehaviour
{
	public SixenseHands	m_hand;
	public SixenseInput.Controller m_controller = null;

	float 		m_fLastTriggerVal;
	Vector3		m_initialPosition;
	Quaternion 	m_initialRotation;
    
	protected void Start() 
	{
		m_initialRotation = transform.localRotation;
		m_initialPosition = transform.localPosition;
	}

	protected void Update()
	{
		if ( m_controller == null )
		{
			m_controller = SixenseInput.GetController( m_hand );
		}
	}
	
	public Quaternion InitialRotation
	{
		get { return m_initialRotation; }
	}
	
	public Vector3 InitialPosition
	{
		get { return m_initialPosition; }
	}
}

