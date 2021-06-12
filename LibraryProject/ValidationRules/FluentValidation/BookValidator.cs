using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BookValidator: AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.BookName).NotEmpty();
            RuleFor(b => b.AuthorId).NotEmpty();
            RuleFor(b => b.CategoryId).NotEmpty();
            RuleFor(b => b.PublisherId).NotEmpty();
            
        }
    }
}
