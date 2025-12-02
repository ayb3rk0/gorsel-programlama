using System;

// 4.15: Computerization of Health Records
class HealthProfile
{
    // Özellikler (Properties)
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int BirthMonth { get; set; }
    public int BirthDay { get; set; }
    public int BirthYear { get; set; }
    public double HeightInInches { get; set; }
    public double WeightInPounds { get; set; }

    // Constructor (Kurucu Metot)
    public HealthProfile(string firstName, string lastName, string gender,
                         int birthMonth, int birthDay, int birthYear,
                         double height, double weight)
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        BirthMonth = birthMonth;
        BirthDay = birthDay;
        BirthYear = birthYear;
        HeightInInches = height;
        WeightInPounds = weight;
    }

    // Yaş Hesaplama Metodu (Yıl bazlı)
    public int CalculateAge()
    {
        var today = DateTime.Today;
        var age = today.Year - BirthYear;
        // Eğer bu yıl doğum günü henüz gelmediyse yaşı 1 azalt
        if (birthDateNotPassedYet(today))
        {
            age--;
        }
        return age;
    }

    private bool birthDateNotPassedYet(DateTime today)
    {
        return today.Month < BirthMonth || (today.Month == BirthMonth && today.Day < BirthDay);
    }

    // Maksimum Kalp Atış Hızı (220 - Yaş)
    public int CalculateMaxHeartRate()
    {
        return 220 - CalculateAge();
    }

    // Hedef Kalp Atış Hızı Aralığı (%50 - %85)
    public string CalculateTargetHeartRate()
    {
        int maxHeartRate = CalculateMaxHeartRate();
        int minTarget = (int)(maxHeartRate * 0.50);
        int maxTarget = (int)(maxHeartRate * 0.85);
        return $"{minTarget} - {maxTarget} bpm";
    }

    // Vücut Kitle İndeksi (BMI) Hesaplama
    // Formül: (WeightInPounds * 703) / (HeightInInches * HeightInInches)
    public double CalculateBMI()
    {
        if (HeightInInches <= 0) return 0;
        return (WeightInPounds * 703) / (HeightInInches * HeightInInches);
    }
}

class HealthProfileTest
{
    static void Main()
    {
        Console.WriteLine("--- SAGLIK PROFILI OLUSTURMA (HealthProfile) ---");
        Console.WriteLine("Lutfen asagidaki bilgileri giriniz:\n");

        // Kullanıcıdan veri alma
        Console.Write("Ad (First Name): ");
        string fName = Console.ReadLine();

        Console.Write("Soyad (Last Name): ");
        string lName = Console.ReadLine();

        Console.Write("Cinsiyet (Gender): ");
        string gender = Console.ReadLine();

        Console.Write("Dogum Yili (Year): ");
        int bYear = int.Parse(Console.ReadLine());

        Console.Write("Dogum Ayi (Month 1-12): ");
        int bMonth = int.Parse(Console.ReadLine());

        Console.Write("Dogum Gunu (Day): ");
        int bDay = int.Parse(Console.ReadLine());

        Console.Write("Boy (inch cinsinden): ");
        double height = double.Parse(Console.ReadLine());

        Console.Write("Kilo (pound cinsinden): ");
        double weight = double.Parse(Console.ReadLine());

        // Nesneyi oluşturma
        HealthProfile profile = new HealthProfile(fName, lName, gender, bMonth, bDay, bYear, height, weight);

        // Sonuçları Görüntüleme
        Console.WriteLine("\n\n--- SAGLIK RAPORU ---");
        Console.WriteLine($"Hasta: {profile.LastName}, {profile.FirstName}");
        Console.WriteLine($"Cinsiyet: {profile.Gender}");
        Console.WriteLine($"Dogum Tarihi: {profile.BirthDay}/{profile.BirthMonth}/{profile.BirthYear}");
        Console.WriteLine($"Yas: {profile.CalculateAge()}");
        Console.WriteLine($"Boy: {profile.HeightInInches} inç");
        Console.WriteLine($"Kilo: {profile.WeightInPounds} lbs");
        
        Console.WriteLine(new string('-', 30));
        
        Console.WriteLine($"Maksimum Kalp Atis Hizi: {profile.CalculateMaxHeartRate()} bpm");
        Console.WriteLine($"Hedef Kalp Atis Hizi Araligi: {profile.CalculateTargetHeartRate()}");
        
        double bmi = profile.CalculateBMI();
        Console.WriteLine($"Vucut Kitle Indeksi (BMI): {bmi:F1}");

        // BMI Bilgi Tablosu
        Console.WriteLine("\n--- BMI DEGERLERI ---");
        Console.WriteLine("Dusuk Kilo (Underweight): < 18.5");
        Console.WriteLine("Normal (Normal weight):   18.5 - 24.9");
        Console.WriteLine("Fazla Kilo (Overweight):  25 - 29.9");
        Console.WriteLine("Obez (Obese):             30 ve uzeri");

        Console.WriteLine("\nCikmak icin bir tusa basin...");
        Console.Read();
    }
}