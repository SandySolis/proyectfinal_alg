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
        static List<Almacen> Almacenes = new List<Almacen>();
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
                case 2:
                    GestionarAlmacenes();
                    break;
                case 3: AgregarYExtraerProductos(); break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    Console.ReadKey();
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
                    MostrarInventario();
                    break;
                case 5:
                    MostrarMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    Console.ReadKey();
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

        //Parte 2
        static void MostrarInventario()
        {
            Console.Clear();
            Console.WriteLine("Inventario actual: \n" +
                "-----------------------------------------------------------");

            for (int i = 0; i < inventario.Count; i++)
            {
                Console.WriteLine($"Producto {i + 1}: Nombre: {inventario[i].Nombre} \t- Precio:  $ {inventario[i].Precio} \t- Cantidad:  {inventario[i].Cantidad}");
            }
            Console.ReadLine();
            GestionarProductos();
        }

        
        static void GestionarAlmacenes()
        {
            Console.Clear();
            Console.Write("--------------------------------------------------\n" +
                "|| Gestionar Almacenes - Mi Tiendita ||\n" +
                "--------------------------------------------------\n" +
                "|| 1. Agregar Almacén            ||\n" +
                "|| 2. Eliminar Almacén           ||\n" +
                "|| 3. Mostrar Almacenes          ||\n" +
                "|| 4. Volver al Menú Principal   ||\n" +
                "--------------------------------------------------\n" +
                "Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarAlmacen();
                    break;
                case 2:
                    EliminarAlmacen();
                    break;
                case 3:
                    MostrarAlmacen();
                    break;
                case 4:
                    MostrarMenuPrincipal();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    Console.ReadKey();
                    GestionarAlmacenes();
                    break;
            }
        }
        static void AgregarAlmacen()
        {
            Console.Clear();
            Console.Write("===== Pantalla para Agregar Almacén =====\n" +
                "--------------------------------------------------\n" +
                "Ingrese el nombre del nuevo almacén:\n");
            string nombre = Console.ReadLine();
            Almacen nuevoAlmacen = new Almacen(nombre);

            Almacenes.Add(nuevoAlmacen);
            Console.Write("--------------------------------------------------\n" +
            "Confirmación: Almacén agregado exitosamente. ");
            Console.ReadLine();
            GestionarAlmacenes();
        }
        //Parte 3

        static void EliminarAlmacen()
        {
            Console.Clear();
            Console.Write("===== Pantalla para Eliminar Almacen =====\n" +
                "------------------------------------------------------\n" +
                "Ingrese el nombre del almacen a eliminar: \n");

            string nombreAlmacenEliminar = Console.ReadLine();
            Almacen almacenAEliminar = Almacenes.Find(almacen => almacen.Nombre == nombreAlmacenEliminar);

            if (almacenAEliminar != null)
            {
                Almacenes.Remove(almacenAEliminar);
                Console.Write("-------------------------------------------------\n" +
                    "Confirmacion: Almacen eliminado exitosamente.");
            }
            Console.ReadLine();
            GestionarAlmacenes();
        }

        static void MostrarAlmacen()
        {
            Console.Clear();
            Console.WriteLine("===== Pantalla para Mostrar Almacenes =====\n" +
                "Lista de Almacenes: ");

            for (int i = 0; i < Almacenes.Count; i++)
            {
                Console.WriteLine($"Almacen {i + 1}: {Almacenes[i].Nombre}");
            }
            Console.ReadLine();
            GestionarAlmacenes();
        }
        static void AgregarYExtraerProductos()
        {
            Console.Clear();
            Console.Write("" +
                "--------------------------------------------------------\n" +
                "| |   Agregar y Extraer Productos  - Mi Tiendita     | |\n" +
                "--------------------------------------------------------\n" +
                "| | 1. Ingresar Producto en Almacen                  | |\n" +
                "| | 2. Extraer Producto de Almacen                   | |\n" +
                "| | 3. Ver Stock Actual                              | |\n" +
                "| | 4. Volver al Menu Principal                      | |\n" +
                "--------------------------------------------------------\n" +
                "Seleccione una opcion: ");
        }



    }
    class Almacen
    {
        public string Nombre { get; }

        public Almacen(string nombre)
        {
            Nombre = nombre;
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
}