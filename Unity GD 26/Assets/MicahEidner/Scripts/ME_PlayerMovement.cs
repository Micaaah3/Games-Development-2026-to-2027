using System;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class ME_PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Gradient throttleSpeedSlope;

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
    [SerializeField]
    private Vector3 _direction;

    private void Update()
    {
        //This function is where throttle is handled.
        HandleThrottle();

        //Gravity
        _acceleration += new Vector3(0,-9.81f, 0);


        Vector3 keyMovement = GetRotationMovement();

        transform.Rotate(keyMovement * Time.deltaTime);

        _velocity += _acceleration * Time.deltaTime;


        // Very basic drag simulation.
        _velocity = _velocity * 0.97f;

        transform.position += _velocity * Time.deltaTime;

    }
    
    private Vector3 GetRotationMovement()
    {
        _direction = BringAxisToZero(_direction);
        if (Input.GetKey(KeyCode.W))
        {
            _direction.x = Mathf.Lerp(_direction.x, 1 * xSensitivity, 0.01f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _direction.x = Mathf.Lerp(_direction.x, - 1 * xSensitivity, 0.01f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _direction.z = Mathf.Lerp(_direction.z, 1 * zSensitivity, 0.01f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction.z = Mathf.Lerp(_direction.z, -1 * zSensitivity, 0.01f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            _direction.y = Mathf.Lerp(_direction.y, 1 * ySensitivity, 0.01f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            _direction.y = Mathf.Lerp(_direction.y, -1 * ySensitivity, 0.01f);
        }



        return _direction;
    }

    private Vector3 BringAxisToZero(Vector3 axes)
    {
        float xAxis = Mathf.Lerp(axes.x, 0, 0.002f);
        float yAxis = Mathf.Lerp(axes.y, 0, 0.005f);
        float zAxis = Mathf.Lerp(axes.z, 0, 0.005f);

        return new Vector3(xAxis,yAxis,zAxis);
    }


    private void HandleThrottle()
    {
        //set to zero
        _acceleration = new Vector3();

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

        Color speed = throttleSpeedSlope.Evaluate(throttle / 100);

        _acceleration = (transform.forward * _thrust * (speed.a*20)) + (_acceleration * (0.8f - Time.deltaTime * 10));
    }
}
