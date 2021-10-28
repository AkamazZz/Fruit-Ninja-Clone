using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 16;
        _rigidBody.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
