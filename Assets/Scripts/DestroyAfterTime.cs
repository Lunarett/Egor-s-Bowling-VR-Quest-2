using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DestroyAfterTime : MonoBehaviour
{
	[SerializeField] private float m_delayDestroy = 10.0f;
	[SerializeField] private LayerMask m_layer;

	private void OnTriggerEnter(Collider other)
	{
		int layer = 1 << other.gameObject.layer;
		if (m_layer.value == layer)
			StartCoroutine(DelayDestroy(m_delayDestroy, other.gameObject));
	}

	IEnumerator DelayDestroy(float time, GameObject obj)
	{
		yield return new WaitForSeconds(time);
		Destroy(obj);
	}
}
