using UnityEngine;
using UnityEngine.UI;

public class ArrowUIController : MonoBehaviour
{
    [SerializeField] private AudioClip WeaponSwapSound;

    public Image arrowUIImage; // Reference to the Image component of the arrow UI.
    public Sprite[] arrowSprites; // Array of arrow sprites to cycle through.
    public PlayerAnimationArrowController playerAnimationController; // Reference to the PlayerAnimationController script.

    private int currentSpriteIndex = 0;

    private void Start()
    {
        // Ensure that arrowUIImage, arrowSprites, and playerAnimationController are set in the Inspector.
        if (arrowUIImage == null || arrowSprites.Length == 0 || playerAnimationController == null)
        {
            Debug.LogError("Arrow UI Controller: One or more required references not set.");
            enabled = false; // Disable the script to avoid errors.
            return;
        }

        // Set the initial arrow icon.
        arrowUIImage.sprite = arrowSprites[currentSpriteIndex];
    }

    private void Update()
    {
        // Check for the "E" key press to change the arrow icon and player's animation.
        if (Input.GetKeyDown(KeyCode.R))
        {
            SoundManager.instance.PlaySound(WeaponSwapSound);
            // Increment the current sprite index and loop back to the beginning if necessary.
            currentSpriteIndex = (currentSpriteIndex + 1) % arrowSprites.Length;

            // Update the arrow icon.
            arrowUIImage.sprite = arrowSprites[currentSpriteIndex];

            // Determine the arrow type and change the player's animation accordingly.
            string arrowType = GetArrowType(currentSpriteIndex);
            playerAnimationController.ChangeArrowAnimation(arrowType);
        }
    }

    private string GetArrowType(int index)
    {
        switch (index)
        {
            case 0:
                return "RedArrow";
            case 1:
                return "GreenArrow";
            case 2:
                return "BlueArrow";
            case 3:
                return "YellowArrow";
            default:
                return "";
        }
    }
}