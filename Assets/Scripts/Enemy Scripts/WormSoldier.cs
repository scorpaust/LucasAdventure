using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSoldier : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    [SerializeField]
    private LayerMask groundLayer;

    private Transform groundCheckPos;

    private Vector3 tempPos, tempScale;

    private bool moveLeft;

    private RaycastHit2D groundHit;

	private void Awake()
	{
        groundCheckPos = transform.GetChild(0).transform;

        if (Random.Range(0,2) > 0)
		{
            moveLeft = true;
		}
        else
		{
            moveLeft = false;
		}
	}

	private void Update()
	{
        HandleMovement();

        CheckForGround();
	}

    private void HandleMovement()
	{
        tempPos = transform.position;

        tempScale = transform.localScale;

        if (moveLeft)
		{
            tempPos.x -= moveSpeed * Time.deltaTime;

            tempScale.x = -1f;
		}
        else
		{
            tempPos.x += moveSpeed * Time.deltaTime;

            tempScale.x = 1f;
        }

        transform.position = tempPos;

        transform.localScale = tempScale;
	}

    private void CheckForGround()
	{
        groundHit = Physics2D.Raycast(groundCheckPos.position, Vector2.down, 0.5f, groundLayer);

        if (!groundHit)
		{
            moveLeft = !moveLeft;
		}
	}


}
