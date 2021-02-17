using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AgentMovement : MonoBehaviour
{

    CharacterController controller;
    Animator animator;
    public float rotationSpeed, movementSpeed, gravity = 20;
    Vector3 movementVector = Vector3.zero;
    private float desiredRotationAngle = 0;

    private bool canWalk = true;

    public bool isMoving = false;

        // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float rotation = Input.GetAxis("Horizontal") * 1.0f;
        transform.Rotate(0, rotation, 0);

        if (movementVector.magnitude > 0)
        {
            var animationSpeedMultiplier = SetCorrectAnimation();
            RotateAgent();
            movementVector *= animationSpeedMultiplier;
        }
        controller.Move(movementVector * Time.deltaTime);
    }

    public void HandleMovement(Vector2 input)
    {
        if (Input.GetKey(KeyCode.W) && canWalk)
        {
            movementVector = transform.forward * movementSpeed;
            float run = 0;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                run = 1;
            }
            animator.SetFloat("forward", 1 + run);
            isMoving = true;
        }
        else
        {
            movementVector = Vector3.zero;
            animator.SetFloat("forward", 0);
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
        float currentAnimationSpeed = animator.GetFloat("forward");
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision detected");
        collision.collider.enabled = false;
    }

    private void PickUpOrb(GameObject gameObject)
    {
        if (gameObject.name == "Orb")
        {
            animator.Play("Standing Taunt Battlecry");
        }
    }

}
