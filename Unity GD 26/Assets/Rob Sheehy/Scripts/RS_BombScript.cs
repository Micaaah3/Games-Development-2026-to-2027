using System;
using UnityEngine;

public class RS_BombScript : MonoBehaviour
{
    enum BombState { LockedToSlot, Dropping, Exploding}

    BombState isCurrently = BombState.LockedToSlot;

    Vector3 velocity, acceleration;
    float rotationRate = 360;
    internal void SetInitialVelocity(Vector3 StartingVelocity)
    {
        velocity = StartingVelocity;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(isCurrently)
        {
            case BombState.LockedToSlot:

                break;

                case BombState.Exploding:

                break;

            case BombState.Dropping:
                acceleration = new Vector3(0, -9.81f, 0);

                velocity += acceleration * Time.deltaTime;
                transform.position += velocity * Time.deltaTime;

                transform.Rotate(Vector3.forward, rotationRate * Time.deltaTime);

                break;

        }



    }

    internal void Drop(Vector3 velocityOfPlane)
    {
        isCurrently = BombState.Dropping;
        transform.parent = null;
        SetInitialVelocity(velocityOfPlane);
    }
}
