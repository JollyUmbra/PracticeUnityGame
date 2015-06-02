using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	private bool movingLeft = false;
	private bool movingRight = false;

	// Update is called once per frame
	void Update ()
	{
		if (target && target.position.x > transform.position.x && movingRight || target && target.position.x < transform.position.x && movingLeft)
		{
			Vector3 delta = new Vector3();
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			if(target.position.y <= 0.1)
			{
				delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.1f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			}
			if(target.position.y > 0.1)
			{
				delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.4f, point.z));
			}
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}

		if(Input.GetAxis("Horizontal") > 0)
		{
			movingLeft = false;
			movingRight = true;
		}
		if(Input.GetAxis("Horizontal") < 0)
		{
			movingLeft = true;
			movingRight = false;
		}

	}
}
