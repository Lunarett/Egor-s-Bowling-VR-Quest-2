using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPins : MonoBehaviour
{
	private Rigidbody[] rb;

	private void Awake()
	{
		rb = GetComponentsInChildren<Rigidbody>();
	}

	public void SetKinematic(bool state)
	{
		foreach (Rigidbody body in rb)
		{
			body.isKinematic = state;
		}
	}
}
