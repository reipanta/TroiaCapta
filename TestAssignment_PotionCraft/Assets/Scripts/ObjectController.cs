using System;
using System.Collections.Generic;
using Data;
using EventSystem;
using GameServices.Input;
using Interactables.IngredientSpawners;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

// This class controls ingredient spawning and also registers them upon being thrown into the pot 
public class ObjectController : MonoBehaviour
{
    public static ObjectController Instance; // Singleton pattern 

    private Ingredient _ingredient;

    public List<Ingredient> ingredientsInThePot = new List<Ingredient>();

    private void OnEnable()
    {
        GameEvent.Ingredients.OnThrownToPot?.AddListener(AddToListOfIngredients);
    }

    private void OnDisable()
    {
        GameEvent.Ingredients.OnThrownToPot?.RemoveListener(AddToListOfIngredients);
    }

    private void AddToListOfIngredients(Ingredient ingredient)
    {
        ingredientsInThePot.Add(ingredient);
        Debug.Log($"Ingredient {ingredient.Name} is now in the cooking pot");
    }

    public void InstantiateIngredient(Spawner spawnParameters)
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _ingredient = spawnParameters.CreateIngredient((Vector2)spawnPosition);

        Instantiate(_ingredient.IngredientPrefab, _ingredient.transform);
        Debug.Log($"Ingredient {_ingredient.Name} has exactly {_ingredient.Points} points to it!");
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}