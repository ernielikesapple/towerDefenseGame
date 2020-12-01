using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class playerInfo : MonoBehaviour
{
	public static int Money;
	public static string notificationTextToDisplay;
	public static bool notificationTextToDisplayNotified = false;
	public int startMoney = 100;
	public Text currentMoneyText;
	public Text notificationText;
	// todo : track the current level text
	public Text remainingLivesText;

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
		if (notificationTextToDisplayNotified) {
			StartCoroutine(ShowMessage(notificationTextToDisplay, 3));
			notificationTextToDisplayNotified = false;
		}

		remainingLivesText.text = Lives.ToString();
	}

	IEnumerator ShowMessage(string message, float delay)
	{
		notificationText.text = message;
		yield return new WaitForSeconds(delay);
		notificationText.text = "";
	}

}
