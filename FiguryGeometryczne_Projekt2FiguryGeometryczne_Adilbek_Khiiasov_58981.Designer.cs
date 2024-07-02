namespace Projekt2FiguryGeometryczne_Adilbek_Khiiasov_58981
{
    partial class FiguryGeometryczne_Projekt2FiguryGeometryczne_Adilbek_Khiiasov_58981
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
            this.akRycownica = new System.Windows.Forms.PictureBox();
            this.btnPrzesuńFigury = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.aktxtN = new System.Windows.Forms.TextBox();
            this.chlbFiguryGeometryczne = new System.Windows.Forms.CheckedListBox();
            this.aklabel1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnWłącz = new System.Windows.Forms.Button();
            this.btnWyłącz = new System.Windows.Forms.Button();
            this.btnPopredni = new System.Windows.Forms.Button();
            this.akbtnNastępny = new System.Windows.Forms.Button();
            this.akbAutomatyczny = new System.Windows.Forms.RadioButton();
            this.akbManualny = new System.Windows.Forms.RadioButton();
            this.txtNumerFigury = new System.Windows.Forms.TextBox();
            this.lblNumerFigury = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.akbPunkt = new System.Windows.Forms.RadioButton();
            this.akbOkrąg = new System.Windows.Forms.RadioButton();
            this.akbLiniaKreślonaMyszą = new System.Windows.Forms.RadioButton();
            this.akbWielokątForemny = new System.Windows.Forms.RadioButton();
            this.akbDrawClosedCurve = new System.Windows.Forms.RadioButton();
            this.akbFillPie = new System.Windows.Forms.RadioButton();
            this.akbLiniaProsta = new System.Windows.Forms.RadioButton();
            this.akbDrawPath = new System.Windows.Forms.RadioButton();
            this.akbDrawPie = new System.Windows.Forms.RadioButton();
            this.akbDrawArc = new System.Windows.Forms.RadioButton();
            this.akbFillPath = new System.Windows.Forms.RadioButton();
            this.akbDrawCurve = new System.Windows.Forms.RadioButton();
            this.akbFillieElipsa = new System.Windows.Forms.RadioButton();
            this.akbKwadrat = new System.Windows.Forms.RadioButton();
            this.akbElipsa = new System.Windows.Forms.RadioButton();
            this.akbProstokąt = new System.Windows.Forms.RadioButton();
            this.gbWybierzFigurę = new System.Windows.Forms.GroupBox();
            this.btnZmieńLosowoLokalizację = new System.Windows.Forms.Button();
            this.btnZmieńLosowoAtrybuty = new System.Windows.Forms.Button();
            this.lbNumerFigury = new System.Windows.Forms.Label();
            this.lbWspX = new System.Windows.Forms.Label();
            this.lbWspY = new System.Windows.Forms.Label();
            this.lblWspółrzędnePołożenia = new System.Windows.Forms.Label();
            this.lblWspX = new System.Windows.Forms.TextBox();
            this.lblWspY = new System.Windows.Forms.TextBox();
            this.akbDrawLines = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.akRycownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbWybierzFigurę.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbRycownica
            // 
            this.akRycownica.Location = new System.Drawing.Point(166, 65);
            this.akRycownica.Name = "pbRycownica";
            this.akRycownica.Size = new System.Drawing.Size(904, 243);
            this.akRycownica.TabIndex = 0;
            this.akRycownica.TabStop = false;
            this.akRycownica.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbRycownica_MouseDown);
            this.akRycownica.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbRycownica_MouseMove);
            this.akRycownica.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbRycownica_MouseUp);
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
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(45, 93);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(131, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // vstxtN
            // 
            this.aktxtN.Location = new System.Drawing.Point(45, 65);
            this.aktxtN.Name = "vstxtN";
            this.aktxtN.Size = new System.Drawing.Size(87, 22);
            this.aktxtN.TabIndex = 3;
            // 
            // chlbFiguryGeometryczne
            // 
            this.chlbFiguryGeometryczne.FormattingEnabled = true;
            this.chlbFiguryGeometryczne.Items.AddRange(new object[] {
            "Punkt",
            "Linia",
            "Elipsa",
            "Okrąg",
            "Prostokąt",
            "Kwadrat",
            "Wielokąt foremny",
            "Koło jednobarwne"});
            this.chlbFiguryGeometryczne.Location = new System.Drawing.Point(1096, 181);
            this.chlbFiguryGeometryczne.Name = "chlbFiguryGeometryczne";
            this.chlbFiguryGeometryczne.Size = new System.Drawing.Size(159, 191);
            this.chlbFiguryGeometryczne.TabIndex = 4;
            // 
            // vslabel1
            // 
            this.aklabel1.AutoSize = true;
            this.aklabel1.Location = new System.Drawing.Point(9, 33);
            this.aklabel1.Name = "vslabel1";
            this.aklabel1.Size = new System.Drawing.Size(223, 17);
            this.aklabel1.TabIndex = 5;
            this.aklabel1.Text = "Podaj liczbę figur geometrycznych";
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
            this.akbtnNastępny.Location = new System.Drawing.Point(454, 611);
            this.akbtnNastępny.Name = "btnNastępny";
            this.akbtnNastępny.Size = new System.Drawing.Size(143, 51);
            this.akbtnNastępny.TabIndex = 11;
            this.akbtnNastępny.Text = "Następny";
            this.akbtnNastępny.UseVisualStyleBackColor = true;
            this.akbtnNastępny.Click += new System.EventHandler(this.btnNastępny_Click);
            // 
            // akbAutomatyczny
            // 
            this.akbAutomatyczny.AutoSize = true;
            this.akbAutomatyczny.Location = new System.Drawing.Point(17, 21);
            this.akbAutomatyczny.Name = "akbAutomatyczny";
            this.akbAutomatyczny.Size = new System.Drawing.Size(117, 21);
            this.akbAutomatyczny.TabIndex = 12;
            this.akbAutomatyczny.TabStop = true;
            this.akbAutomatyczny.Text = "Automatyczny";
            this.akbAutomatyczny.UseVisualStyleBackColor = true;
            // 
            // akbManualny
            // 
            this.akbManualny.AutoSize = true;
            this.akbManualny.Location = new System.Drawing.Point(17, 48);
            this.akbManualny.Name = "akbManualny";
            this.akbManualny.Size = new System.Drawing.Size(179, 21);
            this.akbManualny.TabIndex = 13;
            this.akbManualny.TabStop = true;
            this.akbManualny.Text = "Manualny (przyciskowy)";
            this.akbManualny.UseVisualStyleBackColor = true;
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
            this.groupBox1.Controls.Add(this.akbAutomatyczny);
            this.groupBox1.Controls.Add(this.akbManualny);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.groupBox1.Location = new System.Drawing.Point(187, 593);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 83);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pokaz figur";
            // 
            // abPunkt
            // 
            this.akbPunkt.AutoSize = true;
            this.akbPunkt.Checked = true;
            this.akbPunkt.Location = new System.Drawing.Point(21, 31);
            this.akbPunkt.Name = "akbPunkt";
            this.akbPunkt.Size = new System.Drawing.Size(65, 21);
            this.akbPunkt.TabIndex = 18;
            this.akbPunkt.TabStop = true;
            this.akbPunkt.Text = "Punkt";
            this.akbPunkt.UseVisualStyleBackColor = true;
            // 
            // akbOkrąg
            // 
            this.akbOkrąg.AutoSize = true;
            this.akbOkrąg.Location = new System.Drawing.Point(21, 58);
            this.akbOkrąg.Name = "akabOkrąg";
            this.akbOkrąg.Size = new System.Drawing.Size(68, 21);
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
            this.akbLiniaKreślonaMyszą.Size = new System.Drawing.Size(171, 21);
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
            this.akbWielokątForemny.Size = new System.Drawing.Size(138, 21);
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
            this.akbDrawClosedCurve.Size = new System.Drawing.Size(141, 21);
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
            this.akbFillPie.Size = new System.Drawing.Size(66, 21);
            this.akbFillPie.TabIndex = 22;
            this.akbFillPie.TabStop = true;
            this.akbFillPie.Text = "FillPie";
            this.akbFillPie.UseVisualStyleBackColor = true;
            // 
            // akbLiniaProsta
            // 
            this.akbLiniaProsta.AutoSize = true;
            this.akbLiniaProsta.Location = new System.Drawing.Point(136, 31);
            this.akbLiniaProsta.Name = "akbLiniaProsta";
            this.akbLiniaProsta.Size = new System.Drawing.Size(104, 21);
            this.akbLiniaProsta.TabIndex = 25;
            this.akbLiniaProsta.TabStop = true;
            this.akbLiniaProsta.Text = "Linia Prosta";
            this.akbLiniaProsta.UseVisualStyleBackColor = true;
            // 
            // akbDrawPath
            // 
            this.akbDrawPath.AutoSize = true;
            this.akbDrawPath.Location = new System.Drawing.Point(21, 193);
            this.akbDrawPath.Name = "akbDrawPath";
            this.akbDrawPath.Size = new System.Drawing.Size(90, 21);
            this.akbDrawPath.TabIndex = 24;
            this.akbDrawPath.TabStop = true;
            this.akbDrawPath.Text = "DrawPath";
            this.akbDrawPath.UseVisualStyleBackColor = true;
            // 
            // akbDrawPie
            // 
            this.akbDrawPie.AutoSize = true;
            this.akbDrawPie.Location = new System.Drawing.Point(259, 193);
            this.akbDrawPie.Name = "akbDrawPie";
            this.akbDrawPie.Size = new System.Drawing.Size(81, 21);
            this.akbDrawPie.TabIndex = 32;
            this.akbDrawPie.TabStop = true;
            this.akbDrawPie.Text = "DrawPie";
            this.akbDrawPie.UseVisualStyleBackColor = true;
            // 
            // abDrawArc
            // 
            this.akbDrawArc.AutoSize = true;
            this.akbDrawArc.Location = new System.Drawing.Point(259, 166);
            this.akbDrawArc.Name = "akbDrawArc";
            this.akbDrawArc.Size = new System.Drawing.Size(82, 21);
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
            this.akbFillPath.Size = new System.Drawing.Size(75, 21);
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
            this.akbDrawCurve.Size = new System.Drawing.Size(98, 21);
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
            this.akbFillieElipsa.Size = new System.Drawing.Size(95, 21);
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
            this.akbKwadrat.Size = new System.Drawing.Size(80, 21);
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
            this.akbElipsa.Size = new System.Drawing.Size(67, 21);
            this.akbElipsa.TabIndex = 26;
            this.akbElipsa.TabStop = true;
            this.akbElipsa.Text = "Elipsa";
            this.akbElipsa.UseVisualStyleBackColor = true;
            // 
            // akbProstokąt
            // 
            this.akbProstokąt.AutoSize = true;
            this.akbProstokąt.Location = new System.Drawing.Point(137, 58);
            this.akbProstokąt.Name = "akabProstokąt";
            this.akbProstokąt.Size = new System.Drawing.Size(89, 21);
            this.akbProstokąt.TabIndex = 33;
            this.akbProstokąt.TabStop = true;
            this.akbProstokąt.Text = "Prostokąt";
            this.akbProstokąt.UseVisualStyleBackColor = true;
            // 
            // gbWybierzFigurę
            // 
            this.gbWybierzFigurę.Controls.Add(this.akbDrawLines);
            this.gbWybierzFigurę.Controls.Add(this.akbPunkt);
            this.gbWybierzFigurę.Controls.Add(this.akbProstokąt);
            this.gbWybierzFigurę.Controls.Add(this.akbDrawPie);
            this.gbWybierzFigurę.Controls.Add(this.lblNumerFigury);
            this.gbWybierzFigurę.Controls.Add(this.akbDrawArc);
            this.gbWybierzFigurę.Controls.Add(this.akbOkrąg);
            this.gbWybierzFigurę.Controls.Add(this.akbFillPath);
            this.gbWybierzFigurę.Controls.Add(this.akbWielokątForemny);
            this.gbWybierzFigurę.Controls.Add(this.akbDrawCurve);
            this.gbWybierzFigurę.Controls.Add(this.akbLiniaKreślonaMyszą);
            this.gbWybierzFigurę.Controls.Add(this.akbFillieElipsa);
            this.gbWybierzFigurę.Controls.Add(this.akbFillPie);
            this.gbWybierzFigurę.Controls.Add(this.akbKwadrat);
            this.gbWybierzFigurę.Controls.Add(this.akbDrawClosedCurve);
            this.gbWybierzFigurę.Controls.Add(this.akbElipsa);
            this.gbWybierzFigurę.Controls.Add(this.akbDrawPath);
            this.gbWybierzFigurę.Controls.Add(this.akbLiniaProsta);
            this.gbWybierzFigurę.Location = new System.Drawing.Point(1219, 393);
            this.gbWybierzFigurę.Name = "gbWybierzFigurę";
            this.gbWybierzFigurę.Size = new System.Drawing.Size(366, 225);
            this.gbWybierzFigurę.TabIndex = 34;
            this.gbWybierzFigurę.TabStop = false;
            this.gbWybierzFigurę.Text = "Wybierz figurę geometryczną do kreślenia myszą";
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
            this.lbNumerFigury.Size = new System.Drawing.Size(89, 17);
            this.lbNumerFigury.TabIndex = 38;
            this.lbNumerFigury.Text = "Numer figury";
            // 
            // lbWspX
            // 
            this.lbWspX.AutoSize = true;
            this.lbWspX.Location = new System.Drawing.Point(677, 28);
            this.lbWspX.Name = "lbWspX";
            this.lbWspX.Size = new System.Drawing.Size(17, 17);
            this.lbWspX.TabIndex = 39;
            this.lbWspX.Text = "X";
            // 
            // lbWspY
            // 
            this.lbWspY.AutoSize = true;
            this.lbWspY.Location = new System.Drawing.Point(788, 28);
            this.lbWspY.Name = "lbWspY";
            this.lbWspY.Size = new System.Drawing.Size(17, 17);
            this.lbWspY.TabIndex = 40;
            this.lbWspY.Text = "Y";
            // 
            // lblWspółrzędnePołożenia
            // 
            this.lblWspółrzędnePołożenia.AutoSize = true;
            this.lblWspółrzędnePołożenia.Location = new System.Drawing.Point(380, 23);
            this.lblWspółrzędnePołożenia.Name = "lblWspółrzędnePołożenia";
            this.lblWspółrzędnePołożenia.Size = new System.Drawing.Size(234, 17);
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
            // kabDrawLines
            // 
            this.akbDrawLines.AutoSize = true;
            this.akbDrawLines.Location = new System.Drawing.Point(137, 140);
            this.akbDrawLines.Name = "akbDrawLines";
            this.akbDrawLines.Size = new System.Drawing.Size(95, 21);
            this.akbDrawLines.TabIndex = 35;
            this.akbDrawLines.TabStop = true;
            this.akbDrawLines.Text = "DrawLines";
            this.akbDrawLines.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.gbWybierzFigurę);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNumerFigury);
            this.Controls.Add(this.akbtnNastępny);
            this.Controls.Add(this.btnWyłącz);
            this.Controls.Add(this.btnWłącz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.aklabel1);
            this.Controls.Add(this.chlbFiguryGeometryczne);
            this.Controls.Add(this.aktxtN);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnPrzesuńFigury);
            this.Controls.Add(this.akRycownica);
            this.Name = "FiguryGeometryczne";
            this.Text = "Losowa prezentacja figur geometrycznych";
            ((System.ComponentModel.ISupportInitialize)(this.akRycownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbWybierzFigurę.ResumeLayout(false);
            this.gbWybierzFigurę.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox akRycownica;
        private System.Windows.Forms.Button btnPrzesuńFigury;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox aktxtN;
        private System.Windows.Forms.CheckedListBox chlbFiguryGeometryczne;
        private System.Windows.Forms.Label aklabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtNumerFigury;
        private System.Windows.Forms.RadioButton akbManualny;
        private System.Windows.Forms.RadioButton akbAutomatyczny;
        private System.Windows.Forms.Button akbtnNastępny;
        private System.Windows.Forms.Button btnWyłącz;
        private System.Windows.Forms.Button btnWłącz;
        private System.Windows.Forms.Label lblNumerFigury;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton akbProstokąt;
        private System.Windows.Forms.RadioButton akbDrawPie;
        private System.Windows.Forms.RadioButton akbDrawArc;
        private System.Windows.Forms.RadioButton akbFillPath;
        private System.Windows.Forms.RadioButton akbDrawCurve;
        private System.Windows.Forms.RadioButton akbFillieElipsa;
        private System.Windows.Forms.RadioButton akbKwadrat;
        private System.Windows.Forms.RadioButton akbElipsa;
        private System.Windows.Forms.RadioButton akbLiniaProsta;
        private System.Windows.Forms.RadioButton akbDrawPath;
        private System.Windows.Forms.RadioButton akbDrawClosedCurve;
        private System.Windows.Forms.RadioButton akbFillPie;
        private System.Windows.Forms.RadioButton akbLiniaKreślonaMyszą;
        private System.Windows.Forms.RadioButton akbWielokątForemny;
        private System.Windows.Forms.RadioButton akbOkrąg;
        private System.Windows.Forms.RadioButton akbPunkt;
        private System.Windows.Forms.Button btnZmieńLosowoAtrybuty;
        private System.Windows.Forms.Button btnZmieńLosowoLokalizację;
        private System.Windows.Forms.GroupBox gbWybierzFigurę;
        private System.Windows.Forms.Button btnPopredni;
        private System.Windows.Forms.Label lbNumerFigury;
        private System.Windows.Forms.Label lblWspółrzędnePołożenia;
        private System.Windows.Forms.Label lbWspY;
        private System.Windows.Forms.Label lbWspX;
        private System.Windows.Forms.TextBox lblWspY;
        private System.Windows.Forms.TextBox lblWspX;
        private System.Windows.Forms.RadioButton akbDrawLines;
    }
}

