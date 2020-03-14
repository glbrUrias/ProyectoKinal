using System;
using GasolineraKalum.Controllers;
using GasolineraKalum.Entidades;
using static GasolineraKalum.Util.Printer;

namespace GasolineraKalum
{
    class Program
    {
        static void Main(string[] args)
        {
            Beep();
            WriteTitle("Gasolinera Kalum");
           new MenuPrincipal().MostrarMenu();

           
           //string salida = "GasolineraKalum.Entities.Super";
           //LastIndexOf para uscar un caracter de derecha a izquierda
           //indexof de izquierda a derecha
           // Console.WriteLine(salida.Substring(salida.LastIndexOf(".")+1));
            //se puede utilizar split como: string[] valores = salida.Split("."); Guarda el valor en el arreglo cuando encuentra el punto


          
            PresionarEnter();
            

        }
    }
}
