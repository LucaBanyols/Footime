using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public enum PickUpType {
        bonusShoot,
        malusShoot,
        bonusFreeze
    }

    public PickUpType type;
}
