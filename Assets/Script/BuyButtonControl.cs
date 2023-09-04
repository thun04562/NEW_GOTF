using UnityEngine;
using UnityEngine.UI;

public class BuyButtonControl : MonoBehaviour
{
    public Button buyButton;
    private bool isSold = false;

    private void Start()
    {
        buyButton.onClick.AddListener(OnBuyButtonClick);
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
        }
    }
}
