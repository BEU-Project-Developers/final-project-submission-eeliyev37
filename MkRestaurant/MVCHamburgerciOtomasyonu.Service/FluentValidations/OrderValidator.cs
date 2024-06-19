using FluentValidation;
using MVCHamburgerciOtomasyonu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCHamburgerciOtomasyonu.Service.FluentValidations
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.MenuID)
                .NotEmpty()
                .NotNull()
                .WithName("Memü");

            RuleFor(x => x.MenuSizeID)
               .NotEmpty()
               .NotNull()
               .WithName("Boyut");
        }
    }
}
