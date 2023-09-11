// SkillActivation.cs script (or similar, attached to the player)
using UnityEngine;

public class SkillActivation : MonoBehaviour
{
    // Assign the skill GameObjects in the Inspector.
    public GameObject greenArrowSkill;
    public GameObject blueArrowSkill;
    public GameObject yellowArrowSkill;
    // ...

    private void Update()
    {
        // Check for skill activation input (e.g., pressing a key).
        if (Input.GetButtonDown("Fire1"))
        {
            // Activate the current skill only if it's unlocked.
            if (IsSkillUnlocked())
            {
                ActivateCurrentSkill();
            }
        }
    }

    private bool IsSkillUnlocked()
    {
        // Check if the currently selected skill (based on player input) is unlocked.
        GameObject currentSkill = GetSelectedSkill(); // Implement this method.

        if (currentSkill != null)
        {
            SkillUnlock skillUnlock = currentSkill.GetComponent<SkillUnlock>();
            if (skillUnlock != null)
            {
                return skillUnlock.isUnlocked;
            }
        }

        // Default to false if the skill or SkillUnlock component is missing.
        return false;
    }

    private void ActivateCurrentSkill()
    {
        // Implement logic to activate the current skill.
    }

    private GameObject GetSelectedSkill()
    {
        // Implement logic to determine the currently selected skill based on player input.
        // Return the GameObject of the selected skill.

        // Replace this with your actual logic.
        if (Input.GetKeyDown(KeyCode.Alpha1)) // For example, check if key 1 is pressed for skill 1.
        {
            return greenArrowSkill; // Return the GameObject of the Green Arrow skill.
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // Check for other keys as needed.
        {
            return blueArrowSkill; // Return the GameObject of the Blue Arrow skill.
        }
        // Add similar logic for other skills.

        return null; // Return null if no skill is selected.
    }

}
