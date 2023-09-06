using UnityEngine;

public class ArrowController : MonoBehaviour
{
    /*private GreenArrowSkill greenArrowSkill;
    private BlueArrowSkill blueArrowSkill;
    private YellowArrowSkill yellowArrowSkill;

    private int currentSkillIndex = 0;
    private ISkill currentSkill;

    private void Start()
    {
        // Attach the skill scripts to the player GameObject or reference them as needed.
        greenArrowSkill = GetComponent<GreenArrowSkill>();
        blueArrowSkill = GetComponent<BlueArrowSkill>();
        yellowArrowSkill = GetComponent<YellowArrowSkill>();

        // Initialize the current skill.
        SwitchSkill(currentSkillIndex);
    }

    private void Update()
    {
        // Check for skill switch input (holding "E" key).
        if (Input.GetKey(KeyCode.E))
        {
            // Implement logic to handle skill switching.
            // For example, you can use a timer or other conditions to determine when to switch skills.
        }

        // Check for skill activation input (e.g., pressing the left mouse button).
        if (Input.GetButtonDown("Fire1"))
        {
            // Activate the current skill.
            currentSkill?.Activate();
        }
    }

    private void SwitchSkill(int newIndex)
    {
        // Deactivate the current skill.
        currentSkill?.Deactivate();

        // Update the current skill index.
        currentSkillIndex = newIndex;

        // Activate the new skill based on the index.
        switch (currentSkillIndex)
        {
            case 0:
                currentSkill = greenArrowSkill;
                break;
            case 1:
                currentSkill = blueArrowSkill;
                break;
            case 2:
                currentSkill = yellowArrowSkill;
                break;
        }

        // Activate the new skill.
        currentSkill?.Activate();
    }*/
}
