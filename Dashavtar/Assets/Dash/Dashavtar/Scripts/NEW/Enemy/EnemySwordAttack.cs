using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordAttack : MonoBehaviour
{
	public GameObject Player;
	public Animator anim;

	private void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		StartCoroutine(SwordAttack());
	}


	IEnumerator SwordAttack()
	{
		yield return new WaitForSeconds(0f);

		if(gameObject.GetComponent<EnemyFollowPlayer>().playerReached && Vector2.Distance(transform.position, new Vector2(Player.transform.position.x, transform.position.y)) <= 4.5f /*&& Player.transform.position.y <= (transform.position.y+1)*/)
		{
			anim.SetBool("isAttacking",true);
			
			yield return new WaitForSeconds(2f);
			FindObjectOfType<PlayerHealth>().playerHealth -= 10;
			anim.SetBool("isAttacking",false);
			


		}

		StartCoroutine(SwordAttack());
	}
}
