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
        public static IngredientEvents Ingredients = new IngredientEvents();
        public static UIRestartButtonEvent RestartButtonEvent = new UIRestartButtonEvent();

        public class IngredientEvents
        {
            public UnityEvent<Ingredient> OnThrownToPot = new UnityEvent<Ingredient>();
            public UnityEvent OnMealComplete = new UnityEvent();
        }

        public class UIRestartButtonEvent
        {
            public UnityEvent OnRestartButtonHover = new UnityEvent();
        }
    }
}