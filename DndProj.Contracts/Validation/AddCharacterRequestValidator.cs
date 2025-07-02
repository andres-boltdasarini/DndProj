using DndProj.Contracts.Models.Character;
using FluentValidation;

namespace HomeApi.Contracts.Validation
{
    public class AddCharacterRequestValidator : AbstractValidator<CharacterCreationRequest>
    {
        public AddCharacterRequestValidator()
        {

            /* Зададим правила валидации */

            RuleFor(x => x.Name).NotEmpty(); // Проверим на null и на пустое свойство
            // RuleFor(x => x.Worldview).NotEmpty();
            // RuleFor(x => x.Gender).NotEmpty();
            // RuleFor(x => x.Background).NotEmpty();
            // RuleFor(x => x.Move).NotEmpty().InclusiveBetween(1, 20).WithMessage("от 1 до 20");
            // RuleFor(x => x.Helth).NotEmpty().InclusiveBetween(1, 20).WithMessage("от 1 до 20");
            // RuleFor(x => x.ClassArmor).NotEmpty().InclusiveBetween(1, 20).WithMessage("от 1 до 20");
            // RuleFor(x => x.Initiative).NotEmpty().InclusiveBetween(1, 20).WithMessage("от 1 до 20");
        }
    }
}
