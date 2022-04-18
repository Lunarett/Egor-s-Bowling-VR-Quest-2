using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ClearPin : MonoBehaviour
{
	[SerializeField] private LayerMask m_layer;
	[SerializeField] private GameObject m_pinsPrefab;
	[SerializeField] private Transform m_pinSpawnPoint;
	[SerializeField] private Transform m_pinClearer;
	[SerializeField] private Transform m_edge;
	[SerializeField] private Transform m_location;
	[Space]
	[SerializeField] private float m_pinClearerSpeed = 3.0f;

	[SerializeField] private EventReference m_strike;
	[SerializeField] private EventReference m_machine;

	private bool m_inProgress;
	private Vector3 m_initPos;
	private Rigidbody m_edgeRB;
	private SetPins m_pins;

	private void Start()
	{
		m_edgeRB = m_edge.GetComponent<Rigidbody>();
		m_initPos = m_edge.position;
	}

	private void OnTriggerEnter(Collider other)
	{
		int layer = 1 << other.gameObject.layer;
		if (m_layer.value == layer && !m_inProgress)
		{
			StartCoroutine(ClearPins());
		}
	}

	IEnumerator ClearPins()
	{
		m_inProgress = true;
		RuntimeManager.PlayOneShot(m_strike, transform.position);
		
		yield return new WaitForSeconds(1);


		// Move Down Vertically
		while(m_edge.position.y >= m_location.position.y)
		{
			m_edge.position += -Vector3.up * m_pinClearerSpeed * Time.deltaTime;
			yield return new WaitForSeconds(0.001f);
		}

		yield return new WaitForSeconds(0.5f);
		
		RuntimeManager.PlayOneShot(m_machine, transform.position);

		while (m_edge.position.x >= m_location.position.x)
		{
			m_edge.position += -Vector3.right * m_pinClearerSpeed * Time.deltaTime;
			yield return new WaitForSeconds(0.001f);
		}

		yield return new WaitForSeconds(1);

		while (m_edge.position.x <= m_initPos.x)
		{
			m_edge.position += Vector3.right * m_pinClearerSpeed * Time.deltaTime;
			yield return new WaitForSeconds(0.001f);
		}

		GameObject pins = Instantiate(m_pinsPrefab, m_pinSpawnPoint.position, m_pinSpawnPoint.rotation);
		pins.transform.SetParent(null);
		m_pins = pins.GetComponent<SetPins>();
		m_pins.SetKinematic(true);

		while(pins.transform.position.y >= m_location.position.y)
		{
			pins.transform.position += -Vector3.up * m_pinClearerSpeed * Time.deltaTime;
			yield return new WaitForSeconds(0.001f);
		}

		yield return new WaitForSeconds(0.5f);

		m_pins.SetKinematic(false);

		while (m_edge.position.y <= m_initPos.y)
		{
			m_edge.position += Vector3.up * m_pinClearerSpeed * Time.deltaTime;
			yield return new WaitForSeconds(0.001f);
		}

		m_inProgress = false;

		yield return null;
	}
}
