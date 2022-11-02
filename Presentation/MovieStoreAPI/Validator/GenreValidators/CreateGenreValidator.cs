using FluentValidation;
using MovieStoreAPI.Models.GenreModels;

namespace MovieStoreAPI.Validator.GenreValidators
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreVM>
    {
        public CreateGenreValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Tür adı boş olamaz").MaximumLength(50).WithMessage("50 karakterden fazla giriş yapılamaz").MinimumLength(2).WithMessage("Minimum 2 karakter olmalıdır");
        }
    }
}
