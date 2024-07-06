using System;
using System.Collections.Generic;
using EventSystem;
using Interactables.IngredientSpawners;
using TMPro;
using UnityEngine;

namespace UI
{
    public class BestMeal : MonoBehaviour
    {
        private TMP_Text _text;
        private void OnEnable()
        {
            GameEvent.Ingredients.OnMealComplete?.AddListener(ShowBestMeal);
        }

        private void OnDisable()
        {
            GameEvent.Ingredients.OnMealComplete?.RemoveListener(ShowBestMeal);
        }

        void ShowBestMeal()
        {
            var mealIngredients = ObjectController.Instance.ingredientsInThePot;
        }
    }
}