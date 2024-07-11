using System.Collections.Generic;
using EventSystem;
using Interactables.IngredientSpawners;
using UnityEngine;


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
    }

    public void InstantiateIngredient(Spawner spawnParameters)
    {
        Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _ingredient = spawnParameters.CreateIngredient((Vector2)spawnPosition);

        Instantiate(_ingredient.IngredientPrefab, _ingredient.transform);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}