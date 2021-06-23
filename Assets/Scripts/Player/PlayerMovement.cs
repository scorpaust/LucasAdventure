using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

	[SerializeField]
	private float normalJumpForce = 5f, doubleJumpForce = 5f;

	[SerializeField]
	private LayerMask groundMask;

	private float jumpForce = 5f;

	private RaycastHit2D groundCast;

	private CapsuleCollider2D capsCol;

    private float horizontalMovement;

    private Vector3 movePos;

	private bool canDoubleJump;

	private bool jumped;
    
    private Rigidbody2D myBody;

	private PlayerAnimation playerAnim;

	private void Awake()
	{
        myBody = GetComponent<Rigidbody2D>();

		playerAnim = GetComponent<PlayerAnimation>();

		capsCol = GetComponent<CapsuleCollider2D>();

		canDoubleJump = true;
	}

	private void Update()
	{
		horizontalMovement = Input.GetAxisRaw(TagManager.HORIZONTAL_MOVEMENT_AXIS);

		HandleAnimation();

		HandleJumping();

		CheckToDoubleJump();

		FromJumpToWalkOrIdle();

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

		playerAnim.PlayJumpAndFall((int)myBody.velocity.y);
	}

	private void HandleJumping()
	{

		IsGrounded();

		if (Input.GetButtonDown(TagManager.JUMP_BUTTON))
		{
			if (IsGrounded())
			{
				jumpForce = normalJumpForce;

				Jump();
			}
			else
			{
				if (canDoubleJump)
				{
					canDoubleJump = false;
					jumpForce = doubleJumpForce;
					Jump();
				}
			}
				
		}
	}

	bool IsGrounded()
	{
		groundCast = Physics2D.BoxCast(capsCol.bounds.center, capsCol.bounds.size, 0f, Vector2.down, 0.2f, groundMask);

		return groundCast.collider != null;
	}

	private void Jump()
	{
		myBody.velocity = Vector2.up * jumpForce;

		jumped = true;
	}

	private void CheckToDoubleJump()
	{
		if (!canDoubleJump && myBody.velocity.y == 0)
			canDoubleJump = true;
	}

	private void FromJumpToWalkOrIdle()
	{
		if (jumped && myBody.velocity.y == 0)
		{
			jumped = false;

			if (Mathf.Abs((int)myBody.velocity.x) > 0)
			{
				playerAnim.PlayAnimationWithName(TagManager.WALK_ANIMATION);
			}
			else
			{
				playerAnim.PlayAnimationWithName(TagManager.IDLE_ANIMATION);
			}
		}
	}
}
