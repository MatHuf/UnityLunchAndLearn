using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ClickerAssets/UpgradesList")]

public class UpgradesList : ScriptableObject
{
    public List<Purchasable> upgrades = new List<Purchasable>();
}
