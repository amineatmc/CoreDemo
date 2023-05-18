using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {

            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog Başlığı Boş Geçilemez");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog İçerik Boş Geçilemez");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Blog Görseli Boş Geçilemez");
            RuleFor(x => x.NailImage).NotEmpty().WithMessage("Blog Görseli Boş Geçilemez");
            RuleFor(x => x.Title).MaximumLength(150).WithMessage("150 karakterden az veri girişi yapılmalı");
        }
    }
}
