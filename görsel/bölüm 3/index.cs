using System;

class CircleStats
{
    static void Main()
    {
        Console.WriteLine("--- Circle Statistics Calculator ---");
        
        // 1. Kullanıcıdan yarıçapı (radius) tamsayı olarak al
        Console.Write("Enter the radius of the circle (integer): ");
        int radius = int.Parse(Console.ReadLine());

        // 2. Hesaplamalar ve Çıktı
        // Not: Sonuçlar bir değişkende saklanmadan doğrudan WriteLine içinde hesaplanıyor.
        // Math.PI sabiti kullanılarak hassas hesaplama yapılıyor.
        
        Console.WriteLine($"Diameter = {2 * radius}");
        
        // Çevre: 2 * PI * r
        Console.WriteLine($"Circumference = {2 * Math.PI * radius:F5}");
        
        // Alan: PI * r^2
        Console.WriteLine($"Area = {Math.PI * radius * radius:F5}");

        Console.WriteLine("\nPress any key to exit...");
        Console.Read();
    }
}