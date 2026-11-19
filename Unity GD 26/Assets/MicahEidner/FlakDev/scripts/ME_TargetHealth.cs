using System;
using System.Collections;
using UnityEngine;

public class ME_TargetHealth : MonoBehaviour, IHealth, Iimmunity, ITargetable
{
    [SerializeField]
    private float health = 100;
    [SerializeField]
    private float maxHealth = 100;

    [SerializeField]
    private bool _isImmune = false;
    [SerializeField]
    private bool _AATargetable = true;

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
    #region Iimmunity
    public void SetImmunity(bool immunity)
    {
        _isImmune = immunity;
    }

    public void ToggleImmunity()
    {
        _isImmune = !_isImmune;
    }

    #endregion
    #region ITargetable


    public bool shouldGetTargetedByAA()
    {
        return _AATargetable;
    }

    public void toggleTargetByAA()
    {
        _AATargetable = !_AATargetable;
    }

    public void setTargetByAA(bool shouldGetTargeted)
    {
        _AATargetable = shouldGetTargeted;
    }
    #endregion
}
