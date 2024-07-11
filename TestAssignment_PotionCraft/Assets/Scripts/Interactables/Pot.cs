using System.Collections.Generic;
using EventSystem;
using Interactables.IngredientSpawners;
using UnityEngine;

namespace Interactables
{
    // Controlling the pot and logic that is bound to it
    public class Pot : MonoBehaviour
    {
        private List<Ingredient> _ingredientsInThePot = new List<Ingredient>();
        public static Ingredient IngredientToPassToIcon { get; set; }

        private void Start()
        {
            _ingredientsInThePot = ObjectController.Instance.ingredientsInThePot;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            Ingredient ingredient = other.gameObject.GetComponentInParent<Ingredient>();

            IngredientToPassToIcon = ingredient;

            GameEvent.Ingredients.OnThrownToPot?.Invoke(ingredient);

            if (_ingredientsInThePot.Count == 5)
            {
                CreateMeal();
                _ingredientsInThePot.Clear();

                ObjectController.Instance.ingredientsInThePot = _ingredientsInThePot;
            }

            Destroy(ingredient.gameObject);
        }

        void CreateMeal()
        {
            GameEvent.Ingredients.OnMealComplete?.Invoke();
        }
    }
}