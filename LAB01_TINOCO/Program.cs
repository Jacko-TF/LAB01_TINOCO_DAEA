// See https://aka.ms/new-console-template for more information
using LAB01_TINOCO;

CajeroAutomatico cajeroAutomatico = new CajeroAutomatico(
    "Jacko Tinoco", 
    "123456789", 
    1245, 
    150);

void validacion() {
    try
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Inicio de sesión");
        Console.WriteLine("Ingrese su número de cuenta");
        string numeroCuenta = Console.ReadLine();
        Console.WriteLine("Ingrese su pin de seguridad");
        int pin = int.Parse(Console.ReadLine());
        if (cajeroAutomatico.login(numeroCuenta, pin))
        {
            menuInteractivo();
        }
        else
        {
            if (cajeroAutomatico.intentosFallidos >= 3)
            {
                Console.WriteLine("Demasiados intentos fallidos");
            }
            else
            {
                Console.WriteLine("Credenciales inválidas");
                validacion();
            }
        }
    }
    catch (Exception e) { Console.WriteLine("Error inesperado", e); } 
}

void menuInteractivo()
{
    try
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Bienvenido al menú interactivo");
        Console.WriteLine("Ingrese 1 para consultar su saldo");
        Console.WriteLine("Ingrese 2 para depositar fondos");
        Console.WriteLine("Ingrese 3 para hacer un retiro");
        Console.WriteLine("Ingrese 4 para cambiar su pin");

        int accion = int.Parse(Console.ReadLine());

        switch (accion)
        {
            case 1:
                cajeroAutomatico.consultarSaldo();
                break;
            case 2:
                cajeroAutomatico.depositarFondos();
                break;
            case 3:
                cajeroAutomatico.retirarEfecivo();
                break;
            case 4:
                cajeroAutomatico.cambiarPin();
                break;
            default:
                Console.WriteLine("Transacción inválida");
                break;
        }

        Console.WriteLine("Desea continuar? Y / N");

        string newaccion = Console.ReadLine();

        switch (newaccion)
        {
            case "Y":
                menuInteractivo();
                break;
            default:
                Console.WriteLine("Gracias, hasta luego");
                break;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("Error inesperado", ex);
    }
}

validacion();