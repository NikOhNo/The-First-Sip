using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObj : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 offset;    // Offset between the object's position and the mouse position
    Rigidbody2D rigidbody2D;

    protected virtual void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        offset = transform.position - mouseWorldPosition; // Calculate offset
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        transform.position = mouseWorldPosition + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rigidbody2D.velocity = Vector2.ClampMagnitude(eventData.delta, 20f);
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get mouse position in screen space and convert to world space
        Vector3 screenMousePosition = Input.mousePosition;

        // Ensure z-axis matches the object's current position for correct 2D plane conversion
        screenMousePosition.z = 0;
        return Camera.main.ScreenToWorldPoint(screenMousePosition);
    }
}
