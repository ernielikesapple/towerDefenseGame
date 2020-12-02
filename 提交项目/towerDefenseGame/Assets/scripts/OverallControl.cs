using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverallControl : MonoBehaviour
{
	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;
	public GameObject optionsLevelUI;
	public GameObject menuUI;

	void Start()
	{
		GameIsOver = false;

		if (SceneManager.GetActiveScene().name == "level1") {
			playerInfo.notificationTextToDisplay = "Hint: buy the turret from the market and place it on the tile to defend your home";
			playerInfo.notificationTextToDisplayNotified = true;
		}
		
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
		Time.timeScale = 0f;
		gameOverUI.SetActive(true);
	}

	public void WinLevel()
	{
		GameIsOver = true;
		completeLevelUI.SetActive(true);
	}

	public void MenuButtonClicked() {

		menuUI.SetActive(!menuUI.activeSelf);

		if (menuUI.activeSelf)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	public void newGame()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("level1");
	}

	public void ContinueGame()
	{
		menuUI.SetActive(!menuUI.activeSelf);

		if (menuUI.activeSelf)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	public void OptionButtonClicked()
	{
		optionsLevelUI.SetActive(true);

	}

	public void ExitGame()
	{
		Application.Quit();

	}

}
