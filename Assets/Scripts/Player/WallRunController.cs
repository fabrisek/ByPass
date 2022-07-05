using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunController : MonoBehaviour
{
    public static WallRunController Instance;
    [Header("Wallrunning")]
    public LayerMask whatIsWall;
    public LayerMask whatIsGround;
    public float wallRunForce;
    public float wallJumpUpForce;
    public float wallJumpSideForce;
    public float wallClimbSpeed;
    public float maxWallRunTime;
    private float wallRunTimer;
    private float timerFoostep;

    [Header("CameraEffects")]
    [SerializeField] float tilt;

    [Header("Input")]
    private bool upwardsRunning;
    private bool downwardsRunning;
    private float horizontalInput;
    private float verticalInput;

    [Header("Detection")]
    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit leftWallhit;
    private RaycastHit rightWallhit;
    private bool wallLeft;
    private bool wallRight;

    [Header("Exiting")]
    private bool exitingWall;
    public bool GetExitingWall()
    {
        return exitingWall;
    }

    public float exitWallTime;
    private float exitWallTimer;

    [Header("Gravity")]
    public bool useGravity;
    public float gravityCounterForce;

    [Header("References")]
    public Transform orientation;
    public PlayerCam cam;
    private PlayerController playerController;
    private Rigidbody rb;


    //bug doublejumpwall
    float timerDouble = 0.3f;
    bool stopWallRun;

    static Input input;


    // LOOPS AND FUNCTIONS///////////////////////////////////////////////////////////////////
    private void Awake()
    {
        Instance = this;
        input = new Input();


    }

    private void OnEnable()
    {
        input.Enable();
        input.InGame.Jump.performed += context => WallJump();
    }
    private void OnDisable()
    {
        input.Disable();
        input.InGame.Jump.performed += context => WallJump();
    }


    //get inputs


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        timerFoostep = 0f;
    }

    private void Update()
    {
        CheckForWall();
        StateMachine();

        timerDouble -= Time.deltaTime;
        if (timerDouble < 0 && stopWallRun)
        {
            stopWallRun = false;
            playerController.SetCanDoubleJump(true);
        }


    }

    private void FixedUpdate()
    {
        if (playerController.wallrunning)
            WallRunningMovement();
    }

    private void CheckForWall()
    {
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallhit, wallCheckDistance, whatIsWall);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallhit, wallCheckDistance, whatIsWall);
    }

    private bool AboveGround()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, whatIsGround);
    }

    private void StateMachine()
    {
        // Getting Inputs
        horizontalInput = playerController.GetHorizontalInput();
        verticalInput = playerController.GetVerticalInput();

        // State 1 - Wallrunning
        if ((wallLeft || wallRight) && verticalInput > 0 && AboveGround() && !exitingWall)
        {
            if (!playerController.wallrunning)
                StartWallRun();

            // wallrun timer
            if (wallRunTimer > 0)
            {
                wallRunTimer -= Time.deltaTime;
            }

            if (wallRunTimer <= 0 && playerController.wallrunning)
            {
                exitingWall = true;
                exitWallTimer = exitWallTime;
            }

        }

        // State 2 - Exiting
        else if (exitingWall)
        {
            if (playerController.wallrunning)
                StopWallRun();

            if (exitWallTimer > 0)
                exitWallTimer -= Time.deltaTime;

            if (exitWallTimer <= 0)
                exitingWall = false;
        }

        // State 3 - None
        else
        {
            if (playerController.wallrunning)
                StopWallRun();
        }

    }

    private void StartWallRun()
    {
        playerController.wallrunning = true;
        wallRunTimer = maxWallRunTime;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // apply camera effects
        if (wallLeft) cam.DoTilt(-tilt);
        if (wallRight) cam.DoTilt(tilt);

    }

    private void WallRunningMovement()
    {
        rb.useGravity = useGravity;

        Vector3 wallNormal = wallRight ? rightWallhit.normal : leftWallhit.normal;

        Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);

        if ((orientation.forward - wallForward).magnitude > (orientation.forward - -wallForward).magnitude)
            wallForward = -wallForward;

        // forward force
        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);

        // upwards/downwards force
        if (upwardsRunning)
            rb.velocity = new Vector3(rb.velocity.x, wallClimbSpeed, rb.velocity.z);
        if (downwardsRunning)
            rb.velocity = new Vector3(rb.velocity.x, -wallClimbSpeed, rb.velocity.z);

        // push to wall force
        if (!(wallLeft && horizontalInput > 0) && !(wallRight && horizontalInput < 0))
            rb.AddForce(-wallNormal * 100, ForceMode.Force);

        // weaken gravity
        if (useGravity)
            rb.AddForce(transform.up * gravityCounterForce, ForceMode.Force);
    }

    private void StopWallRun()
    {
        playerController.wallrunning = false;

        // reset camera effects
        cam.DoTilt(0f);

        timerDouble = 0.3f;
        stopWallRun = true;
    }

    public void WallJump()
    {
        if (playerController != null)
        {
            if (playerController.wallrunning)
            {
                playerController.PlayerJumpDown(false);
                playerController.SetCanDoubleJump(false);
                // enter exiting wall state
                exitingWall = true;
                exitWallTimer = exitWallTime;

                Vector3 wallNormal = wallRight ? rightWallhit.normal : leftWallhit.normal;

                Vector3 forceToApply = transform.up * wallJumpUpForce + wallNormal * wallJumpSideForce;

                // reset y velocity and add force
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(forceToApply, ForceMode.VelocityChange);

            }
        }
    }
}
