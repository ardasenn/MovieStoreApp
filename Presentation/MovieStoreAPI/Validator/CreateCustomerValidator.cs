using FluentValidation;
using MovieStoreAPI.Models;

namespace MovieStoreAPI.Validator
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerVM>
    {
        public CreateCustomerValidator()
        {
            RuleFor(a => a.UserName).NotEmpty().WithMessage("Username boş olamaz").MaximumLength(20).WithMessage("Username en fazla 20 karakter olabilir").MinimumLength(3).WithMessage("UserName boş olamaz ve 3 ila 20 karakter arasında olabilir.");
            RuleFor(a => a.Email).NotEmpty().WithMessage("Email boş olamaz").MaximumLength(200).WithMessage("Email en fazla 200 karakter olabilir").EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Şifre boş olamaz").MinimumLength(6).WithMessage("Şifreniz minimum 6 karakter maximum 200 karakter olabilir.").MaximumLength(200).WithMessage("şifre en fazla 200 karakter olabilir");
            RuleFor(a => a.PasswordConfirm).NotEmpty().WithMessage("Şifre onayı boş olamaz").Equal(a => a.Password).WithMessage("Şifreniz birbiri ile uyuşmuyor.");
            RuleFor(a => a.PhoneNumber).NotEmpty().WithMessage("Telefon boş olamaz").MaximumLength(15).WithMessage("Telefon numaranız en fazla 15 hane olabilir").MinimumLength(6).WithMessage("Telefon numaranız minumum 6 karakterden oluşmalı");
            RuleFor(b => b.FirstName).NotEmpty().WithMessage("İsim boş olamaz").MaximumLength(200).WithMessage("İsminiz en fazla 200 karakter olabilir");
            RuleFor(b => b.LastName).NotEmpty().WithMessage("Soyisim boş olamaz").MaximumLength(200).WithMessage("Soyisminiz en fazla 200 karakter olabilir");
        }
    }
}
