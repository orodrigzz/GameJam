using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class UI_Testing : MonoBehaviour {

    [SerializeField] private HighscoreTable highscoreTable;

    //InputName
    public GameObject InputName;
    public GameObject submit;

    private void Start() {
        transform.Find("submitScoreBtn").GetComponent<Button_UI>().ClickFunc = () => {
            UI_Blocker.Show_Static();

                UI_InputWindow.Show_Static("Player Name", "", "ABCDEFGIHJKLMNOPQRSTUVXYWZabcdefgihjklmnopqrstuvxywz", 10, () => { 
                    UI_Blocker.Hide_Static();
                }, (string nameText) => { 
                    UI_Blocker.Hide_Static();
                   
                    PlayerPrefs.SetString("name", nameText);
                    PlayerPrefs.Save();

                    InputName.SetActive(false);
                    submit.SetActive(false);
                    Time.timeScale = 1f;
                });
        };
    }
}
