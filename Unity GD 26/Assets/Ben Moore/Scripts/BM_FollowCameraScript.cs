using UnityEngine;

public class BM_FollowCameraScript : MonoBehaviour
{

    //public Transform thePlane; //public variable appears on script in unity editor, have to drag appropriate item from hierarchy to the slot in the inspector,
                               //not good for multiple objects or instantiated objects

    RS_PlaneControl thePlaneScript;
    Transform thePlane;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thePlaneScript = FindAnyObjectByType<RS_PlaneControl>();
        thePlane = thePlaneScript.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            thePlaneScript.TurnRed();
        }
        transform.position = Vector3.Lerp(transform.position, thePlane.transform.position - 10 * thePlane.forward + 2 * thePlane.up, 0.05f);

        transform.rotation = Quaternion.Slerp(transform.rotation, thePlane.rotation, 0.005f);

    }
}
