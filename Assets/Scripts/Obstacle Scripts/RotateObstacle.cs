using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    [SerializeField]
    private float rotSpeed = 200f;

	[SerializeField]
	private float moveSpeed = 1f;

	[SerializeField]
	private LayerMask groundLayer;

	private CircleCollider2D col;

	private Vector3 tempPos;

	private float zAngle;

	private bool moveLeft;

	private RaycastHit2D groundHit;

	private void Awake()
	{
		col = GetComponent<CircleCollider2D>();
	}

	private void Start()
	{
		if (Random.Range(0, 2) > 0)
		{
			moveLeft = true;
		}
	}

	private void Update()
	{
		Rotate();

		HandleMovement();

		CheckForGround();
	}

	private void HandleMovement()
	{
		tempPos = transform.position;

	    if (moveLeft)
		{
			tempPos.x += moveSpeed * Time.deltaTime;
		}
		else
		{
			tempPos.x -= moveSpeed * Time.deltaTime;
		}

		transform.position = tempPos;
	}

	private void CheckForGround()
	{
		groundHit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);

		if (!groundHit)
		{
			moveLeft = !moveLeft;
		}
	}

	private void Rotate()
	{
		
		if (moveLeft)
		{
			zAngle -= Time.deltaTime * rotSpeed;
		}
		else
		{
			zAngle += Time.deltaTime * rotSpeed;
		}
		

		transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag(TagManager.PLAYER_TAG))
		{

		}
	}
}
