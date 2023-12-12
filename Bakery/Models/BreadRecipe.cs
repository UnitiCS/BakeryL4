using System;
using System.Collections.Generic;

namespace Bakery.Models
{
    public partial class BreadRecipe
    {
        public int BreadRecipeId { get; set; }
        public int? IngredientId { get; set; }
        public int? BakeryProductId { get; set; }
        public string? ProductName { get; set; }
        public string? IngredientName { get; set; }
        public int? QuantityPerUnit { get; set; }
        public decimal? Price { get; set; }

        public virtual Ingredient? Ingredient { get; set; }
        public virtual BakeryProduct? BakeryProduct { get; set; }
    }
}
