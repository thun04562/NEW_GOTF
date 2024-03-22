using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonControl : MonoBehaviour
{
    PlayerControl playerControl;
    public GameObject Arrow;
    test test;
    public Button buyButton;
    private bool isSold = false;
    //private string buttonStateKey;
    private int valueGem = 0;
    public int price = 0;
    private int calculator = 0;
    public GemNumberDisplay gemDisplay;
    private SkillUnlock skillUnlock; // Reference to the SkillUnlock component.

    private void Start()
    {
        gemDisplay = FindObjectOfType<GemNumberDisplay>();

        // Define a unique key for each button based on its name.
       // buttonStateKey = $"IsSold_{buyButton.gameObject.name}";

        // Load the button state from PlayerPrefs when the game starts.
        //isSold = PlayerPrefs.GetInt(buttonStateKey, 0) == 1;

        // Update the button text and interactable state accordingly.
        UpdateButtonState();

        buyButton.onClick.AddListener(OnBuyButtonClick);

        // Clear button state on game start.
        ClearButtonStateOnGameStart();

        test = FindObjectOfType<test>();
        playerControl = FindObjectOfType<PlayerControl>();
    }

    private void OnBuyButtonClick()
    {
        if (!isSold)
        {
            // Handle the purchase logic here.
            // You can add code to deduct money, unlock an item, etc.
            valueGem = playerControl.gemCount;
            Debug.Log(valueGem);
            Debug.Log("This Item Price " + price.ToString());
            calculator = valueGem - price;
            if (calculator < 0)
            {
                return;
            }
            Debug.Log("Now, you have money " + calculator.ToString());
            playerControl.gemCount = calculator;
            //PlayerPrefs.SetInt("GemCount", calculator);
            gemDisplay.UpdateGemUI();
            Debug.Log("after gemDisplay");

            // Change the button text to "SOLD."
            buyButton.GetComponentInChildren<Text>().text = "SOLD";

            // Disable the button.
            buyButton.interactable = false;

            // Set isSold to true to prevent further clicks.
            isSold = true;

            // Save the button state to PlayerPrefs.
            //PlayerPrefs.SetInt(buttonStateKey, 1);

            // Unlock the skill by setting its SkillUnlock component to true.
            test.BUYArrow(Arrow);
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
        //PlayerPrefs.DeleteKey(buttonStateKey);
    }
}