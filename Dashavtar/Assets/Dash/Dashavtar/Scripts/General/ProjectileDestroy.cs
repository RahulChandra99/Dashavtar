using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{                                                                                                                                                                           /* Deals the lifetime of projectiles*/
    #region FUNCTIONS

    private void Start()
    {
        StartCoroutine(ArrowTimer());
    }


    IEnumerator ArrowTimer()
    {
        yield return new WaitForSeconds(2f);
        Destroy(transform.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerManager>().health -= 10;
            Destroy(transform.gameObject);
        }
    }




	#endregion
}
