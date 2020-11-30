using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class playerInfo : MonoBehaviour
{
	public static int Money;
	public int startMoney = 100;
	public Text currentMoneyText;


	public static int Lives;
	public int startLives = 5;

	public static int Rounds;

	void Start()
	{
		Money = startMoney;
		Lives = startLives;

		Rounds = 0;
	}

    void Update()
    {
		currentMoneyText.text = "$: " + Money.ToString();

	}

}
