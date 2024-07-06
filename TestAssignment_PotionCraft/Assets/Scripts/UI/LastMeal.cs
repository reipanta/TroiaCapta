using System;
using System.Linq;
using System.Collections.Generic;
using EventSystem;
using Interactables.IngredientSpawners;
using TMPro;
using UnityEngine;
using Object = System.Object;

namespace UI
{
    public class LastMeal : MonoBehaviour
    {
        private TMP_Text _text;
        private string _mealTitle = "";
        private string _ingredientCountResult = "";

        public static List<MealData> LastMealResult = new List<MealData>();

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _text.text = $"Последнее блюдо: {_mealTitle} ({_ingredientCountResult}) [{Score.CurrentMealScore}]";
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
                _mealTitle = meat;
            }
            else if (onion != "Суп")
            {
                _mealTitle = onion;
            }
            else if (potato != "Суп")
            {
                _mealTitle = potato;
            }
            else if (onion == "Суп" &&
                     potato == "Суп")
            {
                _mealTitle = "Овощное рагу";
            }
            else
            {
                _mealTitle = "Суп";
            }

            var ingredientCounts = mealIngredients.GroupBy(i => i.Name)
                .Select(group => new
                {
                    Name = group.Key,
                    Count = group.Count()
                })
                .ToList();

            _ingredientCountResult = string.Join(", ", ingredientCounts.Select(ic => $"{ic.Count} {ic.Name}"));

            var data = new MealData().GetData(title: _mealTitle, _ingredientCountResult, Score.CurrentMealScore);
            LastMealResult.Add(data);
        }

        private string CheckForMeat(List<Ingredient> ingredients)
        {
            string meatString = "Мясо";
            int meatCounter = ingredients.Count(i => i.Name == meatString);

            switch (meatCounter)
            {
                case 5:
                    _mealTitle = "Мясо в собственном соку";
                    break;
                case 4:
                    _mealTitle = "Мясо с гарниром";
                    break;
                case 2 or 3:
                    _mealTitle = "Рагу";
                    break;
                case 0:
                    _mealTitle = "Овощное рагу";
                    break;
                default:
                    _mealTitle = "Суп";
                    break;
            }

            return _mealTitle;
        }

        private string CheckForOnion(List<Ingredient> ingredients)
        {
            string onionString = "Лук";
            int onionCounter = ingredients.Count(i => i.Name == onionString);

            switch (onionCounter)
            {
                case 4 or 5:
                    _mealTitle = "Луковый суп";
                    break;
                default:
                    _mealTitle = "Суп";
                    break;
            }

            return _mealTitle;
        }

        private string CheckForPotato(List<Ingredient> ingredients)
        {
            string potatoString = "Картофель";
            int potatoCounter = ingredients.Count(i => i.Name == potatoString);

            switch (potatoCounter)
            {
                case 4 or 5:
                    _mealTitle = "Картофельное пюре";
                    break;
                default:
                    _mealTitle = "Суп";
                    break;
            }

            return _mealTitle;
        }
    }
}