using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
	[SerializeField] private LayerMask m_layer;

	private void OnTriggerEnter(Collider other)
	{
		int layer = 1 << other.gameObject.layer;
		if (m_layer.value == layer)
		{
			Destroy(other.gameObject);
		}
	}
}
