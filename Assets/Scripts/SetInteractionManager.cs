using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetInteractionManager : MonoBehaviour
{
	private XRGrabInteractable grab;

	private void Awake()
	{
		grab = GetComponent<XRGrabInteractable>();
		grab.interactionManager = FindObjectOfType<XRInteractionManager>();
	}
}
