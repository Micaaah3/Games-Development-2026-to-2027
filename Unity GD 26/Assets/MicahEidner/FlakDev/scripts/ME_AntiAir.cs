using UnityEngine;
public class ME_AntiAir : MonoBehaviour, IHealth
{
    #nullable enable
    // ^^^^^^^^^^^^^
    // Makes code more understandable.
    // Some functions may actually return null, I'm doing this to avoid any possible errors.

    [SerializeField]
    private float health = 100;
    [SerializeField]
    private float maxHealth = 100;

    [SerializeField]
    private float _minRange = 10f;
    [SerializeField]
    private float _maxRange = 500f;

    [SerializeField]
    private float _initialShellSpeed = 300f;

    [SerializeField]
    private GameObject? _currentTarget = null;

    private int _retargetTimer;

    [SerializeField]
    private int _retargetMax = 360;
    //Some random number I chose ^^

    private void Start()
    {
        _currentTarget = findClosestTarget();
    }

    private void Update()
    {
        if (_currentTarget != null) {
            float distance = Vector3.Distance(_currentTarget.transform.position, transform.position);

            if (distance > 20f && _retargetTimer >= _retargetMax)
            {
                _currentTarget = findClosestTarget();
                _retargetTimer = 0;
            }else{
                if (_retargetTimer >= _retargetMax)
                    _retargetTimer = 0;
                _retargetTimer++;
            }
        }else{
            _currentTarget = findClosestTarget();
        }
            
    }

    #region AA

    public GameObject? findClosestTarget()
    {
        // Can return Null if there is no target in range of AA.
        float closestTargetRange = Mathf.Infinity;
        GameObject? closestTarget = null;

        Collider[] _colliderAlloc = Physics.OverlapSphere(transform.position, _maxRange);

        foreach (Collider collider in _colliderAlloc)
        {
            if (collider.gameObject == gameObject)
                continue;

            collider.TryGetComponent<IHealth>(out IHealth? component);

            if (component is null)
                continue;

            float distance = Vector3.Distance(collider.transform.position, transform.position);

            if (distance >= closestTargetRange)
                continue;

            closestTargetRange = distance;
            closestTarget = collider.gameObject;
        }


        return closestTarget;
    }
    #endregion

    #region IHealth

    public void Damage(float damageAmount)
    {
        if (damageAmount < 0)
            return;

        health -= damageAmount;
        Debug.Log("Damaged! I'm now at: " + health);
    }

    public void Heal(float healAmount)
    {
        if (healAmount < 0)
            return;

        health = Mathf.Min(health + healAmount, maxHealth);
        Debug.Log("Healed! I'm now at: " + health);
    }

    public void HealToMax(float delayUntilRepair = 0)
    {
        if (delayUntilRepair > 0)
        {
            throw new System.NotImplementedException();
        }

        health = maxHealth;
        Debug.Log("Healed! I'm now at: " + health);
    }
    public void UpdateMaxHealth(float newMaxHealth)
    {
        if (newMaxHealth < 0)
            return;

        maxHealth = newMaxHealth;

        if (health > maxHealth)
            health = maxHealth;


        Debug.Log("New Max Health! I'm now at: " + health + "And my max health is " + maxHealth);
    }

    #endregion
}
