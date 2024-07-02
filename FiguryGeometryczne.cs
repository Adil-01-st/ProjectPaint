using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//udostępnienie przetrzeni nazw Drawing2D dla potrzeb grafiki 2D
using System.Drawing.Drawing2D;

namespace Projekt2FiguryGeometryczne_Adilbek_Khiiasov_58981
{
    public partial class FiguryGeometryczne : Form
    {
        //deklaracje stałych
        const int Margines = 20;/*Margines od krewędzi powierzchni graficznej*/
        /* deklaracja zmiennej referencyjnej (adresu) do egzemplarza powierzchni 
           graficznej, która będzie utworzona na BitMapie kontrolki PictureBox o 
           identyfikatorze AkRysownica umieszczonej na formularzu*/
        Graphics Rysownica;
        Punkt[] TFG;/* TFG - Tablica Figur Geometrycznych: dla ewidencjonowania referencji
                        egzemplarzy figur geometrycznych*/
        int IndexTFG; // index tablicy TFG
        ushort InterwałZegara = 1000;
        //deklaracje Listy Figur Geometrycznych
        List<Punkt> LFG = new List<Punkt>();
        /*deklaracja zmiennej PunktStartu, w której będą przechowywane współrzędne (X, Y) punktu,
         * w który nastąpiło kliknięcie lewym przyciskiem myszy*/
        Point PunktStartu = Point.Empty;
        //deklaracja zmiemmej referencyjnej do egzepmlarza powierzchni chwilowej
        Graphics RysownicaChwilowa;
        //deklaracja zmiennej referencyjnej Pióra Pomocniczego dla kreślenia
        Pen PióroPomocnicze;
        GraphicsPath Path = new GraphicsPath();



