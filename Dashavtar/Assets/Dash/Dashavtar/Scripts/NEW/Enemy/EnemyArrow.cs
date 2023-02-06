using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrow : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(ArrowTimer());
	}

	IEnumerator ArrowTimer()
	{
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			
			FindObjectOfType<PlayerHealth>().playerHealth -= 5;
			Destroy(gameObject);
		}

	}

}
