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
            //RuleFor(x => x.Strength).NotEmpty().InclusiveBetween(1, 20).WithMessage("от 1 до 20");
            //RuleFor(x => x.Dexterity).NotEmpty().InclusiveBetween(1, 20).WithMessage("от 1 до 20");
            //RuleFor(x => x.Vitality).NotEmpty().InclusiveBetween(1, 20).WithMessage("от 1 до 20");
            //RuleFor(x => x.Intelligence).NotEmpty().InclusiveBetween(1, 20).WithMessage("от 1 до 20");
            //RuleFor(x => x.Wisdom).NotEmpty().InclusiveBetween(1, 20).WithMessage("от 1 до 20");
            //RuleFor(x => x.Charisma).NotEmpty().InclusiveBetween(1, 20).WithMessage("от 1 до 20");
        }
    }
}
