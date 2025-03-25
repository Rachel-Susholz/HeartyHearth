using System;

namespace HeartyHearthWinForm
{
    public static class RecipeEvents
    {
        public static event EventHandler RecipeStatusChanged;
        public static void RaiseRecipeStatusChanged()
        {
            RecipeStatusChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}
