using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParshuSpecialAttackDamage : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			collision.gameObject.GetComponent<EnemyHealth>().enemyHealth = 0;
			Camera.main.GetComponent<Animator>().SetBool("cameraShake", true);
		}
	}
}
