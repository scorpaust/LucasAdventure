using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDelegate : MonoBehaviour
{
    [SerializeField]
    private float scaleTime = 1f;

    private Vector3 myScale;

    private bool canScale;

    private CapsuleCollider2D myCollider;

	private void Awake()
	{
        myCollider = GetComponent<CapsuleCollider2D>();
	}

	private void OnEnable()
	{
		Key.KeyCollectedInfo += UnlockDoor;
	}

	private void Update()
	{
		Unlock();
	}

	private void OnDisable()
	{
		Key.KeyCollectedInfo -= UnlockDoor;
	}

	private void Unlock()
	{
		if (canScale)
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

	void UnlockDoor()
	{
		canScale = true;
	}
}
