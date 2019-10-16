using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ClickerAssets/Purchasable")]
public class Purchasable : ScriptableObject
{
    public int price = 0;
    public float priceMultiplier = 1.5f;
    public GameObject prefab = default;
    public string label = default;
}
