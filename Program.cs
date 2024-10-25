using System;

public class Nodo
{
    public int Valor;      
    public Nodo Siguiente;  

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

public class ListaEnlazada
{
    private Nodo inicio;  
    private int tamaño;   

    public ListaEnlazada()
    {
        inicio = null;  
        tamaño = 0;
    }

    
    public void InsertarNodo(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor); 
        if (inicio == null)
        {
            inicio = nuevoNodo;  
        }
        else
        {
            Nodo actual = inicio; 
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
        tamaño++;
        Console.WriteLine($"Nodo con valor {valor} insertado.");
    }

 
    public void ImprimirTamaño()
    {
        Console.WriteLine($"Tamaño de la lista: {tamaño}");
    }

  
    public Nodo BuscarNodo(int valor)
    {
        Nodo actual = inicio; 
        while (actual != null)
        {
            if (actual.Valor == valor)
            {
                Console.WriteLine($"Nodo con valor {valor} encontrado.");
                return actual;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine($"Nodo con valor {valor} no encontrado.");
        return null;
    }

    
    public void BorrarNodo(int valor)
    {
        if (inicio == null) 
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        if (inicio.Valor == valor) 
        {
            inicio = inicio.Siguiente; 
            tamaño--;
            Console.WriteLine($"Nodo con valor {valor} eliminado.");
            return;
        }

        Nodo actual = inicio; 
        while (actual.Siguiente != null && actual.Siguiente.Valor != valor)
        {
            actual = actual.Siguiente;
        }

        if (actual.Siguiente != null)
        {
            actual.Siguiente = actual.Siguiente.Siguiente;
            tamaño--;
            Console.WriteLine($"Nodo con valor {valor} eliminado.");
        }
        else
        {
            Console.WriteLine($"Nodo con valor {valor} no encontrado.");
        }
    }

 
    public void ModificarNodo(int valorAntiguo, int valorNuevo)
    {
        Nodo nodo = BuscarNodo(valorAntiguo);
        if (nodo != null)
        {
            nodo.Valor = valorNuevo;
            Console.WriteLine($"Nodo modificado de {valorAntiguo} a {valorNuevo}.");
        }
    }

    
    public bool BuscarValor(int valor)
    {
        Nodo actual = inicio; 
        while (actual != null)
        {
            if (actual.Valor == valor)
            {
                Console.WriteLine($"Valor {valor} encontrado.");
                return true;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine($"Valor {valor} no encontrado.");
        return false;
    }

    
    public void ImprimirLista()
    {
        if (inicio == null) 
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = inicio; 
        Console.WriteLine("Elementos de la lista:");
        while (actual != null)
        {
            Console.Write(actual.Valor + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();
        int opcion;
        do
        {
            Console.WriteLine("\nMENU LISTAS");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1.- Insertar Nodo");
            Console.WriteLine("2.- Imprimir Tamaño");
            Console.WriteLine("3.- Buscar Nodo");
            Console.WriteLine("4.- Borrar Nodo");
            Console.WriteLine("5.- Modificar Nodo");
            Console.WriteLine("6.- Buscar Valor");
            Console.WriteLine("7.- Imprimir Lista");
            Console.WriteLine("8.- Salir");
            Console.WriteLine("---------------------------------");
            Console.Write("Seleccionar Opción => ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese valor a insertar: ");
                    int valorInsertar = int.Parse(Console.ReadLine());
                    lista.InsertarNodo(valorInsertar);
                    break;
                case 2:
                    lista.ImprimirTamaño();
                    break;
                case 3:
                    Console.Write("Ingrese valor a buscar: ");
                    int valorBuscar = int.Parse(Console.ReadLine());
                    lista.BuscarNodo(valorBuscar);
                    break;
                case 4:
                    Console.Write("Ingrese valor a eliminar: ");
                    int valorEliminar = int.Parse(Console.ReadLine());
                    lista.BorrarNodo(valorEliminar);
                    break;
                case 5:
                    Console.Write("Ingrese valor del nodo a modificar: ");
                    int valorAntiguo = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese nuevo valor: ");
                    int valorNuevo = int.Parse(Console.ReadLine());
                    lista.ModificarNodo(valorAntiguo, valorNuevo);
                    break;
                case 6:
                    Console.Write("Ingrese valor a buscar: ");
                    int valorBuscarValor = int.Parse(Console.ReadLine());
                    lista.BuscarValor(valorBuscarValor);
                    break;
                case 7:
                    lista.ImprimirLista();
                    break;
                case 8:
                    Console.WriteLine("Saliendo del programa.");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 8);
    }
}
