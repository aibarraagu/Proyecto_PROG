// DisneyjitsuStore
// datos de la caja
using System.Security.Cryptography;

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

    //extras, cada uno tiene un bool para que si intentas volver a cobrarlo no puedas si ya lo has hecho
    bool parche = false;
    bool cinturon = false;

    int numExtras = 0;
    double precioExtras = 0;
    int opcionExtra = -1;

    // se repite hasta que se pulsa 0
    while (opcionExtra != 0)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Extras (llevas " + numExtras + ", provisional " + (precioProducto + precioExtras).ToString("F2") + " euros)");
        Console.WriteLine("1 Parche bordado - 8 €");
        Console.WriteLine("2 Cinturón a juego - 12 €");
        Console.WriteLine("3 Kit antihongos - 9 €");
        Console.WriteLine("0 Ya está, no quiero más");
        Console.WriteLine("Selecciona una opción: ");
        opcionExtra = int.Parse(Console.ReadLine()!);
    }
    if (opcionExtra == 1)
    {
        //si ya lo tiene, se avisa y no se suma
        if (parche == true)
        {
            Console.WriteLine("El parche ya está en tu pedido.");
        }
        else
        {
            parche = true; precioExtras = precioExtras + 8;
            numExtras++;
        }
    }
    else if (opcionExtra == 2)
    {
        if (cinturon == true)
        {
            Console.WriteLine("El cinturón ya está en tu pedido.");
        }
        else
        {
            cinturon = true;
            precioExtras = precioExtras + 12;
            numExtras++;
        }
    }
    else if (opcionExtra == 3)
    {
        if (kitAntiHongos)
        {
            Console.WriteLine("El kit ya está en tu pedido.");
        }
        else
        {
            kitAntiHongos = true;
            precioExtras = precioExtras + 9;
            numExtras++;
        }
    }
    else if (opcionExtra != 0)
    {
        //si el numero es fuera de rango
        Console.WriteLine("Opción inválida");
    }
    //parte de la entrega, tienda o por envio
    Console.WriteLine(" ");
    Console.WriteLine("¿Cómo quieres adquirirlo?");
    Console.WriteLine("1 En la tienda - gratis");
    Console.WriteLine("2 Envío a casa - 6 €");
    Console.WriteLine("2 Envío a casa - 6 €");
    Console.WriteLine("Selecciona una opción: ");
    int opcionEntrega =int.Parse(Console.ReadLine()!);

    while (opcionEntrega <1 || opcionEntrega >2)
    {
        Console.Write("Elge 1 o 2: ");
        opcionEntrega = int.Parse(Console.ReadLine()!);
    }
string entrega = "Recogida en tienda";
string direccion = "";
double costeEnvio=0;

// la direccion solamente se pide si se elige el envio, si no hay envio logicamente no se pide 
if (opcionEntrega==2)
    {
        entrega="Envío a casa";
        costeEnvio=6;
        Console.Write("Direccion de envío: ");
        direccion = Console.ReadLine()??"";
        while (direccion.Trim() == "")
        {
            Console.Write("Falta la dirección, escríbela otra vez: ;
            direccion = Console.ReadLine()?? "");
        }
    }




}