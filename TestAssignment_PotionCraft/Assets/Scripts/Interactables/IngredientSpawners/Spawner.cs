using System;
using System.Text;
using Data;
using GameServices.Input;
using UnityEngine;

namespace Interactables.IngredientSpawners
{
    // Spawner, Ingredient and ObjectController classes
    // represent a Factory pattern that spawns appropriate Products
    public class Spawner : MonoBehaviour
    {
        // This SerializeField has a ScriptableObject attached in the inspector
        // There are 5 spawners on the scene and each has a different SO asset
        [SerializeField] private IngredientsData ingredientsData;
        private Ingredient _ingredient;

        // This public method provides an interface for the created ingredient 
        // Vector3 position parameter is needed to spawn objects at mouse position
        // It also assigns data to the new object via AssignData();
        public Ingredient CreateIngredient(Vector3 position)
        {
            InitializeIngredient();
            _ingredient.transform.position = position;
            return _ingredient;
        }

        // Creates a new GameObject and assigns
        // corresponding ScriptableObject data to an ingredient
        public void InitializeIngredient()
        {
            _ingredient = new GameObject("IngredientHolder").AddComponent<Ingredient>();
            _ingredient.Name = ingredientsData.name;
            _ingredient.Points = ingredientsData.points;
            _ingredient.IngredientPrefab = ingredientsData.ingredientPrefab;
        }

        // Spawns an ingredient object by calling a singleton method
        // and providing current spawner's data as a parameter
        private void OnMouseDown()
        {
            // Temporary switch off the collider of the spawner
            // to get rid of newly spawned ingredients' physics bugs and flickering
            GetComponent<Collider2D>().enabled = false;

            // Spawn initialized ingredient from the ObjectController class
            ObjectController.Instance.InstantiateIngredient(this); 
        }

        private void OnMouseUp()
        {
            // Switch the collider back again after spawning the ingredient
            GetComponent<Collider2D>().enabled = true;
        }
    }
}