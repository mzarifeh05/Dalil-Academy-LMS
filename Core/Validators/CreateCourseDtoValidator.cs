using Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Validators
{
    public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDTO>
    {
        public CreateCourseDtoValidator()
        {
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be zero or moer");
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);
            RuleFor(x => x.InstructorId)
                .GreaterThan(0)
                .WithMessage("Enter a valid ID number");
        }
    }
}
