using UnityEngine;

public class PlayerAnimationArrowController : MonoBehaviour
{
    public Animator playerAnimator; // Reference to the player's Animator component.
    public AnimatorOverrideController redArrowOverride;
    public AnimatorOverrideController greenArrowOverride;
    public AnimatorOverrideController blueArrowOverride;
    public AnimatorOverrideController yellowArrowOverride;

    private AnimatorOverrideController currentOverrideController;
    private string currentArrowType = "RedArrow"; // Initial arrow type.

    private void Start()
    {
        // Ensure that playerAnimator is set in the Inspector.
        if (playerAnimator == null)
        {
            Debug.LogError("Player Animation Controller: Player Animator reference not set.");
            enabled = false; // Disable the script to avoid errors.
            return;
        }

        // Set the initial override controller to Red Arrow.
        currentOverrideController = redArrowOverride;
        playerAnimator.runtimeAnimatorController = currentOverrideController;
    }

    public void ChangeArrowAnimation(string arrowType)
    {
        // Determine the appropriate Animator Override Controller based on the arrow type.
        switch (arrowType)
        {
            case "RedArrow":
                currentOverrideController = redArrowOverride;
                break;
            case "GreenArrow":
                currentOverrideController = greenArrowOverride;
                break;
            case "BlueArrow":
                currentOverrideController = blueArrowOverride;
                break;
            case "YellowArrow":
                currentOverrideController = yellowArrowOverride;
                break;
            default:
                Debug.LogError("Invalid arrow type: " + arrowType);
                return;
        }

        // Apply the selected Animator Override Controller.
        playerAnimator.runtimeAnimatorController = currentOverrideController;

        // Update the current arrow type.
        currentArrowType = arrowType;
    }

    public string GetCurrentArrowType()
    {
        return currentArrowType;
    }
}
