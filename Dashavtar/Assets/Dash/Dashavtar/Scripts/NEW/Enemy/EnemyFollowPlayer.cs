using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
	public bool followPlayer = false;
	public float followSpeed = 3f;
	public bool playerReached = false;
	public GameObject Player;

	public Animator anim;

	private void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
	}

	private void Update()
	{
		if(followPlayer)
		{
			anim.SetBool("isRunning",true);
			
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y), followSpeed * Time.deltaTime);

			if (Player.transform.position.x < transform.position.x)
				transform.rotation = Quaternion.Euler(0, 0, 0);

			if (Player.transform.position.x > transform.position.x)
				transform.rotation = Quaternion.Euler(0, 180, 0);
		}

		if (Vector2.Distance(transform.position, new Vector2(Player.transform.position.x, transform.position.y)) <= 4.5f && followPlayer)
		{
			anim.SetBool("isRunning",false);
			followPlayer = false;
			playerReached = true;
		}

		if (playerReached && Vector2.Distance(transform.position, new Vector2(Player.transform.position.x, transform.position.y)) > 4.5f)
		{
			followPlayer = true;
			playerReached = false;
		}

		//Debug.Log(Vector2.Distance(transform.position, new Vector2(Player.transform.position.x, transform.position.y)));
		

	}
}
