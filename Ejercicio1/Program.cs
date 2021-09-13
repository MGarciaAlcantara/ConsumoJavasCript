using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
           int numero = 15;
           string binario="";
           int valor;

           while (numero > 0)
           {
               valor = numero % 2;
               numero = numero / 2;
               binario = valor.ToString() + binario;                  
           }

           Console.WriteLine(binario);
           Console.ReadKey();


        }

      
    }
}
