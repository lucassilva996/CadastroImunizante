using CadastroImuno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CadastroImuno.Validations
{
    public class ImunizanteValidations : AbstractValidator<Imunizante>
    {
        public ImunizanteValidations()
        {
            //validacoes do Fabricante
            RuleFor(x => x.Fabricante).NotEmpty().WithMessage("Informar Fabricante");
            RuleFor(x => x.Fabricante).Must(FabricantesImuno).WithMessage("Fabricantes validos: Sinovac ou Pfizer");

        
            //validacoes do AnoLote
            RuleFor(x => x.AnoLote).NotEmpty().WithMessage("Informar Ano do Lote");
            RuleFor(x => x.AnoLote).MaximumLength(4);
            RuleFor(x => x.AnoLote).GreaterThan("2020").WithMessage("Ano do lote precisa ser maior que 2020").Matches(@"^\d+$");
        }

        private static bool FabricantesImuno(string arg)
        {
            return arg.Equals("Sinovac") || arg.Equals("Pfizer");
        }

    }
}
