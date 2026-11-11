// DisneyjitsuStore
// datos de la caja
int pedidosQueSeHanRealizado = 0;
double totalRecaudado = 0;
double ventaMasCara = 0;
string clienteVentaMasCara = "";


bool tiendaAbierta = true;
// menu

while (tiendaAbierta == true)
{

    Console.WriteLine();
    Console.WriteLine("========================================");
    Console.WriteLine("             DisneyjitsuStore");
    Console.WriteLine("========================================");
    Console.WriteLine("1. Nueva venta");
    Console.WriteLine("2. Consultar la caja de la tienda");
    Console.WriteLine("3. Salir");
    Console.Write("Selecciona una opción: ");
    int opcionMenu = int.Parse(Console.ReadLine()!);

    if (opcionMenu == 1)
    {
        //el producto
        Console.WriteLine(" ");
        Console.WriteLine("¿Qué se lleva?");
        Console.WriteLine("1 Kimono (gi) - 85 €");
        Console.WriteLine("2 Rashguard - 35€");
        Console.WriteLine("3 Shorts no-gi - 30€");
        Console.WriteLine("Selecciona una opción: ");
        int opcionProducto = int.Parse(Console.ReadLine()!);

        //si no es un numero de los que aparece, te lo vuelve a pedir
        while (opcionProducto < 1 || opcionProducto > 3)
        {
            Console.WriteLine("Opción no válida, elige de 1 a 3: ");
            opcionProducto = int.Parse(Console.ReadLine()!);
        }
    }
    string producto;
    double precioProducto;
    //se guarda el precio y el nombre según lo que elija
    if (opcionProducto == 1)
    {
        producto = "Kimono(gi)";
        precioProducto = 85;
    }
    else if (opcionProducto == 2)
    {
        producto = "Rasguard";
        precioProducto = 35;
    }
    else
    {
        producto = "Shorts no-gi";
        precioProducto = 30;
    }

    // la talla, no pueide estar vacía
    Console.Write("Escribe la talla que desees | Talla A0 = XS | A1 = S | A2 = M | A3 = L | A4 = XL | A5 = XXL")
string talla = Console.ReadLine() ?? "";

    while (talla.Trim() == "")
    {
        Console.Write("La talla es obligatorio, escríbela otra vez: ");
        talla = Console.ReadLine() ?? "";
    }
}