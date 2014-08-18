using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace UNWomen.Prototype.Client.Entities
{
    public class Movie : ClientEntity<Prototype.Entities.Movie>
    {
        protected override IValidator GetValidator()
        {
            return new MovieValidator();
        }

        class MovieValidator : AbstractValidator<Prototype.Entities.Movie>
        {
            public MovieValidator()
            {
                RuleFor(obj => obj.Title).NotEmpty()
                    .Must(m => m.Length <= 200)
                    .WithMessage("Title must not be empty and must be less than 200 characters");
                RuleFor(obj => obj.ReleaseYear).NotEmpty()
                    .GreaterThan(2000)
                    .LessThanOrEqualTo(DateTime.Now.Year + 1)
                    .WithMessage("Release must not be empty and must be greater than 2000 less than next year");
                RuleFor(obj => obj.ImdbId).NotEmpty()
                    .Must(m => m.Length <= 4)
                    .WithMessage("IMDB Id must not be empty and must be less that 4 characters");
            }
        }
    }
}
