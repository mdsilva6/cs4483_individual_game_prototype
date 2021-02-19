using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AgentMovement : MonoBehaviour
{

    CharacterController controller;
    Animator animator;
    public float rotationSpeed, gravity = 20f;
    public float movementSpeed = 2f;
    Vector3 movementVector = Vector3.zero;
    private float desiredRotationAngle = 0;

    private bool canWalk = true;

    public bool isMoving = false;

    // Start is called before the first frame update
    const float smoothTime = 0.1f;

    float turnSmoothVelocity;

    Transform cameraTransform;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        controller.enabled = true;
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.rotation.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

 
        if (movementVector.magnitude > 0)
        {
            var animationSpeedMultiplier = SetCorrectAnimation();
            RotateAgent();
            movementVector *= animationSpeedMultiplier;
            Debug.Log("Moving character");
        }
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * movementVector;
        controller.Move(movementVector * Time.deltaTime);
    }

    public void HandleMovement(Vector2 input)
    {
        if (Input.GetKey(KeyCode.W) && canWalk)
        {
            movementVector = cameraTransform.forward;
            transform.rotation = cameraTransform.rotation;
            float run = 0;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                run = 1;
            }
            animator.SetFloat("speedPercent", 1 + run);
            isMoving = true;
        }
        else
        {
            movementVector = Vector3.zero;
            animator.SetFloat("speedPercent", 0);
            isMoving = false;
        }
    }

    public void HandleMovementDirection(Vector3 direction)
    {
        desiredRotationAngle = Vector3.Angle(transform.forward, direction);
        var crossProduct = Vector3.Cross(transform.forward, direction).y;
        if (crossProduct < 0)
        {
            desiredRotationAngle *= -1;
        }
    }

    private void RotateAgent()
    {
        if(desiredRotationAngle > 10 || desiredRotationAngle < -10)
        {
            transform.Rotate(Vector3.up * desiredRotationAngle * rotationSpeed * Time.deltaTime);
        }
    }

    private float SetCorrectAnimation()
    {
        float currentAnimationSpeed = animator.GetFloat("speedPercent");
        if (currentAnimationSpeed != 0)
        {
            if (desiredRotationAngle > 10 || desiredRotationAngle < -10)
            {
                if (currentAnimationSpeed < 0.5f)
                {
                    currentAnimationSpeed += Time.deltaTime * 2;
                    currentAnimationSpeed = Mathf.Clamp(currentAnimationSpeed, 0, 0.5f);
                }
            }
            else
            {
                if (currentAnimationSpeed < 1)
                {
                    currentAnimationSpeed += Time.deltaTime * 2;
                }
                else
                {
                    currentAnimationSpeed = 1;
                }
            }
        }
        else
        {
            Debug.LogError("speedPercent is 0");
        }
        return currentAnimationSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject gameObject = other.gameObject;
        
        Debug.Log("We trigger hit " + gameObject.name);

        if (gameObject.tag == "Orb")
        {
            PickUpOrb(gameObject);
            gameObject.SetActive(false);
        }
     
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("collision detected");
    //    collision.collider.enabled = false;
    //}

    private void PickUpOrb(GameObject gameObject)
    {
        if (gameObject.name == "Orb")
        {
            animator.Play("Standing Taunt Battlecry");
        }
    }

}
