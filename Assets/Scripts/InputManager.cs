using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction select;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        select = playerInput.Player.Select;
        select.Enable();
        select.performed += Select;
        
    }

    private void OnDisable()
    {
        select.Disable();
    }

    private void Select(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 rayOrigin = new Vector2(mousePosition.x, mousePosition.y);
            GameObject objectHit = Physics2D.Raycast(rayOrigin, Vector2.zero).collider.gameObject;

            if (objectHit)
            {
                if (objectHit.tag == "ForbiddenFruit")
                {
                    Application.Quit();
                }
                if (objectHit.tag == "Drink")
                {
                    Debug.Log("yayasdfasdf");
                }
            }
        }
    }
}
