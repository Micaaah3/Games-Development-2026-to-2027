using UnityEngine;

public interface IHealth
{
    // can not be negative.
    void Damage(float damageAmount);

    // can not be negative.
    void Heal(float healAmount);

    //0 for instantaneous
    void HealToMax(float delayUntilRepair);

    void UpdateMaxHealth(float newMaxHealth);
}
