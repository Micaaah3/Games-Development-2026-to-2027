using System;
using UnityEngine;

public class ME_PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float throttle;
    [SerializeField]
    private float engineLag = 1f;

    [SerializeField]
    private float xSensitivity = 20f;
    [SerializeField]
    private float ySensitivity = 20f;
    [SerializeField]
    private float zSensitivity = 20f;
    [SerializeField]
    private float _thrust = 2f;

    [SerializeField]
    private Vector3 _velocity;
    [SerializeField]
    private Vector3 _acceleration;

    private void Update()
    {
        //This function is where throttle is handled.
        HandleThrottle();

        //Gravity
        _acceleration += new Vector3(0,-9.8f, 0);


        Vector3 keyMovement = GetRotationMovement();

        transform.Rotate(keyMovement * Time.deltaTime);

        _velocity += _acceleration * Time.deltaTime;


        // Very basic drag simulation.
        _velocity = _velocity * 0.99f;

        transform.position += _velocity * Time.deltaTime;

    }
    
    private Vector3 GetRotationMovement()
    {
        Vector3 direction = new();
        if (Input.GetKey(KeyCode.W))
        {
            direction.x = 1 * xSensitivity;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.x = -1 * xSensitivity;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.z = 1 * zSensitivity;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.z = -1 * zSensitivity;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            direction.y = 1 * ySensitivity;
        }
        if (Input.GetKey(KeyCode.E))
        {
            direction.y = -1 * ySensitivity;
        }



        return direction;
    }


    private void HandleThrottle()
    {
        //set to zero
        _acceleration = Vector3.zero;

        if (Input.GetKey(KeyCode.R))
        {
            float newThrottle = Math.Max(0, Math.Min(throttle + 0.25f, 105));
            throttle = Mathf.Lerp(throttle, newThrottle, engineLag);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            float newThrottle = Math.Max(0, Math.Min(throttle - 0.25f, 105));
            throttle = Mathf.Lerp(throttle, newThrottle, engineLag);
        }

        _acceleration = transform.forward * _thrust * throttle;
    }
}
