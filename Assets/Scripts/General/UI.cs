using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text levelText;
    public GameObject completeLevelPanel;
    public GameObject winPanel;
    public GameObject losePanel;

    private void Start() {
        completeLevelPanel.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void SetLevel(int level) {
        levelText.text = "Level: " + level;
    }

    public void WinGame() {
        winPanel.SetActive(true);
    }

    public void CompleteLevel() {
        completeLevelPanel.SetActive(true);
    }

    public void NextLevel() {
        Grid.instance.NextLevel();

        completeLevelPanel.SetActive(false);
    }

    public void ToLevelOne() {
        Grid.instance.PlayLevelOne();

        winPanel.SetActive(false);
    }

    public void LoseLevel() {
        losePanel.SetActive(true);
    }

    public void RestartLevel() {
        Grid.instance.RestartLevel();
        losePanel.SetActive(false);
    }
}
