using UnityEngine;

public class RD_followCameraScript : MonoBehaviour
{
    //Method1
    //public Transform thePlane;          //Public variable appears on script in unity editor, have to drag appropriate item from hierarchy to the slot in the inspector.
                                        //Not good for multiple objects or instantiated 
    //Method 2
    RD_movementScript thePlaneScript;
    Transform thePlane;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thePlaneScript = FindAnyObjectByType<RD_movementScript>();
        thePlane = thePlaneScript.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            thePlaneScript.TurnRed();
        }

        transform.position = Vector3.Lerp(transform.position, thePlane.transform.position - 15 * thePlane.forward + 4 * thePlane.up, 0.015f);

        transform.rotation = Quaternion.Slerp(transform.rotation, thePlane.rotation, 0.015f);

    }
}
