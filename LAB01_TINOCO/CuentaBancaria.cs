using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB01_TINOCO
{
    public class CuentaBancaria
    {
        protected string numeroCuenta { get; set; }
        protected string titularCuenta { get; set; }
        protected double saldoCuenta { get; set; }
        protected int pinSeguridad { get; set;}
    }
}
