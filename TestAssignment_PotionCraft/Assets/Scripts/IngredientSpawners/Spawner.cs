using Data;
using GameServices.Input;
using UnityEngine;

namespace IngredientSpawners
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
        // It also assigns data to the new object via AssignData();
        public Ingredient GetIngredient()
        {
            AssignData();
            return _ingredient;
        }

        // Assigns corresponding ScriptableObject data to an ingredient
        private void AssignData()
        {
            _ingredient = gameObject.AddComponent<Ingredient>();
            _ingredient.Initialize(ingredientsData);
        }

        // Spawns an ingredient object by calling a singleton method
        // and providing current spawner's data as a parameter
        private void OnMouseDown()
        {
            ObjectController.Instance.Spawn(this);
            
        }
    }
}