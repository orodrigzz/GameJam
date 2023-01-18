using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("Fila");

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 30f;
        for (int i = 0; i < 10; i++) {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            //RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();    
            //entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankStr;
            switch (rank)
            {
                default:
                    rankStr = rank + "º"; break;

                case 1: rankStr = "1º"; break;
                case 2: rankStr = "2º"; break;
                case 3: rankStr = "3º"; break;


            }
            entryTransform.Find("posText").GetComponent<Text>().text = rankStr;

            int score = Random.Range(0, 1000);

            entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

            string name = "AAA";
            entryTransform.Find("nameText").GetComponent<Text>().text = name;

        }
    }

}
