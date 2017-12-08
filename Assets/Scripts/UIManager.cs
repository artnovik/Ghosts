using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    //Private
    private GameObject ButtonPlay,
                       ButtonMenu,
                       ButtonRestart,
                       ButtonExit;
    public Text NumberOfGhostsText, ScoreText;

    //Public
    public int Score = 0;

	// Use this for initialization
	private void Start () {
        Time.timeScale = 1;
        ButtonPlay = GameObject.Find("ButtonPlay");
        ButtonMenu = GameObject.Find("ButtonMenu");
        ButtonRestart = GameObject.Find("ButtonRestart");
        ButtonExit = GameObject.Find("ButtonExit");

        NumberOfGhostsText = GameObject.Find("NumberOfGhostsText").GetComponent<Text>();
        ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();

        ButtonRestart.SetActive(false);
        ButtonExit.SetActive(false);
    }

    public void Play()
    {
        GameObject.Find("Ghosts").GetComponent<GhostsManager>().CreateGhost();
        NumberOfGhostsText.text = "Ghosts: " + GameObject.Find("Ghosts").GetComponent<GhostsManager>().numberOfGhosts;
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        ButtonPlay.SetActive(false);
        ButtonMenu.SetActive(false);
        Time.timeScale = 0;

        ButtonRestart.SetActive(true);
        ButtonExit.SetActive(true);
    }
}
