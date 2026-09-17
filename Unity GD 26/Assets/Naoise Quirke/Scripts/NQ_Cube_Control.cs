using UnityEngine;

public class NQ_Cube_Control: MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
        }

        if (Input.GetKey(KeyCode.RightArrow)) {

            print("Going right!");
            transform.Rotate(Vector3.right, 1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            print("Going back!");
            transform.Rotate(Vector3.down, 1);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {

            print("Rolling forward!");
            transform.Rotate(Vector3.up, 1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("Going down");
            transform.Rotate(Vector3.left, 1);
        }


    }
}
