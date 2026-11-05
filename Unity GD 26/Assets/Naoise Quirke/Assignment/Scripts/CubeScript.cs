using UnityEngine;

public class CubeScript : MonoBehaviour, I_Refuelable, I_Rebombable
{
    float currentFuel = 10;
    float maxCapacity = 100;
    float ticks = 1;
    int start = 0;
    int maxTick = 0;
    int ammo = 0;
    float maxAmmo = 4;

    public void takebombtick(float tickamount)
    {
        ticks += tickamount;
        print("Reloading");
        if (ticks >= 1 && ammo != 4)
        {
            ammo++;
            ticks = start;
            print("Bomb added");
        }
        if (ammo >= 4)
        {
            ticks = maxTick;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print("Fuel " + currentFuel.ToString());
        print("tick " + ticks.ToString());
    }
}
