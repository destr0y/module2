using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Module2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetTotalTax(1, 100, 100));
            Console.WriteLine("Hello World!");
        }

        public static int GetTotalTax(int companiesNumber, int tax, int companyRevenue)
        {
            double companyTax = (double)companyRevenue * tax / 100;
            return Convert.ToInt32(companyTax * companiesNumber);
        }

        public string GetCongratulation(int input)
        {
            string output;
            
            if ((input % 2 == 0) && (input >= 18))
                output = "Поздравляю с совершеннолетием!";
            else if (((input >= 12) && (input <= 18)) && (input % 2 != 0))
                output = "Поздравляю с переходом в старшую школу!";
            else output = $"Поздравляю с {input}-летием!";

            return output;
        }

        public double GetMultipliedNumbers(string first, string second)
        {
            var formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };

            double firstNumber = double.Parse(first.Replace(',','.'), formatter);
            double secondNumber = double.Parse(second.Replace(',','.'), formatter);

            return firstNumber * secondNumber;
        }

        public double GetFigureValues(FigureEnum figureType, ParameterEnum parameterToCompute, Dimensions dimensions)
        {
            double result = 0;
            
            switch (figureType)
            {
                case FigureEnum.Circle:
                {
                    result = parameterToCompute == ParameterEnum.Perimeter
                        ? 3.14 * 2 * dimensions.Radius
                        : 3.14 * Math.Pow(dimensions.Radius, 2);
                    break;
                }
                case FigureEnum.Rectangle:
                {
                    result = parameterToCompute == ParameterEnum.Perimeter
                        ? (dimensions.FirstSide + dimensions.SecondSide) * 2
                        : dimensions.FirstSide * dimensions.SecondSide;
                    break;
                }
                case FigureEnum.Triangle:
                {
                    result = parameterToCompute == ParameterEnum.Perimeter
                        ? dimensions.FirstSide + dimensions.SecondSide + dimensions.ThirdSide
                        : dimensions.FirstSide * dimensions.Height * 0.5;
                    if (result == 0)
                    {
                        var p = dimensions.FirstSide + dimensions.SecondSide + dimensions.ThirdSide;
                        result = Math.Sqrt(p * 
                                           (p - dimensions.FirstSide) *
                                           (p - dimensions.SecondSide) *
                                           (p - dimensions.ThirdSide));
                    }
                    break;
                }
            }

            return Math.Round(result);
        }
    }
}
