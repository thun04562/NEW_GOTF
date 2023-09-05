/*using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public int skillCost = 10;  // Cost of the skill
    public Text costText;      // Text displaying the cost
    public Button buyButton;   // Button to buy the skill

    private bool isPurchased = false;  // Flag to track if the skill is purchased

    private void Start()
    {
        // Initialize the button text and click event
        UpdateUI();
        buyButton.onClick.AddListener(BuySkill);
    }

    private void BuySkill()
    {
        if (!isPurchased && BuyButtonControl.Instantiate.CanAfford(skillCost))
        {
            // Deduct the cost from the player's resources
            BuyButtonControl.instance.SpendResources(skillCost);

            // Implement skill effect here (e.g., unlock an ability)

            // Mark the skill as purchased
            isPurchased = true;

            // Update the UI
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if (isPurchased)
        {
            // Skill has been purchased
            costText.text = "Purchased";
            buyButton.interactable = false;
        }
        else
        {
            // Skill is available for purchase
            costText.text = "Cost: " + skillCost.ToString();
            buyButton.interactable = BuyButtonControl.instance.CanAfford(skillCost);
        }
    }
}
*/