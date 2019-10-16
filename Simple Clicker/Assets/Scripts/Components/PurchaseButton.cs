using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class PurchaseButton : MonoBehaviour
{
    public Purchasable upgrade;
    int price = 0;
    float priceMultiplier = 1.5f;
    GameObject prefab = default;
    string label = default;
    IntGameObjectEvent purchased;
    Button button = default;
    Text buttonText = default;
    UnityAction<int> UpdateScore;

    #region  MonoBehaviour
    // Start is called before the first frame update
    void Start()
    {
        Init();
        UpdateButtonLabel();
        button.interactable = false;

        UpdateScore += CheckPurchasable;

        GameController gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        purchased.AddListener(gc.Purchase);
        gc.scoreChanged.AddListener(UpdateScore);
    }

    #endregion

    #region Public
    public void Purchase()
    {
        purchased.Invoke(price, prefab);
        price = Mathf.RoundToInt(price * priceMultiplier);
        UpdateButtonLabel();
    }
    #endregion

    #region  Private
    void Init()
    {
        if (purchased == null) purchased = new IntGameObjectEvent();
        button = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();

        if (upgrade == null)
        {
            Debug.Log("Button created but not provided purchasable definition");
            return;
        }

        price = upgrade.price;
        priceMultiplier = upgrade.priceMultiplier;
        prefab = upgrade.prefab;
        label = upgrade.label;
    }

    void CheckPurchasable(int points)
    {
        button.interactable = points - price > -1;
    }

    void UpdateButtonLabel()
    {
        buttonText.text = $"{label} ({price})";
    }
    #endregion
}
