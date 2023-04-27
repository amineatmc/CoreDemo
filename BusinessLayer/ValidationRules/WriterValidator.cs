using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Yazarın Ad ve Soyad Bilgisi Boş Geçilemez");
            RuleFor(x => x.Mail).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
            RuleFor(x=>x.Name).MinimumLength(2).WithMessage("en az iki karakter");

        }
    }
}
