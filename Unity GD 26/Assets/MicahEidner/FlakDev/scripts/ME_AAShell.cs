using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ME_AAShell : MonoBehaviour, ME_IFused
{
    [SerializeField]
    private Vector3 _direction;
    [SerializeField]
    private float   _speed;
    [SerializeField]
    private float   _explosionDistance;

    public void InitializeShell(Vector3 target, float speed, float explosionDistance,float fuseDelay) {
        // fuseDelay is in seconds. Ms = 0.001
        _direction = (target - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        Quaternion _lookRotation = Quaternion.LookRotation(_direction);

        transform.rotation = _lookRotation;

        _speed = speed;
        _explosionDistance = explosionDistance;
        
        //start explosion coroutine.
        StartCoroutine("Detonate", fuseDelay);
    }


    private void Update()
    {
        transform.position = transform.position + _speed * Time.deltaTime * transform.up;

        float randomDrag = Random.Range(0, 100) / 10000;

        _speed = _speed * (0.99f+randomDrag);
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
