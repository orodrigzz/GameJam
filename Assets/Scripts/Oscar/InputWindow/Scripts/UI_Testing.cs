/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class UI_Testing : MonoBehaviour {

    [SerializeField] private HighscoreTable highscoreTable;

    private void Start() {
        transform.Find("submitScoreBtn").GetComponent<Button_UI>().ClickFunc = () => {
            UI_Blocker.Show_Static();

                UI_InputWindow.Show_Static("Player Name", "", "ABCDEFGIJKLMNOPQRSTUVXYWZabcdefgijklmnopqrstuvxywz", 10, () => { 
                    UI_Blocker.Hide_Static();
                }, (string nameText) => { 
                    UI_Blocker.Hide_Static();
                   
                    PlayerPrefs.SetString("name", nameText);
                    PlayerPrefs.Save();
                    //Quitar UI

                    //Cuando morir 
                    //highscoreTable.AddHighscoreEntry(GameManager._GAME_MANAGER.score,  PlayerPrefs.GetString("name"););

                });
        };
    }
}
