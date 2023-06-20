using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayer : MonoBehaviour
{
    public GameObject leftPlayer;
    public GameObject rightPlayer;
    public JerseyDatabase jerseyDB;
    public SpriteRenderer sr;
    public GameObject BonusShootActive;
    public GameObject MalusShootActive;
    public GameObject BonusFreezeActive;
    
    private LeftInventoryManager inventoryManager;
    private int selectedJersey = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("LeftSelectedJersey")) {
            selectedJersey = 0;
        } else {
            Load();
        }
        inventoryManager = GetComponent<LeftInventoryManager>();
        UpdateJersey(selectedJersey);
    }

    private void UpdateJersey(int selectedJersey)
    {
        Jersey jersey = jerseyDB.GetJersey(selectedJersey);
        sr.sprite = jersey.jerseySprite;
    }

    void OnTriggerEnter2D(Collider2D hit) 
    {
        if(hit.CompareTag("Pickup")) {
            PickUp item = hit.GetComponent<PickUp>();
            inventoryManager.Add(item);
            Destroy(hit.gameObject);
        }
    } 

    private void Load()
    {
        selectedJersey = PlayerPrefs.GetInt("LeftSelectedJersey");
    }

    void Update()
    {
        BonusShootActive.transform.position = leftPlayer.transform.position;
        MalusShootActive.transform.position = rightPlayer.transform.position;
        BonusFreezeActive.transform.position = rightPlayer.transform.position;
    }
}