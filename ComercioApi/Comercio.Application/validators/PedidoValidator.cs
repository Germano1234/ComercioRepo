//Rules for before saving on the database
using Comercio.Domain;
using FluentValidation;

namespace Comercio.Application.Validators
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(p => p.Cliente)
                .NotEmpty()
                .WithMessage("O nome do Cliente e obrigatorio.")
                .Length(2,200)
                .WithMessage("O nome do Cliente deve ter entre 2 a 200 caracteres.");

            RuleFor(p => p.DataPedido)
                .NotEmpty()
                .WithMessage("A data do pedido e obrigatoria");
        }
    }
}