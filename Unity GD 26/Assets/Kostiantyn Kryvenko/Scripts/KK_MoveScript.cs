using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotSpeed = 10f;
    Vector3 velocity;
    Vector3 acceleration;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        Vector3 rotation = Vector3.zero;


        if (Input.GetKey(KeyCode.Return)) //Engines
        {

            acceleration = transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            rotation -= Vector3.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rotation += Vector3.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotation += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation -= Vector3.down;
        }

        direction.Normalize(); //Prevent digonal movement from being faster than straight movement
        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
        transform.Rotate(rotation * rotSpeed * Time.deltaTime);
    }
}
