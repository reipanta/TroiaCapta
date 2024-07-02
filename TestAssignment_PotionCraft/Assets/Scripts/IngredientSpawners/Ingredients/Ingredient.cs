using Data;

namespace IngredientSpawners.Ingredients
{
    public class Ingredient : IIngredient
    {
        public IngredientsData IngredientsData { get; set; }

        public Ingredient(IngredientsData ingredients)
        {
            IngredientsData = ingredients;
        }
        
    }
}