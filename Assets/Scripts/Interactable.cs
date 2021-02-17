using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 3.0f;

    public Transform player;

    bool isFocus = false;

    public bool isInteracting = false;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }


    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log(gameObject.name + " loaded");
    }

    // Update is called once per frame
    public void Update()
    {
        if (isFocus)
        {
            float distance = Vector3.Distance(player.position, gameObject.transform.position);
            if (distance <= radius)
            {
                if (!isInteracting)
                {
                    Interact();
                    isInteracting = true;
                }
            }
            else
            {
                isInteracting = false;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        isInteracting = false;
    }
}
