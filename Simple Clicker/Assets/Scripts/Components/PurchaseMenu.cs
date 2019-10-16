using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseMenu : MonoBehaviour
{
    [SerializeField] GameObject buttonPrefab = default;
    [SerializeField] string upgradesListResourcePath = default;
    Transform buttonGroup = default;
    UIController uc = default;

    #region MonoBehaviour
    void Awake()
    {
        // Get the upgrades list from settings
        var purchasables = Resources.Load<UpgradesList>(upgradesListResourcePath);

        if (purchasables == null)
        {
            Debug.Log($"Unable to find upgrades list in {upgradesListResourcePath}");
            return;
        }

        // Get the UIController and VerticalLayoutGroup transform
        uc = GetComponentInParent<UIController>();
        buttonGroup = GetComponentInChildren<VerticalLayoutGroup>().transform;

        // Create the menu buttons
        foreach (var upgrade in purchasables.upgrades)
        {
            CreatePurchaseButton(upgrade);
        }
    }
    #endregion

    #region Private
    void CreatePurchaseButton(Purchasable upgrade)
    {
        // Create button GameObject
        var purchaseButton = GameObject.Instantiate(buttonPrefab, Vector3.zero, Quaternion.identity, buttonGroup);
        purchaseButton.GetComponent<PurchaseButton>().upgrade = upgrade;

        // Setup OnClick listener so the panel is hidden after purchase
        purchaseButton.GetComponent<Button>().onClick.AddListener(uc.ToggleUpgradesPanel);

        // Set the GameObject name
        purchaseButton.name = $"{upgrade.label} Button";
    }
    #endregion
}
