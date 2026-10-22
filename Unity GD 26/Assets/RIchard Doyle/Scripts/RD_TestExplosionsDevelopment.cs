using UnityEngine;

public class RD_TestExplosionsDevelopment : MonoBehaviour
{
    RD_explosionController changeType;
    public Transform explosionCloneTemplate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            //Destroy(gameObject);
            //Destroy(Instantiate(explosionCloneTemplate).gameObject, 2f);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

        }
        if (Input.GetKeyDown(KeyCode.T))
        {

        }
    }
}