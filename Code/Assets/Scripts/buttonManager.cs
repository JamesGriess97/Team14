using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour {

	public Button startButton;
	public Button exitButton;

    void Start()
    {
        Button startBtn = startButton.GetComponent<Button>();
		Button exitBtn = exitButton.GetComponent<Button>();
        startBtn.onClick.AddListener(startClick);
		exitBtn.onClick.AddListener(quitClick);
    }

    void startClick()
    {
		SceneManager.LoadScene("Main");
        Debug.Log("You have clicked the button!");
    }

	void quitClick() {
		Debug.Log("exit");
        //Application.Quit();
         #if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
	}
}
