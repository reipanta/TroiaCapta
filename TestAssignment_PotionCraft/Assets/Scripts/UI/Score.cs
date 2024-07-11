using System;
using System.Linq;
using EventSystem;
using TMPro;
using UnityEngine;

namespace UI
{
    // This class is used to set score and update UI accordingly
    public class Score : MonoBehaviour
    {
        public static float CurrentMealScore;
        private TMP_Text _text;
        private float _totalScore = 0;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            GameEvent.Ingredients.OnMealComplete?.AddListener(CalculateScore);
        }

        private void OnDisable()
        {
            GameEvent.Ingredients.OnMealComplete?.RemoveListener(CalculateScore);
        }

        private void CalculateScore()
        {
            CurrentMealScore = 0;

            var mealIngredients = ObjectController.Instance.ingredientsInThePot;

            var ingredientCounts = mealIngredients
                .GroupBy(ingredient => ingredient.Name)
                .ToDictionary(group => group.Key, group => group.Count());

            foreach (var ingredient in mealIngredients)
            {
                int count = ingredientCounts[ingredient.Name];
                float multiplier = GetMultiplier(count, ingredientCounts.Count);
                CurrentMealScore += ingredient.Points * multiplier;
            }

            _totalScore += CurrentMealScore;

            _text.text = $"Счет: {Convert.ToInt32(_totalScore)}";
        }

        private float GetMultiplier(int count, int uniqueIngredientCount)
        {
            if (uniqueIngredientCount == count)
            {
                return 2.0f;
            }

            switch (count)
            {
                case 2:
                    return 2.0f;
                case 3:
                    return 1.5f;
                case 4:
                    return 1.25f;
                case 5:
                    return 1.0f;
                default:
                    return 1.0f;
            }
        }
    }
}