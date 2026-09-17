using UnityEngine;

public class CubeControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            print("Going up");
            transform.position += (new Vector3(0, 1, 0)) * Time.deltaTime;
        }
        else
        {
            print(" Going Down");
        }
    }
}
