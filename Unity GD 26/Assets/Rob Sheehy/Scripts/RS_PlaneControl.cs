using System;
using UnityEngine;

public class RS_PlaneControl : MonoBehaviour, RS_IDamagable
{
    float pitchingSpeed = 45f;  // Speed in degrees per second for pitching
    private float rollingSpeed = 45f;
    internal Vector3 velocity, acceleration;
    private float thrustValue = 20f;
    private float gravity = 9.81f;
    float drag = 1;
    public GameObject theBombCloneTemplate;

    int NextBombSlotIndex = 0;

    RS_BombSlotScript[] bombSlots;

    internal void TurnRed()
    {

        Renderer r = GetComponentInChildren<Renderer>();

        r.material.color = Color.red;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {

        print("PLane Awake");

        bombSlots = GetComponentsInChildren<RS_BombSlotScript>();

        for (int i = 0; i < bombSlots.Length; i++)
        {
            bombSlots[i].IamTheBoss(this);
        }

    }


    void Start()
    {
        print("Plane Start");
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

        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Pitch
            transform.Rotate(Vector3.right, pitchingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Pitch
            transform.Rotate(Vector3.right, -pitchingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Pitch
            transform.Rotate(Vector3.forward, rollingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Pitch
            transform.Rotate(Vector3.forward, -rollingSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            acceleration += transform.forward * thrustValue;
        }

  
        acceleration += -drag* velocity;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Drop bomb
            bombSlots[NextBombSlotIndex].DroptheBomb();

            NextBombSlotIndex = (NextBombSlotIndex + 1) % bombSlots.Length;

            

        }
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;


    }

    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}
