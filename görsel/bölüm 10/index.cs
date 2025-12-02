using System;

// Sınıf Tanımı
public class DepreciatingValue
{
    // Instance (Nesneye özgü) özellik: Her varlığın kendi değeri vardır.
    public decimal ValueOfAsset { get; private set; }

    // Static (Sınıfa özgü) özellik: Tüm varlıklar aynı amortisman oranını paylaşır.
    // Read-write property (Hem okunabilir hem yazılabilir)
    public static decimal AnnualDepreciationRate { get; set; }

    // Kurucu Metot (Constructor)
    public DepreciatingValue(decimal initialValue)
    {
        if (initialValue >= 0)
            ValueOfAsset = initialValue;
        else
            throw new ArgumentOutOfRangeException("Asset value cannot be negative.");
    }

    // Yıllık değer kaybını hesaplayan ve varlığın değerinden düşen metot
    public void CalculateAnnualDepreciation()
    {
        // Değer kaybı = Mevcut Değer * Oran
        decimal depreciationAmount = ValueOfAsset * AnnualDepreciationRate;
        
        // Yeni değer = Mevcut Değer - Değer Kaybı
        ValueOfAsset -= depreciationAmount;
    }
}

// Test Uygulaması
class DepreciatingValueTest
{
    static void Main()
    {
        // 1. Nesneleri Oluşturma (5M, 6M ve 7M değerlerinde)
        DepreciatingValue asset1 = new DepreciatingValue(5000000m);
        DepreciatingValue asset2 = new DepreciatingValue(6000000m);
        DepreciatingValue asset3 = new DepreciatingValue(7000000m);

        Console.WriteLine("--- BASLANGIC DEGERLERI ---");
        DisplayAssets(asset1, asset2, asset3);

        // 2. Oranı %10 (0.10) olarak ayarlama
        DepreciatingValue.AnnualDepreciationRate = 0.10m;
        
        Console.WriteLine($"\n--- 1 YIL SONRA (Oran: {DepreciatingValue.AnnualDepreciationRate:P0}) ---");
        
        // Değer kaybını hesapla
        asset1.CalculateAnnualDepreciation();
        asset2.CalculateAnnualDepreciation();
        asset3.CalculateAnnualDepreciation();

        // Yeni değerleri göster
        DisplayAssets(asset1, asset2, asset3);

        // 3. Oranı %11 (0.11) olarak değiştirme
        DepreciatingValue.AnnualDepreciationRate = 0.11m;

        Console.WriteLine($"\n--- GELECEK 3 YIL (Yeni Oran: {DepreciatingValue.AnnualDepreciationRate:P0}) ---");

        // Sonraki 3 yıl için döngü
        for (int year = 1; year <= 3; year++)
        {
            Console.WriteLine($"\n> YIL {year + 1} SONU:");
            
            asset1.CalculateAnnualDepreciation();
            asset2.CalculateAnnualDepreciation();
            asset3.CalculateAnnualDepreciation();

            DisplayAssets(asset1, asset2, asset3);
        }

        Console.ReadLine(); // Konsolu açık tutmak için
    }

    // Varlıkların değerini ekrana yazdıran yardımcı metot
    static void DisplayAssets(DepreciatingValue a1, DepreciatingValue a2, DepreciatingValue a3)
    {
        Console.WriteLine($"Asset 1 Degeri: {a1.ValueOfAsset:C}");
        Console.WriteLine($"Asset 2 Degeri: {a2.ValueOfAsset:C}");
        Console.WriteLine($"Asset 3 Degeri: {a3.ValueOfAsset:C}");
    }
}