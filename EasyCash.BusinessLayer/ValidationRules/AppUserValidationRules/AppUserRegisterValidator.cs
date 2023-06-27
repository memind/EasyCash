using EasyCash.DtoLayer.Dtos.AppUserDTOs;
using FluentValidation;

namespace EasyCash.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş olamaz!");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Ad 30 karakterden fazla olamaz!");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Ad 2 karakterden az olamaz!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş olamaz!");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Soyad 30 karakterden fazla olamaz!");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Soyad 2 karakterden az olamaz!");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı alanı boş olamaz!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanı boş olamaz!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir email adresi giriniz!");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).NotEmpty().WithMessage("Şifre alanı boş olamaz!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Doğrulama alanı boş olamaz!");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Girdiğiniz şifreler aynı olmalıdır!");
        }
    }
}
