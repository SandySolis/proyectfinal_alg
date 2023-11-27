using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1_proyectfinal
{
   class Program
{
    static List<Producto> inventario = new List<Producto>();

    static void Main()
    {
        MostrarMenuPrincipal();
    }

    static void MostrarMenuPrincipal()
    {
        Console.Clear();
        Console.Write("" +
                        "==================================================\n" +
                        "||                                               ||\n" +
                        "||    Sistema de Inventario \"Mi Tiendita\"        ||\n" +
                        "||                                               ||\n" +
                        "==================================================\n" +
                        "|| 1. Gestionar Productos                        ||\n" +
                        "|| 2. Gestionar Almacenes                        ||\n" +
                        "|| 3. Agregar y Extraer Productos                ||\n" +
                        "==================================================\n" +
                        "Seleccione una opción y presione Enter: ");

        int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                GestionarProductos();
                break;
            // Puedes agregar casos para gestionar almacenes y operaciones de productos aquí
            default:
                Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                MostrarMenuPrincipal();
                break;
        }
    }

    static void GestionarProductos()
    {
        Console.Clear();
        Console.Write("" +
                        "--------------------------------------------------\n" +                    
                        "||   Gestionar Productos - Mi Tiendita          ||\n" +
                        "--------------------------------------------------\n" +
                        "|| 1. Agregar Producto                          ||\n" +
                        "|| 2. Eliminar Producto                         ||\n" +
                        "|| 3. Modificar Producto                        ||\n" +
                        "|| 4. Mostrar Inventario                        ||\n" +
                        "|| 5. Volver al Menú Principal                  ||\n" +
                        "--------------------------------------------------\n" +
                        "Seleccione una opción: ");

    int opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
            case 1:
                AgregarProducto();
                break;
            case 2:
                EliminarProducto();
                break;
            case 3:
                ModificarProducto();
                break;
            case 4:
                MostrarMenuPrincipal();
                break;
            default:
                Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                GestionarProductos();
                break;
        }
    }

    static void AgregarProducto()
    {
        Console.Clear();
        Console.WriteLine("===== Pantalla para Agregar Producto =====");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Ingrese el nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.WriteLine("Ingrese el precio del producto: ");
        decimal precio = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Ingrese la cantidad del producto: ");
        int cantidad = Convert.ToInt32(Console.ReadLine());

        Producto nuevoProducto = new Producto(nombre, precio, cantidad);
        inventario.Add(nuevoProducto);
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Confirmación: Producto agregado exitosamente.");
        Console.ReadLine();
        GestionarProductos();
    }

    static void EliminarProducto()
    {
        Console.Clear();
        Console.WriteLine("===== Pantalla para Eliminar Producto =====");
        Console.WriteLine("Ingrese el nombre del producto a eliminar: ");
        string nombre = Console.ReadLine();

        Producto productoAEliminar = inventario.Find(p => p.Nombre == nombre);

        if (productoAEliminar != null)
        {
            inventario.Remove(productoAEliminar);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Confirmación: Producto eliminado exitosamente.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Producto no encontrado. Inténtelo de nuevo.");
        }

        GestionarProductos();
    }

    static void ModificarProducto()
    {
        Console.Clear();
        Console.WriteLine("===== Pantalla para Modificar Producto =====");
        Console.WriteLine("Ingrese el nombre del producto a modificar: ");
        string nombre = Console.ReadLine();

        Producto productoAModificar = inventario.Find(p => p.Nombre == nombre);

        if (productoAModificar != null)
        {
            Console.WriteLine("Ingrese el nuevo precio: ");
            decimal nuevoPrecio = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Ingrese la nueva cantidad: ");
            int nuevaCantidad = Convert.ToInt32(Console.ReadLine());

            productoAModificar.Precio = nuevoPrecio;
            productoAModificar.Cantidad = nuevaCantidad;

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Confirmación: Producto modificado exitosamente.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Producto no encontrado. Inténtelo de nuevo.");
        }

        GestionarProductos();
    }

}

class Producto
{
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(string nombre, decimal precio, int cantidad)
    {
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }
}
