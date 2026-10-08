# Scrum Workflow Guide: Mini-Component Delivery
### 🛠️ Unity & GitHub Individual Assignment Edition

Welcome to your next-week assignment guide! This document outlines exactly how our team will adapt the **Scrum Framework** to complete our individual Unity tasks using **GitHub** for project management and version control. 

By completing this, you will practice strict variable scoping, cross-team software testing, and professional engineering workflows.

---

## 🛠️ The 5-Phase Scrum Delivery Lifecycle

Instead of a multi-week sprint, we are running a **Mini-Sprint** where each student delivers one isolated feature using a strict **Coder-Tester pair** setup. You cannot merge your code until your designated Tester signs off.

```
 [1. DEFINE] ──> [2. DEFINE TEST] ──> [3. IMPLEMENT] ──> [4. TEST] ──> [5. COMPLETE]
  (Developer)        (Tester)           (Developer)     (Tester)        (Both)
```

---

## 💻 Phase-by-Phase Technical Setup

### 📝 Phase 1: Define (Role: Developer)
Your job is to clarify *what* you are building before writing code.
1. Create a new file in your repository named `docs/Task_S[YourNumber]_Definition.md`.
2. Write a clear description of the feature and list the exact C# variables and visibility scopes (`private`, `[SerializeField]`, `public`) you plan to use.
3. Open a **GitHub Issue** titled `[Feature] Task S[YourNumber] - Description` and paste your text there. Assign the issue to yourself.

### 🧪 Phase 2: Define Test (Role: Tester)
*The tester must establish the bar for success before implementation begins.*
1. Review the GitHub Issue created by your assigned Developer.
2. In the comments of that Issue, write the **Acceptance Criteria (AC)** and exact test steps.
   * *Example:* "1. Open the project. 2. Enter Play Mode. 3. Press Spacebar 3 times. 4. Verify the console displays 90, 80, 70. 5. Inspect the script to ensure `currentHealth` is explicitly marked `private`."
3. Once you both agree, the Tester posts a comment saying `✔️ Test Criteria Approved`.

### 💻 Phase 3: Implement (Role: Developer)
Now you build the feature locally on your machine.

- Sync Fork
- Update/Clone onto local copy
- Create dedicated development and test scene
- Create solution
- push to personal
- pull request

### 🔍 Phase 4: Test (Role: Tester)

1. Bring down updated versio with code to test
2. Open Unity. Execute the exact test steps you outlined in **Phase 2**.
3. Inspect their C# script code to ensure they used appropriate C# variable rules (e.g., they didn't make variables `public` when they should have used `private` or `[SerializeField]`).
4. **If it passes:** Go to the GitHub Pull Request, select **Review Changes**, write your feedback, and click **Approve**.
5. **If it fails:** Leave a review explaining the bug or scoping violation, select **Request Changes**, and send it back to Phase 3.

### 🎉 Phase 5: Complete (Role: Both)
1. Once the Pull Request is **Approved**, the Developer merges the branch into `main` via the GitHub web UI.
2. Close the original GitHub Issue.
3. Congratulations! Your feature is officially **Done**.

---

## 🛑 Critical Git Rules for Unity Projects
Unity projects generate a lot of background metadata. To avoid breaking each other's work, follow these rules strictly:
* **Never commit without a `.gitignore`:** Ensure your repository has a proper Unity `.gitignore` file active before pushing anything. This prevents giant temporary files (like the `Library` folder) from cluttering the repo.
* **Work in separate Scenes/Prefabs:** To eliminate merge conflicts entirely, build your task inside your own isolated test Scene or package your feature into an isolated Prefab. Do not modify the shared global scene at the same time.
* **Close Unity before switching branches:** When using `git checkout` to jump to your peer's testing branch, close the Unity Editor first. Unity can become unstable if the underlying files change while the editor is running.
