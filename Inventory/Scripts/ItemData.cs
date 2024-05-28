using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData")]
public class ItemData : ScriptableObject
{
    public int ID;
    public string itemName;
    public string itemDescription;
    public GameObject prefab;
    public Sprite Icon;
    public Color IconColour;
    public bool contraband;
}
