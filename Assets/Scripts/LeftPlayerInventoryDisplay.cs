using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeftPlayerInventoryDisplay : MonoBehaviour
{
    public GameObject rightPlayer;
    public Image leftBonusShootPlaceholder;
    public Image leftMalusShootPlaceholder;
    public Image rightBonusShootPlaceholder;
    public Image rightMalusShootPlaceholder;
    public Image rightBonusFreezePlaceholder;
    public Sprite BonusShoot;
    public Sprite BonusShootDisable;
    public GameObject LeftBonusShootActive;
    public GameObject RightBonusShootActive;
    public Sprite MalusShoot;
    public Sprite MalusShootDisable;
    public GameObject LeftMalusShootActive;
    public GameObject RightMalusShootActive;
    public Sprite BonusFreeze;
    public GameObject LeftBonusFreezeActive;

    //public TMP_Text inventoryText;
    //private string newInventoryText;

    public void OnChangeInventory(Dictionary<PickUp.PickUpType, int> inventory) 
    {
        //inventoryText.text = "";
        //newInventoryText = "carrying: ";
        //int numItems = inventory.Count;

        foreach (var item in inventory) {
            //int itemTotal = item.Value;
            //string description = item.Key.ToString();
            //newInventoryText += " [ " + description + " " + itemTotal + " ] ";

            if (item.Key.ToString() == "bonusShoot") {
                if (RightMalusShootActive.activeSelf == false) {
                    leftBonusShootPlaceholder.sprite = BonusShoot;
                    LeftBonusShootActive.SetActive(true);
                } else {
                    leftMalusShootPlaceholder.sprite = MalusShootDisable;
                    RightMalusShootActive.SetActive(false);
                }
            }
                
            if (item.Key.ToString() == "malusShoot") {
                if (RightBonusShootActive.activeSelf == false) {
                    rightMalusShootPlaceholder.sprite = MalusShoot;
                    LeftMalusShootActive.SetActive(true);
                } else {
                    rightBonusShootPlaceholder.sprite = BonusShootDisable;
                    RightBonusShootActive.SetActive(false);
                }
            }
                
            if (item.Key.ToString() == "bonusFreeze") {
                rightBonusFreezePlaceholder.sprite = BonusFreeze;
                LeftBonusFreezeActive.SetActive(true);
            }
        }
        //if (numItems < 1)
        //newInventoryText = "(empty inventory)";
        //inventoryText.text = newInventoryText;
        
        inventory.Clear();
    }
}
