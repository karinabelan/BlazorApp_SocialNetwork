using BlazorApp_SocialNetwork.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp_SocialNetwork.Account
{
    public class EditUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Hometown { get; set; }
        [Required]
        public string Id { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [MinLength(6, ErrorMessage = "Error")]
        public string Password { get; set; }

        public EditUser() { }

        public EditUser(User user)
        {
            Hometown = user.Email;
            Id = user.Id;
            FirstName = user.firstname;
            LastName = user.lastname;
            Username = user.firstname + " " + user.lastname;
        }
    }
}
