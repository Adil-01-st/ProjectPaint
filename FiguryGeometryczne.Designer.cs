namespace Projekt2FiguryGeometryczne_Adilbek_Khiiasov_58981
{
    partial class FiguryGeometryczne
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AkRycownica = new System.Windows.Forms.PictureBox();
            this.btnPrzesuńFigury = new System.Windows.Forms.Button();
            this.AkbtnStart = new System.Windows.Forms.Button();
            this.AktxtN = new System.Windows.Forms.TextBox();
            this.AkchlbFiguryGeometryczne = new System.Windows.Forms.CheckedListBox();
            this.Aklabel1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnWłącz = new System.Windows.Forms.Button();
            this.btnWyłącz = new System.Windows.Forms.Button();
            this.btnPopredni = new System.Windows.Forms.Button();
            this.btnNastępny = new System.Windows.Forms.Button();
            this.AkbAutomatyczny = new System.Windows.Forms.RadioButton();
            this.AkbManualny = new System.Windows.Forms.RadioButton();
            this.txtNumerFigury = new System.Windows.Forms.TextBox();
            this.lblNumerFigury = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AKbPunkt = new System.Windows.Forms.RadioButton();
            this.akbOkrąg = new System.Windows.Forms.RadioButton();
            this.akbLiniaKreślonaMyszą = new System.Windows.Forms.RadioButton();
            this.akbWielokątForemny = new System.Windows.Forms.RadioButton();
            this.akbDrawClosedCurve = new System.Windows.Forms.RadioButton();
            this.akbFillPie = new System.Windows.Forms.RadioButton();
            this.akbDrawPath = new System.Windows.Forms.RadioButton();
            this.akWybierzFigurę = new System.Windows.Forms.GroupBox();
            this.akbDrawLines = new System.Windows.Forms.RadioButton();
            this.akbProstokąt = new System.Windows.Forms.RadioButton();
            this.akbDrawPie = new System.Windows.Forms.RadioButton();
            this.akbDrawArc = new System.Windows.Forms.RadioButton();
            this.akbFillPath = new System.Windows.Forms.RadioButton();
            this.akbDrawCurve = new System.Windows.Forms.RadioButton();
            this.akbFillieElipsa = new System.Windows.Forms.RadioButton();
            this.akbKwadrat = new System.Windows.Forms.RadioButton();
            this.akbElipsa = new System.Windows.Forms.RadioButton();
            this.akbLiniaProsta = new System.Windows.Forms.RadioButton();
            this.btnZmieńLosowoLokalizację = new System.Windows.Forms.Button();
            this.btnZmieńLosowoAtrybuty = new System.Windows.Forms.Button();
            this.lbNumerFigury = new System.Windows.Forms.Label();
            this.lbWspX = new System.Windows.Forms.Label();
            this.lbWspY = new System.Windows.Forms.Label();
            this.lblWspółrzędnePołożenia = new System.Windows.Forms.Label();
            this.lblWspX = new System.Windows.Forms.TextBox();
            this.lblWspY = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.AkRycownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.akWybierzFigurę.SuspendLayout();
            this.SuspendLayout();
            // 
            // AkRycownica
            // 
            this.AkRycownica.Location = new System.Drawing.Point(166, 65);
            this.AkRycownica.Name = "AkRycownica";
            this.AkRycownica.Size = new System.Drawing.Size(904, 243);
            this.AkRycownica.TabIndex = 0;
            this.AkRycownica.TabStop = false;
  
            // 
            // btnPrzesuńFigury
            // 
            this.btnPrzesuńFigury.Location = new System.Drawing.Point(45, 202);
            this.btnPrzesuńFigury.Name = "btnPrzesuńFigury";
            this.btnPrzesuńFigury.Size = new System.Drawing.Size(131, 72);
            this.btnPrzesuńFigury.TabIndex = 1;
            this.btnPrzesuńFigury.Text = "Zmień lokalizację figur geometrycznych";
            this.btnPrzesuńFigury.UseVisualStyleBackColor = true;
            this.btnPrzesuńFigury.Click += new System.EventHandler(this.btnPrzesuńFigury_Click);
            // 
            // AkbtnStart
            // 
            this.AkbtnStart.Location = new System.Drawing.Point(45, 93);
            this.AkbtnStart.Name = "AkbtnStart";
            this.AkbtnStart.Size = new System.Drawing.Size(131, 23);
            this.AkbtnStart.TabIndex = 2;
            this.AkbtnStart.Text = "Start";
            this.AkbtnStart.UseVisualStyleBackColor = true;
            this.AkbtnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // AktxtN
            // 
            this.AktxtN.Location = new System.Drawing.Point(45, 65);
            this.AktxtN.Name = "AktxtN";
            this.AktxtN.Size = new System.Drawing.Size(87, 22);
            this.AktxtN.TabIndex = 3;
            // 
            // AkchlbFiguryGeometryczne
            // 
            this.AkchlbFiguryGeometryczne.FormattingEnabled = true;
            this.AkchlbFiguryGeometryczne.Items.AddRange(new object[] {
            "Punkt",
            "Linia",
            "Elipsa",
            "Okrąg",
            "Prostokąt",
            "Kwadrat",
            "Wielokąt foremny",
            "Koło jednobarwne"});
            this.AkchlbFiguryGeometryczne.Location = new System.Drawing.Point(1096, 181);
            this.AkchlbFiguryGeometryczne.Name = "AkchlbFiguryGeometryczne";
            this.AkchlbFiguryGeometryczne.Size = new System.Drawing.Size(159, 191);
            this.AkchlbFiguryGeometryczne.TabIndex = 4;
            // 
            // Aklabel1
            // 
            this.Aklabel1.AutoSize = true;
            this.Aklabel1.Location = new System.Drawing.Point(9, 33);
            this.Aklabel1.Name = "Aklabel1";
            this.Aklabel1.Size = new System.Drawing.Size(210, 16);
            this.Aklabel1.TabIndex = 5;
            this.Aklabel1.Text = "Podaj liczbę figur geometrycznych";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(1093, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 97);
            this.label2.TabIndex = 7;
            this.label2.Text = "Zaznacz figury geometryczne, które mają być losowane i wyświetlane na planszy gra" +
    "ficznej\r\n\r\n";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tag = "0";
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnWłącz
            // 
            this.btnWłącz.Location = new System.Drawing.Point(11, 527);
            this.btnWłącz.Name = "btnWłącz";
            this.btnWłącz.Size = new System.Drawing.Size(149, 55);
            this.btnWłącz.TabIndex = 8;
            this.btnWłącz.Text = "Włącz slajder figur geomtrycznych";
            this.btnWłącz.UseVisualStyleBackColor = true;
            this.btnWłącz.Click += new System.EventHandler(this.btnWłącz_Click);
            // 
            // btnWyłącz
            // 
            this.btnWyłącz.Location = new System.Drawing.Point(11, 613);
            this.btnWyłącz.Name = "btnWyłącz";
            this.btnWyłącz.Size = new System.Drawing.Size(149, 63);
            this.btnWyłącz.TabIndex = 9;
            this.btnWyłącz.Text = "Wyłącz slajder figur geometrycznych";
            this.btnWyłącz.UseVisualStyleBackColor = true;
            this.btnWyłącz.Click += new System.EventHandler(this.btnWyłącz_Click);
            // 
            // btnPopredni
            // 
            this.btnPopredni.Location = new System.Drawing.Point(783, 611);
            this.btnPopredni.Name = "btnPopredni";
            this.btnPopredni.Size = new System.Drawing.Size(143, 51);
            this.btnPopredni.TabIndex = 37;
            this.btnPopredni.Text = "Poprzedni";
            this.btnPopredni.UseVisualStyleBackColor = true;
            this.btnPopredni.Click += new System.EventHandler(this.btnPopredni_Click);
            // 
            // btnNastępny
            // 
            this.btnNastępny.Location = new System.Drawing.Point(454, 611);
            this.btnNastępny.Name = "btnNastępny";
            this.btnNastępny.Size = new System.Drawing.Size(143, 51);
            this.btnNastępny.TabIndex = 11;
            this.btnNastępny.Text = "Następny";
            this.btnNastępny.UseVisualStyleBackColor = true;
            this.btnNastępny.Click += new System.EventHandler(this.btnNastępny_Click);
            // 
            // AkbAutomatyczny
            // 
            this.AkbAutomatyczny.AutoSize = true;
            this.AkbAutomatyczny.Location = new System.Drawing.Point(17, 21);
            this.AkbAutomatyczny.Name = "AkbAutomatyczny";
            this.AkbAutomatyczny.Size = new System.Drawing.Size(111, 20);
            this.AkbAutomatyczny.TabIndex = 12;
            this.AkbAutomatyczny.TabStop = true;
            this.AkbAutomatyczny.Text = "Automatyczny";
            this.AkbAutomatyczny.UseVisualStyleBackColor = true;
            // 
            // AkbManualny
            // 
            this.AkbManualny.AutoSize = true;
            this.AkbManualny.Location = new System.Drawing.Point(17, 48);
            this.AkbManualny.Name = "AkbManualny";
            this.AkbManualny.Size = new System.Drawing.Size(170, 20);
            this.AkbManualny.TabIndex = 13;
            this.AkbManualny.TabStop = true;
            this.AkbManualny.Text = "Manualny (przyciskowy)";
            this.AkbManualny.UseVisualStyleBackColor = true;
            // 
            // txtNumerFigury
            // 
            this.txtNumerFigury.Location = new System.Drawing.Point(641, 625);
            this.txtNumerFigury.Name = "txtNumerFigury";
            this.txtNumerFigury.Size = new System.Drawing.Size(86, 22);
            this.txtNumerFigury.TabIndex = 14;
            this.txtNumerFigury.TextChanged += new System.EventHandler(this.txtNumerFigury_TextChanged);
            // 
            // lblNumerFigury
            // 
            this.lblNumerFigury.Location = new System.Drawing.Point(0, 0);
            this.lblNumerFigury.Name = "lblNumerFigury";
            this.lblNumerFigury.Size = new System.Drawing.Size(100, 23);
            this.lblNumerFigury.TabIndex = 34;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AkbAutomatyczny);
            this.groupBox1.Controls.Add(this.AkbManualny);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox1.Location = new System.Drawing.Point(187, 593);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 83);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pokaz figur";
            // 
            // AKbPunkt
            // 
            this.AKbPunkt.AutoSize = true;
            this.AKbPunkt.Checked = true;
            this.AKbPunkt.Location = new System.Drawing.Point(21, 31);
            this.AKbPunkt.Name = "AKbPunkt";
            this.AKbPunkt.Size = new System.Drawing.Size(61, 20);
            this.AKbPunkt.TabIndex = 18;
            this.AKbPunkt.TabStop = true;
            this.AKbPunkt.Text = "Punkt";
            this.AKbPunkt.UseVisualStyleBackColor = true;
            // 
            // akbOkrąg
            // 
            this.akbOkrąg.AutoSize = true;
            this.akbOkrąg.Location = new System.Drawing.Point(21, 58);
            this.akbOkrąg.Name = "akbOkrąg";
            this.akbOkrąg.Size = new System.Drawing.Size(65, 20);
            this.akbOkrąg.TabIndex = 19;
            this.akbOkrąg.TabStop = true;
            this.akbOkrąg.Text = "Okrąg";
            this.akbOkrąg.UseVisualStyleBackColor = true;
            // 
            // akbLiniaKreślonaMyszą
            // 
            this.akbLiniaKreślonaMyszą.AutoSize = true;
            this.akbLiniaKreślonaMyszą.Location = new System.Drawing.Point(21, 112);
            this.akbLiniaKreślonaMyszą.Name = "akbLiniaKreślonaMyszą";
            this.akbLiniaKreślonaMyszą.Size = new System.Drawing.Size(163, 20);
            this.akbLiniaKreślonaMyszą.TabIndex = 21;
            this.akbLiniaKreślonaMyszą.TabStop = true;
            this.akbLiniaKreślonaMyszą.Text = "Linia \"kreślona\" myszą";
            this.akbLiniaKreślonaMyszą.UseVisualStyleBackColor = true;
            // 
            // akbWielokątForemny
            // 
            this.akbWielokątForemny.AutoSize = true;
            this.akbWielokątForemny.Location = new System.Drawing.Point(21, 85);
            this.akbWielokątForemny.Name = "akbWielokątForemny";
            this.akbWielokątForemny.Size = new System.Drawing.Size(134, 20);
            this.akbWielokątForemny.TabIndex = 20;
            this.akbWielokątForemny.TabStop = true;
            this.akbWielokątForemny.Text = "WielokątForemny";
            this.akbWielokątForemny.UseVisualStyleBackColor = true;
            // 
            // akbDrawClosedCurve
            // 
            this.akbDrawClosedCurve.AutoSize = true;
            this.akbDrawClosedCurve.Location = new System.Drawing.Point(21, 166);
            this.akbDrawClosedCurve.Name = "akbDrawClosedCurve";
            this.akbDrawClosedCurve.Size = new System.Drawing.Size(137, 20);
            this.akbDrawClosedCurve.TabIndex = 23;
            this.akbDrawClosedCurve.TabStop = true;
            this.akbDrawClosedCurve.Text = "DrawClosedCurve";
            this.akbDrawClosedCurve.UseVisualStyleBackColor = true;
            // 
            // akbFillPie
            // 
            this.akbFillPie.AutoSize = true;
            this.akbFillPie.Location = new System.Drawing.Point(21, 139);
            this.akbFillPie.Name = "akbFillPie";
            this.akbFillPie.Size = new System.Drawing.Size(65, 20);
            this.akbFillPie.TabIndex = 22;
            this.akbFillPie.TabStop = true;
            this.akbFillPie.Text = "FillPie";
            this.akbFillPie.UseVisualStyleBackColor = true;
            // 
            // akbDrawPath
            // 
            this.akbDrawPath.AutoSize = true;
            this.akbDrawPath.Location = new System.Drawing.Point(21, 193);
            this.akbDrawPath.Name = "akbDrawPath";
            this.akbDrawPath.Size = new System.Drawing.Size(86, 20);
            this.akbDrawPath.TabIndex = 24;
            this.akbDrawPath.TabStop = true;
            this.akbDrawPath.Text = "DrawPath";
            this.akbDrawPath.UseVisualStyleBackColor = true;
            // 
            // akWybierzFigurę
            // 
            this.akWybierzFigurę.Controls.Add(this.akbDrawLines);
            this.akWybierzFigurę.Controls.Add(this.AKbPunkt);
            this.akWybierzFigurę.Controls.Add(this.akbProstokąt);
            this.akWybierzFigurę.Controls.Add(this.akbDrawPie);
            this.akWybierzFigurę.Controls.Add(this.lblNumerFigury);
            this.akWybierzFigurę.Controls.Add(this.akbDrawArc);
            this.akWybierzFigurę.Controls.Add(this.akbOkrąg);
            this.akWybierzFigurę.Controls.Add(this.akbFillPath);
            this.akWybierzFigurę.Controls.Add(this.akbWielokątForemny);
            this.akWybierzFigurę.Controls.Add(this.akbDrawCurve);
            this.akWybierzFigurę.Controls.Add(this.akbLiniaKreślonaMyszą);
            this.akWybierzFigurę.Controls.Add(this.akbFillieElipsa);
            this.akWybierzFigurę.Controls.Add(this.akbFillPie);
            this.akWybierzFigurę.Controls.Add(this.akbKwadrat);
            this.akWybierzFigurę.Controls.Add(this.akbDrawClosedCurve);
            this.akWybierzFigurę.Controls.Add(this.akbElipsa);
            this.akWybierzFigurę.Controls.Add(this.akbDrawPath);
            this.akWybierzFigurę.Controls.Add(this.akbLiniaProsta);
            this.akWybierzFigurę.Location = new System.Drawing.Point(1219, 393);
            this.akWybierzFigurę.Name = "akWybierzFigurę";
            this.akWybierzFigurę.Size = new System.Drawing.Size(366, 225);
            this.akWybierzFigurę.TabIndex = 34;
            this.akWybierzFigurę.TabStop = false;
            this.akWybierzFigurę.Text = "Wybierz figurę geometryczną do kreślenia myszą";
            // 
            // akbDrawLines
            // 
            this.akbDrawLines.AutoSize = true;
            this.akbDrawLines.Location = new System.Drawing.Point(137, 140);
            this.akbDrawLines.Name = "akbDrawLines";
            this.akbDrawLines.Size = new System.Drawing.Size(91, 20);
            this.akbDrawLines.TabIndex = 35;
            this.akbDrawLines.TabStop = true;
            this.akbDrawLines.Text = "DrawLines";
            this.akbDrawLines.UseVisualStyleBackColor = true;
            // 
            // akbProstokąt
            // 
            this.akbProstokąt.AutoSize = true;
            this.akbProstokąt.Location = new System.Drawing.Point(137, 58);
            this.akbProstokąt.Name = "akbProstokąt";
            this.akbProstokąt.Size = new System.Drawing.Size(85, 20);
            this.akbProstokąt.TabIndex = 33;
            this.akbProstokąt.TabStop = true;
            this.akbProstokąt.Text = "Prostokąt";
            this.akbProstokąt.UseVisualStyleBackColor = true;
            // 
            // akbDrawPie
            // 
            this.akbDrawPie.AutoSize = true;
            this.akbDrawPie.Location = new System.Drawing.Point(259, 193);
            this.akbDrawPie.Name = "akbDrawPie";
            this.akbDrawPie.Size = new System.Drawing.Size(79, 20);
            this.akbDrawPie.TabIndex = 32;
            this.akbDrawPie.TabStop = true;
            this.akbDrawPie.Text = "DrawPie";
            this.akbDrawPie.UseVisualStyleBackColor = true;
            // 
            // akbDrawArc
            // 
            this.akbDrawArc.AutoSize = true;
            this.akbDrawArc.Location = new System.Drawing.Point(259, 166);
            this.akbDrawArc.Name = "akbDrawArc";
            this.akbDrawArc.Size = new System.Drawing.Size(79, 20);
            this.akbDrawArc.TabIndex = 31;
            this.akbDrawArc.TabStop = true;
            this.akbDrawArc.Text = "DrawArc";
            this.akbDrawArc.UseVisualStyleBackColor = true;
            // 
            // akbFillPath
            // 
            this.akbFillPath.AutoSize = true;
            this.akbFillPath.Location = new System.Drawing.Point(259, 140);
            this.akbFillPath.Name = "akbFillPath";
            this.akbFillPath.Size = new System.Drawing.Size(72, 20);
            this.akbFillPath.TabIndex = 30;
            this.akbFillPath.TabStop = true;
            this.akbFillPath.Text = "FillPath";
            this.akbFillPath.UseVisualStyleBackColor = true;
            // 
            // akbDrawCurve
            // 
            this.akbDrawCurve.AutoSize = true;
            this.akbDrawCurve.Location = new System.Drawing.Point(259, 112);
            this.akbDrawCurve.Name = "akbDrawCurve";
            this.akbDrawCurve.Size = new System.Drawing.Size(94, 20);
            this.akbDrawCurve.TabIndex = 29;
            this.akbDrawCurve.TabStop = true;
            this.akbDrawCurve.Text = "DrawCurve";
            this.akbDrawCurve.UseVisualStyleBackColor = true;
  
            // 
            // akbFillieElipsa
            // 
            this.akbFillieElipsa.AutoSize = true;
            this.akbFillieElipsa.Location = new System.Drawing.Point(259, 85);
            this.akbFillieElipsa.Name = "akbFillieElipsa";
            this.akbFillieElipsa.Size = new System.Drawing.Size(94, 20);
            this.akbFillieElipsa.TabIndex = 28;
            this.akbFillieElipsa.TabStop = true;
            this.akbFillieElipsa.Text = "FillieElipsa";
            this.akbFillieElipsa.UseVisualStyleBackColor = true;
            // 
            // akbKwadrat
            // 
            this.akbKwadrat.AutoSize = true;
            this.akbKwadrat.Location = new System.Drawing.Point(259, 58);
            this.akbKwadrat.Name = "akbKwadrat";
            this.akbKwadrat.Size = new System.Drawing.Size(76, 20);
            this.akbKwadrat.TabIndex = 27;
            this.akbKwadrat.TabStop = true;
            this.akbKwadrat.Text = "Kwadrat";
            this.akbKwadrat.UseVisualStyleBackColor = true;
            // 
            // akbElipsa
            // 
            this.akbElipsa.AutoSize = true;
            this.akbElipsa.Location = new System.Drawing.Point(259, 31);
            this.akbElipsa.Name = "akbElipsa";
            this.akbElipsa.Size = new System.Drawing.Size(66, 20);
            this.akbElipsa.TabIndex = 26;
            this.akbElipsa.TabStop = true;
            this.akbElipsa.Text = "Elipsa";
            this.akbElipsa.UseVisualStyleBackColor = true;
            // 
            // akbLiniaProsta
            // 
            this.akbLiniaProsta.AutoSize = true;
            this.akbLiniaProsta.Location = new System.Drawing.Point(136, 31);
            this.akbLiniaProsta.Name = "akbLiniaProsta";
            this.akbLiniaProsta.Size = new System.Drawing.Size(98, 20);
            this.akbLiniaProsta.TabIndex = 25;
            this.akbLiniaProsta.TabStop = true;
            this.akbLiniaProsta.Text = "Linia Prosta";
            this.akbLiniaProsta.UseVisualStyleBackColor = true;
            // 
            // btnZmieńLosowoLokalizację
            // 
            this.btnZmieńLosowoLokalizację.Location = new System.Drawing.Point(1225, 613);
            this.btnZmieńLosowoLokalizację.Name = "btnZmieńLosowoLokalizację";
            this.btnZmieńLosowoLokalizację.Size = new System.Drawing.Size(318, 47);
            this.btnZmieńLosowoLokalizację.TabIndex = 35;
            this.btnZmieńLosowoLokalizację.Text = "Zmień losowo lolkalizację figur geometrycznych kreślonych myszą";
            this.btnZmieńLosowoLokalizację.UseVisualStyleBackColor = true;
            // 
            // btnZmieńLosowoAtrybuty
            // 
            this.btnZmieńLosowoAtrybuty.Location = new System.Drawing.Point(1228, 666);
            this.btnZmieńLosowoAtrybuty.Name = "btnZmieńLosowoAtrybuty";
            this.btnZmieńLosowoAtrybuty.Size = new System.Drawing.Size(315, 51);
            this.btnZmieńLosowoAtrybuty.TabIndex = 36;
            this.btnZmieńLosowoAtrybuty.Text = "Zmień losowo atrybuty graficzne figur geometrycznych kreślonych myszą";
            this.btnZmieńLosowoAtrybuty.UseVisualStyleBackColor = true;
            // 
            // lbNumerFigury
            // 
            this.lbNumerFigury.AutoSize = true;
            this.lbNumerFigury.Location = new System.Drawing.Point(641, 586);
            this.lbNumerFigury.Name = "lbNumerFigury";
            this.lbNumerFigury.Size = new System.Drawing.Size(82, 16);
            this.lbNumerFigury.TabIndex = 38;
            this.lbNumerFigury.Text = "Numer figury";
            // 
            // lbWspX
            // 
            this.lbWspX.AutoSize = true;
            this.lbWspX.Location = new System.Drawing.Point(677, 28);
            this.lbWspX.Name = "lbWspX";
            this.lbWspX.Size = new System.Drawing.Size(15, 16);
            this.lbWspX.TabIndex = 39;
            this.lbWspX.Text = "X";
            // 
            // lbWspY
            // 
            this.lbWspY.AutoSize = true;
            this.lbWspY.Location = new System.Drawing.Point(788, 28);
            this.lbWspY.Name = "lbWspY";
            this.lbWspY.Size = new System.Drawing.Size(16, 16);
            this.lbWspY.TabIndex = 40;
            this.lbWspY.Text = "Y";
            // 
            // lblWspółrzędnePołożenia
            // 
            this.lblWspółrzędnePołożenia.AutoSize = true;
            this.lblWspółrzędnePołożenia.Location = new System.Drawing.Point(380, 23);
            this.lblWspółrzędnePołożenia.Name = "lblWspółrzędnePołożenia";
            this.lblWspółrzędnePołożenia.Size = new System.Drawing.Size(226, 16);
            this.lblWspółrzędnePołożenia.TabIndex = 41;
            this.lblWspółrzędnePołożenia.Text = "Współrzędne (x,y) położenia myszy:";
            // 
            // lblWspX
            // 
            this.lblWspX.Location = new System.Drawing.Point(731, 23);
            this.lblWspX.Name = "lblWspX";
            this.lblWspX.Size = new System.Drawing.Size(51, 22);
            this.lblWspX.TabIndex = 42;
            // 
            // lblWspY
            // 
            this.lblWspY.Location = new System.Drawing.Point(834, 23);
            this.lblWspY.Name = "lblWspY";
            this.lblWspY.Size = new System.Drawing.Size(50, 22);
            this.lblWspY.TabIndex = 43;
            // 
            // FiguryGeometryczne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1588, 711);
            this.Controls.Add(this.lblWspY);
            this.Controls.Add(this.lblWspX);
            this.Controls.Add(this.lblWspółrzędnePołożenia);
            this.Controls.Add(this.lbWspY);
            this.Controls.Add(this.lbWspX);
            this.Controls.Add(this.lbNumerFigury);
            this.Controls.Add(this.btnPopredni);
            this.Controls.Add(this.btnZmieńLosowoAtrybuty);
            this.Controls.Add(this.btnZmieńLosowoLokalizację);
            this.Controls.Add(this.akWybierzFigurę);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNumerFigury);
            this.Controls.Add(this.btnNastępny);
            this.Controls.Add(this.btnWyłącz);
            this.Controls.Add(this.btnWłącz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Aklabel1);
            this.Controls.Add(this.AkchlbFiguryGeometryczne);
            this.Controls.Add(this.AktxtN);
            this.Controls.Add(this.AkbtnStart);
            this.Controls.Add(this.btnPrzesuńFigury);
            this.Controls.Add(this.AkRycownica);
            this.Name = "FiguryGeometryczne";
            this.Text = "Losowa prezentacja figur geometrycznych";
            ((System.ComponentModel.ISupportInitialize)(this.AkRycownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.akWybierzFigurę.ResumeLayout(false);
            this.akWybierzFigurę.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AkRycownica;
        private System.Windows.Forms.Button btnPrzesuńFigury;
        private System.Windows.Forms.Button AkbtnStart;
        private System.Windows.Forms.TextBox AktxtN;
        private System.Windows.Forms.CheckedListBox AkchlbFiguryGeometryczne;
        private System.Windows.Forms.Label Aklabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtNumerFigury;
        private System.Windows.Forms.RadioButton AkbManualny;
        private System.Windows.Forms.RadioButton AkbAutomatyczny;
        private System.Windows.Forms.Button btnNastępny;
        private System.Windows.Forms.Button btnWyłącz;
        private System.Windows.Forms.Button btnWłącz;
        private System.Windows.Forms.Label lblNumerFigury;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton akbDrawPath;
        private System.Windows.Forms.RadioButton akbDrawClosedCurve;
        private System.Windows.Forms.RadioButton akbFillPie;
        private System.Windows.Forms.RadioButton akbLiniaKreślonaMyszą;
        private System.Windows.Forms.RadioButton akbWielokątForemny;
        private System.Windows.Forms.RadioButton akbOkrąg;
        private System.Windows.Forms.RadioButton AKbPunkt;
        private System.Windows.Forms.Button btnZmieńLosowoAtrybuty;
        private System.Windows.Forms.Button btnZmieńLosowoLokalizację;
        private System.Windows.Forms.GroupBox akWybierzFigurę;
        private System.Windows.Forms.Button btnPopredni;
        private System.Windows.Forms.Label lbNumerFigury;
        private System.Windows.Forms.Label lblWspółrzędnePołożenia;
        private System.Windows.Forms.Label lbWspY;
        private System.Windows.Forms.Label lbWspX;
        private System.Windows.Forms.TextBox lblWspY;
        private System.Windows.Forms.TextBox lblWspX;
        private System.Windows.Forms.RadioButton akbDrawLines;
        private System.Windows.Forms.RadioButton akbProstokąt;
        private System.Windows.Forms.RadioButton akbDrawPie;
        private System.Windows.Forms.RadioButton akbFillPath;
        private System.Windows.Forms.RadioButton akbDrawCurve;
        private System.Windows.Forms.RadioButton akbFillieElipsa;
        private System.Windows.Forms.RadioButton akbKwadrat;
        private System.Windows.Forms.RadioButton akbElipsa;
        private System.Windows.Forms.RadioButton akbLiniaProsta;
        private System.Windows.Forms.RadioButton akbDrawArc;
    }
}

