using EventSystem;
using TMPro;
using UnityEngine;

namespace UI
{
    // This class tracks the best meal that was made during the game
    public class BestMeal : MonoBehaviour
    {
        private TMP_Text _text;
        private MealData _highestScoreMeal; // Struct MealData is used to store ingredient parameters of the best meal

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
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

            _text.text =
                $"Best squad: {_highestScoreMeal.Title} ({_highestScoreMeal.IngredientCountResult}) {_highestScoreMeal.CurrentMealScore}";
        }
    }
}