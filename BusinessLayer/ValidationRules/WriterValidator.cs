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
    public class WriterValidator:AbstractValidator<AppUser>
    {
        public WriterValidator()
        {
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Yazarın Ad ve Soyad Bilgisi Boş Geçilemez");
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x=>x.PasswordHash).NotEmpty();
            RuleFor(x=>x.UserName).MinimumLength(2).WithMessage("en az iki karakter");

        }
    }
}
