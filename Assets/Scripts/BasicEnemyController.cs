using UnityEngine;
using System.Collections;

public class BasicEnemyController : MonoBehaviour
{
	private bool dirRight = true;
	public float speed = 1.0f;
	public float walkDistance = 0.5f;
	public Animator HUDControl;

	float start;

	void Start()
	{
		start = transform.position.x;
	}

	void Update ()
	{
	    if (dirRight)
	        transform.Translate (Vector2.right * speed * Time.deltaTime);
	    else
	        transform.Translate (-Vector2.right * speed * Time.deltaTime);

	    if(transform.position.x >= start + walkDistance)
		{
	        dirRight = false;
	    }

	    if(transform.position.x <= start - walkDistance)
		{
	        dirRight = true;
	    }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			HUDControl.SetBool("GameOver", true);
			Destroy(other.gameObject);
		}
	}
}
