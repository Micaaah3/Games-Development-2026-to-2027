using System;
using UnityEngine;

public class RS_BombSlotScript : MonoBehaviour
{
    RS_PlaneControl theBoss;
    RS_BombScript theCurrentBomb;
    internal void IamTheBoss(RS_PlaneControl rS_PlaneControl)
    {
       theBoss = rS_PlaneControl;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initialize bomb at the slot; 
        InitializeBombAtSlot();
        
    }

    private void InitializeBombAtSlot()
    {
        GameObject newBombGO = Instantiate(theBoss.theBombCloneTemplate, transform.position, transform.rotation, transform);
        RS_BombScript theNewBombScript = newBombGO.GetComponent<RS_BombScript>();
        theNewBombScript.SetInitialVelocity(theBoss.velocity);
        theCurrentBomb = theNewBombScript;
    }

    // Update is called once per frame
    void Update()
    {
        // check if on cooldown, and if cooldown is over initialise bomb at the slot

    }




    internal void DroptheBomb()
    {
        // we drop the bomb
        theCurrentBomb.Drop(theBoss.velocity);
        // start a cooldown timer

    }
}
