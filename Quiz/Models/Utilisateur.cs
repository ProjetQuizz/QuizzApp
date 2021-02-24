using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuizApp.Models
{
    public class Utilisateur
    {
        public int? Id { get; set; }

        [Required]
        [Display(Name = "Nom")]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Min 2 caractères")]
        public string Name { get; set; }


        [Required]
        [MaxLength(150)]
        [EmailAddress]
        [Index(IsUnique=true)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

     
        [Required]
        [Display(Name = "Role")]
        public UserRole Role { get; set; }

    }
}


