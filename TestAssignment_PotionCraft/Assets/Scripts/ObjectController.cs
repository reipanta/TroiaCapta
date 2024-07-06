using System;
using System.Collections.Generic;
using Data;
using EventSystem;
using GameServices.Input;
using Interactables.IngredientSpawners;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectController : MonoBehaviour
{
    public static ObjectController Instance; // Singleton pattern 
    private Ingredient _ingredient; // Holder for the returned value taken from Spawner in the InstantiateIngredient method
    
    public List<Ingredient> spawnedIngredients = new List<Ingredient>();
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
    
    // This method instantiates a prefab with data from Spawner attached to it as parent
    public void InstantiateIngredient(Spawner spawnParameters)
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Get current mouse position
       _ingredient = spawnParameters.CreateIngredient((Vector2)spawnPosition); // Create a holder for ingredient on a mouseclick
      
       // Create a prefab that is a child object of a holder created on the previous step 
        Instantiate(_ingredient.IngredientPrefab, _ingredient.transform); 
        
        Debug.Log($"Ingredient {_ingredient.Name} has exactly {_ingredient.Points} points to it!");
    }
    
    // In this Awake() method we make there's only one instance of this singleton
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}