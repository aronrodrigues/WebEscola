﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebEscola.Validators
{
    public class Soma13Attribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object valor, ValidationContext validationContext)
        {
            if (valor != null)
            {
                if (valor is int)
                {

                    int buffer = (int)valor;
                    int soma = 0;
                    while (buffer != 0)
                    {
                        soma += buffer % 10;
                        buffer /= 10;
                    }

                    if (soma == 13)
                    {
                        return new ValidationResult("A numerologia deste número não é boa.");
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }

                }

            }

            return new ValidationResult("Só funciona com números.");
        }
    }
}
