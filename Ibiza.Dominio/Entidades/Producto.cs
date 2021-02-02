﻿using Ibiza.DominioBase;
using System.ComponentModel.DataAnnotations;

namespace Ibiza.Dominio.Entidades
{
    public class Producto : EntityBase
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}
