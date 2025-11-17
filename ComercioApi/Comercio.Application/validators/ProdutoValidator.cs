//Rules for before saving on the database
using Comercio.Domain;
using FluentValidation;

namespace Comercio.Application.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("O nome do produto e obrigatorio.")
                .Length(3,200)
                .WithMessage("O nome do produto deve ter entre 3 a 200 caracteres.");
            
            RuleFor(p => p.Descricao)
                .NotEmpty()
                .WithMessage("A descricao do produto e obrigatoria")
                .Length(10,500)
                .WithMessage("A descricao do produto deve ter entre 10 e 500 cracteres.");

            RuleFor(p => p.Valor)
                .NotEmpty()
                .WithMessage("O valor do produto e obrigatorio")
                .GreaterThan(0)
                .WithMessage("O valor do produto deve ser maior que zero.");
        }
    }
}