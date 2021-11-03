using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private float _minVelocity = 0.1f;
    private Rigidbody _rigidBody;
    private Vector3 _lastMousePosition;
    private Vector3 _mouseVecocity;
    private Collider _collider;
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetBladeToMouse();
        OnChangeCollider();
    }

    private void SetBladeToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z =16;
        _rigidBody.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
    private Vector3 GetCurrentMousePosition()
    {
        return transform.position;
    }
    private bool isMouseMoving()
    {
        Vector3 curPosition = GetCurrentMousePosition();
        float travelLenght = (_lastMousePosition - curPosition).magnitude;
        _lastMousePosition = curPosition;
        if(travelLenght > _minVelocity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void OnChangeCollider()
    {
        _collider.enabled = isMouseMoving();
    }
}
