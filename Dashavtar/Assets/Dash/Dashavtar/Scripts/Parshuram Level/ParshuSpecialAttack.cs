using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParshuSpecialAttack : MonoBehaviour
{
	public GameObject Parshu;
	public Transform ParshuLocation;
	public float attackSpeed = 5f;
	public bool parshuAttached = true;
	public int abilityBar = 0;

	public Animator anim;
	public float seconds = 1f;
	public float f = 1f;

	private void Start()
	{
		StartCoroutine(SpecialAttackBar());	
	}


	

	IEnumerator SpecialAttack()
	{
		GameObject ParshuWeapon = Instantiate(Parshu, ParshuLocation.position, Quaternion.identity, transform);
		Rigidbody2D rb = ParshuWeapon.GetComponent<Rigidbody2D>();
		rb.AddForce(transform.right * attackSpeed, ForceMode2D.Impulse);
		parshuAttached = false;
		abilityBar -= 50;

		
		yield return new WaitForSeconds(seconds);

		parshuAttached = true;
		Destroy(ParshuWeapon);
		
		

	}


	IEnumerator SpecialAttackBar()
	{
		if(abilityBar == 100)
		{
			yield return null;
		}

		else
		{
			yield return new WaitForSeconds(5f);
			abilityBar += 10;
		}

		StartCoroutine(SpecialAttackBar());

	}

	public void Attack()
	{
		if (parshuAttached && abilityBar >= 50)
		{
			anim.SetBool("isSpecial",true);
			StartCoroutine(SpecialAttack());
			StartCoroutine(SAFinish());
		}
	}

	IEnumerator SAFinish()
	{
		
		yield return new WaitForSeconds(f);
		anim.SetBool("isSpecial",false);
	}
}
