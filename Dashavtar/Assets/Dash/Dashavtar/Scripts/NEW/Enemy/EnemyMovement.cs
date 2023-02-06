using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public bool playerFound = false;
	

	[Header("Enemy Properties")]
	public bool goLeft = true;
	public float enemySpeed = 2f;
	public float travelDistance = 3;
	public float seconds = 2f;
	Vector2 left, right;

	private void Start()
	{
		

		left = new Vector2(transform.position.x - travelDistance, transform.position.y);
		right = new Vector2(transform.position.x + travelDistance, transform.position.y);

		if (goLeft)
			transform.rotation = Quaternion.Euler(0, 0, 0);

		if(!goLeft)
			transform.rotation = Quaternion.Euler(0, 180, 0);


		StartCoroutine(ChangeDirection());
	}

	private void Update()
	{
		if (!playerFound)
		{
			if (goLeft)
				transform.position = Vector2.MoveTowards(transform.position, left, enemySpeed * Time.deltaTime);

			if (!goLeft)
				transform.position = Vector2.MoveTowards(transform.position, right, enemySpeed * Time.deltaTime);

			if((Vector2)transform.position == left || (Vector2)transform.position == right)
			{
				gameObject.GetComponent<Animator>().SetBool("isWalking", false);
			}

			else
				gameObject.GetComponent<Animator>().SetBool("isWalking", true);

		}

	}

	IEnumerator ChangeDirection()
	{
		yield return new WaitForSeconds(seconds);

		if (!playerFound)
		{
			if (goLeft)
			{
				goLeft = false;
				transform.rotation = Quaternion.Euler(0, 180, 0);
			}

			else
			{
				goLeft = true;
				transform.rotation = Quaternion.Euler(0, 0, 0);
			}

			

		}


		StartCoroutine(ChangeDirection());


	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
			Physics2D.IgnoreCollision(transform.gameObject.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>());
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawLine(new Vector2(transform.position.x - travelDistance, transform.position.y), new Vector2(transform.position.x + travelDistance, transform.position.y));
	}
}
