﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TP2Console.Models.EntityFramework
{
    public partial class Categorie
    {
        public override string ToString()
        {
            return "Id: " + this.Id + " Nom: " + this.Nom;
        }
    }
}
