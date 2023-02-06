using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			transform.parent.gameObject.GetComponent<EnemyMovement>().playerFound = true;

			if (transform.gameObject.name == "Arrow Vision")
			{
				StartCoroutine(FindObjectOfType<EnemyArrowAttack>().ArrowAttackTimer());
				GetComponent<BoxCollider2D>().enabled = false;
			}

			if(transform.gameObject.name == "Vision")
				transform.parent.gameObject.GetComponent<EnemyFollowPlayer>().followPlayer = true;


		}
	}
}
