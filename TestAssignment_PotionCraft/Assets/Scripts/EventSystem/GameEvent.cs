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
        public static readonly IngredientEvents Ingredients = new IngredientEvents();

        public class IngredientEvents
        {
            public UnityEvent<Ingredient> OnThrownToPot;
            public UnityEvent<Ingredient> OnMealComplete;
        }
    }
}