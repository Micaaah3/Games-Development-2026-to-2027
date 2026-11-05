using UnityEngine;

public class AirplaneBombAim : MonoBehaviour
{
    public Transform plane;
    public Transform bombSpawnPoint;      // необязательно: точка сброса под самолётом
    public LayerMask hitMask = ~0;        // в инспекторе убери слой Plane
    public float bombSpeed = 0f;
    public float gravity = 9.81f;
    public float maxTime = 15f;
    public int steps = 150;

    KK_MoveScript move;

    void Awake()
    {
        move = plane.GetComponent<KK_MoveScript>();
    }

    void Update()
    {
        Vector3 velocity = move.GetVelocity() + plane.forward * bombSpeed;
        Vector3 position = bombSpawnPoint ? bombSpawnPoint.position : plane.position;

        float stepTime = maxTime / steps;

        for (int i = 0; i < steps; i++)
        {
            Vector3 nextPosition = position + velocity * stepTime;
            velocity += Vector3.down * gravity * stepTime;

            if (Physics.Linecast(position, nextPosition, out RaycastHit hit,
                hitMask, QueryTriggerInteraction.Ignore))
            {
                transform.position = hit.point;
                return;
            }

            position = nextPosition;
        }
    }
}