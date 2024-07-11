using Interactables.IngredientSpawners;
using UnityEngine.Events;


namespace EventSystem
{
    public static class GameEvent
    {
        // Initializing static events to have one entry point across all scripts
        public static IngredientEvents Ingredients = new IngredientEvents();

        public class IngredientEvents
        {
            public UnityEvent<Ingredient> OnThrownToPot = new UnityEvent<Ingredient>();
            public UnityEvent OnMealComplete = new UnityEvent();
        }
    }
}