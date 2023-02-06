using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowAttack : MonoBehaviour
{
	public GameObject Arrow;
	public GameObject Player;
	public Transform ArrowSpawn;

	public int arrowsLeft = 5;
	public float arrowSpeed = 4f;
	public bool isAttacking = false;

	private void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		isAttacking = gameObject.GetComponent<Animator>().GetBool("isAttacking");
	}



	public IEnumerator ArrowAttackTimer()
	{

		ArrowAttack();
		yield return new WaitForSeconds(0.5f);
		gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
		yield return new WaitForSeconds(1f);

		ArrowAttack();
		yield return new WaitForSeconds(0.5f);
		gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
		yield return new WaitForSeconds(1f);

		ArrowAttack();
		yield return new WaitForSeconds(0.5f);
		gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
		yield return new WaitForSeconds(1f);

		ArrowAttack();
		yield return new WaitForSeconds(0.5f);
		gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
		yield return new WaitForSeconds(1f);

		ArrowAttack();
		yield return new WaitForSeconds(0.5f);
		gameObject.GetComponent<Animator>().SetBool("isAttacking", false);
		yield return new WaitForSeconds(3.5f);

		StartCoroutine(ArrowAttackTimer());
	}


	void ArrowAttack()
	{
		
		if (Player.transform.position.x < transform.position.x)
			transform.rotation = Quaternion.Euler(0, 0, 0);

		else
			transform.rotation = Quaternion.Euler(0, 180, 0);

		GameObject Arrows = Instantiate(Arrow, ArrowSpawn.position, transform.rotation);
		Arrows.GetComponent<Rigidbody2D>().AddForce(-transform.right * arrowSpeed, ForceMode2D.Impulse);
		gameObject.GetComponent<Animator>().SetBool("isAttacking", true);
		gameObject.GetComponent<Animator>().SetBool("isWalking", false);

	}
}
