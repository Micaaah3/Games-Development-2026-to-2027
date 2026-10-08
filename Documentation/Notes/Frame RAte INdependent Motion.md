# Frame Rate Independent (FRI) Motion & Kinematic Physics in Unity

## 🎯 What is Frame Rate Independent Motion?

By default, Unity's `Update()` function executes once per rendered frame. If a player's computer is running fast, it might render at **120 Frames Per Second (FPS)**; if it is struggling, it might drop to **30 FPS**.

If we translate an object inside `Update()` by a fixed distance without accounting for time, the object's speed becomes tied directly to the hardware's performance:
*   At **120 FPS**, the object moves 120 times per second (incredibly fast).
*   At **30 FPS**, the object moves only 30 times per second (sluggish and slow).

**Frame Rate Independent Motion** decouples movement speed from the rendering hardware, ensuring an object moves at the exact same physical speed through game space regardless of whether the computer is running fast or slow. We achieve this by multiplying our movement vectors by **`Time.deltaTime`** (the elapsed time in seconds since the last frame).

---

## 📐 The 3 Rules of Linear Motion (Kinematics)

To calculate realistic, smooth movement dynamically in code, we implement the classic physics laws of linear motion under **constant acceleration**. 

Here are the three formulas and how they apply mathematically inside our C# scripts:

### Rule 1: The Velocity-Time Equation
$\mathbf{v} = \mathbf{u} + \mathbf{a}t$
*   *Where:* $\mathbf{v}$= final velocity, $\mathbf{u}$ = initial velocity, $\mathbf{a}$ = acceleration, $t$ = time.
*   **Relevance to Unity FRI:** Velocity is rarely fixed; it changes continuously based on inputs like pushing the engine thrust or gravity pulling an object down. To find the current velocity at the end of a frame, we take our existing velocity and add the accumulation of our acceleration multiplied by `Time.deltaTime`.

### Rule 2: The Displacement-Velocity Equation
$$\mathbf{s} = \mathbf{s_0} + \mathbf{v}t$$
*   *Where:* $\mathbf{s}$ = final position, $\mathbf{s_0}$ = starting position, $\mathbf{v}$ = velocity, $t$ = time.
*   **Relevance to Unity FRI:** Once we calculate how fast an object is traveling (velocity), we update its physical location in 3D space by shifting its coordinates by the velocity multiplied by `Time.deltaTime`.

### Rule 3: The Complete Kinematic Displacement Equation
$$\mathbf{s} = \mathbf{s_0} + \mathbf{u}t + \frac{1}{2}\mathbf{a}t^2$$
*   *Where:* This blends Rule 1 and Rule 2 together to track how position shifts over time under constant, active acceleration.
*   **Relevance to Unity FRI:** In standard game loops, we approximate this calculus incrementally frame-by-frame (Euler Integration) by calculating Rule 1 first, immediately followed by Rule 2.

---

## 💻 Implementation in Our Codebase (`RS_PlaneControl`)

Our plane script applies these exact rules sequentially inside the `Update()` loop. Because frames happen dynamically, `Time.deltaTime` acts as our variable $t$.

Look closely at how our `Update()` routine directly executes the linear motion laws:

```csharp
void Update()
{
    // RESET: Start the frame with zero active acceleration
    acceleration = Vector3.zero;

    // PHYSICS FORCE 1: Apply simulated gravity downward
    float simulatedGravity = 9.8f;
    acceleration += new Vector3(0, -simulatedGravity, 0);

    // PHYSICS FORCE 2: Apply thrust forward on Keypress
    if (Input.GetKey(KeyCode.Space))
    {
        acceleration += transform.forward * thrustValue;
    }

    // PHYSICS FORCE 3: Apply drag (resists current velocity)
    acceleration += -drag * velocity;

    // ==========================================
    // LINEAR MOTION RULE 1: v = u + at
    // ==========================================
    // We add the change in acceleration over elapsed frame time to our velocity.
    velocity += acceleration * Time.deltaTime;

    // ==========================================
    // LINEAR MOTION RULE 2: s = s0 + vt
    // ==========================================
    // We update the 3D position vector using our newly computed frame velocity.
    transform.position += velocity * Time.deltaTime;
}
```

---

## 🔑 Crucial Takeaways for Level 6 Students

1. **Why do we multiply by `Time.deltaTime` twice?** 
   Notice that `Time.deltaTime` appears on both the velocity line and the position line. This is structurally correct! Acceleration is measured in **meters per second squared ($m/s^2$)**. To convert it to a velocity change ($m/s$), you multiply by time once. To convert velocity to a displacement change ($m$), you multiply by time a second time.
2. **`Update()` vs. `FixedUpdate()`**
   * Use **`Update()` + `Time.deltaTime`** when you are manually translating raw transform mathematics like `transform.position += ...` or handling instant keyboard/controller inputs.
   * If you choose to hand control over entirely to Unity's built-in rigid body physics engine (e.g., using `RigidBody.AddForce`), that movement should take place inside **`FixedUpdate()`** using **`Time.fixedDeltaTime`** to preserve structural integrity.
