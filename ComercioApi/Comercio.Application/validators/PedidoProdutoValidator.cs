//Rules for before saving on the database
using Comercio.Domain;
using FluentValidation;

namespace Comercio.Application.Validators
{
    public class PedidoProdutoValidator : AbstractValidator<PedidoProduto>
    {
        public PedidoProdutoValidator()
        {
            RuleFor(p => p.PedidoId)
                .NotEmpty()
                .WithMessage("O PedidoId e obrigatorio");

            RuleFor(p => p.ProdutoId)
                .NotEmpty()
                .WithMessage("O ProdutoId e obrigatorio");

            RuleFor(p => p.Quantidade)
                .NotEmpty()
                .WithMessage("Precisa ter uma quantidade")
                .GreaterThan(0)
                .WithMessage("A quantidade deve ser maior que zero");
        }
    }
}