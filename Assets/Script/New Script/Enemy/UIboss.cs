using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIboss : MonoBehaviour
{
	public Boss bossHealth;
	public Slider slider;

	void Start()
	{

		slider.maxValue = bossHealth.maxHP;

	}

	// Update is called once per frame
	void Update()
	{
		slider.value = bossHealth.currentHP;

	}
}