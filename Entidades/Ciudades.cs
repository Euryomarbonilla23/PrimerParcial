using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrimerParcial.Entidades
{
    public class Ciudades
    {
        [Key]
        public int CiudadId { get; set; }
        public String Nombre { get; set; }
        
    }
}