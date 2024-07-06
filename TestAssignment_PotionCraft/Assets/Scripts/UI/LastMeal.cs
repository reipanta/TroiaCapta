using System;
using System.Linq;
using System.Collections.Generic;
using EventSystem;
using Interactables.IngredientSpawners;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LastMeal : MonoBehaviour
    {
        private TMP_Text _text;
        private string mealTitle = "";

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _text.text = $"Последнее блюдо: {mealTitle} [{Score.CurrentMealScore}]";
        }

        private void OnEnable()
        {
            GameEvent.Ingredients.OnMealComplete?.AddListener(ShowLastMeal);
        }

        private void OnDisable()
        {
            GameEvent.Ingredients.OnMealComplete?.RemoveListener(ShowLastMeal);
        }

        void ShowLastMeal()
        {
            var mealIngredients = ObjectController.Instance.ingredientsInThePot;

            var meat = CheckForMeat(mealIngredients);
            var onion = CheckForOnion(mealIngredients);
            var potato = CheckForPotato(mealIngredients);

            if (meat != "Суп" && meat != "Овощное рагу")
            {
                mealTitle = meat;
            }
            else if (onion != "Суп")
            {
                mealTitle = onion;
            }
            else if (potato != "Суп")
            {
                mealTitle = potato;
            }
            else if (onion == "Суп" &&
                     potato == "Суп")
            {
                mealTitle = "Овощное рагу";
            }
            else
            {
                mealTitle = "Суп";
            }

            var ingredientCounts = mealIngredients.GroupBy(i => i.Name)
                .Select(group => new
                {
                    Name = group.Key,
                    Count = group.Count()
                })
                .ToList();

            Debug.Log($"{ingredientCounts}");
        }

        private string CheckForMeat(List<Ingredient> ingredients)
        {
            string meatString = "Мясо";
            int meatCounter = ingredients.Count(i => i.Name == meatString);

            switch (meatCounter)
            {
                case 5:
                    mealTitle = "Мясо в собственном соку";
                    break;
                case 4:
                    mealTitle = "Мясо с гарниром";
                    break;
                case 2 or 3:
                    mealTitle = "Рагу";
                    break;
                case 0:
                    mealTitle = "Овощное рагу";
                    break;
                default:
                    mealTitle = "Суп";
                    break;
            }

            return mealTitle;
        }

        private string CheckForOnion(List<Ingredient> ingredients)
        {
            string onionString = "Лук";
            int onionCounter = ingredients.Count(i => i.Name == onionString);

            switch (onionCounter)
            {
                case 4 or 5:
                    mealTitle = "Луковый суп";
                    break;
                default:
                    mealTitle = "Суп";
                    break;
            }

            return mealTitle;
        }

        private string CheckForPotato(List<Ingredient> ingredients)
        {
            string potatoString = "Картофель";
            int potatoCounter = ingredients.Count(i => i.Name == potatoString);

            switch (potatoCounter)
            {
                case 4 or 5:
                    mealTitle = "Картофельное пюре";
                    break;
                default:
                    mealTitle = "Суп";
                    break;
            }

            return mealTitle;
        }
    }
}