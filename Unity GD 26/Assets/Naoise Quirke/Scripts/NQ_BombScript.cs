using System;
using UnityEngine;

public class NQ_BombScript : MonoBehaviour
{   
    enum BombSlate {  LockedToSlot, Dropping, Exploding}

    BombSlate isCurrently = BombSlate.LockedToSlot;

    private Vector3 velocity;
    private Vector3 acceleration;
    float rotationRate = 360;
    internal void SetInitalVelocity(Vector3 StartingVelocity)
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
            case BombSlate.LockedToSlot:

                break;

                case BombSlate.Exploding:

                break;

            case BombSlate.Dropping:
                acceleration = new Vector3(0, -9.18f, 0);
                velocity += acceleration * Time.deltaTime;
                transform.position += velocity * Time.deltaTime;

                transform.Rotate(transform.forward, rotationRate * Time.deltaTime);

                break;
        }

    }

    internal void Drop(Vector3 velocityOfPlane)
    {
        isCurrently = BombSlate.Dropping;
        transform.parent = null;
        SetInitalVelocity(velocityOfPlane);
    }
}
