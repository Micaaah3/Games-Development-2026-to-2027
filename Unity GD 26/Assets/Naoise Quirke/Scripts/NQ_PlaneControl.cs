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
    float currentFuel = 20; //Fuel it has when it starts
    float maxCapacity = 100; //Maximum fuel it can have.
    float ticks = 0; //counter basically, once it reaches 1, the ammo is distrabuted to the plane if its in the fueling area long enough.
    int start = 0; //might be reduent because maxTick probably does the same thing. sets tick to 0.
    int maxTick = 0; //sets tick to 0.
    int ammo = 4; // how much ammo the plane currently has.
    float maxAmmo = 4; //not used, but could be in the future for if the plane can carry more then it current has.
    float fuelconsmptionrate = 1; //The rate at which the fuel is consumed. Is that right? I can't spell.

    int NextBombSlotIndex = 0; //what the next bombslot is so the plane knows where to put the bombs its given by the R&R zone.
    private float reloadTime = 5f; //How fast the plane reloads.

    internal void TurnRed()
    {

        Renderer r = GetComponentInChildren<Renderer>();

        r.material.color = Color.red;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        bombSlot = GetComponentsInChildren<NQ_BombSlotScript>(); //Gets the 

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
            // Roll
            transform.Rotate(Vector3.forward, rollingSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Roll
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
            //Basically if the plane moves forward, then fuel is consumed. If there is no fuel, it cannot move.

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
            } //If the plane has at least one bomb left, it will select the next bomb to drop when you hit return.
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
        ticks += tickamount; //tick increases by the amount it should every second.
    
        if (ticks >= reloadTime)
        {
            print("Reloading");
            allocateBomb();
            //If the ticks have reached the same about as reloadTime, then the R&R zone allocates a bomb to the plane and annonces it. 

            //NextBombSlotIndex--;
            //ticks = start;
            //print("Bomb added");
        }
        if (ammo >= 4)
        {
            ticks = maxTick; //if the ammo is at the max it should go, (This is where max ammo would go), then it ticks will no longer increase until there is less than it should.
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
