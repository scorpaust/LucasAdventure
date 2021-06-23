using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public static Lock instance;

	[SerializeField]
	private float scaleTime = 1f;

	private Vector3 myScale;

	private bool keyCollected, canScale;

	private CapsuleCollider2D myCollider;

	private void Awake()
	{
		if (instance == null)
			instance = this;

		myCollider = GetComponent<CapsuleCollider2D>();
	}

	private void Update()
	{
		Unlock();
	}

	private void Unlock()
	{
		if (keyCollected && canScale)
		{
			myScale = transform.localScale;

			myScale.y -= scaleTime * Time.deltaTime;

			if (myScale.y <= 0)
			{
				myScale.y = 0;

				canScale = false;

				myCollider.enabled = false;
			}

			transform.localScale = myScale;
		}
	}

	public void UnlockDoor()
	{
		keyCollected = true;

		canScale = true;
	}
}
