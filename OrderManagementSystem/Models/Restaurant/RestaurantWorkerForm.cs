﻿namespace OrderManagementSystem.Models.Restaurant
{
    using System.ComponentModel.DataAnnotations;
    using Domain.User;
    using System;

    /// <summary>
    /// Formularz pracownika restuaracji
    /// </summary>
    public class RestaurantWorkerForm
    {
        /// <summary>
        /// Id pracownika restauracji
        /// </summary>
        public Guid? RestaurantWorkerId { get; set; }

        [Display(Name= "Active")]
        public bool Active { get; set; }

        [Display(Name = "Position")]
        public Position Position { get; set; }

        [Display(Name= "Pseudonym")]
        public string Nick { get; set; }

        [Required]
        [Display(Name = "Employee's name")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "The employee's name")]
        public string Lastname { get; set; }

        public int AppUserId { get; set; }

        [Display(Name="Login")]
        public string Login { get; set; }

        [Display(Name= "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Id restauracji
        /// </summary>
        public Guid? RestaurantId { get; set; }

        [Display(Name = "The name of the restaurant")]
        public string RestaurantName { get; set; }

        public RestaurantWorkerForm() { }

        /// <summary>
        /// Rekonstrukcja formularza z danych przesłanych przez użytkownika
        /// </summary>
        /// <param name="receivedForm">Wpisane dane</param>
        public RestaurantWorkerForm(RestaurantWorkerForm receivedForm)
        {
            this.RestaurantWorkerId = receivedForm.RestaurantWorkerId;
            this.Firstname = receivedForm.Firstname;
            this.Lastname = receivedForm.Lastname;
            this.Nick = receivedForm.Nick;
            this.Position = receivedForm.Position;
            this.RestaurantName = receivedForm.RestaurantName;
            this.RestaurantId = receivedForm.RestaurantId;
            this.Login = receivedForm.Login;
            this.Password = receivedForm.Password;
        }
    }
}