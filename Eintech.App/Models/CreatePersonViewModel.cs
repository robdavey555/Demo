using Eintech.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Eintech.App.Models
{
    public class CreatePersonViewModel
    {
        public PersonDTO Person { get; set; }

        public List<SelectListItem> Groups { get; set; }
    }
}