using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInfo : MonoBehaviour
{
	public static int Money;
	public int startMoney = 100;

	public static int Lives;
	public int startLives = 5;

	public static int Rounds;

	void Start()
	{
		Money = startMoney;
		Lives = startLives;

		Rounds = 0;
	}

}
