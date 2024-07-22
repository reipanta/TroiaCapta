using System.Linq;
using System.Collections.Generic;
using EventSystem;
using Interactables.IngredientSpawners;
using TMPro;
using UnityEngine;


namespace UI
{
    // This class operates on the logic intended to show the last meal data to the UI 
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

            if (meat != "Mycenians")
            {
                _mealTitle = meat;
            }
            else if (onion != "Mycenians")
            {
                _mealTitle = onion;
            }
            else if (potato != "Mycenians")
            {
                _mealTitle = potato;
            }
            
            else
            {
                _mealTitle = "Mycenians";
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

            _text.text = $"Last group: {_mealTitle} ({_ingredientCountResult}) {Score.CurrentMealScore}";
        }

        private string CheckForMeat(List<Ingredient> ingredients)
        {
            string meatString = "Etruscan";
            int meatCounter = ingredients.Count(i => i.Name == meatString);

            switch (meatCounter)
            {
                case 5:
                    _mealTitle = "Etruscan nobility";
                    break;
                case 4:
                    _mealTitle = "Ligurians";
                    break;
                case 2 or 3:
                    _mealTitle = "Mycenians";
                    break;
                default:
                    _mealTitle = "Mycenians";
                    break;
            }

            return _mealTitle;
        }

        private string CheckForOnion(List<Ingredient> ingredients)
        {
            string onionString = "Amazon";
            int onionCounter = ingredients.Count(i => i.Name == onionString);

            switch (onionCounter)
            {
                case 4 or 5:
                    _mealTitle = "Amazon riders";
                    break;
                default:
                    _mealTitle = "Mycenians";
                    break;
            }

            return _mealTitle;
        }

        private string CheckForPotato(List<Ingredient> ingredients)
        {
            string potatoString = "Macedonian";
            int potatoCounter = ingredients.Count(i => i.Name == potatoString);

            switch (potatoCounter)
            {
                case 4 or 5:
                    _mealTitle = "Pelides";
                    break;
                default:
                    _mealTitle = "Mycenians";
                    break;
            }

            return _mealTitle;
        }
    }
}