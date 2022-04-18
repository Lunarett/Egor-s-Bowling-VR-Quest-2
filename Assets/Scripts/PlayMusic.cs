using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayMusic : MonoBehaviour
{
	[SerializeField] private EventReference m_music;

	private void Start()
	{
		RuntimeManager.PlayOneShotAttached(m_music.Guid, gameObject);
	}
}
