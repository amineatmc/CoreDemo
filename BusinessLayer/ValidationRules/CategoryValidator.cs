using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Blog Başlığı Boş Geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Blog İçerik Boş Geçilemez");
            RuleFor(x => x.Description).MaximumLength(150).WithMessage("150 karakterden az veri girişi yapılmalı");
        }
    }
}
