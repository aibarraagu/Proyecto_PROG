// DisneyjitsuStore
int pedidosQueSeHanRealizado = 0;
double totalRecaudado = 0;

int opcionMenu = 0;

// menu

do
{
    Console.WriteLine();
    Console.WriteLine("========================================");
    Console.WriteLine("             DisneyjitsuStore");
    Console.WriteLine("========================================");
    Console.WriteLine("1. Nueva venta");
    Console.WriteLine("2. Consultar la caja de la tienda");
    Console.WriteLine("3. Salir");
    Console.Write("Selecciona una opción: ");
    opcionMenu = int.Parse(Console.ReadLine()!);
}

if  