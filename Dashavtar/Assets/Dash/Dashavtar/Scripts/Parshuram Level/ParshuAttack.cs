using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParshuAttack : MonoBehaviour
{
	public float attackRadius = 2f;
	public Transform AttackPoint;
	public LayerMask EnemyLayer;
	public LayerMask ArrowLayer;
	public bool attack = false;
	public bool deflect = false;

	public Animator anim;


	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(AttackPoint.position, attackRadius);
	}

	public void Attack()
	{
		anim.SetBool("isMelee",true);

		StartCoroutine(FinishAnimation());
		
		if (Physics2D.OverlapCircle(AttackPoint.position, attackRadius, EnemyLayer))
		{
			Physics2D.OverlapCircle(AttackPoint.position, attackRadius, EnemyLayer).gameObject.GetComponent<EnemyHealth>().enemyHealth -= 40;
			
			FindObjectOfType<ParshuSpecialAttack>().abilityBar += 10;
		}

		if (Physics2D.OverlapCircle(AttackPoint.position, attackRadius, ArrowLayer))
		{
			Destroy(Physics2D.OverlapCircle(AttackPoint.position, attackRadius, ArrowLayer).gameObject);
			FindObjectOfType<ParshuSpecialAttack>().abilityBar += 5;

		}

		//attack = true;
	}

	IEnumerator FinishAnimation()
	{
		yield return new WaitForSeconds(0.5f);
		anim.SetBool("isMelee",false);
	}

}



