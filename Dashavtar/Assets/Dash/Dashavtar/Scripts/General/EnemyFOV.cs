using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    #region VARIABLES

    public GameObject Enemy;
    public GameObject Player;
    public GameObject ArrowPos;

    bool followPlayer = false;
    public bool nearPlayer = false;
    public float followSpeed = 10f;
    public float checkSphere = 3f;
    public bool attack = false;
    public bool arrowEnemy = false;

    public Collider2D[] Colliders;
    public Animator enemyAnim;

	#endregion

	#region CALLBACK METHODS

	private void Start()
	{
        StartCoroutine(SwordAttack());
	}

	private void Update()
    {
        if(followPlayer)
        {
            Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, Player.transform.position, followSpeed * Time.deltaTime);
            Vector2 direction = Player.transform.position - Enemy.transform.position;

            if (direction.x > 0)
                Enemy.transform.rotation = Quaternion.Euler(0, 0, 0);

            if (direction.x < 0)
                Enemy.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

	private void FixedUpdate()
	{
        int notPlayerColliders = 0;

        Colliders = Physics2D.OverlapCircleAll(Enemy.transform.position, checkSphere);

        foreach(Collider2D coll in Colliders)
		{
            if (coll.gameObject.tag == "Player")
            {
                followPlayer = false;
                nearPlayer = true;
                attack = true;
            }

            if (coll.gameObject.tag != "Player")
                notPlayerColliders++;

            if (notPlayerColliders == Colliders.Length)
            {
                nearPlayer = false;
                attack = false;
            }
        }


	}


	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (!arrowEnemy)
            {
                EnemyAI.playerFound = true;
                followPlayer = true;
            }

            if(arrowEnemy)
			{
                EnemyAI.playerFound = true;
                
                //ArrowAttack();
                
                StartCoroutine(KillPlayer());
			}
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !nearPlayer)
        {
            if (!arrowEnemy)
            {
                EnemyAI.playerFound = true;
                followPlayer = true;
            }

            if(arrowEnemy)
			{
                EnemyAI.playerFound = true;
                //ArrowAttack();
			}
        }
    }

	#endregion

	#region METHODS

    IEnumerator SwordAttack()
	{
        
        yield return new WaitForSeconds(1f);

        if (attack)
        {
            enemyAnim.SetBool("isAttacking",true);
            Debug.Log("potty");
            yield return new WaitForSeconds(1f);

            if (!FindObjectOfType<PlayerManager>().isGuarded)
            {
                FindObjectOfType<PlayerManager>().health -= 20;
            }
            
        }

        if (!attack)
        {
            enemyAnim.SetBool("isAttacking",false);
        }

        StartCoroutine(SwordAttack());
	}


    IEnumerator KillPlayer()
	{
        yield return new WaitForSeconds(1f);
        ArrowPos.GetComponent<Weapon>().Shoot();

        yield return new WaitForSeconds(1f);
        ArrowPos.GetComponent<Weapon>().Shoot();

        yield return new WaitForSeconds(1f);
        ArrowPos.GetComponent<Weapon>().Shoot();

        yield return new WaitForSeconds(5f);
        
        StartCoroutine(KillPlayer());
    }

    #endregion
}