        public FiguryGeometryczne()
        {
            InitializeComponent();//zainicjowanie komponentów (kontrolek) formularza
                                  //Lokalizacja i zwymiarowanie formularza
            this.Left = Screen.PrimaryScreen.Bounds.Left + Margines;
            this.Top = Screen.PrimaryScreen.Bounds.Top + Margines;
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.95F);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.85F);
            this.StartPosition = FormStartPosition.Manual;
            /*lokalizacja kontrolki labeli i kontrolek umieszczonych po lewej stronie
             formularza*/
            Aklabel1.Location = new Point(this.Left + Margines / 2, this.Top + 2 * Margines);
            AktxtN.Location = new Point(Aklabel1.Location.X + Margines,
                                        Aklabel1.Location.Y + Aklabel1.Height
                                                            + Margines);
            AkbtnStart.Location = new Point(AktxtN.Location.X - Margines,
                                          AktxtN.Location.Y + AktxtN.Height + Margines);
            //lokalizacja i zwymiarowanie kontrolki PictureBox
            AkRycownica.Location = new Point(Aklabel1.Location.X + Aklabel1.Width,
                /*+ Margines,*/ Aklabel1.Location.Y);
            AkRycownica.Width = (int)(this.Width * 0.5F);
            AkRycownica.Height = (int)(this.Height * 0.55F);
            //ustalenie obramowania koloru kontrolki PictureBox
            AkRycownica.BackColor = Color.Beige;
            AkRycownica.BorderStyle = BorderStyle.Fixed3D;
            //utworzenie mapy bitowej i "podpięcie" jej do kontrolki PictureBox
            AkRycownica.Image = new Bitmap(AkRycownica.Width, AkRycownica.Height);
            /*utworzenie egzemplarza powierzchni graficznej na BitMapie
             kontrolki PictureBox*/
            Rysownica = Graphics.FromImage(AkRycownica.Image);
            //lokalizacja kontrolki label umieszczona nad kontrolką CheckeListBpc
            label2.Location = new Point(AkRycownica.Location.X +
                                        AkRycownica.Width + Margines, AkRycownica.Location.Y);
            /*lokalizacja kontrolki CheckedListBox unieszczinej na formularzu po prawej stronie
             * kontrolki PictureBoc*/
            AkchlbFiguryGeometryczne.Location = new Point(label2.Location.X,
                                                        label2.Location.Y + label2.Height
                                                        + Margines);
            //utworzenie egzemplarza chwilowej powierzchni graficznej na powierzchni kontrolki PictureBox
            RysownicaChwilowa = this.AkRycownica.CreateGraphics();
            /*metoda CreateGraphics() klasy Control jest dziedziczona przez wszystkie klasy potomne
             * od klasy bazowej Control, czyli egzemplarz powierzchni graficznej możemy utworzyć
             * na dowolnej kontrolce, w tym, na powierzchn kontrolki PictureBox*/
            //utworzenie egzemplarza tymczasowego pióra
            PióroPomocnicze = new Pen(Color.Blue, 1);

        }
        public class Punkt
        {
            /*deklaracja rozmiaru punktu: punkt jest pkreślony jako koło 
             * (wypełniony kolorem okrąg) o średnicy 20 pikseli*/
            protected const int RozmiarPunktu = 20;
            //deklaracja pół klasy, które będą dostępnie w klasach potomnych
            protected int X;
            protected int Y;
            protected Color Kolor; //Kolor Punktu
            //deklaracje atrybutów wspólnych dla wszystkich klas potomnych
            protected int GrubośćLinii;
            protected DashStyle StylLinii;
            protected bool Widoczność;/* stanu widoczności figury geometrycznej
                                         true - gdy widoczny, false - gdy nie*/
            // pusta metoda dla linii kreślonej myszą
            public virtual void DodajPunktKrzywej(int newX, int newY) { }

            public Punkt(int x, int y)
            {
                /* inicjowanie pól (atrybutów) klasy Punkt na podstawie 
                 * wartości parametrów konstruktora*/
                X = x;
                Y = y;
                /*inicjowanie pól (atrybutów) klasy Punkt na podstawie
                 * domyślnych wartości strybutów ustalonych przez projektanta*/
                Kolor = Color.Black;
                StylLinii = DashStyle.Solid;
                Widoczność = false;
                GrubośćLinii = RozmiarPunktu;//średnica punktu
            }
            public Punkt(int x, int y, Color KolorPunktu)
            {
                /* inicjowanie pól (atrybutów) klasy Punkt na podstawie
                 * wartości parametrów konstruktora*/
                X = x;
                Y = y;
                Kolor = KolorPunktu;
                /*inicjowanie wartości pozostałych pól (atrybutów) klasy Punkt na podstawie
                 *domyślnych wartości atrybutów ustalonych przez projektanta */
                Kolor = Color.Black;
                StylLinii = DashStyle.Solid;
                GrubośćLinii = RozmiarPunktu;//średnica punktu
                Widoczność = false;
            }
            public Punkt(int x, int y, Color KolorPunktu, int RozmiarPunktu)
            {
                /* inicjowanie pól (atrybutów) klasy Punkt
                 * na podstawie wartości parametrów konstruktora*/
                X = x;
                Y = y;
                Kolor = KolorPunktu;
                GrubośćLinii = RozmiarPunktu;
                /*inicjowanie wartości pozostałych pól(atrybutów) klasy Punkt
                 *na podstawie domyślnych wartości atrybutów ustalonych przez projektanta*/
                Kolor = Color.Black;
                StylLinii = DashStyle.Solid;
                Widoczność = false;
            }
            private void UaktualnijXY(int X, int Y)
            {
                this.X = X;
                this.Y = Y;
            }
            //przeciążenie metody UaktualnijXY(...)
            private void UaktualnijXY(Point NowaLokalizacja)
            {
                X = NowaLokalizacja.X;
                Y = NowaLokalizacja.Y;
            }
            protected void UstalStylLinii(DashStyle StylLinii)
            {
                this.StylLinii = StylLinii;
            }
            public void UstalAtrybutyGraficzne(Color KolorLinii,
                DashStyle StylLinii, int GrubośćLinii, Color KolorTła)
            {
                this.Kolor = KolorLinii;
                this.StylLinii = StylLinii;
                this.GrubośćLinii = GrubośćLinii;
            }

            public virtual void Wykreśl(Graphics PowierzchniaGraficzna)
            {// wykreślenie punktu jako wypełnionego okręgu
                using (SolidBrush Pędzel = new SolidBrush(Kolor))
                {
                    PowierzchniaGraficzna.FillEllipse(Pędzel,
                            X - GrubośćLinii / 2, Y - GrubośćLinii / 2,
                            GrubośćLinii, GrubośćLinii);
                    Widoczność = true;//ustawienie atrybutu widoczności
                }//automatyczne zwolnienie Pędzla
            }
            public virtual void Wymaż(Control Kontrolka, Graphics
                                                            PowierzchniaGraficzna)
            {
                if (this.Widoczność)
                {
                    /*dla wymazania ounktu wykreślamy go w kolorze tła kontrolki
                     * na której utworzono egzemplarz powierzchni graficznej*/
                    using (SolidBrush Pędzel = new SolidBrush(Kontrolka.BackColor))
                    {
                        PowierzchniaGraficzna.FillEllipse(Pędzel, X - GrubośćLinii / 2,
                                        -GrubośćLinii / 2, GrubośćLinii, GrubośćLinii);
                        this.Widoczność = false;//wyłączenie atrybutu widoczności
                        Pędzel.Dispose();
                    }//automatyczne zwolninie Pędzla

                }

            }
            public virtual void PrzesuńDoNowegoXY(Control Kontrolka, Graphics
                                    PowierzchniaGraficzna, int x, int y)
            {
                //uaktualnienie lokalizacji (położenia) figury geometrycznej
                this.X = x;
                this.Y = y;
                //wykreślenie figury geometrycznej w nowym położeniu
                Wykreśl(PowierzchniaGraficzna);
            }
            public class Linia : Punkt
            {

                //deklaracja atrybutów klasy Linia
                // deklaracje dla przechowania współrzędnych końca linii
                int Xk, Yk;
                //deklaracje konstruktorów klasy Linia
                public Linia(int Xp, int Yp, int Xk, int Yk) : base(Xp, Yp)
                {
                    this.Xk = Xk;
                    this.Yk = Yk;
                }
                public Linia(int Xp, int Yp, int Xk, int Yk, Color KolorLinii,
                            DashStyle StylLinii, int GrubośćLinii) :
                            base(Xp, Yp, KolorLinii, GrubośćLinii)
                {
                    this.Xk = Xk;
                    this.Yk = Yk;
                    this.StylLinii = StylLinii;
                }
                //deklaracje metod nadpisujących metody wirtualne klasy Punkt
                public override void Wykreśl(Graphics PowierzchniaGraficzna)
                {//utworzenie i sformatowanie egzemplarza pióra
                    using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                    {
                        Pióro.DashStyle = StylLinii;
                        //wykreślenie linii
                        PowierzchniaGraficzna.DrawLine(Pióro, X, Y, Xk, Yk);
                        Widoczność = true;//linia została wykreślona
                    }
                }
                public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                {
                    if (Widoczność)
                    {
                        //utworzenie i sformatowanie egzemplarza pióra
                        using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                        {
                            Pióro.DashStyle = StylLinii;
                            //wykreślenie linii
                            PowierzchniaGraficzna.DrawLine(Pióro, X, Y, Xk, Yk);
                            Widoczność = false;//linia zostałą wymazana
                        }
                    }
                }
                public override void PrzesuńDoNowegoXY(Control Kontrolka,
                            Graphics PowierzchniaGraficzna, int x, int y)
                {
                    /*deklaracje zmiennych dla wyznaczenie przyrostów zmian
                     * współrzędnych początku Linii*/
                    int AKx, AKy;
                    //wyznaczenie przyrostu zmian współrzędnej X
                    if (x > X)
                        AKx = x - X;
                    else
                        AKx = X - x;
                    //wyznaczenie przyrostu zmian współrzędnej Y
                    if (y > Y)
                        AKy = y - Y;
                    else
                        AKy = Y - y;
                    /*zmiama współrzędnych końca linii tak, aby nie wychodziły
                   poza obszar powierzchni graficznej*/
                    Xk = (Xk + AKx) % Kontrolka.Width;
                    Yk = (Yk = AKy) % Kontrolka.Height;
                    //wykreślenie linii o nowych współrzęnych początku i końća Linii
                    Wykreśl(PowierzchniaGraficzna);
                }
                public class DrawCurve : Punkt
                {
                    Point[] Points =
                    {
                        new Point(213,204),
                        new Point(63, 143),
                        new Point(227, 60),
                        new Point(123, 222),
                        new Point(72, 64),
                    };
                    GraphicsPath graficzny = new GraphicsPath();
                    private List<Point> klik = new List<Point>();
                    private List<Point> nieklik = new List<Point>();
                    GraphicsPath Path;

                    public DrawCurve(int x, int y) : base(x, y)
                    {

                    }
                    public DrawCurve(int x, int y, Color Kolor, DashStyle StylLinii,
                                  int GrubośćLinii) : base(x, y, Kolor, RozmiarPunktu)
                    {
                        Path.AddCurve(Points);
                    }
                    public override void Wykreśl(Graphics PowierzchniaGraficzna)
                    {
                        //utworzenie i sformatowanie egzemplarza pióra
                        using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                        {
                            Pióro.DashStyle = StylLinii;
                            //wykreślenie elipsy
                            PowierzchniaGraficzna.DrawCurve(Pióro, Points);

                            Widoczność = true; // elipsa została wykreślona
                        }
                    }
                    public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                    {
                        if (this.Widoczność)
                        {
                            //utworzenie i sformatowanie egzemplarza pióra
                            using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                            {
                                Pióro.DashStyle = StylLinii;
                                //wymazanie elipsy(czyli wykreślenie w kolorze tła)
                                PowierzchniaGraficzna.DrawCurve(Pióro, Points);
                                Widoczność = false; // elipsa została wymazana
                            }
                        }
                    }
                }
                public class DrawLines : Linia
                {
                    public DrawLines(int Xp, int Yp, int Xk, int Yk) : base(Xp, Yp, Xk, Yk)
                    {
                        this.Xk = Xk;
                        this.Yk = Yk;
                    }
                    public DrawLines(int Xp, int Yp, int Xk, int Yk, Color KolorLinii,
                                DashStyle StylLinii, int GrubośćLinii) :
                                base(Xp, Yp, Xk, Yk)
                    {
                        this.Xk = Xk;
                        this.Yk = Yk;
                        this.StylLinii = StylLinii;
                    }
                    //deklaracje metod nadpisujących metody wirtualne klasy Punkt
                    public override void Wykreśl(Graphics PowierzchniaGraficzna)
                    {//utworzenie i sformatowanie egzemplarza pióra
                        using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                        {
                            Point[] linii =
                            {
                                new Point(10, 10),
                                new Point(10,100),
                                new Point(200, 50),
                                new Point(250, 300)
                            };
                            Pióro.DashStyle = StylLinii;
                            //wykreślenie linii
                            PowierzchniaGraficzna.DrawLines(Pióro, linii);
                            Widoczność = true;//linia została wykreślona
                        }
                    }
                    public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                    {
                        if (Widoczność)
                        {
                            //utworzenie i sformatowanie egzemplarza pióra
                            using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                            {
                                Point[] linii =
                             {
                                new Point(10, 10),
                                new Point(10,100),
                                new Point(200, 50),
                                new Point(250, 300)
                            };
                                Pióro.DashStyle = StylLinii;
                                //wykreślenie linii
                                PowierzchniaGraficzna.DrawLines(Pióro, linii);
                                Widoczność = false;//linia zostałą wymazana
                            }
                        }
                    }
                }
                public class DrawClosedCurve : Punkt
                {
                    Point[] Points =
                    {
                        new Point(213,204),
                        new Point(63, 143),
                        new Point(227, 60),
                        new Point(123, 222),
                        new Point(72, 64),
                    };
                    GraphicsPath graficzny = new GraphicsPath();
                    private List<Point> klik = new List<Point>();
                    private List<Point> nieklik = new List<Point>();
                    GraphicsPath Path;

                    public DrawClosedCurve(int x, int y) : base(x, y)
                    {

                    }
                    public DrawClosedCurve(int x, int y, Color Kolor, DashStyle StylLinii,
                                  int GrubośćLinii) : base(x, y, Kolor, RozmiarPunktu)
                    {
                        Path.AddCurve(Points);
                    }
                    public override void Wykreśl(Graphics PowierzchniaGraficzna)
                    {
                        //utworzenie i sformatowanie egzemplarza pióra
                        using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                        {
                            Pióro.DashStyle = StylLinii;
                            //wykreślenie elipsy
                            PowierzchniaGraficzna.DrawClosedCurve(Pióro, Points);
                            Widoczność = true; // elipsa została wykreślona
                        }
                    }
                    public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                    {
                        if (this.Widoczność)
                        {
                            //utworzenie i sformatowanie egzemplarza pióra
                            using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                            {
                                Pióro.DashStyle = StylLinii;
                                //wymazanie elipsy(czyli wykreślenie w kolorze tła)
                                PowierzchniaGraficzna.DrawClosedCurve(Pióro, Points);
                                Widoczność = false; // elipsa została wymazana
                            }
                        }
                    }
                }


                public class Elipsa : Punkt
                {
                    // deklaracje dla przechowania wartości osi dużej i małej
                    protected int OśDuża, OśMała;
                    //deklaracje konsturtorów klasy Elipsa
                    public Elipsa(int x, int y, int OśDuża, int OśMała) : base(x, y)
                    {
                        this.OśDuża = OśDuża;
                        this.OśMała = OśMała;
                    }
                    public Elipsa(int x, int y, int OśDuża, int OśMała, Color KolorLinii,
                        DashStyle StylLinii, int GrubośćLinii) : base(x, y, KolorLinii, GrubośćLinii)
                    {
                        this.OśDuża = OśDuża;
                        this.OśMała = OśMała;
                        this.StylLinii = StylLinii;
                    }
                    //deklaracje metod nadpisujących metody wirtualne w klasie Elipsa
                    public override void Wykreśl(Graphics PowierzchniaGraficzna)
                    {
                        //utworzenie i sformatowanie egzemplarza pióra
                        using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                        {
                            Pióro.DashStyle = StylLinii;
                            //wykreślenie elipsy
                            PowierzchniaGraficzna.DrawEllipse(Pióro, X - OśDuża / 2,
                                                             Y - OśMała / 2, OśDuża, OśMała);
                            Widoczność = true; // elipsa została wykreślona
                        }
                    }
                    public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                    {
                        if (this.Widoczność)
                        {
                            //utworzenie i sformatowanie egzemplarza pióra
                            using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                            {
                                Pióro.DashStyle = StylLinii;
                                //wymazanie elipsy(czyli wykreślenie w kolorze tła)
                                PowierzchniaGraficzna.DrawEllipse(Pióro, X - OśDuża / 2,
                                                                 Y - OśMała / 2, OśDuża, OśMała);
                                Widoczność = false; // elipsa została wymazana
                            }
                        }
                    }
                    public class FillieElipsa : Elipsa
                    {
                        // deklaracje dla przechowania wartości osi dużej i małej
                        protected int OśDuża, OśMała;
                        //deklaracje konsturtorów klasy Elipsa
                        public FillieElipsa(int x, int y, int OśDuża, int OśMała) : base(x, y, OśDuża, OśMała)
                        {
                            this.OśDuża = OśDuża;
                            this.OśMała = OśMała;
                        }
                        public FillieElipsa(int x, int y, int OśDuża, int OśMała, Color KolorLinii,
                            DashStyle StylLinii, int GrubośćLinii) : base(x, y, OśDuża, OśMała)
                        {
                            this.OśDuża = OśDuża;
                            this.OśMała = OśMała;
                            this.StylLinii = StylLinii;
                        }
                        //deklaracje metod nadpisujących metody wirtualne w klasie Elipsa
                        public override void Wykreśl(Graphics PowierzchniaGraficzna)
                        {
                            //utworzenie i sformatowanie egzemplarza pióra
                            using (SolidBrush Pędzel = new SolidBrush(Kolor))
                            {
                                Pędzel.Color = Color.Red;
                                //wykreślenie elipsy
                                PowierzchniaGraficzna.FillEllipse(Pędzel, X - OśDuża / 2,
                                                                 Y - OśMała / 2, OśDuża, OśMała);
                                Widoczność = true; // elipsa została wykreślona
                            }
                        }
                        public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                        {
                            if (this.Widoczność)
                            {
                                //utworzenie i sformatowanie egzemplarza pióra
                                using (SolidBrush Pędzel = new SolidBrush(Kolor))
                                {
                                    Pędzel.Color = Color.Red;
                                    //wykreślenie elipsy
                                    PowierzchniaGraficzna.FillEllipse(Pędzel, X - OśDuża / 2,
                                                                     Y - OśMała / 2, OśDuża, OśMała);
                                    Widoczność = false; // elipsa została wykreślona
                                }
                            }
                        }
                        public class FillPath : FillieElipsa
                        {
                            public FillPath(int x, int y, int OśDuża, int OśMała) : base(x, y, OśDuża, OśMała)
                            {
                                this.OśDuża = OśDuża;
                                this.OśMała = OśMała;
                            }
                            public FillPath(int x, int y, int OśDuża, int OśMała, Color KolorLinii,
                                DashStyle StylLinii, int GrubośćLinii) : base(x, y, OśDuża, OśMała)
                            {
                                this.OśDuża = OśDuża;
                                this.OśMała = OśMała;
                                this.StylLinii = StylLinii;
                            }
                            //deklaracje metod nadpisujących metody wirtualne w klasie Elipsa
                            public override void Wykreśl(Graphics PowierzchniaGraficzna)
                            {
                                //utworzenie i sformatowanie egzemplarza pióra
                                using (SolidBrush Pędzel = new SolidBrush(Color.Yellow))
                                {
                                    Pędzel.Color = Color.Yellow;
                                    GraphicsPath graficzna = new GraphicsPath();
                                    //wykreślenie elipsy
                                    PowierzchniaGraficzna.FillPath(Pędzel, graficzna);
                                    graficzna.AddEllipse(X, Y, OśDuża, OśMała);
                                    Widoczność = true; // elipsa została wykreślona
                                }
                            }
                            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                            {
                                if (this.Widoczność)
                                {
                                    //utworzenie i sformatowanie egzemplarza pióra
                                    using (SolidBrush Pędzel = new SolidBrush(Color.Yellow))
                                    {
                                        Pędzel.Color = Color.Yellow;
                                        GraphicsPath graficzna = new GraphicsPath();
                                        //wykreślenie elipsy
                                        PowierzchniaGraficzna.FillPath(Pędzel, graficzna);
                                        graficzna.AddEllipse(X, Y, OśDuża, OśMała);
                                        Widoczność = false; // elipsa została wykreślona
                                    }
                                }
                            }
                        }
                        public class Koło : FillieElipsa
                        { // deklaracje konstruktorów klasy Koło
                          // deklaracje dla przechowania wartości osi dużej i małej
                          //deklaracje konsturtorów klasy Elipsa
                            public Koło(int x, int y, int OśDuża, int OśMała) : base(x, y, OśDuża, OśMała)
                            {
                                this.OśDuża = OśDuża;
                                this.OśMała = OśMała;
                            }
                            public Koło(int x, int y, int OśDuża, int OśMała, Color KolorLinii,
                                DashStyle StylLinii, int GrubośćLinii) : base(x, y, OśDuża, OśMała)
                            {
                                this.OśDuża = OśDuża;
                                this.OśMała = OśMała;
                                this.StylLinii = StylLinii;
                            }
                            //deklaracje metod nadpisujących metody wirtualne w klasie Elipsa
                            public override void Wykreśl(Graphics PowierzchniaGraficzna)
                            {
                                //utworzenie i sformatowanie egzemplarza pióra
                                using (SolidBrush Pędzel = new SolidBrush(Kolor))
                                {
                                    Pędzel.Color = Color.Red;
                                    //wykreślenie elipsy
                                    PowierzchniaGraficzna.FillEllipse(Pędzel, X - OśDuża,
                                                                     Y - OśMała, OśDuża * 2, OśMała * 2);
                                    Widoczność = true; // elipsa została wykreślona
                                }
                            }
                            public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                            {
                                if (this.Widoczność)
                                {
                                    //utworzenie i sformatowanie egzemplarza pióra
                                    using (SolidBrush Pędzel = new SolidBrush(Kolor))
                                    {
                                        Pędzel.Color = Color.Red;
                                        //wykreślenie elipsy
                                        PowierzchniaGraficzna.FillEllipse(Pędzel, X - OśDuża,
                                                                     Y - OśMała, OśDuża * 2, OśMała * 2);
                                        Widoczność = false; // elipsa została wykreślona
                                    }
                                }
                            }

                        }
                    }
                    public class Okrąg : Elipsa
                    {
                        protected int Promień; // promień okręgu
                        // deklaracje konstruktorów klasy Okrąg
                        public Okrąg(int x, int y, int Promień) :
                                                       base(x, y, 2 * Promień, 2 * Promień)
                        {
                            this.Promień = Promień;
                        }
                        public Okrąg(int x, int y, int Promień, Color KolorLinii,
                                            DashStyle StylLinii, int GrubośćLinii) :
                                                       base(x, y, 2 * Promień, 2 * Promień,
                                                           KolorLinii, StylLinii, GrubośćLinii)
                        {
                            this.Promień = Promień;
                        }
                        // deklaracje metod nadpisujących metody wirtualne klasy Punkt
                        public override void Wykreśl(Graphics PowierzchniaGraficzna)
                        {
                            // utworzenie i sformatowanie egzemplarza pióra
                            using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                            {
                                Pióro.DashStyle = StylLinii;
                                //wykreślenie okręgu
                                PowierzchniaGraficzna.DrawEllipse(Pióro, X - Promień, Y - Promień,
                                                                        2 * Promień, 2 * Promień);
                                Widoczność = true; // okrąg został wykreślony
                            }
                        }
                        public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                        {
                            if (this.Widoczność)
                            {

                                // utworzenie i sformatowanie egzemplarza pióra
                                using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                                {
                                    Pióro.DashStyle = StylLinii;
                                    //wymazanie okręgu(czyli wykreślenie w kolorze tła)
                                    PowierzchniaGraficzna.DrawEllipse(Pióro, X - Promień, Y - Promień,
                                                                            2 * Promień, 2 * Promień);
                                    Widoczność = false; // okrąg został wymazany
                                }
                            }
                        }

                    }
                    public class DrawPath : Punkt
                    {
                        GraphicsPath graficznyPath = new GraphicsPath();

                        //deklaracje dla przechowania wartości osi dużej i małej
                        protected int OśDuża, OśMała;
                        //deklaracje konsturtorów klasy Elipsa
                        public DrawPath(int x, int y, int OśDuża, int OśMała) : base(x, y)
                        {
                            this.OśDuża = OśDuża;
                            this.OśMała = OśMała;
                        }
                        public DrawPath(int x, int y, int OśDuża, int OśMała, Color KolorLinii,
                            DashStyle StylLinii, int GrubośćLinii) : base(x, y, KolorLinii, GrubośćLinii)
                        {
                            this.OśDuża = OśDuża;
                            this.OśMała = OśMała;
                            this.StylLinii = StylLinii;
                        }
                        //deklaracje metod nadpisujących metody wirtualne w klasie Elipsa
                        public override void Wykreśl(Graphics PowierzchniaGraficzna)
                        {
                            //utworzenie i sformatowanie egzemplarza pióra
                            using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                            {
                                Pióro.DashStyle = StylLinii;
                                //wykreślenie elipsy
                                PowierzchniaGraficzna.DrawPath(Pióro, graficznyPath);
                                Widoczność = true; // elipsa została wykreślona
                            }
                        }
                        public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                        {
                            if (this.Widoczność)
                            {
                                //utworzenie i sformatowanie egzemplarza pióra
                                using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                                {
                                    Pióro.DashStyle = StylLinii;
                                    //wymazanie elipsy(czyli wykreślenie w kolorze tła)
                                    PowierzchniaGraficzna.DrawPath(Pióro, graficznyPath);
                                    Widoczność = false; // elipsa została wymazana
                                }
                            }

                        }
                    }
                }
            }

            public class Prostokąt : Punkt
            {
                protected int Szerokość, Wysokość;
                public Prostokąt(int x, int y, int Szerokość, int Wysokość) : base(x, y)
                {
                    this.Szerokość = Szerokość;
                    this.Wysokość = Wysokość;
                    StylLinii = DashStyle.Solid;

                }
                public Prostokąt(int x, int y, int Szerokość, int Wysokość, Color KolorLinii, DashStyle StylLinii,
                            int GrubośćLinii) : base(x, y, KolorLinii, GrubośćLinii)
                {
                    this.Szerokość = Szerokość;
                    this.Wysokość = Wysokość;
                    this.GrubośćLinii = GrubośćLinii;
                    this.StylLinii = StylLinii;
                }
                public override void Wykreśl(Graphics PowierzchniaGraficzna)
                {
                    // utworzenie i sformatowanie egzemplarza pióra
                    using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                    {
                        Pióro.DashStyle = StylLinii;
                        //wykreślenie prostokąta
                        PowierzchniaGraficzna.DrawRectangle(Pióro, X, Y, Szerokość, Wysokość);
                        Widoczność = true; // prostokąt został wykreślony
                        Pióro.Dispose();
                    }
                }
                public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                {
                    if (this.Widoczność)
                    {

                        // utworzenie i sformatowanie egzemplarza pióra
                        using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                        {
                            Pióro.DashStyle = DashStyle.Solid;
                            //wymazanie prostokąta
                            PowierzchniaGraficzna.DrawRectangle(Pióro, X, Y, Szerokość, Wysokość);
                            Widoczność = false; // prostokąt został wymazany
                            Pióro.Dispose();
                        }
                    }
                }
                public class DrawArc : Prostokąt
                {
                    protected int Szerokość, Wysokość;
                    public DrawArc(int x, int y, int Szerokość, int Wysokość) : base(x, y, Szerokość, Wysokość)
                    {
                        this.Szerokość = Szerokość;
                        this.Wysokość = Wysokość;
                        StylLinii = DashStyle.Solid;

                    }
                    public DrawArc(int x, int y, int Szerokość, int Wysokość, Color KolorLinii, DashStyle StylLinii,
                                int GrubośćLinii) : base(x, y, Szerokość, Wysokość)
                    {
                        this.Szerokość = Szerokość;
                        this.Wysokość = Wysokość;
                        this.GrubośćLinii = GrubośćLinii;
                        this.StylLinii = StylLinii;
                    }
                    public override void Wykreśl(Graphics PowierzchniaGraficzna)
                    {
                        // utworzenie i sformatowanie egzemplarza pióra
                        using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                        {
                            Pióro.DashStyle = StylLinii;
                            //wykreślenie prostokąta
                            PowierzchniaGraficzna.DrawArc(Pióro, X, Y, Szerokość, Wysokość, Szerokość, Wysokość);
                            Widoczność = true; // prostokąt został wykreślony
                            Pióro.Dispose();
                        }
                    }
                    public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                    {
                        if (this.Widoczność)
                        {

                            // utworzenie i sformatowanie egzemplarza pióra
                            using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                            {
                                Pióro.DashStyle = DashStyle.Solid;
                                //wymazanie prostokąta
                                PowierzchniaGraficzna.DrawArc(Pióro, X, Y, Szerokość, Wysokość, Szerokość, Wysokość);
                                Widoczność = false; // prostokąt został wymazany
                                Pióro.Dispose();
                            }
                        }
                    }
                }
            }
            /*public class FillPath : Prostokąt
            {
                public FillPath( int x, int y, int Szerokość, int Wysokość) : base(x, y, Szerokość, Wysokość)
                {
                    this.Szerokość = Szerokość;
                    this.Wysokość = Wysokość;
                }
                public FillPath(int x, int y, int Szerokość, int Wysokość, Color KolorLinii, DashStyle StylLinii,
                            int GrubośćLinii) : base(x, y, Szerokość, Wysokość)
                {
                    this.Szerokość = Szerokość;
                    this.Wysokość = Wysokość;
                    this.GrubośćLinii = GrubośćLinii;
                    this.StylLinii = StylLinii;
                }
                public override void Wykreśl(Graphics PowierzchniaGraficzna)
                {
                    // utworzenie i sformatowanie egzemplarza pędzla
                    using (SolidBrush Pędzel = new SolidBrush(Color.Yellow))
                    {
                        Pędzel.Color = Color.Yellow;
                        GraphicsPath graficzna = new GraphicsPath();
                        //wykreślenie elipsy
                        PowierzchniaGraficzna.FillPath(Pędzel, graficzna);
                        graficzna.AddEllipse(X, Y, Szerokość, Wysokość);
                        Widoczność = true; // elipsa została wykreślona
                        Pędzel.Dispose();
                    }
                }
                public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                {
                    if (this.Widoczność)
                    {

                        // utworzenie i sformatowanie egzemplarza pióra
                        using (SolidBrush Pędzel = new SolidBrush(Color.Yellow))
                        {
                            Pędzel.Color = Color.Yellow;
                            GraphicsPath graficzna = new GraphicsPath();
                            //wykreślenie elipsy
                            PowierzchniaGraficzna.FillPath(Pędzel, graficzna);
                            graficzna.AddEllipse(X, Y, Szerokość, Wysokość);
                            Widoczność = false; // elipsa została wymazana
                            Pędzel.Dispose();
                        }
                    }
                }
            }*/
            public class DrawPie : Prostokąt
            {
                public DrawPie(int x, int y, int Szerokość, int Wysokość) : base(x, y, Szerokość, Wysokość)
                {
                    this.Szerokość = Szerokość;
                    this.Wysokość = Wysokość;
                }
                public DrawPie(int x, int y, int Szerokość, int Wysokość, Color KolorLinii, DashStyle StylLinii,
                            int GrubośćLinii) : base(x, y, Szerokość, Wysokość)
                {
                    this.Szerokość = Szerokość;
                    this.Wysokość = Wysokość;
                    this.GrubośćLinii = GrubośćLinii;
                    this.StylLinii = StylLinii;
                }
                public override void Wykreśl(Graphics PowierzchniaGraficzna)
                {
                    // utworzenie i sformatowanie egzemplarza pióra
                    using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                    {

                        GraphicsPath graficzna = new GraphicsPath();
                        Rectangle rect = new Rectangle(X, Y, Szerokość, Wysokość);
                        //wykreślenie elipsy
                        PowierzchniaGraficzna.DrawPie(Pióro, rect, Szerokość, Wysokość);
                        Widoczność = true; // elipsa została wykreślona
                        Pióro.Dispose();
                    }
                }
                public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                {
                    if (this.Widoczność)
                    {

                        // utworzenie i sformatowanie egzemplarza pióra
                        using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                        {

                            GraphicsPath graficzna = new GraphicsPath();
                            Rectangle rect = new Rectangle(X, Y, Szerokość, Wysokość);
                            //wykreślenie elipsy
                            PowierzchniaGraficzna.DrawPie(Pióro, rect, Szerokość, Wysokość);
                            Widoczność = false; // elipsa została wykreślona
                            Pióro.Dispose();
                        }
                    }
                }
                public class FillPie : DrawPie
                {
                    public FillPie(int x, int y, int Szerokość, int Wysokość) : base(x, y, Szerokość, Wysokość)
                    {
                        this.Szerokość = Szerokość;
                        this.Wysokość = Wysokość;
                    }
                    public FillPie(int x, int y, int Szerokość, int Wysokość, Color KolorLinii, DashStyle StylLinii,
                                int GrubośćLinii) : base(x, y, Szerokość, Wysokość)
                    {
                        this.Szerokość = Szerokość;
                        this.Wysokość = Wysokość;
                        this.GrubośćLinii = GrubośćLinii;
                        this.StylLinii = StylLinii;
                    }
                    public override void Wykreśl(Graphics PowierzchniaGraficzna)
                    {
                        // utworzenie i sformatowanie egzemplarza pióra
                        using (SolidBrush Pędzel = new SolidBrush(Color.Red))
                        {

                            GraphicsPath graficzna = new GraphicsPath();
                            //wykreślenie elipsy
                            PowierzchniaGraficzna.FillPie(Pędzel, X, Y, Szerokość, Wysokość, Szerokość, Wysokość);
                            Widoczność = true; // elipsa została wykreślona
                            Pędzel.Dispose();
                        }
                    }
                    public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                    {
                        if (this.Widoczność)
                        {

                            // utworzenie i sformatowanie egzemplarza pióra
                            using (SolidBrush Pędzel = new SolidBrush(Color.Red))
                            {

                                GraphicsPath graficzna = new GraphicsPath();
                                //wykreślenie elipsy
                                PowierzchniaGraficzna.FillPie(Pędzel, X, Y, Szerokość, Wysokość, Szerokość, Wysokość);
                                Widoczność = false; // elipsa została wykreślona
                                Pędzel.Dispose();
                            }
                        }
                    }
                }
            }

            public class Kwadrat : Punkt
            {
                protected int DługośćBoku;
                public Kwadrat(int x, int y, int DługośćBoku) : base(x, y)
                {
                    this.DługośćBoku = DługośćBoku;
                    StylLinii = DashStyle.Solid;
                }
                public Kwadrat(int x, int y, int DługośćBoku, Color KolorLinii, DashStyle StylLinii,
                     int GrubośćLinii) : base(x, y, KolorLinii, GrubośćLinii)
                {
                    this.DługośćBoku = DługośćBoku;
                    this.StylLinii = StylLinii;
                    this.GrubośćLinii = GrubośćLinii;

                }
                public override void Wykreśl(Graphics PowierzchniaGraficzna)
                {
                    // utworzenie i sformatowanie egzemplarza pióra
                    using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                    {
                        Pióro.DashStyle = StylLinii;
                        //wykreślenie kwadrata
                        PowierzchniaGraficzna.DrawRectangle(Pióro, X, Y, DługośćBoku, DługośćBoku);
                        Widoczność = true; // kwadrat został wykreślony
                        Pióro.Dispose();
                    }
                }
                public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                {
                    if (this.Widoczność)
                    {

                        // utworzenie i sformatowanie egzemplarza pióra
                        using (Pen Pióro = new Pen(Kontrolka.BackColor, GrubośćLinii))
                        {
                            Pióro.DashStyle = StylLinii;
                            //wymazanie kwadrata
                            PowierzchniaGraficzna.DrawRectangle(Pióro, X, Y, DługośćBoku, DługośćBoku);
                            Widoczność = false; // kwadrat został wymazany
                            Pióro.Dispose();
                        }
                    }
                }
            }
            public class LiniaKreślonaMyszą : Punkt
            {//zrobimy nową listę (zbiór krzywej)
                protected List<Point> PunktyKrzywej = new List<Point>();
                public override void DodajPunktKrzywej(int newX, int newY)
                {
                    PunktyKrzywej.Add(new Point(newX, newY));
                }

                public LiniaKreślonaMyszą(int Xp, int Yp, int Xk, int Yk) : base(Xp, Yp)
                {

                    PunktyKrzywej.Add(new Point(Xp, Yp));
                    PunktyKrzywej.Add(new Point(Xk, Yk));
                }

                public LiniaKreślonaMyszą(int Xp, int Yp, int Xk, int Yk, Color Kolor,
                    DashStyle StylLinii, int GrubośćLinii) : base(Xp, Yp)
                {

                    PunktyKrzywej.Add(new Point(Xp, Yp));
                    PunktyKrzywej.Add(new Point(Xk, Yk));
                    this.StylLinii = StylLinii;
                    this.GrubośćLinii = GrubośćLinii;
                }

                // nadpisanie metod virtualnych
                public void UstawXY(int X, int Y)
                {
                    // zapisz przesunięcie
                    this.X = X;
                    this.Y = Y;

                    // ustal przesunięcie i uaktualniej listę punktów
                    // aktualna pozycja X,Y - nowa pozycja X,Y
                    // moveX = puPunktyKrzywej[0].X - X  <wtedy i tylko wtedy gdy> X = puPunktyKrzywej[i].X - moveX
                    int moveX = PunktyKrzywej[0].X - X;
                    int moveY = PunktyKrzywej[0].Y - Y;
                    for (int i = 0; i < PunktyKrzywej.Count; i++)
                    {
                        PunktyKrzywej[i] = new Point(PunktyKrzywej[i].X - moveX, PunktyKrzywej[i].Y - moveY);
                    }
                }
                public override void Wykreśl(Graphics PowierzchniaGraficzna)
                {
                    Pen Pióro = new Pen(Kolor, GrubośćLinii);
                    Pióro.DashStyle = this.StylLinii;
                    for (int i = 1; i < PunktyKrzywej.Count; i++)
                    {
                        PowierzchniaGraficzna.DrawLine(Pióro, PunktyKrzywej[i - 1].X, PunktyKrzywej[i - 1].Y, PunktyKrzywej[i].X, PunktyKrzywej[i].Y);
                    }
                    Pióro.Dispose();
                }
                public void WykreślPokaz(Graphics PowierzchniaGraficzna, int px, int py)
                {
                    Pen Pióro = new Pen(Kolor, GrubośćLinii);
                    Pióro.DashStyle = this.StylLinii;

                    int moveX = PunktyKrzywej[0].X - px;
                    int moveY = PunktyKrzywej[0].Y - py;
                    for (int i = 1; i < PunktyKrzywej.Count; i++)
                    {
                        PowierzchniaGraficzna.DrawLine(Pióro, PunktyKrzywej[i - 1].X - moveX, PunktyKrzywej[i - 1].Y - moveY, PunktyKrzywej[i].X - moveX, PunktyKrzywej[i].Y - moveY);
                    }
                    Pióro.Dispose();
                }
                public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                {
                    Pen Pióro = new Pen(Kontrolka.BackColor, this.GrubośćLinii);
                    Pióro.DashStyle = this.StylLinii;
                    for (int i = 1; i < PunktyKrzywej.Count; i++)
                    {
                        PowierzchniaGraficzna.DrawLine(Pióro, PunktyKrzywej[i - 1].X, PunktyKrzywej[i - 1].Y, PunktyKrzywej[i].X, PunktyKrzywej[i].Y);
                    }
                    Pióro.Dispose();
                }
            }



            public class WielokątForemny : Punkt
            {
                /* deklaracje chronione, gdyż klasa WielokątForemny może być klasą bazową
                dla innych klasy potomnych*/
                protected int PromieńOkręgu;
                protected int StopieńWielokąta;
                protected Point[] TablicaWierzchołkówWielokąta;
                protected float KątPołożeniaPierwszegoWierzchołka;

                public WielokątForemny(int StopieńWielokąta, int x, int y, int PromieńOkręgu) :
                                                        base(x, y)
                {
                    /* zapisanie wartości parametrów konstruktora w odpowiednich
                     * zmiennych zadeklarowanych w klasie : WielokątForemny*/
                    this.PromieńOkręgu = PromieńOkręgu;
                    this.StopieńWielokąta = StopieńWielokąta;
                    this.KątPołożeniaPierwszegoWierzchołka = 0.0F;
                    // utworzenir egzemplarza tablicy wierzchołków wielokąta 
                    TablicaWierzchołkówWielokąta = new Point[StopieńWielokąta + 1];
                    //utworzenie egzemplarzy wierzchołków Wiekąta
                    for (int i = 0; i < StopieńWielokąta; i++)
                        TablicaWierzchołkówWielokąta[i] = new Point();
                }
                public WielokątForemny(int StopieńWielokąta, int x, int y, int PromieńOkręgu,
                                  Color KolorLinii, DashStyle StylLinii, int GrubośćLinii) :
                                                      base(x, y, KolorLinii)
                {
                    /* zapisanie wartości parametrów konstruktora w odpowiednich zmiennych
                     * zadeklarowanych w klasie : WielokątForemny*/
                    this.PromieńOkręgu = PromieńOkręgu;
                    this.StopieńWielokąta = StopieńWielokąta;
                    this.KątPołożeniaPierwszegoWierzchołka = 0.0F;
                    /*zapisanie wartości parametró konstruktora w odpowiednich
                     * zmiennych zadeklarowanych w klasie bazowej : Punkt*/
                    base.StylLinii = StylLinii;
                    base.GrubośćLinii = GrubośćLinii;
                    //utworznie egzemplarza tablicy wierzchołków wielokąta
                    TablicaWierzchołkówWielokąta = new Point[StopieńWielokąta + 1];
                    //utworzenie egzemplarzy wierzchołków Wielokąta
                    for (int i = 0; i < StopieńWielokąta; i++)
                        TablicaWierzchołkówWielokąta[i] = new Point();
                }
                public override void Wykreśl(Graphics PowierzchniaGraficzna)
                {
                    //deklaracja i utworzenie egzemplarza
                    using (Pen Pióro = new Pen(Kolor, GrubośćLinii))
                    {
                        //sformatowanie Pióra 
                        Pióro.DashStyle = StylLinii;
                        /*obliczenie kąta środkowego (czyli kąta między dwoma sąsiednimi
                         * wierzchołkami wielokąta*/
                        float KatMiedzyWierzcholkami = 360F / StopieńWielokąta;
                        //wyznaczenie wspólrzędnych wierzchołków wielokąta
                        for (int i = 0; i <= StopieńWielokąta; i++)
                        //relacja <= , gdyż wielokąt musi być zamknięty
                        {
                            /*z równania parametrycznego okręgu wyznaczamy współrzędzne
                             * wierzchołków wielokąta*/
                            TablicaWierzchołkówWielokąta[i].X = (int)(this.X + PromieńOkręgu *
                                   Math.Cos(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                                                   i * KatMiedzyWierzcholkami) / 180));
                            TablicaWierzchołkówWielokąta[i].Y = (int)(this.Y - PromieńOkręgu *
                                   Math.Sin(Math.PI * (KątPołożeniaPierwszegoWierzchołka +
                                                   i * KatMiedzyWierzcholkami) / 180));
                        }
                        //wykreślenie wielokąta
                        for (int i = 0; i < this.StopieńWielokąta; i++)
                            PowierzchniaGraficzna.DrawLine(Pióro,
                                                                TablicaWierzchołkówWielokąta[i].X,
                                                                TablicaWierzchołkówWielokąta[i].Y,
                                                                TablicaWierzchołkówWielokąta[i + 1].X,
                                                                TablicaWierzchołkówWielokąta[i + 1].Y);
                        Widoczność = true;//wielokąt został wykreślony
                    }
                }
                public override void Wymaż(Control Kontrolka, Graphics PowierzchniaGraficzna)
                {
                    if (this.Widoczność)
                    {
                        /* deklaracja  i utworzenie egzepmlarza pióra (kolor pióra, to kolor tła
                         * kontrolki na której uworzono powierchnię graficzną)*/
                        using (Pen Pióro = new Pen(Kontrolka.BackColor, this.GrubośćLinii))
                        {
                            //sforatowanie Pióra
                            Pióro.DashStyle = this.StylLinii;
                            //wykreślenie (wymazanie) wielokąta
                            for (int i = 0; i < this.StopieńWielokąta; i++)
                                PowierzchniaGraficzna.DrawLine(Pióro,
                                                                TablicaWierzchołkówWielokąta[i].X,
                                                                TablicaWierzchołkówWielokąta[i].Y,
                                                                TablicaWierzchołkówWielokąta[i + 1].X,
                                                                TablicaWierzchołkówWielokąta[i + 1].Y);
                            Widoczność = false;//wielokąt został wymazany
                        }
                    }
                }
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (AkchlbFiguryGeometryczne.SelectedItems.Count <= 0)
            {
                //sygnalizacja błędu
                errorProvider1.SetError(AkchlbFiguryGeometryczne,
                    "ERROR: musisz wybrać (zaznaczyć) figury geometryczne do wizualizacji");
                return; //przerwanie obsługi zdarzenia btnStart_Click
            }
            else
                errorProvider1.Dispose();
            ushort N;//liczb figur geometrycznych
            while ((!ushort.TryParse(AktxtN.Text, out N)) || (N <= 0))
            {
                errorProvider1.SetError(AktxtN, "ERROR: musisz podać liczbę figur " +
                    "geometrycznych lub wystąpił niedozwolony znask w jej zapisie!");
                return;//przerwanie obsługi zdarzenia btnStart_Click
            }

            //ustawienie stanu braku aktywności dla kontrolek z danymi wejściowymi
            AkchlbFiguryGeometryczne.Enabled = false;
            AktxtN.Enabled = false;

            //utworzenie egzemplarza tablicy TFG
            TFG = new Punkt[N];
            //ustawienie indeksu tablicy TFG
            IndexTFG = 0;

            /*deklaracja zmiennej WybraneFigury i skopiowanie do niej kolekcji wybranych
              figur geometrycznych w kontrolce CHLB*/
            CheckedListBox.CheckedItemCollection WybraneFigury = AkchlbFiguryGeometryczne.CheckedItems;

            /*deklaracja zmiennych (tyou int, gdyż atrybuty kontrolki PictureBox:
             * Width i Height są typu int) i wyznaczenie rozmiarów powierzchni
             * graficznej (dla potrzeb wizualizacji figur geometrycznych)*/
            int Xmax = AkRycownica.Width;
            int Ymax = AkRycownica.Height;

            /*deklaracja i utworzenie egzepmlarza klasy Random dla denerowania liczb
             * losowych (umożliwi losowy wybór atrybutów graficznych (kolor, styl linii,
             * grubość linii) i geometrycznych (położenie, rozmiar))*/
            Random LiczbaLosowa = new Random();

            /*deklaracje pomocnicze dla przechowania wylosowanych atrybutów graficznych 
             * i geometrycznych dla wylosowanych figur geometrycnych*/
            Color KolorLinii; //kolor linii kreślenia figury geometrycznej
            Color KolorTła; //kolor tła
            int GrubośćLinii; //grubość linii
            DashStyle StylLinii; //styl linii figury geometrycznej
            int Xp, Yp; //współrzędne położenia figury geometrycznej

            /*utworzenie N egzemplarzy figur geometrycznych (losowanych z kolekcji
             * figur wybranych przez użytkownika programu w kontrolce CheckedListBox)
             * oraz zapisanie w tablicy TFG referencji egzemplarzy figur geometrycznych
             * i ich wykreślenie*/
            for (int i = 0; i < N; i++)
            {
                //wylosowanie współrzędnych położenia dla i-tej figury geometrycznej
                Xp = LiczbaLosowa.Next(Margines, Xmax - Margines);
                Yp = LiczbaLosowa.Next(Margines, Ymax - Margines);

                //wylosowanie koloru linii dla i-tej figury geometrycznej
                KolorLinii = Color.FromArgb(LiczbaLosowa.Next(0, 255),
                                            LiczbaLosowa.Next(0, 255),
                                            LiczbaLosowa.Next(0, 255));
                //wylosowanie koloru tła dla i-tej figury geometrycznej
                KolorTła = Color.FromArgb(LiczbaLosowa.Next(0, 255),
                                          LiczbaLosowa.Next(0, 255),
                                          LiczbaLosowa.Next(0, 255));
                //wylosowanie stylu linii dla i-tej figury geometrycznej
                switch (LiczbaLosowa.Next(1, 6))
                {
                    case 1:
                        StylLinii = DashStyle.Dash;
                        break;
                    case 2:
                        StylLinii = DashStyle.DashDot;
                        break;
                    case 3:
                        StylLinii = DashStyle.DashDotDot;
                        break;
                    case 4:
                        StylLinii = DashStyle.Dot;
                        break;
                    case 5:
                        StylLinii = DashStyle.Solid;
                        break;
                    default:
                        StylLinii = DashStyle.Solid;
                        break;
                }
                //wylosowanie grubości linii dla i-tej figury geometrycznej
                GrubośćLinii = LiczbaLosowa.Next(1, 10);
                /*wylosowanie nazwy i-tej geometrycznej wybranej (przez użytkoenika
                 * programu) w kontrolce CHLB*/
                string WylosowanaFigura =
                   WybraneFigury[LiczbaLosowa.Next(WybraneFigury.Count)].ToString();
                switch (WylosowanaFigura)
                {
                    case "Punkt":
                        /* utworzenie egzepmplarza klasy Punkt (z podaniem parametrów aktualnych
                         * dla jego konstruktora) i wpisanie referencji egzemplarza do tablicy TFG*/
                        TFG[IndexTFG] = new Punkt(Xp, Yp, KolorLinii);
                        //wykreślenie Punktu
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        //zwiększenie indeksu ("przejście" do następnej wolnej pozycji) tablicy TFG
                        IndexTFG++;
                        break;
                    case "Linia":
                        //wylosowanie współrzędnych zakończenia linii (nie były losowane!)
                        int Xk = LiczbaLosowa.Next(Margines, Xmax - Margines);
                        int Yk = LiczbaLosowa.Next(Margines, Ymax - Margines);
                        /*utworzenie egzemplarza klasy Linia (z podaniem parametrów aktualnych
                         * dla jego konstruktora) i wpisanie referencji egzemplarza do 
                         *                                              tablicy TFG*/
                        TFG[IndexTFG] = new Punkt.Linia(Xp, Yp, Xk, Yk, KolorLinii, StylLinii,
                                                           GrubośćLinii);
                        //wykreślenie linii
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        //zwiększenie indeksu("przejście" do następnej wolnej pozycji) tablicy TFG
                        IndexTFG++;
                        break;
                    case "Elipsa":
                        int OśDuża = LiczbaLosowa.Next(Margines, Xmax / 4 - Margines);
                        int OśMała = LiczbaLosowa.Next(Margines, Ymax / 4 - Margines);
                        /* utworzenie egzemplarza klasy Elipsa i wpisanie referencji
                         * egzemplarza do tablicy TFG*/
                        TFG[IndexTFG] = new Punkt.Linia.Elipsa(Xp, Yp, OśDuża, OśMała,
                                           KolorLinii, StylLinii, GrubośćLinii);
                        //wykreślenie Elipsy
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        //zwiększenie indeksu("przejście" do następnej wolnej pozycji) tablicy TFG
                        IndexTFG++;
                        break;
                    case "Okrąg":
                        // wylosowanie długości promienia okręgu
                        int Promień = LiczbaLosowa.Next(Margines, Ymax / 4);
                        /*utworzenie egzemplarza klasy Okrąg i wpisanie referencji egzemplarza
                         * do tablicy TFG */
                        TFG[IndexTFG] = new Punkt.Linia.Elipsa.Okrąg(Xp, Yp, Promień, KolorLinii, StylLinii,
                                                                                           GrubośćLinii);
                        // wykreślenie Okręgu
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        //zwiększenie indeksu ("przejście" do następnej wolnej pozycji) tablicy TFG
                        IndexTFG++;
                        break;
                    case "Koło":
                        // wylosowanie koloru tła
                        Promień = LiczbaLosowa.Next(Margines, Xmax / 4 - Margines);

                        /*utworzenie egzemplarza klasy Koło i wpisanie referencji egzemplarza
                         * do tablicy TFG */
                        TFG[IndexTFG] = new Punkt.Linia.Elipsa.FillieElipsa.Koło(Xp, Yp, Xp, Yp, KolorLinii,
                                                StylLinii, GrubośćLinii);
                        // wykreślenie Koła
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        //zwiększenie indeksu ("przejście" do następnej wolnej pozycji) tablicy TFG
                        IndexTFG++;
                        break;
                    case "Prostokąt":
                        //wylosowanie rozmiaru prostokąta
                        int Wysokość = LiczbaLosowa.Next(Margines, Xmax / 2);
                        int Szerokość = LiczbaLosowa.Next(Margines, Ymax / 4);
                        /*utworzenie egzemplarza klasy Prostokąt i wpisanie referencji egzemplarza
                         * do tablicy TFG */
                        TFG[IndexTFG] = new Punkt.Prostokąt(Xp, Yp, Szerokość, Wysokość,
                                                            KolorLinii, StylLinii, GrubośćLinii);
                        //wykreślenie prostokąta
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        //zwiększenie indeksu ("przejście" do następnej wolnej pozycji) tablicy TFG
                        IndexTFG++;
                        break;
                    case "Kwadrat":
                        //wylosowanie długości boku kwadrata
                        int DługośćBoku = LiczbaLosowa.Next(Margines, Xmax / 2);
                        /*utworzenie egzemplarza klasy Kwadrat i wpisanie referencji egzemplarza
                        * do tablicy TFG */
                        TFG[IndexTFG] = new Punkt.Kwadrat(Xp, Yp, DługośćBoku, KolorLinii,
                           StylLinii, GrubośćLinii);
                        //wykreślenie kwadrata
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        //zwiększenie indeksu ("przejście" do następnej wolnej pozycji) tablicy TFG
                        IndexTFG++;
                        break;
                    case "Wielokąt foremny":
                        int Rokręgu;//promień okręgu opisanego na wielokącie
                        Rokręgu = LiczbaLosowa.Next(1, Ymax / 3);//losowanie promienia
                        //wylosowanie stopnia wielokąta w przedziale od 3 do 20
                        int StopieńWielokąta = LiczbaLosowa.Next(3, 21);
                        /*utworzenie egzemplarza klasy WielokątForemny i wpisanie jego
                         * referencji (adresu) do tablicy TFG*/
                        TFG[IndexTFG] = new Punkt.WielokątForemny(StopieńWielokąta, Xp, Yp,
                                Rokręgu, KolorLinii, StylLinii, GrubośćLinii);
                        TFG[IndexTFG].Wykreśl(Rysownica);
                        //zwiększenie indeksu ("przejście" do następnej wolnej pozycji) tablicy TFG
                        IndexTFG++;
                        break;
                    default:
                        errorProvider1.SetError(AkbtnStart, "ERROR: figura o nazwie: " +
                                WylosowanaFigura + "nie może być wykreślona!!!");
                        return;
                }//od switch
            }// od for
             //odświeżenie powierzchni graficznej utworzonej na kontrolce PictureBox
            AkRycownica.Refresh();
            //ustawienie stanu aktywności dla przycisku poleceń: Start
            AkbtnStart.Enabled = false;
        }//od btnStart_Click
        private void btnPrzesuńFigury_Click(object sender, EventArgs e)
        {
            //deklaracje dla wylosowanych współrzędnych położeniu figury geometrycznej
            int Xp, Yp;
            //wymazanie powierzchni graficznej
            Rysownica.Clear(AkRycownica.BackColor);
            //określenie rozmiarów powierzchni graficznej
            int Xmax = AkRycownica.Width;
            int Ymax = AkRycownica.Height;
            //deklaracja i utworzenie egzemplarza obiektu Random
            Random LiczbaLosowa = new Random();
            /*losowa zmiana współrzędnych położenia każdej figury geometrycznej, których
             * referencje egzemplarzy są zapisane w tablicy TFG*/
            for (int i = 0; i < TFG.Length; i++)
            {//losowanie  nowego położenia i-tej figury geometrycznej
                Xp = LiczbaLosowa.Next(Margines, Xmax - Margines);
                Yp = LiczbaLosowa.Next(Margines, Ymax - Margines);
                /*zmiama położenia figury geometrycznej zapisanej na i-teh
                 * pozycji tablicy TFG z jednoczesnym jej wykreśleniem*/
                TFG[i].PrzesuńDoNowegoXY(AkRycownica, Rysownica, Xp, Yp);
            }//for
             //odświeżnie powierzchni graficznej (utworzonej na kontrolce PictureBox)
            AkRycownica.Refresh();
        }//od btnPrzesuńFigury_Click

        private void btnWłącz_Click(object sender, EventArgs e)
        {
            //oczyszczenie powierzchni graficznej
            Rysownica.Clear(AkRycownica.BackColor);

            if (AkbAutomatyczny.Checked)//tryb zegarowy
            {
                //tryb automatyczny (sterowany zegarem : timer1)

                /*wpisanie domyslego numeru (indeksu) pierwszej figury
                 * w wolnym polu Tag kontrolki timer1*/
                timer1.Tag = 0;//index w TFG
                txtNumerFigury.Text = "0";/* wpizanie domyslnego numeru
                w polu edycyjnym komtrolki TextBox: txtNumerFigury*/
                //ustawienie interwalu zegara
                timer1.Interval = InterwałZegara;/*zmienna zadeklarowana
                                        dodatkowo w kłasie głównej FiguryGeometryczne*/
                timer1.Enabled = true;/*włączenie zegara "taktualnego"
                        pokazem figur geometrycznych*/
            }
            else//tryb manualny, czyli przyciskowy
            {
                int IndeksFigury = 0;//domyślne ustawienie nmeru figury w TFG
                /*sprawdzenie, czy został wpisany numer figury do prezentacji w polu
                 * edycyjnym kontrolki TextBox*/
                if (string.IsNullOrEmpty(txtNumerFigury.Text.Trim()))
                    txtNumerFigury.Text = "0";/*wpisanie indeksu domyślnego, gdyż
                            pole edycyjne kontrolki txtNumerFigury było puste*/
                else
                {
                    //pobranie wpisanego numeru figury w TFG
                    if (!int.TryParse(txtNumerFigury.Text, out IndeksFigury))
                    {
                        errorProvider1.SetError(txtNumerFigury, "ERROR: błędny zapis numeru figury!");
                        return;
                    }
                    if ((IndeksFigury < 0) || (IndeksFigury >= (TFG.Length)))
                    {
                        errorProvider1.SetError(txtNumerFigury,
                                    "ERROR: numer figur wykracza poza tablicę TFG!");
                        return;
                    }
                    //wyłączenie errorProvider1
                    errorProvider1.Dispose();
                }
                txtNumerFigury.ReadOnly = true;
                int Xmax = AkRycownica.Width;
                int Ymax = AkRycownica.Height;
                //prezentacja figury geometrycznej w środku powierzchni graficznej
                TFG[IndeksFigury].PrzesuńDoNowegoXY(AkRycownica, Rysownica, Xmax / 2,
                                                                        Ymax / 2);
                //uartywnienie przycisków nawifacyjnych
                btnNastępny.Enabled = true;
                btnPopredni.Enabled = true;
            }
            AkRycownica.Refresh();
            /*ustawienie stanu braku aktywności dla przycisku poleceń:Włączenie
             * slajdera figur geometrycznych, gdyż jego obsługa została zakończona*/
            btnWłącz.Enabled = false;
            //uaktywnienie przycisku poleceń Wyłącz pokaz (slajder) figur geometrycznych
            btnWyłącz.Enabled = true;
        }// od btnWłącz_Click

        private void timer1_Tick(object sender, EventArgs e)
        {
            //wymazanie powierzchni graficznej
            Rysownica.Clear(AkRycownica.BackColor);
            //określenie rozmiaru powierzchni graficznej
            int Xmax = AkRycownica.Width;
            int Ymax = AkRycownica.Height;
            /*pobranie z pola Tag zegara timer1 wartości numeru figury do prezentacji
             * i wpisanie do pola edycyjnego kontrolki TextBox*/
            txtNumerFigury.Text = timer1.Tag.ToString();
            /*do środka powierzchni graficznej przesuwamy figurę geometryczną(z jedno
             * czesnym wykreśleniem ), której numer wpisany jest w polu timer1.Tag
             * (wymagana jest konwersja na typ int)*/
            TFG[(int)timer1.Tag].PrzesuńDoNowegoXY(AkRycownica, Rysownica,
                                               Xmax / 2, Ymax / 2);
            AkRycownica.Refresh();
            timer1.Tag = (int.Parse(timer1.Tag.ToString()) + 1) % TFG.Length;
        }

        private void btnNastępny_Click(object sender, EventArgs e)
        {
            int IndeksFigury;
            IndeksFigury = int.Parse(txtNumerFigury.Text);
            //wymazanie aktualnie prezentowanej figry geometrycznej
            TFG[IndeksFigury].Wymaż(AkRycownica, Rysownica);
            //wyznaczenie indeksu następnej figury geometrycznej, która ma być prezentowana

            if (IndeksFigury < (TFG.Length - 1))
                IndeksFigury++;//przejście do następnego indeksu tablicy TFG
            else
                IndeksFigury = 0;//prejście do zerowego indeksu tablicy TFG
            //określenie rozmiaru powierzchni graficznej
            int Xmax = AkRycownica.Width;
            int Ymax = AkRycownica.Height;
            /* przesunięcie do środka powierzchni graficznej , figury geometrycznej
             * (z jednoczesnym jej wykreślenie), której numer wpisany jest do 
             * zmiennej IndeksFigury*/
            TFG[IndeksFigury].PrzesuńDoNowegoXY(AkRycownica, Rysownica, Xmax / 2, Ymax / 2);
            /*wpisanie do pola edycyjnego kontrolki txtNumerFigury indeksu
             * aktualnie przentowanej geometrycznej*/
            txtNumerFigury.Text = IndeksFigury.ToString();
            //odświeżenie powierzchni graficznej kontrolki PictureBox
            AkRycownica.Refresh();
        }

        private void btnWyłącz_Click(object sender, EventArgs e)
        {
            //wymazanie powierzchni graficznej
            Rysownica.Clear(AkRycownica.BackColor);
            /*wyłączenie zegara "taktujący" pokazem figur geometrycznych w trybie
             * automatycznym*/
            timer1.Enabled = false;
            /*deklaracja zmiennych i wyznaczenie rozmiaru powierzchni graficznej
             * (maksymalnych wartości współrzędnych X i Y)*/
            int Xmax = AkRycownica.Width;
            int Ymax = AkRycownica.Height;
            /*deklaracja zmieennych dla przechowania współrzędnych dla nowej lokalizacji
             * figur geometrycznych*/
            int Xp, Yp;//współrzędne położenia figury geometrycznej
            /*deklaracja zmiennej referencyjnej LiczbaLosowa z utworzeniem egzemplarza
             * generatora liczb losowych, czyli klasy Random*/
            Random LiczbaLosowa = new Random();

            /*wyznaczamy losowo nową lokalizację dla wszystkich figur 
             * geometrycznych, których adresy referencje egzemplarzy zaoisane są w 
             * tablicy TFG*/
            for (int i = 0; i < TFG.Length; i++)
            {//losowanie współrzędnych dla nowego położenia i-tej figury geometrycznej
                Xp = LiczbaLosowa.Next(Margines, Xmax - Margines);
                Yp = LiczbaLosowa.Next(Margines, Ymax - Margines);
                /*ustalenie nowego połoąenia z jednoczesnym wykreśleniem i-tej
                 * figury geometrycznej*/
                TFG[i].PrzesuńDoNowegoXY(AkRycownica, Rysownica, Xp, Yp);
            }// for
             //odświeąm powierzchnię kontrolki PictureBox
            AkRycownica.Refresh();

            //ustawiamy stan aktywności dla przyciscu poleceń Włącz
            btnWłącz.Enabled = true;
            //ustawiamy stanu braku aktywności przycisku poleceń Wyłącz
            btnWyłącz.Enabled = false;
            //ustawiamy stanu sktywności przycisków nawigacyjnych
            btnNastępny.Enabled = false;
            btnPopredni.Enabled = false;
            //zmiana właściwości ReadOnly dla kontrolki txtNumerFigury
            txtNumerFigury.ReadOnly = false;

        }

        private void txtNumerFigury_TextChanged(object sender, EventArgs e)
        {
            //deklaracja pomocnicza dla przechowania numeru figury w tablicy TFG
            ushort IndeksFigury;
            /*pobranie wpisanego numeru figury geometrycznej w polu edycyjnym
             * kontrolki TextBox*/
            if (!ushort.TryParse(txtNumerFigury.Text, out IndeksFigury))
            {
                errorProvider1.SetError(txtNumerFigury,
                                    "ERROR: blędny zapis indeksu figury!");
                return;
            };
            if ((IndeksFigury < 0) || (IndeksFigury >= (TFG.Length)))
            {
                errorProvider1.SetError(txtNumerFigury,
                                    "ERROR: indeks figury wykracza tablicę TFG!");
                return;
            }
            errorProvider1.Dispose();//wyłączenie errorProvider1
        }
        private void FiguryGeometryczne_Load(object sender, EventArgs e)
        {
            //lokalizacje innych kontrolek
            akWybierzFigurę.Location = new Point(AkchlbFiguryGeometryczne.Location.X,
                                               AkchlbFiguryGeometryczne.Location.Y
                                               + AkchlbFiguryGeometryczne.Height + Margines / 2);
        }

        private void btnPopredni_Click(object sender, EventArgs e)
        {
            int IndeksFigury;
            //odczytanie bieżącego indeksu prezentowanej figury
            IndeksFigury = int.Parse(txtNumerFigury.Text);
            //wymazanie aktualnie prezentowanej figury geometrycznej
            TFG[IndeksFigury].Wymaż(AkRycownica, Rysownica);
            //wyznaczamy indeks poprzedniej figury geometrycznej, która będzie teraz prezentowana
            if (IndeksFigury > 0)
                IndeksFigury--;//przejście do poprzedzającego indeksu tablicy TFG
            else
                IndeksFigury = TFG.Length - 1;//przejście do ostatniego indeksu tablicy TFG
            //określenie rozmiaru powierzchni graficznej
            int Xmax = AkRycownica.Width;
            int Ymax = AkRycownica.Height;
            /*przesunieńcie do środka powierzchni graficznej, figury geometrycznej, której
             * numer jest wpisany do zmiennej IndeksFidury*/
            TFG[IndeksFigury].PrzesuńDoNowegoXY(AkRycownica, Rysownica, Xmax / 2, Ymax / 2);
            /*wpisanie do pola edycyjnego kontrolki txtIndeksFigury indeksu aktualnie preze
             *ntowanej figury geometryznej*/
            txtNumerFigury.Text = IndeksFigury.ToString();
            //odświeżenie powierzchni graficznej kontrolki PictureBox
            AkRycownica.Refresh();
        }

        private void pbRycownica_MouseDown(object sender, MouseEventArgs e)
        {
            //monitorowanie aktualnego położenie myszy
            lbWspX.Text = e.Location.X.ToString();
            lbWspY.Text = e.Location.Y.ToString();
            /*rozpoznanie, czy obsługiwane zdarzenie jest spowodowane nacisnięciem lewego
             * przycisku myszy*/
            if (e.Button == MouseButtons.Left)
            {
                //zapamiętanie współrzędne punktu, który został "kliknięty" lewym przyciskiem myszy
                PunktStartu = e.Location;
                //główne wejście w liście LFG dla linii kreślonej myszą
                if (akbLiniaKreślonaMyszą.Checked)
                {
                    if (AKbPunkt.Checked)
                        LFG.Add(new Punkt.LiniaKreślonaMyszą(PunktStartu.X, PunktStartu.Y, e.Location.X, e.Location.Y));
                }

            }
        }

        private void pbRycownica_MouseUp(object sender, MouseEventArgs e)
        {
            //monitorowanie aktualnego położenie myszy
            lbWspX.Text = e.Location.X.ToString();
            lbWspY.Text = e.Location.Y.ToString();

            /*deklaracje zmiennych pomocniczych i wyznaczenie parametrów opisujących prostokąt, w których
             * będzie wykreślana figura geometryczna*/
            int lewyGórnyNarożnikX = (PunktStartu.X > e.Location.X) ? e.Location.X : PunktStartu.X;
            int lewyGórnyNarożnikY = (PunktStartu.Y > e.Location.Y) ? e.Location.Y : PunktStartu.Y;
            int Szerokość = Math.Abs(PunktStartu.X - e.Location.X);
            int Wysokość = Math.Abs(PunktStartu.Y - e.Location.Y);
            int DługośćBoku = Math.Abs(PunktStartu.X - e.Location.X);
            SolidBrush Pędzel = new SolidBrush(Color.Red);
            GraphicsPath graficzna = new GraphicsPath();
            Rectangle rect = new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość);
            Point[] Points =
                    {
                        new Point(213,204),
                        new Point(63, 143),
                        new Point(227, 60),
                        new Point(123, 222),
                        new Point(72, 64),
                    };
            int PunktS = Math.Abs(PunktStartu.X / 2 - e.Location.X);
            int PunktR = Math.Abs(PunktStartu.Y / 2 - e.Location.Y);
            GraphicsPath graficznyPath = new GraphicsPath();
            graficznyPath.AddEllipse(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość);
            Point[] linii =
                            {
                                new Point(10, 10),
                                new Point(10,100),
                                new Point(200, 50),
                                new Point(250, 300)
                            };
            /*sprawdzenie, czy obsługiwane zdarzenie zostało spowodowane
             * zwolniniem lewego przycisku myszy*/
            if (e.Button == MouseButtons.Left)
            {
                //deklaracja pióra
                Pen Pióro = new Pen(Color.Black, 1);
                ushort promieńPunktu = 5;
                //rozpoznanie wybranej figury geometrycznej i jej wykreślenie
                if (AKbPunkt.Checked)
                {
                    //wykreślenie punktu
                    Rysownica.FillEllipse(Brushes.Black, e.Location.X - promieńPunktu,
                                                         e.Location.Y - promieńPunktu,
                                                         promieńPunktu + promieńPunktu,
                                                         promieńPunktu + promieńPunktu);
                    //utworzenie egzemplarza klasy Punkt i dodanie jego refencji do listy LFG
                    LFG.Add(new Punkt(PunktStartu.X, PunktStartu.Y));
                }
                else
                    if (akbLiniaProsta.Checked)
                {
                    //wykreślenie linii
                    Rysownica.DrawLine(Pióro, PunktStartu, e.Location);
                    //utworzenie egzemplarza klasy Linia i dodanie jego referencji do listy LFG
                    LFG.Add(new Punkt.Linia(PunktStartu.X, PunktStartu.Y, e.Location.X, e.Location.Y));
                }
                else
                    if (akbElipsa.Checked)
                {
                    //wykreślenie elipsy
                    Rysownica.DrawEllipse(Pióro, lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość);
                    //utworzenie egzemplarza klasy Elipsa i dodanie jego referencji do listy LFG
                    LFG.Add(new Punkt.Linia.Elipsa(lewyGórnyNarożnikX - Szerokość / 2,
                                    lewyGórnyNarożnikY - Szerokość / 2, Szerokość, Wysokość));
                }

                else
                    if (akbOkrąg.Checked)
                {
                    //wykreślenie okręgu
                    Rysownica.DrawEllipse(Pióro, lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                        Szerokość, Szerokość);
                    //utworzenie egzemplarza klasy Okrąg i dodanie jego referencji do listy LFG
                    LFG.Add(new Punkt.Linia.Elipsa.Okrąg(lewyGórnyNarożnikX - Szerokość / 2,
                                        lewyGórnyNarożnikY - Szerokość / 2, Szerokość));
                }
                else
                    if (akbProstokąt.Checked)
                {
                    //wykreślenie prostokąta
                    Rysownica.DrawRectangle(Pióro, lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość,
                                                                        Wysokość);
                    //utworzenie egzemplarza klasy Prostokąt i dodanie jego referencji do listy LFG
                    LFG.Add(new Punkt.Prostokąt(lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                            Szerokość, Wysokość));
                }
                else
                    if (akbKwadrat.Checked)
                {
                    //wykreślenie kwadratu
                    Rysownica.DrawRectangle(Pióro, lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                       DługośćBoku, DługośćBoku);
                    //utworzenie egzemplarza klasy Kwadrat i dodanie jego referencji do listy LFG
                    LFG.Add(new Punkt.Kwadrat(lewyGórnyNarożnikX, lewyGórnyNarożnikY, DługośćBoku));
                }
                else
                        if (akbFillieElipsa.Checked)
                {
                    //wykreślenie kwadratu
                    Rysownica.FillEllipse(Pędzel, lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                       Szerokość, Wysokość);
                    //utworzenie egzemplarza klay FillElipsa i dodanie jego referencji do listy LFG
                    LFG.Add(new Punkt.Linia.Elipsa.FillieElipsa(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość));
                }
                else
                if (akbLiniaKreślonaMyszą.Checked)
                {
                    if (AKbPunkt.Checked)
                    {
                        Rysownica.DrawLine(Pióro, PunktStartu, e.Location);
                        LFG.Add(new Punkt.LiniaKreślonaMyszą(lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                            Szerokość, Wysokość));
                    }
                }
                else
                    if (akbFillPath.Checked)
                {
                    //Rysownica.FillPath(Pędzel, graficzna);
                    //LFG.Add(new Punkt.Linia.Elipsa.FillieElipsa.FillPath(lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                    //                                      Szerokość, Wysokość));
                    Rysownica.FillPath(Pędzel, graficzna);
                    LFG.Add(new Punkt.Linia.Elipsa.FillieElipsa.FillPath(lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                               Szerokość, Wysokość));

                }
                else
                    if (akbDrawPie.Checked)
                {
                    Rysownica.DrawPie(Pióro, lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość, Szerokość, Wysokość);
                    LFG.Add(new Punkt.Prostokąt.DrawPie(lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                            Szerokość, Wysokość));
                }
                else
                    if (akbFillPie.Checked)
                {
                    Rysownica.FillPie(Pędzel, rect, Szerokość, Wysokość);
                    LFG.Add(new Punkt.DrawPie.FillPie(lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                        Szerokość, Wysokość));
                }
                else
                    if (akbWielokątForemny.Checked)
                {
                    Rysownica.DrawPolygon(Pióro, new Point[] { new Point(100, 100),
                                                               new Point (200, 200),
                                                               new Point(300, 300),
                                                               new Point(400, 400),
                                                               new Point(500, 500)});
                    LFG.Add(new Punkt.Linia.Elipsa.WielokątForemny(lewyGórnyNarożnikX, lewyGórnyNarożnikX,
                                            lewyGórnyNarożnikY, Szerokość));
                }
                else
                    if (akbDrawCurve.Checked)
                {
                    Rysownica.DrawCurve(Pióro, Points);
                    LFG.Add(new Punkt.Linia.DrawCurve(lewyGórnyNarożnikX, lewyGórnyNarożnikY));
                }
                else
                    if (akbDrawClosedCurve.Checked)
                {
                    Rysownica.DrawCurve(Pióro, Points);
                    LFG.Add(new Punkt.Linia.DrawClosedCurve(lewyGórnyNarożnikX, lewyGórnyNarożnikY));
                }
                else
                    if (akbDrawPath.Checked)
                {
                    Rysownica.DrawPath(Pióro, graficznyPath);
                    LFG.Add(new Punkt.Linia.Elipsa.DrawPath(lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                       Szerokość, Wysokość));
                }
                else
                    if (akbDrawArc.Checked)
                {
                    Rysownica.DrawArc(Pióro, rect, PunktS, PunktR);
                    LFG.Add(new Punkt.Prostokąt.DrawArc(lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                            Szerokość, Wysokość));
                }
                else
                    if (akbDrawLines.Checked)
                {
                    Rysownica.DrawLines(Pióro, linii);
                    LFG.Add(new Punkt.Linia.DrawLines(PunktStartu.X, PunktStartu.Y, e.Location.X, e.Location.Y));
                }
                else
                    MessageBox.Show("ERROR: wykreślenie tej figury nie jest jeszcze" + "zakończone:" +
                                        "spróbuj trochę póżniej!!!");
            }
            //odświeżenie Rysownicy
            AkRycownica.Refresh();
        }

        private void pbRycownica_MouseMove(object sender, MouseEventArgs e)
        {
            //monitorowanie aktualnego połozenia myszy
            lblWspX.Text = e.Location.X.ToString();
            lblWspY.Text = e.Location.Y.ToString();

            //sprawdzenie, czy lewy przycissk jest wciśnięty
            if (e.Button == MouseButtons.Left)
            {/*deklaracje zmiennych pomocniczych i wyznaczenie parametrów opisujących prostokąt,
                w którym będzie wykreślana figura geometryczna*/
                int lewyGórnyNarożnikX =
                    (PunktStartu.X > e.Location.X) ? e.Location.X : PunktStartu.X;
                int lewyGórnyNarożnikY =
                    (PunktStartu.Y > e.Location.Y) ? e.Location.Y : PunktStartu.Y;
                int Szerokość = Math.Abs(PunktStartu.X - e.Location.X);
                int Wysokość = Math.Abs(PunktStartu.Y - e.Location.Y);
                int figura = Math.Abs(PunktStartu.X - e.Location.X);
                int figura2 = Math.Abs(PunktStartu.Y - e.Location.Y);
                int PunktS = Math.Abs(PunktStartu.X / 2 - e.Location.X);
                int PunktR = Math.Abs(PunktStartu.Y / 2 - e.Location.Y);
                SolidBrush PędzelPomocniczy = new SolidBrush(Color.Red);
                GraphicsPath graficzna = new GraphicsPath();
                Rectangle rect = new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość);
                Point[] Points =
                    {
                        new Point(213,204),
                        new Point(63, 143),
                        new Point(227, 60),
                        new Point(123, 222),
                        new Point(72, 64),
                    };
                Point[] linii =
                            {
                                new Point(10, 10),
                                new Point(10,100),
                                new Point(200, 50),
                                new Point(250, 300)
                            };
                GraphicsPath graficznyPath = new GraphicsPath();
                graficznyPath.AddEllipse(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość);
                //rozpoznanie zaznaczoej kontrolki RadioButton określającej wybraną figurę geometryczną
                if (AKbPunkt.Checked) ;//instrukcja pusta, bo nie "rozciągamy" punktu
                else
                    if (akbLiniaProsta.Checked)//kreślenie linii prostej
                    RysownicaChwilowa.DrawLine(PióroPomocnicze, PunktStartu.X,
                                        PunktStartu.Y, e.Location.X, e.Location.Y);
                else
                    if (akbElipsa.Checked)//kreślenie Elipsy
                    RysownicaChwilowa.DrawEllipse(PióroPomocnicze,
                                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość,
                                                                        Wysokość));
                else
                    if (akbOkrąg.Checked)//kreślenie okręgu
                    //okrąg ma obywie średniece identyczne
                    RysownicaChwilowa.DrawEllipse(PióroPomocnicze,
                                        new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość,
                                                                        Wysokość));
                else
                     if (akbLiniaKreślonaMyszą.Checked)
                {
                    Rysownica.DrawLine(PióroPomocnicze, PunktStartu, e.Location);
                    if (LFG.Count > 0)
                    {
                        LFG[LFG.Count - 1].DodajPunktKrzywej(e.Location.X, e.Location.Y);
                    }
                    PunktStartu = e.Location;
                }
                else
                    if (akbWielokątForemny.Checked)
                {
                    RysownicaChwilowa.DrawPolygon(PióroPomocnicze, new Point[]
                                                                  {new Point(100,100),
                                                                   new Point(200,200),
                                                                   new Point(300,300),
                                                                   new Point(400,400),
                                                                   new Point(500,500) });
                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                            Szerokość, Wysokość);

                }
                else
                    if (akbProstokąt.Checked)
                {
                    //wykreślenie prostokąta
                    RysownicaChwilowa.DrawRectangle(PióroPomocnicze, lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość,
                                                                        Wysokość);
                    //utworzenie egzemplarza klsyy Prostokąt i dodanie jego referencji do listy LFG
                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                            Szerokość, Wysokość);
                }
                else
                    if (akbKwadrat.Checked)
                {
                    //wykreślenie kwadratu
                    RysownicaChwilowa.DrawRectangle(PióroPomocnicze, lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                      Wysokość, Wysokość);
                    //utworzenie egzemplarza klsyy Kwadrat i dodanie jego referencji do listy LFG
                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Wysokość, Wysokość);
                }
                else
                    if (akbFillieElipsa.Checked) 
                {//wykreślenie elipsy
                    RysownicaChwilowa.FillEllipse(PędzelPomocniczy, lewyGórnyNarożnikX, lewyGórnyNarożnikY,
                                        Wysokość, Szerokość);
                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Wysokość, Szerokość);

                }
                else
                    if (akbFillPath.Checked)
                {


                    graficzna.AddLine(PunktStartu, new Point(e.X, e.Y));
                    Rysownica.FillPath(PędzelPomocniczy, graficzna);
                    //RysownicaChwilowa.FillPath(PędzelPomocniczy, graficzna);
                    // graficzna.AddEllipse(new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Wysokość, Szerokość));
                    // new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość);
                    // RysownicaChwilowa.FillPath(PędzelPomocniczy, graficzna);
                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Wysokość, Szerokość);
                    graficzna.AddEllipse(new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość));
                }
                else
                    if (akbDrawPie.Checked)
                {
                    RysownicaChwilowa.DrawPie(PióroPomocnicze, rect, Szerokość, Wysokość);
                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Wysokość, Szerokość);
                }
                else
                    if (akbFillPie.Checked)
                {
                    Rysownica.FillPie(PędzelPomocniczy, rect, Szerokość, Wysokość);
                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość);
                }
                else
                    if (akbDrawCurve.Checked)
                {
                    RysownicaChwilowa.DrawCurve(PióroPomocnicze, Points);
                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość);
                    Cursor = Cursors.Cross;
                    const int radius = 3;
                    const int diametr = 2 * radius;
                    Rectangle rect2 = new Rectangle(PunktStartu.X - radius, PunktStartu.Y - radius,
                                            diametr, diametr);
                    Rysownica.FillEllipse(PędzelPomocniczy, rect2);
                    Rysownica.DrawEllipse(PióroPomocnicze, rect2);
                }
                else
                    if (akbDrawClosedCurve.Checked)
                {
                    RysownicaChwilowa.DrawClosedCurve(PióroPomocnicze, Points);
                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość);
                    Cursor = Cursors.Cross;
                    const int radius = 3;
                    const int diametr = 2 * radius;
                    Rectangle rect2 = new Rectangle(PunktStartu.X - radius, PunktStartu.Y - radius,
                                            diametr, diametr);
                    Rysownica.FillEllipse(PędzelPomocniczy, rect2);
                    Rysownica.DrawEllipse(PióroPomocnicze, rect2);
                }
                else
                    if (akbDrawPath.Checked)
                {
                    RysownicaChwilowa.DrawPath(PióroPomocnicze, graficznyPath);
                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość);
                }
                else
                    if (akbDrawArc.Checked)
                {
                    RysownicaChwilowa.DrawArc(PióroPomocnicze, rect, PunktS, PunktR);
                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość);
                }
                else
                    if (akbDrawLines.Checked)
                {
                    RysownicaChwilowa.DrawLines(PióroPomocnicze, linii);
                    new Rectangle(lewyGórnyNarożnikX, lewyGórnyNarożnikY, Szerokość, Wysokość);
                }
                else
                {
                    MessageBox.Show("Pracuję nad tą figurą: under construction!");
                    //odświeżenie Rysownicy
                    AkRycownica.Refresh();
                }

            }
        } 
    }
}

