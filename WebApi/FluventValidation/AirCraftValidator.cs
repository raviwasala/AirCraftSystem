using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.FluventValidators
{
    public class AirCraftValidator : AbstractValidator<AirCraft>
    {
        private const int startingPartLength = 2;        
        private const int lastPartLength = 5;

        public AirCraftValidator()
        {
            RuleFor(p => p.Make)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .Length(1, 128);
                

            RuleFor(p => p.Model)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .Length(1, 128);            

            RuleFor(p => p.Registration)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .Length(1, 128);

            RuleFor(x => x.Registration).Must(IsRegistrationNoValid).WithMessage("Registration Number is invalid");

            RuleFor(p => p.Location)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} should be not empty.")
                .Length(2, 255);
            
        }
        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }

        private bool IsRegistrationNoValid(string registrationNumber)
        {
            var firstDelimiter = registrationNumber.IndexOf('-');
            var secondDelimiter = registrationNumber.LastIndexOf('-');
            string[] registrationNumberSplit = registrationNumber.Split("-");

            if (registrationNumberSplit.Length != 2)
                return false;

            if (registrationNumberSplit.Length != 2 && (registrationNumberSplit[0].Length >= 2) && (registrationNumberSplit[1].Length >= 5))
                return false;

            var firstPart = registrationNumber.Substring(0, firstDelimiter);
            if (firstPart.Length > startingPartLength)
                return false;

            var lastPart = registrationNumber.Substring(secondDelimiter + 1);
            if (lastPart.Length > lastPartLength)
                return false;

            return true;
        }
    }
}
