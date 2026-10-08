# C# Scope and Access Modifiers in Unity (For Python Developers)

In **Python**, variable scope and privacy are relatively open. You manage visibility using naming conventions (like `_variable` for internal use), but Python doesn’t compile your code or strictly stop other scripts from breaking those rules. 

**C#** is a **statically typed, Object-Oriented** language where variable types, privacy, and boundaries are strictly enforced at compile time. If your access modifiers or scopes don't match C# rules, your game will not compile, and Unity will display a console error.

---

## 1. Access Modifiers (Variables Across Scripts)

Access modifiers dictate whether code inside *other* scripts can see or change your variables, and how those variables appear in the Unity Inspector.

| Modifier | C# Scope / Visibility | Python Equivalent Behavior | Unity Inspector Interaction |
| :--- | :--- | :--- | :--- |
| **`private`** | Only within the **same class**. | A hidden variable like `_variable`. | **Hidden** by default (can be forced visible). |
| **`public`** | Accessible by **any script** in the project. | A normal variable like `self.variable`. | **Visible** and editable by default. |
| **`internal`** | Visible to all scripts in the **same assembly**. | A package/module variable level. | **Hidden** by default. |

### Private Variables (The "Secret Room" 🔒)
A `private` variable can only be accessed or modified by the specific script it is written in. If you omit the modifier keyword in C#, the language defaults to `private`.

```csharp
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    // C# defaults to private if left blank, but it's best to be explicit!
    private int currentHealth = 100; 

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage; // Allowed: inside the same class
    }
}
```

#### 💡 The Unity Exception: `[SerializeField]`
If you want to protect a variable from other scripts but still tweak its values using sliders or fields in the **Unity Inspector**, add the `[SerializeField]` attribute:

```csharp
[SerializeField] private float movementSpeed = 5.5f; // Safe from code, editable in Unity UI
```

### Public Variables (The "Open Gate" 🚪)
A `public` variable can be accessed, read, and changed by absolutely any other script in your game. Declaring a variable as public instantly displays it inside the Unity Inspector.

```csharp
using UnityEngine;

public class TargetEnemy : MonoBehaviour 
{
    public string enemyName = "Goblin"; // Any script can read or overwrite this
}
```

### Internal Variables (The "Building Residents" 🏢)
In standard Unity setups, `internal` acts similarly to `public`. However, as projects grow, `internal` restricts access to scripts compiled within the exact same **Assembly (.dll)**. Unity automatically bundles your default scripts into `Assembly-CSharp.dll`. Scripts inside that bundle can read an `internal` variable, but external plugins or custom Assembly Definitions cannot.

```csharp
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    internal string systemsKey = "SYS_INIT_992"; // Visible to your game scripts, hidden from plugins
}
```

---

## 2. Scope (Variables Within the Same Script)

**Scope** defines the physical boundary and lifetime of a variable. C# handles scope strictly through curly braces `{ }`. A variable is only alive inside the block of braces where it was declared.

### Local Variables (Short-Lived ⏱️)
A **local variable** is declared inside a specific method, loop, or conditional block. It is created when the method runs and is instantly destroyed when the execution hits the closing curly brace `}`.

* **Python Comparison:** This is exactly like a variable created inside a Python `def function():`.
* **Note:** You **cannot** use access modifiers (`public`, `private`) on local variables.

```csharp
using UnityEngine;

public class BallLauncher : MonoBehaviour 
{
    void Start() 
    {
        // LOCAL VARIABLE
        int launchForce = 10; // Born here, dies at the end of Start()
        Debug.Log(launchForce); // Valid
    }

    void Update() 
    {
        // ❌ COMPILER ERROR: launchForce does not exist in this scope!
        // Debug.Log(launchForce); 
    }
}
```

### Non-Local Variables / Member Variables (Long-Lived 🛡️)
C# does not use Python's `nonlocal` keyword. Instead, any variable declared outside of methods—but inside the main class boundaries—is called a **Member Variable** (or Field). These variables live as long as the object instance exists.

* **Python Comparison:** Equivalent to a variable attached to `self`, like `self.health = 100` defined inside an `__init__` constructor.

```csharp
using UnityEngine;

public class PlayerScore : MonoBehaviour 
{
    // MEMBER VARIABLE (Non-Local to methods)
    private int currentScore = 0; 

    void EnemyDefeated() 
    {
        currentScore += 100; // Valid: Updates the persistent member variable
    }
}
```

### Variable Lifespans Summary

| Variable Type | Where is it declared? | Lifetime / Scope | Can use Access Modifiers? |
| :--- | :--- | :--- | :--- |
| **Local** | Inside a method or loop `{ }`. | Temporary. Erased when the method finishes. | **No** (Causes a compiler error). |
| **Member (Non-Local)** | Inside a class, outside methods. | Persistent. Lives as long as the script component lives. | **Yes** (Controls access for *other* scripts). |

---

## 3. The "Shadowing" Trap ⚠️

Because of how scope works, C# allows you to create a local variable with the **exact same name** as a member variable. The local variable will "shadow" (hide) the member variable within that specific method block, leading to common logical bugs for Python switchers.

```csharp
using UnityEngine;

public class SpeedTracker : MonoBehaviour 
{
    // 1. Member variable
    private float moveSpeed = 5.0f; 

    void SetupSpeed() 
    {
        // 2. Local variable with the SAME name
        // Python developers often do this thinking they are updating the field above.
        float moveSpeed = 10.0f; 

        // Prints 10.0 (reads the local variable scope)
        Debug.Log("Local speed is: " + moveSpeed); 
    }

    void Start() 
    {
        SetupSpeed();
        // Prints 5.0! The member variable was never actually modified.
        Debug.Log("Global member speed is still: " + moveSpeed); 
    }
}
```

*To fix this trap, remove the data type (`float`) inside the method to assign the value directly to the existing member variable instead of declaring a new local one.*
