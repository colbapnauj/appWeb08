using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace appWeb08.Models
{
    public class Cliente
    {
        [Display(Name = "Id Cliente")] public string idcliente { get; set; }
        [Display(Name = "Nombre")] public string nombrecia { get; set; }
        [Display(Name = "Dirección")] public string direccion { get; set;  }
        [Display(Name = "Id Pais")] public string idpais { get; set; }
        [Display(Name ="Telefono")]public string fono { get; set; }

    }
}