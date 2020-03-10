using System;


/*
 * INTERFACE VS ABSTRACT CLASS :
 *
 * 1. Interface can have only abstract methods. Abstract class can have abstract and non-abstract methods.
 *
 * 2. Abstract class can provide the implementation of interface. Interface can’t provide the implementation of abstract class.
 *
 * 3. Abstract class can have final, non-final, static and non-static variables. Interface has only static and final variables.
 *
 * https://www.geeksforgeeks.org/difference-between-abstract-class-and-interface-in-java/
 *
 * Lenyeges kulonbseg az a ket dolog kozott, hogy abstracct classba olyan fuggvenyeket teszunk amiket csak a
 * leszarmaztatott osztaly hasznal vagy annak a leszarmaztatotjai.
 * Interface-nel meg olyan fuggvenyeket vagy tulajdonsagokat amit altalanositani tudunk.
 * LENTI PELDA JOL MUTATJA EZT BE !!!
 * ZH-ban ezt meg az elejen feltuntetik.
 *
 * Basic Code by Sipos Miklos
 */


namespace InterfaceVsClass
{
    interface IAlcohol
    {
        double AlcoholContain();
        bool AgeLimit();
    }

    abstract class Alcohol
    {
        // Option 1.:
        string name1;
        public string Name1 { get { return name1; } set { name1 = value; } } // shortcut.: PROPFULL + TAB + TAB
        // ===============================
        // Option 2.:
        public string Name2 { get; set; }  // shortcut.: PROP + TAB + TAB

        public Alcohol(string name)
        {
            this.name1 = name; // >> Option 1.
            this.Name2 = name; // >> Option 2.
        }

        public abstract string Contains();
    }

    class FizzyAlcohol : Alcohol, IAlcohol // ORDER IS IMPORTANT!!!
    {
        public FizzyAlcohol(string name) : base(name) { }

        public bool AgeLimit() { return true; }

        public double AlcoholContain() { return 0.53; }

        public override string Contains() { return "CO2 "; }

        public override string ToString() { return $"Drink's name >> {Name1},\n\t\tAlcohol: {AlcoholContain()} %" +
                                                   $"\n\t\tAlcohol: { Contains()}"; }
    }

    class StrongDrink : Alcohol, IAlcohol
    {
        public StrongDrink(string name) : base(name) { }

        public bool AgeLimit() { return true; }

        public double AlcoholContain() { return 0.72; }

        public override string Contains() { return "metil-alcohol"; }

        public override string ToString() { return $"Drink's name >> {Name1},\n\t\tAlcohol: {AlcoholContain()} %" +
                                                   $"\n\t\tAlcohol: { Contains()}"; }
    }

    class Juice : IAlcohol
    {
        public string Name { get; set; }

        public bool AgeLimit() { return false; }

        public double AlcoholContain() { return 0.0; }

        public override string ToString() { return $"Drink's name >> {Name},\n\t\tAlcohol: {AlcoholContain()} %"; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tINTERFACE VS ABSTRACT CLASS\n\t" + new string('-',27));

            /*
            IAlcohol[] alcoholsDrinks = new IAlcohol[3]

            alcoholsDrinks[0] = new StrongDrink("Tatratea");
            alcoholsDrinks[1] = new FizzyAlcohol("Somersby");
                                ...
                            It's boring!

                                || It's the same ( Ugyan az )
                                \/
            */

            IAlcohol[] alcoholsDrinks = new IAlcohol[]
            {
                new StrongDrink("Tatratea"),                // interface típusú gyűjteményt tudunk itt is létrehozni                                                
                new FizzyAlcohol("Somersby"),               // csak úgy, mint (abs.) ősosztály esetén
                new Juice() {Name = "Bambi"}
            };


            // polimorfizmus működik interface-k esetén is
            // hiszen ezen esetben CSAK késői kötéssel működnek a metódusok
            // (ha belegondolunk, korai kötés nem is működne, hiszen nincs az "ősben" kifejtve a metódus...)
            for (int i = 0; i < alcoholsDrinks.Length; i++)
            { 
                Console.WriteLine(alcoholsDrinks[i]);
                // override ToString() >> We can costumize ToString ( Testre tudjuk szabni, hogy hogyan irassuk ki a dolgokat )

                if (alcoholsDrinks[i] is Juice)
                {
                    Console.WriteLine("NON-ALCOHOL DRINKS\n" + new string('_',18));
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine((alcoholsDrinks[i] as Juice).Name);
                    Console.ResetColor();
                }
            }
            Console.ReadLine();

        }
    }
}
