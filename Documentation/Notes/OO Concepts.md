# Object Orientated Concepts

# Object-Oriented Programming (OOP) Concepts in Unity 3D

This document provides a concise summary and practical code examples for three core OOP concepts implemented in C# for **Unity 3D**: **Inheritance**, **Interfaces**, and **Polymorphism**.

---

## 1. Inheritance
**Definition:** A mechanism where a new class (Child/Derived class) adopts the properties, methods, and behavior of an existing class (Parent/Base class). It allows you to reuse code and build a hierarchy. 

* **Unity Example:** Creating a base `Enemy` class that handles health, and then creating specific enemy types like `Zombie` that inherit those traits.

```csharp
using UnityEngine;

// Parent Base Class
public class Enemy : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log($"{gameObject.name} took damage! Health is now: {health}");
    }
}

// Child Derived Class
public class Zombie : Enemy
{
    // Zombie automatically has 'health' and the 'TakeDamage' method.
    public float rotSpeed = 2.0f; 
    
    void Start()
    {
        // Calling the inherited method
        TakeDamage(20); 
    }
}
```

---

## 2. Interfaces
**Definition:** A contract that defines a set of signatures (methods, properties) without implementing them. Any class that implements the interface **must** provide the actual code for those methods. Unlike inheritance, a class can implement multiple interfaces, which is perfect for decoupled, reusable gameplay features.

* **Unity Example:** An `IDamageable` interface. Both an enemy AI and a wooden crate can be damaged, but they are completely different types of objects.

```csharp
using UnityEngine;

// The Interface Contract
public interface IDamageable
{
    void Damage(int damageAmount);
}

// Example 1: Applying to an Enemy
public class RobotEnemy : MonoBehaviour, IDamageable
{
    public int shield = 50;

    public void Damage(int damageAmount)
    {
        shield -= damageAmount;
        Debug.Log($"Robot shield absorbed damage. Shield: {shield}");
    }
}

// Example 2: Applying to a Prop
public class WoodenCrate : MonoBehaviour, IDamageable
{
    public void Damage(int damageAmount)
    {
        // Destroy the crate instantly when hit
        Destroy(gameObject);
        Debug.Log("Crate shattered!");
    }
}
```

---

## 3. Polymorphism
**Definition:** The ability for different classes to respond to the same method call in their own unique way. Meaning "many forms," it allows you to treat derived objects as if they were their parent type, while still executing their specific child behaviors at runtime.

* **Unity Example:** A weapon system that fires projectiles. The weapon doesn't care if it's firing a bullet, a rocket, or a laser—it just calls `Fire()`.

```csharp
using UnityEngine;

// Base Class with a virtual method
public class Projectile : MonoBehaviour
{
    public virtual void Fire()
    {
        Debug.Log("Launching basic projectile forward.");
    }
}

// Overriding Child 1
public class Bullet : Projectile
{
    public override void Fire()
    {
        Debug.Log("Bullet fires instantly with high velocity.");
    }
}

// Overriding Child 2
public class HomingRocket : Projectile
{
    public override void Fire()
    {
        Debug.Log("Rocket fires, locks onto target, and accelerates.");
    }
}
```

### How it works in a Unity Manager Script:
```csharp
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    // A list that can hold Bullets, Rockets, or Basic Projectiles
    public Projectile[] ammunitionDeck; 

    void UseWeapon(int index)
    {
        // Polymorphism in action: calling 'Fire' executes the specific override 
        // depending on what object type is actually sitting in that slot.
        ammunitionDeck[index].Fire(); 
    }
}
```

---

## Summary Comparison

| Concept | What it solves | Best Used For in Unity |
| :--- | :--- | :--- |
| **Inheritance** | Code duplication among similar objects | Sharing core stats/logic (e.g., standard items, enemy types) |
| **Interfaces** | Connecting completely unrelated objects | Game mechanics shared by diverse objects (e.g., `IInteractable`, `IDamageable`) |
| **Polymorphism** | Rigid code that needs to change per object type | Swapping out behaviors dynamically (e.g., abilities, weapons, AI states) |
