using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
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
                Debug.Log("Hit " + hit.collider.name + " " + hit.point);
                //autoMove.MoveToPoint(hit.point);

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable == GetFocus())
                {
                    UnsetFocus(interactable);
                } else if (interactable != null) {
                    SetFocus(interactable);
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
