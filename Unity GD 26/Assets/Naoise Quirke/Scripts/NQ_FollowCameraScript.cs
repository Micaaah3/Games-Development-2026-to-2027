using UnityEngine;

public class NQ_FollowCameraScript : MonoBehaviour
{
    //Method 1
    //public Transform thePlane; //Public variable appears on script in unity editor, have to drag appropriate item for heirarchy to the slot in the inspector,
                               //not good for multiple or instantiated objects

    //Method 2

    NQ_PlaneControl thePlaneScript; // An empty container for the plane script on the live plane
    Transform thePlane;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thePlaneScript = FindAnyObjectByType<NQ_PlaneControl>();
        thePlane = thePlaneScript.transform;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.R))
        {
            thePlaneScript.TurnRed();
        }

        transform.position = Vector3.Lerp(transform.position, thePlane.transform.position - 10 * thePlane.forward + 2 * thePlane.up, 0.05F);

        transform.rotation = Quaternion.Slerp(transform.rotation, thePlane.rotation, 0.05F);
    }
}
