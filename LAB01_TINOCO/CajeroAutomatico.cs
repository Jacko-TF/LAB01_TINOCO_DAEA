using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB01_TINOCO
{
    public class CajeroAutomatico:CuentaBancaria
    {
        public int intentosFallidos = 0;

        public CajeroAutomatico(string titularCuenta, string numeroCuenta, int pinSeguridad, double saldoCuenta = 0)
        {
            this.titularCuenta = titularCuenta;
            this.numeroCuenta = numeroCuenta;
            this.saldoCuenta = saldoCuenta;
            this.pinSeguridad = pinSeguridad;

        }
        public bool login(string numeroCuenta, int pin)
        {
            if(numeroCuenta == this.numeroCuenta &&  pin == this.pinSeguridad)
            {
                intentosFallidos = 0;
                return true;
            }
            else
            {
                this.intentosFallidos++;
                return false;
            }
        }
        public void consultarSaldo()
        {
            Console.WriteLine("El saldo de su cuenta es: "+this.saldoCuenta);
        }

        public void depositarFondos()
        {
            Console.WriteLine("Ingrese la cantidad a depositar");
            double fondos = double.Parse(Console.ReadLine());
            this.saldoCuenta += fondos;
            Console.WriteLine("El nuevo saldo de su cuenta es: " + this.saldoCuenta);
        }

        public void retirarEfecivo()
        {
            Console.WriteLine("Ingrese la cantidad a retirar");
            double retiro = double.Parse(Console.ReadLine());
            if (this.saldoCuenta < retiro)
            {
                Console.WriteLine("Saldo de cuenta insuficiente");
            }
            else
            {
                this.saldoCuenta -= retiro;
                Console.WriteLine("El nuevo saldo de su cuenta es: " + this.saldoCuenta);
            }
        }

        public void cambiarPin()
        {
            Console.WriteLine("Ingrese su Pin actual");
            int p = int.Parse(Console.ReadLine());

            if(p != this.pinSeguridad)
            {
                if(this.intentosFallidos >= 3)
                {
                    this.intentosFallidos += 1;
                    Console.WriteLine("Pin de seguridad Incorrecto");
                    cambiarPin();
                }
                else
                {
                    Console.WriteLine("Demasiados intentos fallidos");
                }

            }
            else
            {
                this.intentosFallidos = 0;
                Console.WriteLine("Ingrese su nuevo Pin");
                int np = int.Parse(Console.ReadLine());
                if(np == this.pinSeguridad)
                {
                    Console.WriteLine("El nuevo pin no puede ser igual que el anterior");
                }
                else
                {
                    this.pinSeguridad = np;
                    Console.WriteLine("Pin modificado correctamente");
                }
            }

        }
    }
}
