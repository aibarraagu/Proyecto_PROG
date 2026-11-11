// DisneyjitsuStore
// datos de la caja


int pedidosQueSeHanRealizado = 0;
double totalRecaudado = 0;
double ventaMasCara = 0;
string clienteVentaMasCara = "";


bool tiendaAbierta = true;
// el menu principal

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
            producto = "Rashguard";
            precioProducto = 35;
        }
        else
        {
            producto = "Shorts no-gi";
            precioProducto = 30;
        }

        // la talla, no pueide estar vacía
        Console.Write("Escribe la talla que desees | Talla A0 = XS | A1 = S | A2 = M | A3 = L | A4 = XL | A5 = XXL");
        string talla = Console.ReadLine() ?? "";

        while (talla.Trim() == "")
        {
            Console.Write("La talla es obligatoria, escríbela otra vez: ");
            talla = Console.ReadLine() ?? "";
        }

        //extras, cada uno tiene un bool para que si intentas volver a cobrarlo no puedas si ya lo has hecho
        bool parche = false;
        bool cinturon = false;
        bool kitAntiHongos = false;

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
            Console.Write("Selecciona una opción: ");
            opcionExtra = int.Parse(Console.ReadLine()!);

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
        }
        //parte de la entrega, tienda o por envio
        Console.WriteLine(" ");
        Console.WriteLine("¿Cómo quieres adquirirlo?");
        Console.WriteLine("1 En la tienda - gratis");
        Console.WriteLine("2 Envío a casa - 6 €");
        Console.WriteLine("Selecciona una opción: ");
        int opcionEntrega = int.Parse(Console.ReadLine()!);

        while (opcionEntrega < 1 || opcionEntrega > 2)
        {
            Console.Write("Elge 1 o 2: ");
            opcionEntrega = int.Parse(Console.ReadLine()!);
        }
        string entrega = "Recogida en tienda";
        string direccion = "";
        double costeEnvio = 0;

        // la direccion solamente se pide si se elige el envio, si no hay envio logicamente no se pide 
        if (opcionEntrega == 2)
        {
            entrega = "Envío a casa";
            costeEnvio = 6;
            Console.Write("Direccion de envío: ");
            direccion = Console.ReadLine() ?? "";

            while (direccion.Trim() == "")
            {
                Console.Write("Falta la dirección, escríbela otra vez: ");

                direccion = Console.ReadLine() ?? "";
            }
        }
        // el nombre del cliente que no puede estar vacío y tiene que dar error 
        Console.Write("Nombre del cliente: ");
        string nombreCliente = Console.ReadLine() ?? "";
        while (nombreCliente.Trim() == "")
        {
            Console.Write("El nombre no puede quedar vacío: ");
            nombreCliente = Console.ReadLine() ?? "";
        }

        //el calculo del total 
        //el total es el producto mas los extras menos el descuento más el envío
        // le ponemos un descuento de 5 euros si el producto incluyendo los extras superan los 100 euros sin contar con el envio
        double subtotal = precioProducto + precioExtras;
        double descuento = 0;

        if (subtotal > 100)
        {
            descuento = 5;
        }

        double totalVenta = subtotal - descuento + costeEnvio;

        // esto es para que no salga negativo 
        if (totalVenta < 0)
        {
            totalVenta = 0;
        }

        // este es todod el resumen antes de cobrar al cliente
        Console.WriteLine(" ");
        Console.WriteLine("Producto + extras: " + subtotal.ToString("F2") + " €");
        Console.WriteLine("Descuento: -" + descuento.ToString("F2") + " €");
        Console.WriteLine("Envío: " + costeEnvio.ToString("F2") + " euros");
        Console.WriteLine("A PAGAR: " + totalVenta.ToString("F2") + " €");

        // aqui es por si llega a poner menos dinero de lo que se necesitaría para comprarlo, da error y vuelve a pedir
        Console.Write("Dinero entregado: ");
        double dineroEntregado = double.Parse(Console.ReadLine()!);

        while (dineroEntregado < totalVenta)
        {
            Console.Write("No es el dinero suficiente. Introduce de nuevo el dinero entregado: ");
            dineroEntregado = double.Parse(Console.ReadLine()!);
        }
        double cambio = dineroEntregado - totalVenta;

        // esto para que sea ctualice la caja 
        pedidosQueSeHanRealizado++;
        totalRecaudado = totalRecaudado + totalVenta;

        // con > para que si haya empate se quede con el primero
        if (totalVenta > ventaMasCara)
        {
            ventaMasCara = totalVenta;
            clienteVentaMasCara = nombreCliente;
        }

        // esto es para hacer el ticket 
        Console.WriteLine(" ");
        Console.WriteLine("=========== TICKET DISNEYJITSUSTORE ===========");
        Console.WriteLine("pedido nº " + pedidosQueSeHanRealizado + " - " + nombreCliente);
        Console.WriteLine(producto + ", talla " + talla);

        if (numExtras == 0)
        {
            Console.WriteLine("Sin extras");
        }
        else
        {
            Console.WriteLine("Extras:");
        }
        if (parche == true)
        {
            Console.WriteLine(" + parche bordado");
        }
        if (cinturon == true)
        {
            Console.WriteLine(" + Cinturón a juego");
        }
        if (kitAntiHongos == true)
        {
            Console.WriteLine(" + Kit antihongos");
        }


        Console.WriteLine(entrega);
        if (opcionEntrega == 2)
        {
            Console.WriteLine("Dirección: " + direccion);
        }

        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("Producto: " + precioProducto.ToString("F2"));
        Console.WriteLine("Extras: " + precioExtras.ToString("F2"));
        Console.WriteLine("Descuento: -" + descuento.ToString("F2"));
        Console.WriteLine("Envío: " + costeEnvio.ToString("F2"));
        Console.WriteLine("TOTAL: " + totalVenta.ToString("F2"));
        Console.WriteLine("Entregado: " + dineroEntregado.ToString("F2"));
        Console.WriteLine("Cambio: " + cambio.ToString("F2"));
        Console.WriteLine("===============================================");
    }
    else if (opcionMenu == 2)
    {
        //esto para mostrar la caja
        Console.WriteLine(" ");
        Console.WriteLine("---CAJA---");

        //si no hay ninguna venta no se divide porque daría error
        if (pedidosQueSeHanRealizado == 0)
        {
            Console.WriteLine("Aún no hay ventas cobradas");
        }
        else
        {
            double media = totalRecaudado / pedidosQueSeHanRealizado;
            Console.WriteLine("Ventas: " + pedidosQueSeHanRealizado);
            Console.WriteLine("Recaudado: " + totalRecaudado.ToString("F2") + " €");
            Console.WriteLine("Media por venta: " + media.ToString("F2") + " €");
            Console.WriteLine("Venta más cara: " + ventaMasCara.ToString("F2") + " € (" + clienteVentaMasCara + ")");
        }
    }
    else if (opcionMenu == 3)
    {
        // la opcion de salir para que cuando la pulses ponga un mensaje de despedida
        Console.WriteLine(" ");
        Console.WriteLine("Cerramos por hoy. Ventas: " + pedidosQueSeHanRealizado
            + " | Ingresos: " + totalRecaudado.ToString("F2") + " €");
        Console.WriteLine("¡Hasta la próxima, oss!");
        tiendaAbierta = false;
    }

    else
    {
        // opcion incorrecta
        Console.WriteLine("Opción incorrecta, elige 1, 2 o 3.");
    }
}








