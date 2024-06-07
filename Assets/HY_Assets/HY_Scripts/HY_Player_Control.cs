using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HY_Player_Control : MonoBehaviour
{
    [SerializeField]
    Joystick joystick;// JoyStick Refrence Given in the canvas.
    [SerializeField]
    Rigidbody rb;//Player Rigdbody
    Button btn;
    Vector3 move;
    [SerializeField]
    float moveSpeed = 10f, force = 7f, defaultSpeed = 0.97f, onSliderSpeed = 2.0f,
        waitForSec = 0.5f;//Jump Force
    [SerializeField]
    Animator animator;
    [SerializeField]
    bool isGrounded, isDashing;
    [SerializeField]
    Transform cam;
    bool jumpbtnPressed = false;
    [SerializeField]
    Transform spawnPoint, firstSp, secondSp, thirdSp, fourthSp;
    [SerializeField]
    bool inAir;
    [SerializeField]
    GameObject effect;

    //[SerializeField]
    //float lastTapTime = 0f, doubleTapThreshold = 0.3f;
    [SerializeField]
    float dashDuration = 0.5f, dashSpeed = 10f;
    Vector3 playerScale;
    [SerializeField]
    float scale = 0.75f;
    public bool canControl = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
        animator = GetComponent<Animator>();
        spawnPoint = firstSp;
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
        }
        playerScale = new Vector3(scale, scale, scale);
        transform.localScale = playerScale;


    }
    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        CanAniamte();

        if (canControl == true)
        {
            PlayerMovement();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MobileJumpBtn();
            }
        }


    }
    void HangingAnimation()
    {
        if (!isGrounded && inAir && !isDashing)
        {
            animator.SetBool("Hanging", true);
        }
    }// hanging animation true..
    [System.Obsolete]
    public void PlayerMovement()
    {
        move = cam.transform.right * joystick.Horizontal +
               cam.transform.forward * joystick.Vertical;
        move.y = 0f;
        if (rb != null)
            rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);
        if (move.magnitude != 0)
        {
            Rotate();
        }

    }// joy stick movment.
    public void MobileJumpBtn()
    {
        if (isGrounded && !jumpbtnPressed)
        {
            animator.SetBool("Jump", true);
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            isGrounded = false;
            inAir = true;
            jumpbtnPressed = true;
            StartCoroutine(JumpUp());
        }
    }
    public IEnumerator JumpUp()
    {
        yield return new WaitForSeconds(.2f);
        animator.SetBool("Jump", false);
        animator.SetBool("Hanging", true);
        //rb.AddForce(Vector3.up * (-gravity), ForceMode.Impulse);
    }
    IEnumerator Dash()
    {
        //dash animation.
        animator.SetBool("Dash", true);
        isDashing = true;
        float timer = 0;
        while (timer < dashDuration)
        {
            rb.MovePosition(Vector3.forward * dashSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            print("Dash Animation called");
            yield return null;
        }
        isDashing = false;
        //dash animation stop
        animator.SetBool("Dash", false);
    }//dash animation....//Not in use yet...............
    public void CanAniamte()
    {

        if (move.magnitude != 0 && isGrounded)
        {
            animator.SetFloat("Run", move.magnitude);
        }
        else
        {
            animator.SetFloat("Run", 0);
        }

    }
    [System.Obsolete]
    public void Rotate()
    {
        Quaternion rot = Quaternion.LookRotation(move, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot,
            720f * Time.deltaTime);
    }
    [System.Obsolete]
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground" || collision.transform.tag == "LeftMover" ||
            collision.transform.tag == "RightMover" ||
            collision.transform.tag == "Water")
        {

            animator.SetBool("Hanging", false);

            isGrounded = true;
            jumpbtnPressed = false;
            inAir = false;
            moveSpeed = defaultSpeed;
            animator.SetBool("Dash", false);
            isDashing = false;
        }
        if (collision.transform.tag == "Slider")
        {
            moveSpeed = onSliderSpeed;
            isDashing = true;
            animator.SetBool("Jump", false);
            animator.SetBool("Dash", true);
            animator.SetTrigger("Dashing");
            animator.SetBool("Hanging", false);
            isGrounded = true;
            jumpbtnPressed = false;
            inAir = false;

        }
        if (collision.transform.tag == "Water")
        {
            // gameObject.SetActive(false
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 500f);
            Instantiate(effect, transform.position, Quaternion.EulerRotation(90, 0, 0));
            rb.isKinematic = true;
            StartCoroutine(SpawnWait());
            // transform.position = spawnPoint.position;
        }
       
    }


    IEnumerator SpawnWait()
    {
        yield return new WaitForSeconds(waitForSec);
        transform.localScale = Vector3.Lerp(Vector3.zero, playerScale, 500f);
        rb.isKinematic = false;
        transform.position = spawnPoint.position;
        transform.rotation = spawnPoint.localRotation;

    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "FirstSp":
                spawnPoint = firstSp;
                break;
            case "SecondSp":
                spawnPoint = secondSp;
                break;
            case "ThirdSp":
                spawnPoint = thirdSp;
                break;
            case "FourthSp":
                spawnPoint = fourthSp;
                break;
        }

    }
}
