using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// BoxCollidoer is required for OnMouseDown
[RequireComponent(typeof(BoxCollider))]
public class Clicker : MonoBehaviour
{
    public IntEvent Clicked;
    public int clickValue = 5;
    public float canClickResetInterval = 2f;
    Renderer rendererComponent;
    Material canClickMaterial;
    Material disabledMaterial;
    bool canClick = true;
    float timer = 0f;

    #region MonoBehaviour
    // Need to initialize in Awake instead of Start as it's called when instantiating a prefab
    void Awake()
    {
        // Initialize
        if (Clicked == null) Clicked = new IntEvent();

        // BoxCollider component must be a trigger for OnMouseDown to work
        var collider = GetComponent<BoxCollider>();
        if (collider != null && !collider.isTrigger) collider.isTrigger = true;

        // Get the renderer from the model
        rendererComponent = GetComponentInChildren<Renderer>();

        // Load materials from resources
        canClickMaterial = Resources.Load<Material>("Materials/CanClick");
        disabledMaterial = Resources.Load<Material>("Materials/Disabled");

        // Set the initial material
        rendererComponent.material = canClickMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime is the amount of time between frames
        if (!canClick) timer += Time.deltaTime;

        if (timer >= canClickResetInterval)
        {
            timer = 0f;
            CanClick();
        }
    }

    void OnMouseDown()
    {
        if (!canClick) return;

        canClick = false;
        Clicked.Invoke(clickValue);
        rendererComponent.material = disabledMaterial;
    }
    #endregion

    #region  Private
    void CanClick()
    {
        canClick = true;
        rendererComponent.material = canClickMaterial;
    }
    #endregion
}
