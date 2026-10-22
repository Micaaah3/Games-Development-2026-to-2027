using UnityEngine;

public class RD_explosionController : MonoBehaviour
{
    RD_TestExplosionsDevelopment theCause;
    ParticleSystem[] particleSystems;
    enum ExplosionType {typeOne, typeTwo, typeThree}
    ExplosionType currentType = ExplosionType.typeOne;

    int effectIndex = 0;
    internal void CauseExplosion(RD_TestExplosionsDevelopment RD_TestExplosionsDevelopment)
    {
        theCause = RD_TestExplosionsDevelopment;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        particleSystems = GetComponentsInChildren<ParticleSystem>();
        var main = particleSystems[effectIndex].main;

        switch (currentType)
        {
            case ExplosionType.typeOne:

                effectIndex = 0;

                for (int i = 0; i < particleSystems.Length; i++)

                {
                    main.startLifetimeMultiplier = 1f;
                    main.startSpeedMultiplier = 1f;
                    main.startSizeMultiplier = 1f;
                }

                break;

            case ExplosionType.typeTwo:

                effectIndex = 0;

                for (int i = 0; i < particleSystems.Length; i++)

                {
                    main.startLifetimeMultiplier = 3f;
                    main.startSpeedMultiplier = 3f;
                    main.startSizeMultiplier = 3f;
                }

                break;

            case ExplosionType.typeThree:

                effectIndex = 0;

                for (int i = 0; i < particleSystems.Length; i++)

                {
                    main.startLifetimeMultiplier = 5f;
                    main.startSpeedMultiplier = 5f;
                    main.startSizeMultiplier = 5f;
                }

                break;

        }
    }
}
