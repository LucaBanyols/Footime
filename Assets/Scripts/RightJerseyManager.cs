using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RightJerseyManager : MonoBehaviour
{
    public JerseyDatabase jerseyDB;
    public SpriteRenderer sr;
    private int selectedJersey = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("RightSelectedJersey")) {
            selectedJersey = 0;
        } else {
            Load();
        }
        UpdateJersey(selectedJersey);
    }

    public void NextOption()
    {
        selectedJersey++;

        if (selectedJersey >= jerseyDB.JerseyCount) {
            selectedJersey = 0;
        }

        UpdateJersey(selectedJersey);
        Save();
    }

    public void BackOption()
    {
        selectedJersey--;

        if (selectedJersey < 0) {
            selectedJersey = jerseyDB.JerseyCount - 1;
        }

        UpdateJersey(selectedJersey);
        Save();
    }

    private void UpdateJersey(int selectedJersey)
    {
        Jersey jersey = jerseyDB.GetJersey(selectedJersey);
        sr.sprite = jersey.jerseySprite;
    }

    private void Load()
    {
        selectedJersey = PlayerPrefs.GetInt("RightSelectedJersey");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("RightSelectedJersey", selectedJersey);
    }
}
