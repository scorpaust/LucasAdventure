using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBatV2 : MonoBehaviour
{
    [SerializeField]
    private float minX = -8.3f, maxX = 8.3f, minY = -4.5f, maxY = 4.5f;

    [SerializeField]
    private float moveSpeed = 2f;

    private Vector3 targetPos;

    private SpriteRenderer sr;

	private float prevXPos;

	private void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
        MoveToTargetPos();
	}

    private void MoveToTargetPos()
	{
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
		{
            targetPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);

			prevXPos = transform.position.x;
		}

		ChangeFacingDirection();
	}

	private void ChangeFacingDirection()
	{
		if (transform.position.x > prevXPos)
			sr.flipX = false;
		else if (transform.position.x < prevXPos)
			sr.flipX = true;
	}
}
