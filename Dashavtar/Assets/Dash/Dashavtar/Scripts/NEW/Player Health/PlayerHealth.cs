using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public int playerHealth = 100;
	public GameObject exitScreen;
	public GameObject GameUi;

	private void Update()
	{
		if (playerHealth <= 0)
		{
			gameObject.GetComponentInChildren<Animator>().SetBool("isDead",true);
			StartCoroutine(UareDead());
			
		}
			
	}

	IEnumerator UareDead()
	{
		yield return new WaitForSeconds(1.5f);
		exitScreen.SetActive(true);
		GameUi.SetActive(false);
	}
}
