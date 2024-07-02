using System;
using System.Collections.Generic;
using IngredientSpawners.Ingredients;
using IngredientSpawners.Spawners;
using UnityEditor;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public static ObjectController Instance;

    private List<GameObject> _currentIngredients;
    private IIngredient _ingredient;
    private GameObject _gameobject;

    public void SpawnGameObject(ISpawner spawner)
    {
        _ingredient = spawner.Spawn();
        Instantiate(_ingredient.IngredientsData.ingredientPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = new ObjectController();
    }
}