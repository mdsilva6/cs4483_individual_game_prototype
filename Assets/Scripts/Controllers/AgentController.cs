using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour // used  https://www.youtube.com/watch?v=S2mK6KFdv0I&ab_channel=Brackeys as a guide
{
    IPlayerInput input;
    AgentMovement movement;
    NavMeshAgent agent;
    AgentAutoMove autoMove;

    Camera cam;

    public Interactable focus;

    private void Start()
    {
        cam = Camera.main;
        input = GetComponent<IPlayerInput>();
        movement = GetComponent<AgentMovement>();
        agent = GetComponent<NavMeshAgent>();
        autoMove = GetComponent<AgentAutoMove>();

        input.OnMovementDirectionInput += movement.HandleMovementDirection;
        input.OnMovementInput += movement.HandleMovement;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //autoMove.MoveToPoint(hit.point);

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable == GetFocus())
                {
                    UnsetFocus(interactable);
                } else if (interactable != null) {
                    SetFocus(interactable);
                    Debug.Log("Setting focus: " + hit.collider.name + " " + hit.point);
                }
            }
        }
    }

    Interactable GetFocus()
    {
        return focus;
    }

    void SetFocus(Interactable interactableObject)
    {
        focus = interactableObject;
        interactableObject.OnFocused(transform);
    }

    void UnsetFocus(Interactable interactableObject)
    {
        interactableObject.OnDefocused();
        focus = null;
    }
}
