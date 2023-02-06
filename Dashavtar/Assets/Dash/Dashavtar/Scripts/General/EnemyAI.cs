using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    #region VARIABLES


    public Transform enemyCenter;
    public Transform enemyLeft;
    public Transform enemyRight;
    public Transform enemyVision;

    public bool moveLeft = false;
    public bool moveRight = false;
    public bool atCenter = true;

    public static bool playerFound = false;

    public float enemySpeed = 10f;
    public float health = 100f;

    public Animator enemyAnimation;

    public Transform player;

    #endregion

    #region METHODS


    void Update()
    {

       
        if (!playerFound)
        {
            

            if (atCenter)
            {
                enemyAnimation.SetBool("isRunning",true);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(enemyLeft.position.x, transform.position.y), enemySpeed / 2 * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);

            }

            if (moveRight)
            {
                enemyAnimation.SetBool("isRunning",true);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(enemyRight.position.x, transform.position.y), enemySpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }


            if (moveLeft)
            {
                enemyAnimation.SetBool("isRunning",true);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(enemyLeft.position.x, transform.position.y), enemySpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }



            if (transform.position.x <= enemyLeft.position.x)
            {
                atCenter = false;
                moveRight = true;
                moveLeft = false;
            }

            if (transform.position.x >= enemyRight.position.x)
            {
                moveRight = false;
                moveLeft = true;
            }

            if (player.transform.position.x - transform.position.x <=0.1f)
            {
                Debug.Log("hellow");
            }
            
            
        }

        

    }


    void Die()
    {
        Destroy(transform.parent.gameObject);
        EnemyAI.playerFound = false;
    }

    void TakeDamage(float damageRate)
    {   
        if(health > 0)
            health -= damageRate;

        if (health <= 0)
            Die();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            TakeDamage(20);
            Destroy(collision.gameObject);
        }
    }


    #endregion


}




