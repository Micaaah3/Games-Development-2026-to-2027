using System;
using UnityEngine;

public class Press : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            Clicked();
        }
    }

    private void Clicked()
    {
        print("Command Successful");
    }
}
