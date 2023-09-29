using Application.DTO;
using FluentValidation;
using System.Text.RegularExpressions;

namespace fiap_store.Validation
{
    public partial class CadastrarClienteRequestValidator : AbstractValidator<CadastrarClienteRequest>
    {
        public CadastrarClienteRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .Matches(FullNameRegex()).WithMessage("Nome com caracteres proibidos.")
                .MaximumLength(100).WithMessage("Máximo de 100 caracteres.");

            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(8).WithMessage("Senha mínima de 8 caracteres.")
                .Matches(PasswordRegex()).WithMessage("Senha deve possuir, pelo menos, uma letra maiúscula, uma letra minúscula, um número e um caractere especial.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("Telefone é obrigatório.")
                .Matches(TelefoneRegex()).WithMessage("Telefone deve conter exatamente 11 números.");

            RuleFor(x => x.Endereco.Rua)
                .NotEmpty().WithMessage("Rua é obrigatório.")
                .MaximumLength(100).WithMessage("Máximo de 100 caracteres.");

            RuleFor(x => x.Endereco.Numero)
                .NotEmpty().WithMessage("Número é obrigatório.")
                .MaximumLength(10).WithMessage("Máximo de 10 caracteres.");            

            RuleFor(x => x.Endereco.Cidade)
                .NotEmpty().WithMessage("Cidade é obrigatória.")
                .MaximumLength(30).WithMessage("Máximo de 30 caracteres.");

            RuleFor(x => x.Endereco.Bairro)
                .NotEmpty().WithMessage("Bairro é obrigatório.")
                .MaximumLength(30).WithMessage("Máximo de 30 caracteres.");

            RuleFor(x => x.Endereco.CEP)
                .NotEmpty().WithMessage("CEP é obrigatório.")
                .Matches(@"^\d{8}$").WithMessage("CEP inválido. Use 12345678.")
                .MaximumLength(8).WithMessage("Máximo de 8 caracteres.");
            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage("CPF é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("CPF apenas com 11 dígitos");

            RuleFor(x => x.DataNasc)
                .NotEmpty().WithMessage("Data de nascimento é obrigatório.")
                .Must(BeAtLeast18YearsOld).WithMessage("Idade menor que 18 anos.");
        }

        [GeneratedRegex("^[\\p{L} ]+$", RegexOptions.IgnoreCase | RegexOptions.Compiled, "pt-BR")]
        private static partial Regex FullNameRegex();

        [GeneratedRegex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).+$", RegexOptions.Compiled, "pt-BR")]
        private static partial Regex PasswordRegex();
        [GeneratedRegex(@"^\d{11}$", RegexOptions.IgnoreCase | RegexOptions.Compiled, "pt-BR")]
        private static partial Regex TelefoneRegex();
        private bool BeAtLeast18YearsOld(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            return age >= 18;
        }
    }
}
