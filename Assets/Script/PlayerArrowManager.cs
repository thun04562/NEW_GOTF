using UnityEngine;

public class PlayerArrowManager : MonoBehaviour
{
    public bool canSwitchArrows = false; // Initialize this according to your game's logic.

    private void Update()
    {
        // Check if the player can switch arrows.
        if (canSwitchArrows && Input.GetKeyDown(KeyCode.R))
        {
            // Handle arrow switching logic here.
            // For example, change the current arrow type.
        }
    }
}
