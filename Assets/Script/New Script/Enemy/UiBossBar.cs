using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBossBar : MonoBehaviour
{
	public BossHealth bossHealth;
	public Slider slider;

	/*void Start()
	{
		slider.maxValue = bossHealth.health;
		slider.value = bossHealth.health;
	}

	// Update is called once per frame
	void Update()
	{
		slider.value = bossHealth.health;
	}/*/

	public void SetMaxHealth(int health)
    {
		slider.maxValue = bossHealth.health;
		slider.value = bossHealth.health;
	}

	public void SetHealth(int health)
	{
		slider.value = bossHealth.health;
	}
}