using System;

class ComputerAssistedInstruction
{
    // Rastgele sayı üretici (Sınıf seviyesinde tanımlandı)
    private static Random randomNumbers = new Random();

    static void Main()
    {
        Console.WriteLine("--- Carpim Tablosu Ogretmeni ---");
        Console.WriteLine("(Cikmak icin Ctrl+C yapabilirsiniz)\n");

        // Sonsuz döngü ile sürekli yeni soru soruyoruz
        while (true)
        {
            GenerateQuestion();
        }
    }

    // Her yeni soru için çağrılan metot
    static void GenerateQuestion()
    {
        // İki adet pozitif tek basamaklı sayı üret (1-9 arası)
        int num1 = randomNumbers.Next(1, 10);
        int num2 = randomNumbers.Next(1, 10);
        int correctAnswer = num1 * num2;

        // Soruyu sor
        Ask(num1, num2);

        // Öğrenci doğru bilene kadar döngü devam eder
        while (true)
        {
            // Kullanıcıdan giriş al
            string input = Console.ReadLine();

            if (int.TryParse(input, out int studentAnswer))
            {
                if (studentAnswer == correctAnswer)
                {
                    Console.WriteLine("Very good!\n");
                    // Doğru bildiği için döngüden çık, Main'e dön ve yeni soru üret
                    break; 
                }
                else
                {
                    Console.WriteLine("No. Please try again.");
                    // Yanlış bildiği için aynı soruyu tekrar hatırlat
                    Ask(num1, num2);
                }
            }
            else
            {
                Console.WriteLine("Gecersiz giris. Lutfen bir sayi giriniz.");
                Ask(num1, num2);
            }
        }
    }

    // Soruyu ekrana yazdıran yardımcı metot
    static void Ask(int n1, int n2)
    {
        Console.Write($"How much is {n1} times {n2}? ");
    }
}