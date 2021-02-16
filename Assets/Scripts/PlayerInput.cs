using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

// for the creation of this script I follow this tutorial: https://www.youtube.com/watch?v=Sg0Z09HpU_s&list=PLcRSafycjWFfVVUJvqlYT1nBZJodZuaa0&ab_channel=SunnyValleyStudio
public class PlayerInput : MonoBehaviour, IPlayerInput
{
    public Action<Vector2> OnMovementInput { get; set; }
    public Action<Vector3> OnMovementDirectionInput { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log("Hello there.");
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        GetMovementDirection();
    }

    private void GetMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 input = new Vector2(horizontal, vertical);
        OnMovementInput?.Invoke(input);
    }

    private void GetMovementDirection()
    {
        var cameraForwardDirection = Camera.main.transform.forward;
        var movementDirection = Vector3.Scale(cameraForwardDirection, (Vector3.right + Vector3.forward));
        OnMovementDirectionInput?.Invoke(movementDirection);
    }

}
