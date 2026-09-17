using UnityEngine;

public class BM_Script1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right, 5);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.left, 5);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, 5);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down, 5);
        }
    }
}
