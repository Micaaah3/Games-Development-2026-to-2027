using System;
using UnityEngine;

public class RD_movementScript : MonoBehaviour
{
    private float pitchingSpeed = 45f;
    private float rollingSpeed = 45f;
    private float thrustValue = 30f;
    internal Vector3 velocity, acceleration;
    private float gravity = 9.81f;
    private float drag = 1;
    public GameObject theBombCloneTemplate;
    RD_bombSlotScript[] bombSlots;
    internal void TurnRed()
    {
        Renderer r = GetComponent<Renderer>();
        r.material.color = Color.red;
    }

    int dropBombSlotIndex = 0;

    private void Awake()
    {
        bombSlots = GetComponentsInChildren<RD_bombSlotScript>();

        for (int i = 0; i < bombSlots.Length; i++)
        {
            bombSlots[i].iAmTheBoss(this);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Vector3.zero;

        float simulatedGravity;

        if (velocity.magnitude < 10)
            simulatedGravity = 9.8f;
        else if (velocity.magnitude < 20)
            simulatedGravity = 4f;
        else simulatedGravity = 0;

        acceleration += new Vector3(0, -simulatedGravity, 0);

        // Movement

        // Pitch
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right, pitchingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.left, -pitchingSpeed * -Time.deltaTime);
        }
        // Pitch
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, rollingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward, -rollingSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            acceleration += transform.forward * thrustValue;
        }

        acceleration += -drag * velocity;

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Drop bomb
            bombSlots[dropBombSlotIndex].dropTheBomb();

            dropBombSlotIndex = (dropBombSlotIndex + 1) % bombSlots.Length;
        }
    }
}
