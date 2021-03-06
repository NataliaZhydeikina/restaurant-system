﻿namespace OrderManagementSystem.Models.Product
{
    using Restaurant;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;

    /// <summary>
    /// Formularz dodawania/edycji produktu
    /// </summary>
    public class ProductForm
    {
        /// <summary>
        /// Id produktu
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        /// Id menu, do którego należy produkt
        /// </summary>
        public Guid? MenuId { get; set; }

        [Display(Name= "Active")]
        public bool Active { get; set; }

        /// <summary>
        /// Id kategorii, do której należy produkt
        /// </summary>
        public Guid? ProductCategoryId { get; set; }

        /// <summary>
        /// Id detali produktu
        /// </summary>
        public Guid? ProductDetailsId { get; set; }

        [Display(Name="Name")]
        public string ProductName { get; set; }

        [Display(Name = "Link to the photo")]
        public string ProductPhotoUrl { get; set; }

        [Display(Name = "Category")]
        public string ProductCategoryName { get; set; }

        [Display(Name="Menu's name")]
        public string MenuName { get; set; }

        [Display(Name = "Description")]
        public string ProductDescription { get; set; }

        [RegularExpression(@"[0-9]*\,?[0-9]+", ErrorMessage = "{0} must be a number.")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Promotion (w %)")]
        public int? PercentDiscount { get; set; }

        [Display(Name = "The number of calories")]
        public int? ProductDetailsCalories { get; set; }

        [Display(Name = "The amount of protein in grams")]
        public int? ProductDetailsProtein { get; set; }

        [Display(Name = "Amount of carbohydrates in grams")]
        public int? ProductDetailsCarbohydrates { get; set; }

        [Display(Name = "Amount of fat in grams")]
        public int? ProductDetailsFat { get; set; }

        /// <summary>
        /// Lista dostępnych kategorii w restauracji
        /// </summary>
        [Display(Name= "Category")]
        public List<ProductCategoryForm> ProductCategories { get; set; }

        /// <summary>
        /// Lista dostępnych menu w restauracji
        /// </summary>
        [Display(Name="Menu")]
        public List<MenuForm> Menus { get; set; } 

        public ProductForm()
        {
            ProductCategories = new List<ProductCategoryForm>();
            Menus = new List<MenuForm>(); 
        }

        public ProductForm(List<ProductCategoryForm> productCategories, List<MenuForm> menus)
        {
            ProductCategories = productCategories;
            Menus = menus;
        }
    }

    /// <summary>
    /// Formularz do dodawania/edycji kategorii produktu
    /// </summary>
    public class ProductCategoryForm
    {
        /// <summary>
        /// Id kategorii
        /// </summary>
        public Guid? ProductCategoryId { get; set; }

        /// <summary>
        /// Id restauracji
        /// </summary>
        public Guid? RestaurantId { get; set; }

        [Display(Name = "Category's name")]
        public string ProductCategoryName { get; set; }

        [Display(Name = "Categorie's cod")]
        public string ProductCategoryCode { get; set; }

        /// <summary>
        /// Lista kategorii dostępnych w restauracji
        /// </summary>
        public List<ProductCategoryForm> ProductCategories { get; set; }
    }
}