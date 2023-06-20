using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayer : MonoBehaviour
{
    public GameObject rightPlayer;
    public GameObject leftPlayer;
    public JerseyDatabase jerseyDB;
    public SpriteRenderer sr;
    public GameObject BonusShootActive;
    public GameObject MalusShootActive;
    public GameObject BonusFreezeActive;
    private RightInventoryManager inventoryManager;

    private int selectedJersey = 0;


    void Start()
    {
        if (!PlayerPrefs.HasKey("RightSelectedJersey")) {
            selectedJersey = 0;
        } else {
            Load();
        }
        inventoryManager = GetComponent<RightInventoryManager>();
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
        selectedJersey = PlayerPrefs.GetInt("RightSelectedJersey");
    }

    void Update()
    {
        BonusShootActive.transform.position = rightPlayer.transform.position;
        MalusShootActive.transform.position = leftPlayer.transform.position;
        BonusFreezeActive.transform.position = leftPlayer.transform.position;
    }
}