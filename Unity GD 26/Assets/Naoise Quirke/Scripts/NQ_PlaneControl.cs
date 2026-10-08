using UnityEngine;

public class NQ_PlaneControl : MonoBehaviour, NQ_IDamage
{
    float pitchingSpeed = 45f;  // Speed in degrees per second for pitching
    private float rollingSpeed = 45f;
    internal Vector3 velocity, acceleration;
    private float thrustValue = 20f;
    private float gravity = 9.81f;
    float drag = 1;
    public GameObject theBombCloneTemplate;
    NQ_BombSlotScript[] bombSlot;
    int fuel = 100;
    int ammo = 4;

    int NextBombSlotIndex = 0;

    internal void TurnRed()
    {

        Renderer r = GetComponentInChildren<Renderer>();

        r.material.color = Color.red;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        bombSlot = GetComponentsInChildren<NQ_BombSlotScript>();

        for (int i = 0; i < bombSlot.Length; i++)
        {
            bombSlot[i].IamTheBoss(this);

        }
    }
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
            fuel -= 1; //Figure out how to make it go down for every second.
        }

        acceleration += -drag * velocity;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ammo -= 1;
            bombSlot[NextBombSlotIndex].DroptheBomb();

            NextBombSlotIndex = (NextBombSlotIndex + 1) % bombSlot.Length;

            if (NextBombSlotIndex == bombSlot.Length) NextBombSlotIndex = 0;

        }

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }
}
