using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using FMOD;

public class MusicPlayer : MonoBehaviour
{
	[SerializeField] private EventReference m_music;
	private EventInstance inst;

	private void Awake()
	{
		inst = RuntimeManager.CreateInstance(m_music);
		inst.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
	}

	public void PlaySong(int index)
	{
		UnityEngine.Debug.Log("Playing Song " + index);
		inst.start();
		inst.setParameterByName("MusicState", index);
	}
}
