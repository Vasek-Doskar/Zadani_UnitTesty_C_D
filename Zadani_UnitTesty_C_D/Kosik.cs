using System;
using System.Collections.Generic;
using System.Text;

namespace Zadani_UnitTesty_C_D
{
    /// <summary>
    /// Třída reprezentující nákupní košík s možností správy položek, cenníku a výpočtu slev či DPH.
    /// </summary>
    public class Kosik
    {
        private double celkovaCena = 0;
        private int pocetPolozek = 0;

        /// <summary>
        /// Přidá do košíku položku se zadanou cenou.
        /// </summary>
        /// <param name="cena">Cena přidávané položky.</param>
        /// <exception cref="ArgumentOutOfRangeException">Vyhozeno, pokud je cena záporná.</exception>
        public void PridejPolozku(double cena)
        {
            if (cena < 0)
                throw new ArgumentOutOfRangeException(nameof(cena), "Cena nemůže být záporná.");
            celkovaCena += cena;
            pocetPolozek++;
        }

        /// <summary>
        /// Vypočítá novou cenu po aplikaci procentuální slevy.
        /// </summary>
        /// <param name="cena">Původní cena.</param>
        /// <param name="slevaVProcentech">Výše slevy v rozmezí 0 až 100 %.</param>
        /// <returns>Cena po slevě.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Vyhozeno, pokud je sleva menší než 0 nebo větší než 100.</exception>
        public double VypocitejCenuPoSleve(double cena, double slevaVProcentech)
        {
            if (slevaVProcentech < 0 || slevaVProcentech > 100)
                throw new ArgumentOutOfRangeException("Sleva musí být mezi 0 a 100 %.");
            return cena * (1 - slevaVProcentech / 100);
        }

        /// <summary>
        /// Zjistí, zda celková cena v košíku dosáhla limitu pro poštovné zdarma.
        /// </summary>
        /// <param name="limitProZdarma">Minimální částka pro získání dopravy zdarma.</param>
        /// <returns><c>true</c>, pokud je částka vyšší nebo rovna limitu; jinak <c>false</c>.</returns>
        public bool MaPostovneZdarma(double limitProZdarma) => celkovaCena >= limitProZdarma;

        /// <summary>
        /// Vrátí aktuální celkovou cenu všech položek v košíku.
        /// </summary>
        /// <returns>Celková cena.</returns>
        public double ZiskejCelkovouCenu() => celkovaCena;

        /// <summary>
        /// Vrátí aktuální počet položek vložených do košíku.
        /// </summary>
        /// <returns>Počet položek.</returns>
        public int ZiskejPocetPolozek() => pocetPolozek;

        /// <summary>
        /// Vyprázdní košík (vynuluje celkovou cenu i počet položek).
        /// </summary>
        public void VyprazdniKosik()
        {
            celkovaCena = 0;
            pocetPolozek = 0;
        }

        /// <summary>
        /// Vypočítá výši DPH ze zadané ceny bez DPH a dané sazby.
        /// </summary>
        /// <param name="cenaBezDph">Cena bez daně.</param>
        /// <param name="sazbaDph">Sazba DPH v procentech (např. 21).</param>
        /// <returns>Spočítaná částka DPH.</returns>
        public double SpocitejDph(double cenaBezDph, double sazbaDph) => cenaBezDph * (sazbaDph / 100);

        /// <summary>
        /// Ověří, zda je košík prázdný (neobsahuje žádné položky).
        /// </summary>
        /// <returns><c>true</c>, pokud v košíku nic není; jinak <c>false</c>.</returns>
        public bool JePrazdny() => pocetPolozek == 0;

        /// <summary>
        /// Formátuje číselnou cenu na textový řetězec s měnou (např. "150.00 Kč").
        /// </summary>
        /// <param name="cena">Číselná hodnota ceny.</param>
        /// <returns>Formátovaný řetězec ceny.</returns>
        public string FormatujCenu(double cena) => $"{cena:F2} Kč";

        /// <summary>
        /// Sloučí stav tohoto košíku s hodnotami jiného košíku.
        /// </summary>
        /// <param name="cenaDalsihoKosiku">Cena přičítaného košíku.</param>
        /// <param name="pocetPolozekDalsihoKosiku">Počet položek přičítaného košíku.</param>
        /// <exception cref="ArgumentException">Vyhozeno, pokud je cena nebo počet položek záporný.</exception>
        public void SlucSKosikem(double cenaDalsihoKosiku, int pocetPolozekDalsihoKosiku)
        {
            if (cenaDalsihoKosiku < 0 || pocetPolozekDalsihoKosiku < 0)
                throw new ArgumentException("Hodnoty pro sloučení nesmí být záporné.");
            celkovaCena += cenaDalsihoKosiku;
            pocetPolozek += pocetPolozekDalsihoKosiku;
        }
    }
}