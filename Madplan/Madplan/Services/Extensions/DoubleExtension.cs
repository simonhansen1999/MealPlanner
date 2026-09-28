using Madplan.Models;
using Madplan.Models.Enums;
using System.Globalization;

namespace Madplan.Services.Extensions
{
    public static class DoubleExtension
    {
        private static readonly CultureInfo _culture = new CultureInfo("da-DK");

        public static string PrettyFormat(this double value)
        {
            var decimalSeparator = _culture.NumberFormat.NumberDecimalSeparator;

            return value.ToString("N2", _culture).TrimEnd('0').TrimEnd(decimalSeparator[0]);
        }

        public static string FormatUnitType(this double value, UnitType unitType)
        {
            string unit = unitType switch
            {
                UnitType.Gram => "g",
                UnitType.Kilo => "kg",
                UnitType.Stk => "stk",
                UnitType.Pakke => "pk",
                UnitType.Milliliter => "ml",
                UnitType.Deciliter => "dl",
                UnitType.Liter => "liter",
                UnitType.Teske => "tsk",
                UnitType.Spiseske => "spsk",
                _ => unitType.ToString().ToLower()
            };

            string num = value.ToString("0.##", _culture);

            return $"{num} : {unit}";
        }

        public static NormalizedAmount NormalizeValueWithUnitType(this double amount, UnitType unit)
        {
            return unit switch
            {
                // KEEP
                UnitType.Kilo => Round(amount, UnitType.Kilo),
                UnitType.Stk => Round(amount, UnitType.Stk),
                UnitType.Pakke => Round(amount, UnitType.Pakke),

                // GRAM
                UnitType.Gram => NormalizeGram(amount),

                // CONVERT => GRAM
                UnitType.Milliliter => NormalizeGram(amount),
                UnitType.Deciliter => NormalizeGram(amount * 100),
                UnitType.Liter => NormalizeGram(amount * 1000),
                UnitType.Teske => NormalizeGram(amount * 5),
                UnitType.Spiseske => NormalizeGram(amount * 15),

                _ => throw new NotSupportedException($"Enheden {unit} understøttes ikke")
            };
        }

        // Helpers

        private static NormalizedAmount NormalizeGram(double grams)
        {
            if (grams >= 1000)
            {
                return Round(grams / 1000, UnitType.Kilo);
            }

            return Round(grams, UnitType.Gram);
        }

        private static NormalizedAmount Round(double amount, UnitType unit)
        {
            return new NormalizedAmount(Math.Round(amount, 2, MidpointRounding.AwayFromZero), unit);
        }
    }
}
