using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image manaImage;

    private int maxMana = 100;
    private int currentMana;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    public static ManaBar instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentMana = maxMana;
        UpdateManaBar();
    }

    public void UseMana(int amount)
    {
        if(currentMana - amount >= 0)
        {
            currentMana -= amount;
            UpdateManaBar();

            StartCoroutine(RegenMana());
        }
        else
        {
            Debug.Log("no mana");
        }
    }

    private void UpdateManaBar()
    {
        float fillAmount = (float)currentMana / maxMana;
        manaImage.fillAmount = fillAmount;
    }

    private IEnumerator RegenMana()
    {
        yield return new WaitForSeconds(15);

        while (currentMana < maxMana)
        {
            currentMana += maxMana / 100;
            UpdateManaBar();
            yield return regenTick;
        }
        /*yield return new WaitForSeconds(15);

        while (currentMana < maxMana)
        {
            currentMana += maxMana / 100;
            manaImage.fillAmount = currentMana;
            yield return regenTick;
        }*/
    }
}
