using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private float horizontalMovement;

    private Vector3 movePos;
    
    private Rigidbody2D myBody;

	private PlayerAnimation playerAnim;

	private void Awake()
	{
        myBody = GetComponent<Rigidbody2D>();

		playerAnim = GetComponent<PlayerAnimation>();
	}

	private void Update()
	{
		horizontalMovement = Input.GetAxisRaw(TagManager.HORIZONTAL_MOVEMENT_AXIS);

		HandleAnimation();
	}

	private void FixedUpdate()
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		if (horizontalMovement > 0)
		{
			myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
		}
		else if (horizontalMovement < 0)
		{
			myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
		}
		else
		{
			myBody.velocity = new Vector2(0f, myBody.velocity.y);
		}
	}

	private void HandleAnimation()
	{
		if (myBody.velocity.y == 0)
			playerAnim.PlayWalk(Mathf.Abs((int)myBody.velocity.x));

		playerAnim.ChangeFacingDirection((int)myBody.velocity.x);
	}
}
