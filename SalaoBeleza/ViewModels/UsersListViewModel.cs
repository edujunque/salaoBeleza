using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalaoBeleza.ViewModels
{
    public class UsersListViewModel
    {
        public string Id { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Nome")]
        public string UserName { get; set; }
    }
}