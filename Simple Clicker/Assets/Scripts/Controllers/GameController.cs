using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public int points
    {
        get { return _points; }
        private set
        {
            _points = value;
            scoreChanged.Invoke(points);
        }
    }
    public IntEvent scoreChanged;
    public UnityAction<int, GameObject> Purchase;
    [SerializeField] GameObject startingClickerPrefab = default;
    int _points = 0;
    UnityAction<int> OnClick;
    ClickerPlacementPositions positions = new ClickerPlacementPositions();

    #region  MonoBehaviour
    // Start is called before the first frame update
    void Start()
    {
        if (scoreChanged == null) scoreChanged = new IntEvent();
        OnClick += GivePoints;
        Purchase += BuyClicker;

        // Add the starting clicker
        AddClicker(startingClickerPrefab);
    }
    #endregion

    #region  Event Handlers
    void GivePoints(int value)
    {
        points += value;
    }

    void BuyClicker(int cost, GameObject prefab)
    {
        if (points - cost < 0) return;

        SpendPoints(cost);
        AddClicker(prefab);
    }
    #endregion

    #region  Private
    void AddClicker(GameObject prefab)
    {
        var position = positions.GetNextPosition();
        if (position == null) return;

        // Create clicker at the position without rotation and make it a child of this gameObject
        var clicker = Instantiate<GameObject>(prefab, position.Value, Quaternion.identity, gameObject.transform)
            .GetComponent<Clicker>();

        // Subscribe to click event
        clicker.Clicked.AddListener(OnClick);

        // Set clicker value
        var maxBonus = Mathf.RoundToInt(clicker.clickValue * 0.75f);
        clicker.clickValue += UnityEngine.Random.Range(0, maxBonus);

        // Set interval for being able to click again
        var maxInterval = Mathf.RoundToInt(clicker.clickValue / 3);
        clicker.canClickResetInterval += UnityEngine.Random.Range(0, maxInterval);

        Debug.Log($"Creating new clicker with value {clicker.clickValue} and reset interval {clicker.canClickResetInterval}");
    }

    void SpendPoints(int value)
    {
        points = Mathf.Clamp(points - value, 0, int.MaxValue);
    }
    #endregion
}
