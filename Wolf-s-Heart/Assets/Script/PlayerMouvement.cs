/**
*   @brief Déplacements du joueur
*/


using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 jumpForce;

    private bool isJumping;
    private bool isGrounded;
    public bool isAttacking = false;

/* zone qui détècte si en contact avec le sol */
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    
    public Rigidbody2D rb;
    public Animator animator;
    public Transform transformPlayer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    void Update()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

    /* envoi de la vitesse de déplacement à l'animateur */
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);
        horizontalMovement = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        
        Flip(horizontalMovement);
        MovePlayer(horizontalMovement);
    }

    /**
    *   @brief Déplacement du rigidBody
    *   @param _horizontalMovement : (float) Valeur de déplacement du joueur sur l'axe x
    */
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity,targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(jumpForce);
            isJumping = false;
        }
    }

    /**
    *   @brief Change l'orientation du graphisme du joueur en fonction de sa diraction de déplacement
    *   @param _dir : (float) Direction de déplacement du joueur sur l'axe x
    */
    void Flip(float _horizontalMovement)
    {
        if (_horizontalMovement < -0.1f)
        {
            transformPlayer.localScale = new Vector3(1, 1, 1);
        }
        else if (_horizontalMovement > 0.1f)
        {
            transformPlayer.localScale = new Vector3(-1, 1, 1);
        }
    }
/*#################################################################*/
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
/*#################################################################*/
}
