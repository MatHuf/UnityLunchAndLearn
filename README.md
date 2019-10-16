# Unity_Lunch_n_Learn

## Purpose

Provide a high-level overview of Unity and demonstrate the basics of creating a game.

## Plan

1. Overview
 - What is Unity
 - What can you do with Unity
 - What we'll cover
 - Game demo

2. Project setup and Editor basics
 - Unity Editor overview
 - Project and Scenes
 - Hierarchy
 - Scene
 - Inspector
 - Folder structure
 - GameObjects and MonoBehaviour
 - MonoBehavior lifecycle methods
 - Script execution order
 - ScriptableObjects
 - Serialized fields (for editor)

3. Game Code
 - Game Controller
 - UI Controller
 - Components
 - UnityEvents and C# Events

4. Game Setup in Editor
 - Structuring Prefabs
 - Swapping models
 - Resources
 - Materials

5. Builds
 - Build targets
 - Debugging

6. Wrap Up

## Game

A vary simple clicker (or idle) game where the player clicks on objects to earn points that can be spent to purchase more clickers.

### Gameplay

The player clicks on objects to gain points. Clicker objects have a cool down before they can be clicked again. Points can be spent on additional clicker objects.

### Game Architecture

#### Controllers

##### Game Controller

Responsible for handling click and purchase events. Instantiates new clicker gameobjects and subscribes to their events. Fires an event when the score changes.

##### UI Controller

Handles hide/show updgrade menu and score change events.

#### Components

##### Clicker

Attached to a prefab gameobject that has a collider and mesh renderer. Clickers fire events on mouse down then change the material of the mesh renderer to appear inactive. Once clicked, a timer starts inside an Update method. The clicker sets the material back to the active color when the timer reaches the reset interval.

##### Purchase Menu

Gets the available upgrades from resources, then instantiates menu buttons in the UI panel for each upgrade.

##### Purchase Button

Attached to a button prefab. Has a reference to a clicker prefab that is passed with the event from on click. Subscribes to score update events so it can enable/disable based on the current score.

#### Utilities

##### Clicker Placement Positions

A utility class that has hard coded clicker positions (as Vector3) and a method for returning the next position.

#### Scriptable Objects

##### Purchasable

Defines an upgrade.

##### Upgrades List

A list of purchasables that will be loaded from resources by PurchaseMenu.

#### Events

##### Int Event

Extends UnityEvent to pass an int with the event. Used by score change and click events.

##### Int GameObject Event

Extends UnityEvent to pass an int and a gameobject. Used by purchase event.
