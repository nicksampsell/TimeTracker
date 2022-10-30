using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace TimeTracker.FormValidation
{
    public class TextBoxValidation : ValidationRule
    {
        public Boolean Required { get; set; } = false;
        public Boolean AllowLetters { get; set; } = true;
        public Boolean AllowNumbers { get; set; } = true;
        public Boolean AllowSpecialChars { get; set; } = true;
        public Boolean AllowSpaces { get; set; } = true;
        public Boolean AllowLineBreaks { get; set; } = true;
        public Boolean AllowSymbols { get; set; } = true;
        public Boolean AllowWhiteSpace { get; set; } = true;
        public int? MaxLength { get; set; } 

        public TextBoxValidation()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if(!AllowLetters && ((string)value).Any(ch => Char.IsLetter(ch)))
            {
                return new ValidationResult(false, "This field cannot contain letters.");
            }

            if (!AllowNumbers && ((string)value).Any(ch => Char.IsNumber(ch)))
            {
                return new ValidationResult(false, "This field cannot contain numbers.");
            }

            if (!AllowSpecialChars && ((string)value).Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                return new ValidationResult(false, "This field cannot contain special characters.");
            }

            if (!AllowSpaces && ((string)value).Contains(' '))
            {
                return new ValidationResult(false, "This field cannot contain spaces.");
            }

            if(!AllowLineBreaks && Regex.IsMatch((string)value, @"(\r?\n)"))
            {
                return new ValidationResult(false, "This field cannot contain line breaks.");
            }
                
            if (!AllowWhiteSpace && ((string)value).Any(ch => !Char.IsWhiteSpace(ch)))
            {
                return new ValidationResult(false, "This field cannot contain white space characters.");
            }

            if (!AllowSymbols && ((string)value).Any(ch => Char.IsSymbol(ch)))
            {
                return new ValidationResult(false, "This field cannot contain symbols.");
            }

            if(((string)value).Length <= MaxLength)
            {
                return new ValidationResult(false, $"This field has a maximum length of {MaxLength} characters.");
            }

            if(((string)value).Length == 0)
            {
                return new ValidationResult(false, "This field is required.");
            }





            return ValidationResult.ValidResult;
        }
    }
}
