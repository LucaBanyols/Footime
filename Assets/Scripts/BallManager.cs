using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallManager : MonoBehaviour
{
    public JerseyDatabase ballDB;
    public SpriteRenderer sr;
    private int selectedBall = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("SelectedBall")) {
            selectedBall = 0;
        } else {
            Load();
        }
        UpdateBall(selectedBall);
    }

    public void NextOption()
    {
        selectedBall++;

        if (selectedBall >= ballDB.JerseyCount) {
            selectedBall = 0;
        }

        UpdateBall(selectedBall);
        Save();
    }

    public void BackOption()
    {
        selectedBall--;

        if (selectedBall < 0) {
            selectedBall = ballDB.JerseyCount - 1;
        }

        UpdateBall(selectedBall);
        Save();
    }

    private void UpdateBall(int selectedBall)
    {
        Jersey ball = ballDB.GetJersey(selectedBall);
        sr.sprite = ball.jerseySprite;
    }

    private void Load()
    {
        selectedBall = PlayerPrefs.GetInt("SelectedBall");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("SelectedBall", selectedBall);
    }
}
