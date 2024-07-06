using System;
using System.Collections.Generic;
using EventSystem;
using Interactables.IngredientSpawners;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Score : MonoBehaviour
    {
        public static int CurrentMealScore;
        private TMP_Text _text;
        private int _totalScore = 0;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _text.text = $"Счет: {_totalScore}";
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
            foreach (var individualScore in mealIngredients)
            {
                CurrentMealScore += individualScore.Points;
            }

            // This is used for bonus points
            foreach (var individualScore in mealIngredients)
            {
            }

            _totalScore += CurrentMealScore;

            Debug.Log("This meal is marvelous!!!!!!!!!");
        }
    }
}