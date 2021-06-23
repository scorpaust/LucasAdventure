using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	public delegate void KeyCollected();

	public static event KeyCollected KeyCollectedInfo;

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(TagManager.PLAYER_TAG))
		{
			// Unlock gate
			// Lock.instance.UnlockDoor();
			if (KeyCollectedInfo != null)
				KeyCollectedInfo();

			Destroy(gameObject);
		}
	}
}
