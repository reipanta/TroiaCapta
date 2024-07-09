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
        private MealData _highestScoreMeal;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _text.text = $"Лучшее блюдо: {_highestScoreMeal.Title} ({_highestScoreMeal.IngredientCountResult}) [{_highestScoreMeal.CurrentMealScore}]";
            // TODO: Make it event instead
        }

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
            var mealData = LastMeal.LastMealResult;
            
            MealData highestScoreMeal = mealData[0];

            foreach (var e in mealData)
            {
                if (e.CurrentMealScore > highestScoreMeal.CurrentMealScore)
                {
                    highestScoreMeal = e;
                }
            }

            _highestScoreMeal = highestScoreMeal;
        }
    }
}