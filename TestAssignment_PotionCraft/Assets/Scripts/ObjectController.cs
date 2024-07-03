using System;
using System.Collections.Generic;
using IngredientSpawners;
using UnityEditor;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public static ObjectController Instance; // Singleton pattern 
    private Ingredient _ingredient;
    // TODO: add a List<Ingredient> that will store all objects spawned  

    // This method is called from a Spawner
    public void Spawn(Spawner spawner)
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _ingredient = spawner.GetIngredient(); // Calling a spawner method to return a certain ingredient with initialized values
        Instantiate(_ingredient.IngredientPrefab, (Vector2)spawnPosition, Quaternion.identity); // Spawning!
        Debug.Log($"Ingredient {_ingredient.Name} has exactly {_ingredient.Points} points to it!");
    }

    // In this Awake() method 
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}