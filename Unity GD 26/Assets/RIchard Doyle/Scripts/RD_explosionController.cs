using UnityEngine;

public class RD_explosionController : MonoBehaviour
{
    ParticleSystem[] particleSystems;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        print(particleSystems.Length);
    }

    // Update is called once per frame
    void Update()
    {
        // particleSystems[0].main.
    }
}
