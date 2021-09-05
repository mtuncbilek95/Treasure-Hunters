using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerDataObject", menuName ="ScriptableObjects/Data/PlayerData/PlayerBaseData")]
public class PlayerDataScript : ScriptableObject
{
    [Range(0,20)]
    public int maximumSpeed, jumpSpeed;

    public float groundCheckLength;
    public int jumpCount = 1;

    [Range(0,1)]
    public float jumpMultiplier;

    public float weaponRadius;
}
