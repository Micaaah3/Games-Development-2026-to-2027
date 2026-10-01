using UnityEngine;

public class ME_TargetHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private float health = 100;

    [SerializeField]
    private float maxHealth = 100;


    // Update is called once per frame
    void Update()
    {
        
    }


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

        health = Mathf.Min(health+healAmount, maxHealth);
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

        if (health >  maxHealth)
            health = maxHealth;


        Debug.Log("New Max Health! I'm now at: " + health + "And my max health is " + maxHealth);
    }

    #endregion
}
