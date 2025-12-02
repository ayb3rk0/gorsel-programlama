using System;

class AirlineReservations
{
    static void Main()
    {
        // 10 koltuklu bir uçak (index 0-9). false = boş, true = dolu.
        // C# dilinde bool dizileri varsayılan olarak 'false' başlatılır, 
        // bu yüzden "Initialize all elements to false" kısmı otomatik hallolur.
        bool[] seats = new bool[10]; 
        int seatsFilled = 0;

        Console.WriteLine("--- Havayolu Rezervasyon Sistemine Hoşgeldiniz ---");

        // Uçak tamamen dolana kadar döngü devam eder
        while (seatsFilled < 10)
        {
            Console.WriteLine("\nLütfen Birinci Sınıf (First Class) için 1'e basınız");
            Console.WriteLine("Lütfen Ekonomi (Economy) için 2'ye basınız");
            Console.Write("Seçiminiz: ");

            // Kullanıcı girişi kontrolü
            if (int.TryParse(Console.ReadLine(), out int choice) && (choice == 1 || choice == 2))
            {
                if (choice == 1) // First Class İsteği
                {
                    if (!AssignFirstClass(seats)) // Eğer yerleşemezse (Doluysa)
                    {
                        // Ekonomi'de yer var mı diye bak?
                        if (IsSectionFull(seats, 6, 10))
                        {
                            Console.WriteLine("Üzgünüz, uçak tamamen dolu. Bir sonraki uçuş 3 saat sonra.");
                            break; // Döngüyü kır
                        }
                        else
                        {
                            Console.Write("First Class dolu. Ekonomi bölümüne yerleştirilmeyi kabul ediyor musunuz? (E/H): ");
                            string response = Console.ReadLine().ToUpper();
                            if (response == "E" || response == "Y")
                            {
                                AssignEconomy(seats);
                            }
                            else
                            {
                                Console.WriteLine("Bir sonraki uçuş 3 saat sonra.");
                            }
                        }
                    }
                }
                else if (choice == 2) // Ekonomi İsteği
                {
                    if (!AssignEconomy(seats)) // Eğer yerleşemezse (Doluysa)
                    {
                        // First Class'ta yer var mı diye bak?
                        if (IsSectionFull(seats, 1, 5))
                        {
                            Console.WriteLine("Üzgünüz, uçak tamamen dolu. Bir sonraki uçuş 3 saat sonra.");
                            break;
                        }
                        else
                        {
                            Console.Write("Ekonomi dolu. First Class bölümüne yerleştirilmeyi kabul ediyor musunuz? (E/H): ");
                            string response = Console.ReadLine().ToUpper();
                            if (response == "E" || response == "Y")
                            {
                                AssignFirstClass(seats);
                            }
                            else
                            {
                                Console.WriteLine("Bir sonraki uçuş 3 saat sonra.");
                            }
                        }
                    }
                }

                // Doluluk oranını güncelle
                seatsFilled = 0;
                foreach (bool seat in seats)
                {
                    if (seat) seatsFilled++;
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. Lütfen 1 veya 2 giriniz.");
            }
        }

        if (seatsFilled == 10)
        {
            Console.WriteLine("\nBütün koltuklar doldu. İlginiz için teşekkürler.");
        }
        
        Console.ReadLine(); // Konsolu açık tutmak için
    }

    // First Class (Koltuk 1-5, Index 0-4) Atama Metodu
    static bool AssignFirstClass(bool[] seats)
    {
        for (int i = 0; i < 5; i++)
        {
            if (seats[i] == false) // Koltuk boşsa
            {
                seats[i] = true; // Koltuğu doldur
                PrintBoardingPass(i + 1, "First Class");
                return true; // Başarılı atama
            }
        }
        return false; // Bölüm dolu
    }

    // Ekonomi (Koltuk 6-10, Index 5-9) Atama Metodu
    static bool AssignEconomy(bool[] seats)
    {
        for (int i = 5; i < 10; i++)
        {
            if (seats[i] == false) // Koltuk boşsa
            {
                seats[i] = true; // Koltuğu doldur
                PrintBoardingPass(i + 1, "Economy");
                return true; // Başarılı atama
            }
        }
        return false; // Bölüm dolu
    }

    // Belirli bir aralığın dolu olup olmadığını kontrol eden yardımcı metot
    static bool IsSectionFull(bool[] seats, int startSeat, int endSeat)
    {
        for (int i = startSeat - 1; i < endSeat; i++)
        {
            if (seats[i] == false) return false; // En az bir boş yer var
        }
        return true; // Hepsi dolu
    }

    // Biniş Kartı Yazdırma
    static void PrintBoardingPass(int seatNumber, string section)
    {
        Console.WriteLine($"\n*********************************");
        Console.WriteLine($"* BİNİŞ KARTI (BOARDING PASS)   *");
        Console.WriteLine($"* Koltuk No : {seatNumber, -2}                *");
        Console.WriteLine($"* Bölüm     : {section, -15}   *");
        Console.WriteLine($"*********************************");
    }
}