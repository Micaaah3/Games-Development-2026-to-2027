using System;
using UnityEngine;

public class RD_bombSlotScript : MonoBehaviour
{
    RD_movementScript theBoss;

    RD_bombScript theCurrentBomb;
    internal void iAmTheBoss(RD_movementScript rD_movementScript)
    {
        theBoss = rD_movementScript;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeBombAtSlot();
    }

    private void InitializeBombAtSlot()
    {
        GameObject newBombGO = Instantiate(theBoss.theBombCloneTemplate, transform.position, transform.rotation, transform);
        RD_bombScript theNewBombScript = newBombGO.GetComponent<RD_bombScript>();
        theNewBombScript.setInitialVelocity(theBoss.velocity);
        theCurrentBomb = theNewBombScript;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void dropTheBomb()
    {
        theCurrentBomb.Drop(theBoss.velocity);
    }
}
