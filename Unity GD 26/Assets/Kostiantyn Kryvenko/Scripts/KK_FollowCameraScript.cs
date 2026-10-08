using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class KK_FollowCameraScript : MonoBehaviour
{
    // Method 1
    public Transform thePlane;

    // Method 2
    KK_MoveScript thePlaneScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         thePlaneScript = FindAnyObjectByType< KK_MoveScript >();
         thePlane = thePlaneScript.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            thePlaneScript.TurnRed();
        }
        transform.position = Vector3.Lerp(transform.position, thePlane.transform.position - 15 * thePlane.forward + 5 * thePlane.transform.up, 0.05f);
        transform.rotation = Quaternion.Slerp(transform.rotation, thePlane.transform.rotation, 0.05f);

    }
}
