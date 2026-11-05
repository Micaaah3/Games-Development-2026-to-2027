using System;
using UnityEngine;

public class NQ_PlaneControl : MonoBehaviour, NQ_IDamage, I_Rebombable, I_Refuelable
{
    float pitchingSpeed = 45f;  // Speed in degrees per second for pitching
    private float rollingSpeed = 45f;
    internal Vector3 velocity, acceleration;
    private float thrustValue = 20f;
    private float gravity = 0; //9.81f;
    float drag = 1;
    public GameObject theBombCloneTemplate;
    NQ_BombSlotScript[] bombSlot;
    float currentFuel = 20;
    float maxCapacity = 100;
    float ticks = 0;
    int start = 0;
    int maxTick = 0;
    int ammo = 4;
    float maxAmmo = 4;
    float fuelconsmptionrate = 1;

    int NextBombSlotIndex = 0;
    private float reloadTime = 5f;

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


        //acceleration += new Vector3(0, -simulatedGravity, 0);

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

            if (currentFuel > 0){
                acceleration += transform.forward * thrustValue;
                currentFuel -= fuelconsmptionrate * Time.deltaTime;
            }
            if (currentFuel < 0){
                    thrustValue = 0;
                }

        }

        acceleration += -drag * velocity;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (ammo >= 1)
            {
                ammo--;
                bombSlot[NextBombSlotIndex].DroptheBomb();

                NextBombSlotIndex = (NextBombSlotIndex + 1) % bombSlot.Length;

                if (NextBombSlotIndex == bombSlot.Length) NextBombSlotIndex = 0;
            }
        }

        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        //print("fuel" + currentFuel);
        //print("Fuel " + currentFuel.ToString());
        //print("tick " + ticks.ToString());
        print("ammo: " + ammo.ToString());
    }

    public void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }

    public void takebombtick(float tickamount)
    {
        ticks += tickamount;
    
        if (ticks >= reloadTime)
        {
            print("Reloading");
            allocateBomb();
            //NextBombSlotIndex--;
            //ticks = start;
            //print("Bomb added");
        }
        if (ammo >= 4)
        {
            ticks = maxTick;
        }
    }

    private void allocateBomb()
    {
        foreach (NQ_BombSlotScript bs in bombSlot)
        {
            if (bs.doyouneedbomb() )
            {
                ticks = start;
                ammo++;
                bs.instanceatebomb();
            }
        }
    }

    public void takefuel(float fuelamount)
    {
        currentFuel += fuelamount;
        print("Refueling");
        if (currentFuel >= 100)
        {
            currentFuel = maxCapacity;
        }
    }
}
