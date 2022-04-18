using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnNextBall : MonoBehaviour
{
	[SerializeField] private float m_delay = 5.0f;
	[SerializeField] private float m_delayDestroy = 10.0f;
	[SerializeField] private LayerMask m_layer;
	[SerializeField] private BowlingBallDispenser m_ballDispenser;

	const int totalBalls = 12;
	int ballCount;

	private void Start()
	{
		ballCount = 8;
	}

	private void OnTriggerExit(Collider other)
	{
		int layer = 1 << other.gameObject.layer;
		if (m_layer.value == layer && ballCount < totalBalls)
		{
			StartCoroutine(DelaySpawn(m_delay));
			StartCoroutine(DelayDestroy(m_delayDestroy, other.gameObject));
		}
	}

	IEnumerator DelaySpawn(float duration)
	{
		yield return new WaitForSeconds(duration);
		m_ballDispenser.SpawnBall();
	}

	IEnumerator DelayDestroy(float time, GameObject obj)
	{
		yield return new WaitForSeconds(time);
		Destroy(obj);
	}
}
