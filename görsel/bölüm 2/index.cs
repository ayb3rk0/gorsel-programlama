using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculatorApp
{
    public class CalculatorForm : Form
    {
        // Kontrollerin Tanımlanması
        private TextBox txtDisplay;
        private Panel pnlNumeric;
        private Panel pnlOperators;
        private Panel pnlClear;
        
        // Butonlar
        private Button btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0;
        private Button btn00, btnDot;
        private Button btnPlus, btnMinus, btnMultiply, btnDivide, btnEquals;
        private Button btnC, btnCA, btnOff;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // a) Form Özellikleri
            this.Text = "Calculator";
            this.Font = new Font("Segoe UI", 9F);
            this.Size = new Size(258, 210);
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Boyut sabitlensin
            this.MaximizeBox = false;

            // b) TextBox (Ekran)
            txtDisplay = new TextBox();
            txtDisplay.Text = "0";
            txtDisplay.Location = new Point(12, 12); // Fig 2.38'e uygun tahmini konum
            txtDisplay.Size = new Size(218, 23); // Genişlik panellere göre ayarlandı
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            this.Controls.Add(txtDisplay);

            // c) Panel 1 (Numeric Keys) - Sayısal Tuşlar
            pnlNumeric = new Panel();
            pnlNumeric.BorderStyle = BorderStyle.Fixed3D;
            pnlNumeric.Size = new Size(90, 120);
            pnlNumeric.Location = new Point(12, 45); // TextBox'ın altı, sol taraf
            this.Controls.Add(pnlNumeric);

            // d) Panel 2 (Operator Keys) - İşlem Tuşları
            pnlOperators = new Panel();
            pnlOperators.BorderStyle = BorderStyle.Fixed3D;
            pnlOperators.Size = new Size(62, 120);
            pnlOperators.Location = new Point(108, 45); // Numeric panelin sağı
            this.Controls.Add(pnlOperators);

            // e) Panel 3 (Clear/Clear All) - Temizleme Tuşları
            pnlClear = new Panel();
            pnlClear.BorderStyle = BorderStyle.Fixed3D;
            pnlClear.Size = new Size(54, 62);
            pnlClear.Location = new Point(176, 45); // Operator panelin sağı
            this.Controls.Add(pnlClear);

            // OFF Butonu (Panel 3'ün altında yer alabilir veya bağımsız)
            // Talimatlarda OFF butonu boyutu verilmiş ama paneli belirtilmemiş.
            // Genelde C/A panelinin altında olur.
            btnOff = new Button();
            btnOff.Text = "OFF";
            btnOff.Size = new Size(54, 23);
            btnOff.Location = new Point(176, 113); // Panel 3'ün altı
            this.Controls.Add(btnOff);

            // f) Butonları Ekleme ve Boyutlandırma

            // --- Panel 1 (Numeric) İçeriği ---
            // Standart Grid: 1-9, 0, 00, .
            // Boyutlar: 0-9 ve . (23,23), 00 (52,23)
            
            // Satır 1
            CreateButton(pnlNumeric, "7", 23, 23, 3, 3);
            CreateButton(pnlNumeric, "8", 23, 23, 30, 3);
            CreateButton(pnlNumeric, "9", 23, 23, 57, 3);

            // Satır 2
            CreateButton(pnlNumeric, "4", 23, 23, 3, 30);
            CreateButton(pnlNumeric, "5", 23, 23, 30, 30);
            CreateButton(pnlNumeric, "6", 23, 23, 57, 30);

            // Satır 3
            CreateButton(pnlNumeric, "1", 23, 23, 3, 57);
            CreateButton(pnlNumeric, "2", 23, 23, 30, 57);
            CreateButton(pnlNumeric, "3", 23, 23, 57, 57);

            // Satır 4
            CreateButton(pnlNumeric, "0", 23, 23, 3, 84);
            CreateButton(pnlNumeric, "00", 52, 23, 30, 84); // Geniş Buton
            // Not: "." butonu için yer kalmadı, Panel 1 genellikle sadece sayıları alır.
            // "." butonunu Panel 2'ye kaydırabiliriz veya tasarımda 00 yerine . ve 0 kullanılır.
            // Ancak talimatta 00 boyutu 52 denmiş, bu da 2 birim yer kaplar.
            // Bu durumda "." butonunu Operators paneline ekleyelim.

            // --- Panel 2 (Operators) İçeriği ---
            // Boyutlar: /, *, -, = (23,23), + (23, 81)
            
            // Sütun 1
            CreateButton(pnlOperators, "/", 23, 23, 3, 3);
            CreateButton(pnlOperators, "*", 23, 23, 3, 30);
            CreateButton(pnlOperators, "-", 23, 23, 3, 57);
            CreateButton(pnlOperators, ".", 23, 23, 3, 84); // Nokta buraya eklendi

            // Sütun 2
            // "+" butonu uzun (height: 81)
            btnPlus = new Button();
            btnPlus.Text = "+";
            btnPlus.Size = new Size(23, 81); // Talimattaki boyut
            btnPlus.Location = new Point(30, 3);
            pnlOperators.Controls.Add(btnPlus);

            // "=" butonu
            CreateButton(pnlOperators, "=", 23, 23, 30, 88); // +'nın altı (biraz taşabilir, ayarlandı)

            // --- Panel 3 (Clear) İçeriği ---
            // Boyutlar: C, C/A (44, 23)
            
            CreateButton(pnlClear, "C", 44, 23, 3, 3);
            CreateButton(pnlClear, "C/A", 44, 23, 3, 30);
        }

        // Buton oluşturmak için yardımcı metot
        private void CreateButton(Panel panel, string text, int width, int height, int x, int y)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Size = new Size(width, height);
            btn.Location = new Point(x, y);
            panel.Controls.Add(btn);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());
        }
    }
}