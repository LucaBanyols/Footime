using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RightPlayerInventoryDisplay : MonoBehaviour
{
    public GameObject leftPlayer;
    public Image rightBonusShootPlaceholder;
    public Image rightMalusShootPlaceholder;
    public Image leftBonusShootPlaceholder;
    public Image leftMalusShootPlaceholder;
    public Image leftBonusFreezePlaceholder;
    public Sprite BonusShoot;
    public Sprite BonusShootDisable;
    public GameObject RightBonusShootActive;
    public GameObject LeftBonusShootActive;
    public Sprite MalusShoot;
    public Sprite MalusShootDisable;
    public GameObject RightMalusShootActive;
    public GameObject LeftMalusShootActive;
    public Sprite BonusFreeze;
    public GameObject RightBonusFreezeActive;

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
                if (LeftMalusShootActive.activeSelf == false) {
                    rightBonusShootPlaceholder.sprite = BonusShoot;
                    RightBonusShootActive.SetActive(true);
                } else {
                    rightMalusShootPlaceholder.sprite = MalusShootDisable;
                    LeftMalusShootActive.SetActive(false);
                }
            }
                
            if (item.Key.ToString() == "malusShoot") {
                if (LeftBonusShootActive.activeSelf == false) {
                    leftMalusShootPlaceholder.sprite = MalusShoot;
                    RightMalusShootActive.SetActive(true);
                } else {
                    leftBonusShootPlaceholder.sprite = BonusShootDisable;
                    LeftBonusShootActive.SetActive(false);
                }
            }
                
            if (item.Key.ToString() == "bonusFreeze") {
                leftBonusFreezePlaceholder.sprite = BonusFreeze;
                RightBonusFreezeActive.SetActive(true);
            }
        }
        //if (numItems < 1)
        //newInventoryText = "(empty inventory)";
        //inventoryText.text = newInventoryText;
        
        inventory.Clear();
    }
}
