using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zappts.Domain.Entities;

namespace Zappts.Service.Validators
{
    public class LivrosValidator : AbstractValidator<Livros>
    {
        public LivrosValidator()
        {

            RuleFor(i => i.Autor)
            .MaximumLength(50)
            .NotNull()
            .NotEmpty();

            RuleFor(i => i.Editora)
            .MaximumLength(50)
            .NotNull()
            .NotEmpty();

            RuleFor(i => i.Genero)
            .MaximumLength(50);

            RuleFor(i => i.Nome)
            .MaximumLength(100)
            .NotNull()
            .NotEmpty();

        }
    }
}
