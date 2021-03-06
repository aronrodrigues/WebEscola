﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebEscola.Validators;

namespace WebEscola.Models
{
    public class Aluno
    {

        [Required(ErrorMessage="É necessário informar um {0}")]
        [Range(1000, 9999, ErrorMessage="O campo {0} deve estar entre {1} e {2}")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Digite número válido para o {0}.")]
        [DisplayName("Matrícula")]
        [Soma13]
        public Int32 ID { get; set; }

        [Required(ErrorMessage = "É necessário informar um {0}")]
        [StringLength(50, MinimumLength=3, ErrorMessage="O campo {0} deve ter entre {2} e {1} caracteres")]
        public String Nome { get; set; }

    }
}