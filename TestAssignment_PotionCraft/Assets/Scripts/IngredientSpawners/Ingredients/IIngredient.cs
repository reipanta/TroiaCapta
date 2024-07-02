using Data;
using Unity.VisualScripting;

namespace IngredientSpawners.Ingredients
{
    public interface IIngredient
    {
        public IngredientsData IngredientsData { get; set; }
        
    }
}