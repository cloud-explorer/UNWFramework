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
                RuleFor(obj => obj.Title).NotEmpty();
                RuleFor(obj => obj.ReleaseYear).NotEmpty()
                    .GreaterThan(2000)
                    .LessThanOrEqualTo(DateTime.Now.Year + 1);
                RuleFor(obj => obj.ImdbId).NotEmpty();
            }
        }
    }
}
