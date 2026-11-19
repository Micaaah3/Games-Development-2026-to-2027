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
    [SerializeField]
    private float _randomRotation = 3f;

    private Transform parentTransform;

    public void InitializeShell(Vector3 target, float speed, float explosionDistance,float fuseDelay)
    {
        // fuseDelay is in seconds. Ms = 0.001
        parentTransform = transform.parent;

        _direction = (target - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        Quaternion _lookRotation = LookRotationWithRandom();

        parentTransform.rotation = _lookRotation;

        _speed = speed;
        _explosionDistance = explosionDistance;

        //start explosion coroutine.
        StartCoroutine("Detonate", fuseDelay);
    }

    private Quaternion LookRotationWithRandom()
    {
        Vector3 rotation = Quaternion.LookRotation(_direction).eulerAngles;

        Vector3 RandomRotation = new Vector3(
            Random.Range(-_randomRotation, _randomRotation),
            Random.Range(-_randomRotation, _randomRotation),
            Random.Range(-_randomRotation, _randomRotation));

        return Quaternion.Euler(rotation + RandomRotation);
    }

    private void Update()
    {
        parentTransform.position = parentTransform.position + _speed * Time.deltaTime * transform.up;

        float randomDrag = Random.Range(0, 100) / 10000;

        _speed = _speed * (0.99f+randomDrag);
    }

    #region IFused
    
    public IEnumerator Detonate(float fuseDelay)
    {
        yield return new WaitForSeconds(fuseDelay);

        int targetsHit = 0;

        Collider[] hits = Physics.OverlapSphere(parentTransform.position, _explosionDistance);
        foreach (Collider hit in hits)
        {
            if (hit.gameObject == gameObject)
                continue;

            hit.TryGetComponent<IHealth>(out IHealth health);

            if (health == null)
                continue;

            health.Damage(0);
            targetsHit++;
        }

        //Trigger explosion
        Debug.Log(string.Format("Fuse exploded at {0} and hit {1} targets", parentTransform.position, targetsHit));

        Destroy(parentTransform.gameObject);
    }

    #endregion
}
