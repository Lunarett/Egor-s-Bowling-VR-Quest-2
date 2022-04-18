using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMusic : MonoBehaviour
{
	[SerializeField] private int songCount = 4;
	private MusicPlayer[] players;

	private void Awake()
	{
		players = FindObjectsOfType<MusicPlayer>();
	}

	void Start()
	{
		int songIndex = Random.Range(0, songCount - 1);

		foreach (MusicPlayer p in players)
		{
			p.PlaySong(songIndex);
		}

	}
}
