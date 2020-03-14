using static GasolineraKalum.Util.Printer;
using static System.Console;
using System;
using GasolineraKalum.Controllers;
using GasolineraKalum.Entidades;

namespace GasolineraKalum
{
    public class MenuPrincipal
    {
        private GasolineraController controller = new GasolineraController();
        public void MostrarMenu()
        {
            try
            {
                int opcion = 0;
                do
                {
                    Clear();
                    WriteTitle("Administracion de Bombas");
                    WriteLine("1. Agregar"); //eliminar buscar listar modificar 0 Salir
                    WriteLine("2. Eliminar");
                    WriteLine("3. Buscar");
                    WriteLine("4. Listar");
                    WriteLine("5. Modificar");
                    WriteLine("0. Salir");
                    WriteLine("Ingrese Una Opcion=====");

                    string respuesta = ReadLine();//toma la respuesta de la consola
                    opcion = Convert.ToByte(respuesta);

                    switch (Convert.ToByte(respuesta))
                    {
                        case 1:
                        agregarTipoBomba();
                            break;
                        case 2:
                        eliminar();
                            break;
                        case 3:
                        buscar();
                            break;
                        case 4:
                            listarBombas();
                            break;
                        case 5:
                        modificar();
                            break;
                        case 0:
                            break;
                        default:
                            WriteLine("No existe la opcion");
                            break;
                    }

                } while (opcion != 0);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        private void agregarTipoBomba()
        {
            WriteTitle("Tipo de Bomba");
            WriteLine("1. Super");
            WriteLine("2. Regular");
            WriteLine("3. Diesel");
            WriteLine("0. Salir");
            string respuesta = ReadLine();
            if (respuesta.Equals("1"))
            {
                Bomba super = new Super();
                agregarElemento(super);
            }
            else if (respuesta.Equals("2"))
            {
                Bomba regular = new Regular();
                agregarElemento(regular);
            }
            else if (respuesta.Equals("3"))
            {
                Bomba diesel = new Diesel();
                agregarElemento(diesel);
            }
        }
        private void agregarElemento(Bomba elemento)
        {
            WriteLine("Ingrese un precio");
            elemento.Precio = Convert.ToDouble(ReadLine());

            WriteLine("ingrese Una Medida");
            elemento.Medida = ReadLine();

            WriteLine("Ingrese una Cantidad");
            elemento.Capacidad = Convert.ToInt16(ReadLine());
            if (elemento.GetType() == typeof(Super))
            {
                WriteLine("Ingrese numero de Aditivo");
                ((Super)elemento).Aditivo = Convert.ToInt16(ReadLine());
            }
            else if (elemento.GetType() == typeof(Diesel))
            {
                WriteLine("Ingrese Formula");
                ((Diesel)elemento).Formula = ReadLine();
            }
            controller.agregar(elemento);
        }
        private void listarBombas()
        {
            controller.listar();
            PresionarEnter();
        }
        private void eliminar()
        {
            controller.listar();
            WriteLine("Ingrese el ID a eliminar: ");
            string id = Console.ReadLine();
            Object elemento = buscar(id);
            if(elemento!=null)
            {
                WriteLine("Esta seguro de eliminar? (S/N) ");
                string respuesta = Console.ReadLine();
                if(respuesta.Equals("s"))
                {
                    controller.eliminar(elemento);
                    WriteLine("Registro eliminado!");
                    ReadKey();
                }
            }
        }
        private Object buscar(string  id)
        {
            return controller.buscar(id);
        }

        public void buscar()
        {
            WriteLine("Ingrese el ID: ");
            string id = ReadLine();
            Object elemento = controller.buscar(id);
            
            if(elemento!= null)
            {
                WriteLine(elemento);
            }
            else
            {
                WriteLine("No existen registros..");
            }
            ReadKey();
        }

        public void modificar()
        {
            controller.listar();
            WriteLine("Ingrese el ID: ");
            String id = ReadLine();
            Object elemento = buscar(id);

            if(elemento != null)
            {
                ((Bomba)elemento).Capacidad= 2020;
                WriteLine("Registro Modificado!!!");
            }else
            {
                WriteLine("No existen registros");
            }
            ReadKey();
        }
    }
}