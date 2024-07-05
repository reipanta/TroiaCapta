using System;
using System.Collections.Generic;
using Data;
using EventSystem;
using GameServices.Input;
using Interactables.IngredientSpawners;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectController : MonoBehaviour
{
    public static ObjectController Instance; // Singleton pattern 
    private Ingredient _ingredient;
    public List<IngredientsData> spawnedIngredients = new List<IngredientsData>();

    public List<IngredientsData> ingredientsInThePot = new List<IngredientsData>();

    private void OnEnable()
    {
        GameEvent.Ingredients.OnThrownToPot.AddListener(AddToListOfIngredients);
    }

    private void OnDisable()
    {
        //GameEvent.Ingredients.OnThrownToPot += AddToListOfIngredients;
    }

    private void AddToListOfIngredients(IngredientsData ingredientsData)
    {
        ingredientsInThePot.Add(ingredientsData);
        Debug.Log($"Ingredient {ingredientsData.name} is now in the cooking pot");
    }

    // This method is called from a Spawner
    public void Spawn(Spawner spawner)
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _ingredient =
            spawner.GetIngredient(); // Calling a spawner method to return a certain ingredient with initialized values
        Instantiate(_ingredient.IngredientPrefab, (Vector2)spawnPosition, Quaternion.identity); // Spawning!
        spawnedIngredients.Add(_ingredient._ingredientsData);
        Debug.Log($"Ingredient {_ingredient.Name} has exactly {_ingredient.Points} points to it!");
    }

    // In this Awake() method 
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}