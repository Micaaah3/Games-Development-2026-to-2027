using System;
using UnityEngine;

public class NQ_BombSlotScript : MonoBehaviour
{
    private NQ_PlaneControl theBoss;
    NQ_BombScript theCurrentBomb;

    internal void IamTheBoss(NQ_PlaneControl NQ_PlaneControl)
    {

      theBoss = NQ_PlaneControl;

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
        NQ_BombScript theNewBombScript = newBombGO.GetComponent<NQ_BombScript>();
        theNewBombScript.SetInitalVelocity(theBoss.velocity);
        theCurrentBomb = theNewBombScript;
    }

    // Update is called once per frame
    void Update()
    {
        //check if on cooldown, and if cooldown is ocer initialise bomb at the slot
    }

    internal void DroptheBomb()
    {
        theCurrentBomb.Drop(theBoss.velocity);
    }
}
