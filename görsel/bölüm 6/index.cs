using System;

class GlobalWarmingQuiz
{
    static void Main()
    {
        int score = 0;
        
        Console.WriteLine("--- Kuresel Isinma Bilgi Yarismasi ---");
        Console.WriteLine("Lutfen asagidaki 5 soruyu 1, 2, 3 veya 4 yazarak cevaplayiniz.\n");

        // Soru 1: Temel Bilgi
        Console.WriteLine("1. Asagidakilerden hangisi birincil sera gazi olarak kabul edilir?");
        Console.WriteLine("1) Azot (Nitrogen)");
        Console.WriteLine("2) Oksijen (Oxygen)");
        Console.WriteLine("3) Karbondioksit (Carbon Dioxide)"); // Doğru
        Console.WriteLine("4) Argon");
        if (GetAnswer() == 3) score++;

        // Soru 2: Tarihsel Bilgi
        Console.WriteLine("\n2. 1997 yilinda sera gazi emisyonlarini azaltmak icin hangi uluslararasi anlasma kabul edilmistir?");
        Console.WriteLine("1) Paris Anlasmasi");
        Console.WriteLine("2) Kyoto Protokolu"); // Doğru
        Console.WriteLine("3) Montreal Protokolu");
        Console.WriteLine("4) Cenevre Sozlesmesi");
        if (GetAnswer() == 2) score++;

        // Soru 3: IPCC Görüşü (Bilimsel Konsensus)
        Console.WriteLine("\n3. IPCC'ye gore, 20. yuzyilin ortalarindan beri gozlemlenen isinmanin baskin nedeni nedir?");
        Console.WriteLine("1) Gunes aktiviteleri");
        Console.WriteLine("2) Volkanik patlamalar");
        Console.WriteLine("3) Insan etkisi (Antropojenik)"); // Doğru
        Console.WriteLine("4) Yorunge degisiklikleri");
        if (GetAnswer() == 3) score++;

        // Soru 4: Karşıt Görüş / Skeptik Argüman
        Console.WriteLine("\n4. Kuresel isinma karsitlari (skeptikler) tarafindan iklim degisikligi icin siklikla one surulen dogal neden hangisidir?");
        Console.WriteLine("1) Karbondioksitin sera gazi olmamasi");
        Console.WriteLine("2) Dunyanin aslinda hizla sogumasi");
        Console.WriteLine("3) Iklim degisikliginin dogal gunes donguleri ve yorunge modellerinden kaynaklanmasi"); // Doğru (Argüman olarak)
        Console.WriteLine("4) Okyanus seviyelerinin dusmesi");
        if (GetAnswer() == 3) score++;

        // Soru 5: Sonuçlar
        Console.WriteLine("\n5. Kuresel isinmanin devam etmesi durumunda beklenen en buyuk sonuclardan biri nedir?");
        Console.WriteLine("1) Kutup buzullarinin genislemesi");
        Console.WriteLine("2) Asiri hava olaylarinin azalmasi");
        Console.WriteLine("3) Kuresel deniz seviyelerinin yukselmesi"); // Doğru
        Console.WriteLine("4) Okyanus asitliliginin sabitlenmesi");
        if (GetAnswer() == 3) score++;

        // Sonuçları Değerlendirme
        Console.WriteLine($"\nTest Bitti! 5 sorudan {score} tanesini dogru bildiniz.");

        if (score == 5)
        {
            Console.WriteLine("Mukemmel (Excellent)");
        }
        else if (score == 4)
        {
            Console.WriteLine("Cok Iyi (Very Good)");
        }
        else
        {
            Console.WriteLine("Kuresel isinma konusundaki bilgilerinizi tazeleme zamani.");
            Console.WriteLine("\nBilgi edinebileceginiz bazi kaynaklar:");
            Console.WriteLine("- https://climate.nasa.gov/");
            Console.WriteLine("- https://www.ipcc.ch/");
            Console.WriteLine("- https://skepticalscience.com/ (Karsit gorusleri de inceler)");
        }
        
        Console.WriteLine("\nCikmak icin bir tusa basin...");
        Console.Read(); 
    }

    // Cevabı alan ve doğrulayan yardımcı metot
    static int GetAnswer()
    {
        while (true)
        {
            Console.Write("Cevabiniz (1-4): ");
            if (int.TryParse(Console.ReadLine(), out int answer) && answer >= 1 && answer <= 4)
            {
                return answer;
            }
            Console.WriteLine("Gecersiz giris. Lutfen 1 ile 4 arasinda bir sayi giriniz.");
        }
    }
}