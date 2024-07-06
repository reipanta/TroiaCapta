using System;
using System.Collections.Generic;
using Data;
using EventSystem;
using Interactables.IngredientSpawners;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

namespace Interactables
{
    public class Pot : MonoBehaviour
    {
        private List<Ingredient> _ingredientsInThePot = new List<Ingredient>();
        public static Ingredient IngredientToPassToIcon { get; set; }

        private void Start()
        {
            // Every new ingredient thrown into the pot triggers an update to the variable 
            _ingredientsInThePot = ObjectController.Instance.ingredientsInThePot;
        }

        // Ingredient reacts with the trigger collider2D on the pot
        void OnTriggerEnter2D(Collider2D other)
        {
            // Get the parent object (the one that has Ingredient.cs with all the data attached) of the ingredient prefab
            Ingredient ingredient = other.gameObject.GetComponentInParent<Ingredient>();

            // Using this property to have access to the thrown ingredient in the AboveThePotUI class
            IngredientToPassToIcon = ingredient;

            // Invoke the event that triggers every time the ingredient is added to the pot
            GameEvent.Ingredients.OnThrownToPot?.Invoke(ingredient);

            if (_ingredientsInThePot.Count == 5)
            {
                // If there are 5 ingredients in the pot invoke an event OnMealComplete
                CreateMeal();

                // Clear the list of ingredients in the pot
                _ingredientsInThePot.Clear();
                ObjectController.Instance.ingredientsInThePot =
                    _ingredientsInThePot; // Assign the new 0 value to the ObjectController
            }

            Destroy(ingredient.gameObject); // Destroy the thrown ingredient
        }

        void CreateMeal()
        {
            GameEvent.Ingredients.OnMealComplete?.Invoke();

            Debug.Log("MEAL IS READY MOTHERFUCKER");
        }
    }
}