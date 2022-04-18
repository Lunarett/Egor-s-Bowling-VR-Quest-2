using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAway : MonoBehaviour
{
	[SerializeField] private LayerMask m_layer;
	[SerializeField] private float m_power = 4;

	private void OnTriggerStay(Collider other)
	{
		int layer = 1 << other.gameObject.layer;
		if (m_layer.value == layer)
		{
			other.GetComponent<Rigidbody>().velocity = -Vector3.right * m_power * Time.deltaTime;
		}
	}
}
