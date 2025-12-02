using System;
using System.Collections.Generic;
using System.Linq;

class NameConnector
{
    static void Main()
    {
        // İsimleri tutmak için bir String Listesi oluşturuyoruz
        List<string> names = new List<string>();

        Console.WriteLine("--- 10 Adet İsim Giriniz ---");

        // 1. Kullanıcıdan 10 isim al ve BÜYÜK HARFE çevir
        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"{i}. İsim: ");
            string input = Console.ReadLine();
            
            // "converts them to upper case" kuralı
            names.Add(input.ToUpper());
        }

        // 2. Sıralama İşlemleri
        // List.Sort() varsayılan olarak A'dan Z'ye (Ascending) sıralar.
        names.Sort(); 
        
        // "displays the names in descending order" (Azalan sıra) için listeyi ters çeviriyoruz.
        names.Reverse();

        Console.WriteLine("\n--- Azalan Sıra (Descending) ---");
        // "string method Join with two arguments" ipucu kullanımı
        Console.WriteLine(string.Join(", ", names));

        // 3. Tekrar Artan Sıraya Döndürme
        // "rearranges the names in ascending order... Hint: sentence.Reverse()"
        // Listemiz şu an Z'den A'ya (Azalan) sırada, tekrar Reverse yaparsak A'dan Z'ye (Artan) döner.
        names.Reverse();

        Console.WriteLine("\n--- Artan Sıra (Ascending) ---");
        Console.WriteLine(string.Join(", ", names));

        Console.ReadLine(); // Konsolu açık tutmak için
    }
}