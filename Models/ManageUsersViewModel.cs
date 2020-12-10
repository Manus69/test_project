using System.Collections.Generic;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Users;

namespace AspNetCoreTodo.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }
        public ApplicationUser[] Everyone { get; set;}
    }
}