using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float sidedistance = 3f;
    public float jumpForce = 5f;
    public float sideSpeed = 1f;
    public float gravity = 9.81f;
    public bool isjumping = false;
    private int currentLane = 1; // 0 for left, 1 for middle, 2 for right
    private float verticalVelocity = 0f;
    private float groundY;
    private float startX;
    public ParticleSystem MovementLines;

    

    void Start()
    {
        groundY = transform.position.y;
        startX = transform.position.x;
    }
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
        HandleJump();
        HandleslideMovement();
    }
    public void MoveLeft()
    {
        if (currentLane > 0)
        {
            currentLane--;
            GetComponent<Animator>().SetTrigger("Left");
            MovementLines.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
            MovementLines.Play();

        }
    }
    public void MoveRight()
    {
        if (currentLane < 2)
        {
            currentLane++;
            GetComponent<Animator>().SetTrigger("Right");

            MovementLines.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
            MovementLines.Play();
        }
    }
    public void Jump()
    {
        if (isjumping) return;

        verticalVelocity = jumpForce;
        isjumping = true;
        GetComponent<Animator>().SetBool("Jump" , true);
        MovementLines.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
    }
    void HandleslideMovement()
    {
        float targetX = startX + (currentLane -1) * sidedistance;
        float newX = Mathf.MoveTowards(transform.position.x, targetX, sideSpeed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
    void HandleJump()
    {
        verticalVelocity -= gravity * Time.deltaTime;
        float newY = transform.position.y + verticalVelocity * Time.deltaTime;
        if (newY <= groundY)
        {
            newY = groundY;
            verticalVelocity = 0f;
            isjumping = false;
            GetComponent<Animator>().SetBool("Jump", false);

        }
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
