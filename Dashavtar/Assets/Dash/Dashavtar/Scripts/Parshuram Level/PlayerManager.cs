using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region variables

    [Header("Player Properties")]
    public float runSpeed;
    public float jumpForce;
    public int amountofJumps = 1;
    public int health = 100;
    public bool isGuarded = false;

    [Header("Ground Check Variables")]
    public Transform feetpos;
    public float localradius;
    public LayerMask whatisGround;

    [Header("Misc Variables")]
    public Joystick joystick;
    public Transform Checkpoint;

    [Header("Player Animations")]
    public GameObject idle_Parshuram;
    public GameObject run_Parshuram;

    public Animator anim;

    private Rigidbody2D rb;
    private float moveInputHorz;
    private bool isFacingRight = true;
    private bool isGrounded;
    private bool canJump;
    //private bool canDoublejump = false;
    private int amountOfJumpsLeft;



    #endregion



    #region Functions

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();               //reference to the rigidbody2d
        amountOfJumpsLeft = amountofJumps;

        
    }

    #region Unity Methods
    private void Update()
    {
        CheckMovementUsingJoystick();

        //to flip character based on input controls
        CheckMovementDirection();

        //parshuram level animations
        ParshuramLevel();


        CheckSurroundings();

        if(health == 0)
        {
            SceneManager.LoadScene("ParshuramLevel");
            Destroy(transform.parent.gameObject);
		}

    }

    

    private void FixedUpdate()
    {
        ApplyMovement();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name =="Death")
        {
            transform.position = Checkpoint.position;
        }
    }
    #endregion

    #region CallBack methods

    private void CheckMovementUsingJoystick()
    {
        if (joystick.Horizontal >= 0.5f)             //keeping the threshold of the joystick movement
        {
            moveInputHorz = runSpeed;
        }
        else if(joystick.Horizontal <= -0.5f)
        {
            moveInputHorz = -runSpeed;
        }
        else
            moveInputHorz = 0f;
    }

    private void ApplyMovement()
    {

        rb.velocity = new Vector2(moveInputHorz, rb.velocity.y);
    }

    void CheckMovementDirection()
    {
        if (isFacingRight && moveInputHorz < 0)
        {
            Flip();
        }

        else if (!isFacingRight && moveInputHorz > 0)
        {
            Flip();
        }

    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180f, 0);
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(feetpos.position, localradius, whatisGround);

        CheckifCanJump();
    }

    private void CheckifCanJump()
    {
        if (isGrounded & rb.velocity.y <=0)
        {
            amountOfJumpsLeft = amountofJumps;
        }

        if (amountOfJumpsLeft <= 0)
        {
            canJump = false;

        }
        else
        {
            canJump = true;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                anim.SetBool("isJump",true);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                anim.SetBool("isJump",false);
            }
               
        }
            
    }

    public void Jump()
    {

        if(canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpsLeft--;
        }

    }

    void ParshuramLevel()
    {
        if (moveInputHorz == 0)
        {
            idle_Parshuram.SetActive(true);
            run_Parshuram.SetActive(false);
        }

        if (moveInputHorz > 0 || moveInputHorz < 0)
        {
            idle_Parshuram.SetActive(false);
            run_Parshuram.SetActive(true);
        }

    }

    #endregion


    #endregion
}
