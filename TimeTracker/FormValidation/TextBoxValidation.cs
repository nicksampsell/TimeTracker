using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TimeTracker.FormValidation
{
    public class TextBoxValidation : ValidationRule
    {

        public Boolean AllowLetters { get; set; } = true;
        public Boolean AllowNumbers { get; set; } = true;
        public Boolean AllowSpecialChars { get; set; } = true;
        public Boolean AllowSpaces { get; set; } = true;
        public Boolean AllowLineBreaks { get; set; } = true;
        public int? MaxLength { get; set; } 

        public TextBoxValidation()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!AllowNumbers && ((string)value).Any(ch => Char.IsNumber(ch)))
            {
                return new ValidationResult(false, "This field cannot contains numbers.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
