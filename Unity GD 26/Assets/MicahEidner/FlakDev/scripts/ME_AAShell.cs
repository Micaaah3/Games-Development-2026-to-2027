using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ME_AAShell : MonoBehaviour, ME_IFused
{
    [SerializeField]
    private Vector3 _direction;
    private float   _speed;
    private float   _explosionDistance;

    public ME_AAShell(Vector3 direction, float speed, float explosionDistance,float fuseDelay) {
        // fuseDelay is in seconds. Ms = 0.001
        _direction = direction;
        _speed = speed;
        _explosionDistance = explosionDistance;
        
        //start explosion coroutine.
        StartCoroutine("Detonate", fuseDelay);
    }


    #region IFused
    
    public IEnumerator Detonate(float fuseDelay)
    {
        yield return new WaitForSeconds(fuseDelay);

        //Trigger explosion
        Debug.Log("Fuse exploded at "+transform.position);

        Destroy(gameObject);
    }

    #endregion
}
