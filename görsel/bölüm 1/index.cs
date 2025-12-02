using System;

class BodyMassIndexCalculator
{
    static void Main()
    {
        Console.WriteLine("--- Body Mass Index (BMI) Calculator ---");
        Console.WriteLine("Reference: Exercise 1.27 (Research & Test Drive)\n");

        // 1. Kullanıcıdan Kilo Bilgisini Alma (Pound cinsinden)
        Console.Write("Enter your weight in pounds: ");
        double weightInPounds = Convert.ToDouble(Console.ReadLine());

        // 2. Kullanıcıdan Boy Bilgisini Alma (Inç cinsinden)
        Console.Write("Enter your height in inches: ");
        double heightInInches = Convert.ToDouble(Console.ReadLine());

        // 3. BMI Hesaplama
        // Formül: (weightInPounds * 703) / (heightInInches * heightInInches)
        double bmi = (weightInPounds * 703) / (heightInInches * heightInInches);

        // 4. Sonuçları Görüntüleme
        Console.WriteLine($"\nYour Body Mass Index (BMI): {bmi:F1}");

        // 5. BMI Kategorilerini Listeleme (Department of Health Standartları)
        Console.WriteLine("\n--- BMI VALUES ---");
        Console.WriteLine("Underweight:  less than 18.5");
        Console.WriteLine("Normal:       between 18.5 and 24.9");
        Console.WriteLine("Overweight:   between 25 and 29.9");
        Console.WriteLine("Obese:        30 or greater");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}