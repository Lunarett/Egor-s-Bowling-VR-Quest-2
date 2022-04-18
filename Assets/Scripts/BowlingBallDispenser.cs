using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBallDispenser : MonoBehaviour
{
	[SerializeField] private LayerMask m_layer;
	[SerializeField] private float m_pushPower = 3.0f;
	[SerializeField] private GameObject m_bowlingBall;
	[SerializeField] private Material[] m_bowlingBallMaterials;

	private Rigidbody m_rb;

	private void OnTriggerStay(Collider other)
	{
		int layer = 1 << other.gameObject.layer;
		if (m_layer.value == layer)
		{
			m_rb = other.GetComponent<Rigidbody>();

			if(m_rb != null)
			{
				m_rb.velocity += transform.right * m_pushPower * Time.deltaTime;
				m_rb.angularVelocity += transform.right * m_pushPower * Time.deltaTime;
			}
		}
	}

	public void SpawnBall()
	{
		Debug.Log("Spawned");
		GameObject go = Instantiate(m_bowlingBall, transform.position, transform.rotation);
		go.transform.SetParent(null);
		go.GetComponent<MeshRenderer>().GetComponent<MeshRenderer>().material = m_bowlingBallMaterials[Random.Range(0, m_bowlingBallMaterials.Length)];
		go.GetComponent<Rigidbody>().velocity += transform.right * m_pushPower * Time.deltaTime;
		go.GetComponent<Rigidbody>().angularVelocity += transform.right * m_pushPower * Time.deltaTime;
	}
}
