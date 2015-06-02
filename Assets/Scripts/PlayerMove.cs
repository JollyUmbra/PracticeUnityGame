using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	public float speed = 1f;
	public float jumpForce = 100f;
	Rigidbody2D player;

	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	bool grounded = false;

	void Start()
	{
		player = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		float jump = Input.GetAxis("Jump");

		if(grounded && jump > 0)
		{
			player.AddForce(new Vector2(0, jumpForce));
			grounded = false;
		}
	}

	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		float move = Input.GetAxis("Horizontal");
		player.velocity = new Vector2(move*speed, player.velocity.y);
	}
}
