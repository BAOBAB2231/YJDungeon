using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ConsumableType
{
    Health,
    SpeedUp
}

[Serializable]
public class ItemDataConsumbale
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public GameObject dropPrefab;

    [Header("Consumable")]
    public ItemDataConsumbale[] consumables;
}
