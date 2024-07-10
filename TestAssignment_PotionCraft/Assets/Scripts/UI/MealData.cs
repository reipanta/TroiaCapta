namespace UI
{
    // This struct is created to hold the data of best and last meal
    public struct MealData
    {
        public string Title { get; set; }
        public string IngredientCountResult { get; set; }
        public float CurrentMealScore { get; set; }

        public MealData GetData(string title, string ingredientCountResult, float currentMealScore)
        {
            var data = new MealData();
            data.Title = title;
            data.IngredientCountResult = ingredientCountResult;
            data.CurrentMealScore = currentMealScore;

            return data;
        }
    }
}