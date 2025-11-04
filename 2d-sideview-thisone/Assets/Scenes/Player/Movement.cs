using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hur snabbt v�r karakt�r f�r r�ra sig
    public float jumpForce = 5f; // Vilken force hopp knappen kan g�ra
    public Transform groundCheck; // Kolla om spelaren har r�rt vid marken
    public float groundCheckRadius = 0.2f; // Inom vilken radie kan vi r�ra marken
    public LayerMask groundLayer; // Vilket lager har marken
    private bool isFacingRight = true; // Kolla vilket h�ll karakt�ren tittar i
    private bool isGrounded = false; // Om vi �r p� marken eller inte
    private Rigidbody2D rb; // Ref till v�r rigidbody2D
    private Animator animator; // Ref till vår animator
    private bool isSprinting;
    private float moveSpeedConstant = 5;
    [SerializeField] float sprintMultiplier = 1.5f;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // H�mta v�r Rigidbody 2D
        animator = GetComponent<Animator>(); // Hämta vår Animator
    }
    private void Update()
    {


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Kolla om spelaren �r p� marken
        float moveDirection = Input.GetAxis("Horizontal");  // Kolla om vi r�r oss horisontellt
        Move(moveDirection); // Flytta spelaren
        Sprinting();
        if (moveDirection > 0 && !isFacingRight) // Flippa spelaren s� den tittar i den riktningen som den r�r sig i
        {
            Flip();
        }
        else if (moveDirection < 0 && isFacingRight) // Flippa spelaren s� den tittar i den riktningen som den r�r sig i
        {
            Flip();
        }
        if (Input.GetButtonDown("Jump") && isGrounded) // Om vi tycker p� space, s� l�t spelaren hoppa
        {
            Jump();
        }
        animator.SetBool("Jump", !isGrounded);



    }

    private void Sprinting()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            print("spring!");
        }
        else
        {
            isSprinting = false;
        }

        if (isSprinting == true)
        {
            moveSpeed = sprintMultiplier * moveSpeedConstant;
        }
        else if (isSprinting == false)
        {
            moveSpeed = moveSpeedConstant;
        }
    }

    private void Move(float direction)
    {
        Vector2 movement = new Vector2(direction * moveSpeed, rb.linearVelocity.y); // r�kna ut hur vi r�r oss i relation till spelarens velocity
        rb.linearVelocity = movement;
        float absoluteSpeed = Mathf.Abs(direction * moveSpeed);
        animator.SetFloat("Speed", absoluteSpeed); // Använd Speed parametern i animatorn




    }
    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // L�gg till vertical force f�r att kunna hoppa
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;  // Flippa player spriten horisontellt
        transform.Rotate(0f, 180f, 0f);
    }

}
