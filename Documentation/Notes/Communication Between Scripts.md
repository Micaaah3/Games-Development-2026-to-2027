# Communication between Unity Scripts (Our Project Architecture)

At the core of game programming is communication between different parts of a project. In our bombing run project, we have three core objects that must tightly coordinate their behaviors:
1. **The Plane (`RS_PlaneControl`):** The master vehicle tracking global speed, inputs, and the total collection of bomb bays.
2. **The Bomb Slots (`RS_BombSlotScript`):** Children attached to the plane that manage specific layout anchor points and handle restock cooldown states.
3. **The Bombs (`RS_BombScript`):** Individual dynamic objects spawned at runtime that transition from sitting locked in a slot to falling using custom physics.

Depending on the context, our project relies on three distinct pillars of Unity script communication.

---

## 1. Public Variables (Referencing Asset Prefabs)

**The Rule:** Use public fields when a script attached to an active scene object needs to know about a project file blueprint (Prefab) that does not exist in the hierarchy yet.

### How it works in our code:
Our plane needs to tell the bomb slots what object data blueprint to instantiate when spawning a payload. We achieve this by declaring a public `GameObject` variable inside `RS_PlaneControl`:

```csharp
public class RS_PlaneControl : MonoBehaviour
{
    // Declared public so the 'Bomb Prefab' asset can be dragged in via the Unity Inspector
    public GameObject theBombCloneTemplate; 
}
```

*   **Advantage:** Fast, visual, and allows us to change what type of bomb the plane fires directly within the Unity Editor without rewriting code.
*   **Limitation:** This only gives the plane a template layout; it does not link it to the live instances spawned at runtime.

---

## 2. Parent-to-Child Dependency Injection (Passing "The Boss")

**The Rule:** When a parent object automatically searches for its children at runtime, it can pass a reference of itself (*dependency injection*) down to them so the children know who their manager is.

### How it works in our code:
Inside `RS_PlaneControl.cs`, we don't manually assign our bomb slots in the inspector. Instead, during the `Awake()` phase, the plane dynamically looks down its own object hierarchy tree to find all child slot scripts, and explicitly tells them: *"I am your boss."*

```csharp
// Inside RS_PlaneControl.cs
private void Awake()
{
    // 1. Gather references down the hierarchy tree
    bombSlots = GetComponentsInChildren<RS_BombSlotScript>();

    for (int i = 0; i < bombSlots.Length; i++)
    {
        // 2. Inject this plane reference directly into the child slot script
        bombSlots[i].IamTheBoss(this);
    }
}
```

Down inside `RS_BombSlotScript.cs`, the child script receives this initialization signal via an `internal` custom function and caches the reference locally into a private variable named `theBoss`:

```csharp
// Inside RS_BombSlotScript.cs
public class RS_BombSlotScript : MonoBehaviour
{
    RS_PlaneControl theBoss; // Cached reference to the master controller

    internal void IamTheBoss(RS_PlaneControl rS_PlaneControl)
    {
       theBoss = rS_PlaneControl; // Link successfully formed at runtime!
    }
}
```

*   **Why this is powerful:** The child script can now directly read the plane's state variables at any time (e.g., matching the plane's forward velocity via `theBoss.velocity`) without performing slow, expensive lookup operations like `GameObject.Find()`.

---

## 3. Runtime Initialization Injection (Slot-to-Bomb Passing)

**The Rule:** When an object is spawned programmatically using `Instantiate()`, you must immediately fetch its script component reference at runtime to pass initial settings before it begins updating.

### How it works in our code:
Inside `RS_BombSlotScript.cs`, when a bomb is created at its slot location, it captures a reference to the newly generated clone game object, immediately grabs its C# script component, and pushes data into it:

```csharp
// Inside RS_BombSlotScript.cs
private void InitializeBombAtSlot()
{
    // 1. Spawn the clone object from the template held by theBoss
    GameObject newBombGO = Instantiate(theBoss.theBombCloneTemplate, transform.position, transform.rotation, transform);
    
    // 2. Dynamically extract the C# script component attached to that clone
    RS_BombScript theNewBombScript = newBombGO.GetComponent<RS_BombScript>();
    
    // 3. Push data downward (injecting initial launch speed vectors)
    theNewBombScript.SetInitialVelocity(theBoss.velocity);
    
    // 4. Cache it locally so we can track this specific active bomb
    theCurrentBomb = theNewBombScript;
}
```

---

## Summary Matrix of our Script Communications

| Communicator Link | Method Used | Primary Purpose |
| :--- | :--- | :--- |
| **Inspector → Plane** | Public Inspector Asset Drag | Feeds the `theBombCloneTemplate` Prefab into the engine setup. |
| **Plane → Bomb Slot** | `GetComponentsInChildren` + Method call | Discovers child slots and establishes the structural hierarchy loop. |
| **Bomb Slot → Bomb** | `Instantiate` + `GetComponent<T>` | Spawns individual instances at runtime and synchronizes moving physics states. |



## Physics-Based Communication (Using Scripts instead of Tags)

When objects collide in 3D space, Unity's physics engine automatically triggers functions like `OnTriggerEnter(Collider other)`. The `other` variable gives us a direct reference to the object we collided with.

While many online tutorials use string tags to check what was hit (e.g., `if(other.tag == "Target")`), **our project uses direct script type identification instead.**

### Why we avoid Tags and Names:
1. **Typo Prevention:** If you misspell a string tag like `"Traget"`, Unity will not warn you. The game will run but silently fail, which makes bugs hard to find. If you misspell a script component name like `RS_DestructibleTraget`, Unity will instantly highlight it as a red error and refuse to compile until you fix it.
2. **Behavior Focus:** Checking for a script ensures the object actually possesses the *behaviors* you want to trigger (e.g., an `.Explode()` function).

### Week 3 Implementation Example:
Instead of asking Unity *"What text label is slapped onto this object?"*, we ask *"Does this object have the component script we need to talk to?"* using a null check:

```csharp
private void OnTriggerEnter(Collider other)
{
    // 1. Look for the specific component script on the object we collided with
    RS_DestructibleTarget target = other.GetComponent<RS_DestructibleTarget>();

    // 2. If the component exists (is NOT null), communicate with it!
    if (target != null)
    {
        target.Explode();    // Tell the target script to run its explosion logic
        Destroy(gameObject); // Remove the bomb from the scene
    }
}
```

### Solid Physics Example (`OnCollisionEnter`)

While `OnTriggerEnter` handles ghost-like zones that the plane or bomb can pass straight through, `OnCollisionEnter` is used for **solid, physical impacts** where objects bounce off or stop against one another. 

Instead of a `Collider`, this function provides a `Collision` data packet containing details about the impact (like impact speed or contact vectors), but we can still easily extract the C# script attached to the colliding object.

#### Implementation Example:

```csharp
// Inside RS_BombScript.cs
private void OnCollisionEnter(Collision collision)
{
    // 1. Look for the script component on the solid object we slammed into
    RS_DestructibleTarget target = collision.gameObject.GetComponent<RS_DestructibleTarget>();

    // 2. If the component exists, interact with it directly
    if (target != null)
    {
        target.Explode();    
        Destroy(gameObject); 
    }
}
```

### 🔍 Key Difference in Code Syntax:
*   In `OnTriggerEnter(Collider other)`, you can write `other.GetComponent<T>()` directly because a **Collider** is a component that belongs to a specific GameObject.
*   In `OnCollisionEnter(Collision collision)`, `collision` is a data class container, not a component. Therefore, you must explicitly step through the GameObject layer first by writing **`collision.gameObject.GetComponent<T>()`**.
