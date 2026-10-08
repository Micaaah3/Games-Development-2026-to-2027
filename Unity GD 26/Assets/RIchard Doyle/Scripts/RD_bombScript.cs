using System;
using UnityEngine;

public class RD_bombScript : MonoBehaviour
{
    enum bombState {lockedToSlot, dropping, exploding}

    bombState isCurrently = bombState.lockedToSlot;

    Vector3 velocity, acceleration;
    float rotationRate = 360;

    internal void setInitialVelocity(Vector3 startingVelocity)
    {
        velocity = startingVelocity;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (isCurrently)
        {
            case bombState.lockedToSlot:

                break;

            case bombState.exploding:

                break;

            case bombState.dropping:

                acceleration = new Vector3(0, -9.81f, 0);

                velocity += acceleration * Time.deltaTime;
                transform.position += velocity * Time.deltaTime;

                transform.Rotate(Vector3.forward, rotationRate * Time.deltaTime);

                break;

        }
    }

    internal void Drop(Vector3 velocityOfPlane)
    {
        isCurrently = bombState.dropping;
        transform.parent = null;
        setInitialVelocity(velocityOfPlane);
    }
}
