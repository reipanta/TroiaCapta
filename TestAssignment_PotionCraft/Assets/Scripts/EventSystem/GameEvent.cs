using System.Collections.Generic;
using System.ComponentModel;
using Data;
using Interactables.IngredientSpawners;
using UnityEngine;
using UnityEngine.Events;
using Component = System.ComponentModel.Component;

namespace EventSystem
{
    public static class GameEvent
    {
        // Initializing static events to have one entry point across all scripts
        public static IngredientEvents Ingredients = new IngredientEvents();
        public static UIRestartButtonEvent RestartButtonEvent = new UIRestartButtonEvent();

        public class IngredientEvents // This class is for any interactions regarding Ingredient status change, mostly used in UI
        {
            // What happens after the ingredient is thrown into a pot
            public UnityEvent<Ingredient> OnThrownToPot = new UnityEvent<Ingredient>(); 
            
            // What happens after the there are five ingredients in the pot = meal is complete
            public UnityEvent OnMealComplete = new UnityEvent();
        }

        public class UIRestartButtonEvent // This class contains an event for the restart button
        {
            public UnityEvent OnRestartButtonHover = new UnityEvent();
        }
    }
}