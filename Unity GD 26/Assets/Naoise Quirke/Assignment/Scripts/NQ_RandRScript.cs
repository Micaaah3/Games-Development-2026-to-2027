using UnityEngine;

public class NQ_RandRScript : MonoBehaviour
{   
//Bring fuel and ammo over.
//Find how to make the script detect the plane

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        Collider[] allObjects = Physics.OverlapBox(transform.position, new Vector3(5, 5, 5));
        print(allObjects.Length);
        foreach (Collider coll in allObjects)
        {
            I_Refuelable RefuelableObject = coll.gameObject.GetComponent<I_Refuelable>();
            if (RefuelableObject != null)
            {
                print("Found");
                RefuelableObject.takefuel(0.1f);
            }

            I_Rebombable RebombableObject = coll.gameObject.GetComponent<I_Rebombable>();
            if (RebombableObject != null)
            {
                print("Foundeder");
                RebombableObject.takebombtick(Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Hello");
    }
}
