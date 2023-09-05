using UnityEngine;
using UnityEngine.UI;

public class BuyButtonControl : MonoBehaviour
{
    public Button buyButton;
    private bool isSold = false;
    private string buttonStateKey;

    private void Start()
    {
        // Define a unique key for each button based on its name.
        buttonStateKey = $"IsSold_{buyButton.gameObject.name}";

        // Load the button state from PlayerPrefs when the game starts.
        isSold = PlayerPrefs.GetInt(buttonStateKey, 0) == 1;

        // Update the button text and interactable state accordingly.
        UpdateButtonState();

        buyButton.onClick.AddListener(OnBuyButtonClick);

        // Clear button state on game start.
        ClearButtonStateOnGameStart();
    }

    private void OnBuyButtonClick()
    {
        if (!isSold)
        {
            // Handle the purchase logic here.
            // You can add code to deduct money, unlock an item, etc.

            // Change the button text to "SOLD."
            buyButton.GetComponentInChildren<Text>().text = "SOLD";

            // Disable the button.
            buyButton.interactable = false;

            // Set isSold to true to prevent further clicks.
            isSold = true;

            // Save the button state to PlayerPrefs.
            PlayerPrefs.SetInt(buttonStateKey, 1);
        }
    }

    private void UpdateButtonState()
    {
        // Update the button text and interactable state based on the saved state.
        if (isSold)
        {
            buyButton.GetComponentInChildren<Text>().text = "SOLD";
            buyButton.interactable = false;
        }
        else
        {
            buyButton.GetComponentInChildren<Text>().text = "BUY";
            buyButton.interactable = true;
        }
    }

    private void ClearButtonStateOnGameStart()
    {
        // Clear the button state when the game starts.
        PlayerPrefs.DeleteKey(buttonStateKey);
    }
}
