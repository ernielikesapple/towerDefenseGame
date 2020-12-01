using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallControl : MonoBehaviour
{
	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	void Start()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (GameIsOver)
			return;

		if (playerInfo.Lives <= 0)
		{
			EndGame();
		}
	}

	void EndGame()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
		// todo: scene manager reload the scene
	}

	public void WinLevel()
	{
		GameIsOver = true;
		completeLevelUI.SetActive(true);
	}
}
