using System;
using Data;
using IngredientSpawners.Ingredients;
using UnityEngine;

namespace IngredientSpawners.Spawners
{
    public class Spawner : MonoBehaviour, ISpawner
    {
        [SerializeField] private IngredientsData ingredientsData;
        private IIngredient _ingredient;

        public IIngredient Spawn()
        {
            _ingredient = new Ingredient(ingredientsData);
            AssignData();
            return _ingredient;
        }

        private void AssignData()
        {
            _ingredient.IngredientsData = ingredientsData;
        }

        private void OnMouseDown()
        {
            ObjectController.Instance.SpawnGameObject(this);
        }
    }
}