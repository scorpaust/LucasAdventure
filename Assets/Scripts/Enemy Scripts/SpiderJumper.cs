using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
	[SerializeField]
	private float minWaitTime = 2f, maxWaitTime = 5f;

	[SerializeField]
	private float minJumpForce = 5f, maxJumpForce = 10f;

	private Animator anim;

    private Rigidbody2D myBody;

    private float jumpForce;

    private float jumpTimer;

	private void Awake()
	{
		anim = GetComponent<Animator>();

		myBody = GetComponent<Rigidbody2D>();
	}

	private void Start()
	{
		
	}

	private void Update()
	{
		if (Time.time > jumpTimer)
		{
			Jump();
		}

		if (myBody.velocity.y == 0)
		{
			anim.SetBool(TagManager.JUMP_ANIMATION_PARAM, false);
		}
	}

	private void Jump()
	{
		jumpTimer = Time.time + Random.Range(minWaitTime, maxWaitTime);

		jumpForce = Random.Range(minJumpForce, maxJumpForce);

		myBody.velocity = new Vector2(0f, jumpForce);

		anim.SetBool(TagManager.JUMP_ANIMATION_PARAM, true);
	}
}
