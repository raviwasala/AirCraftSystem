using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DataValidation
{
    public class NumberValidation
    {
        private const int startingPartLength =2;        
        private const int lastPartLength = 5;

        public bool IsValid(string registrationNumber)
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
