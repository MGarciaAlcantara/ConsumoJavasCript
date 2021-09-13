using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero=2;
            bool primo;
            int tot=1;
                
            while(tot<=100) 
            {
                primo=true;

               for (int i = 2; i < numero; i++) {
                if(numero % i == 0)
                {
                    primo = false;
                    break;                
                }
                   
            }
               if (primo == true)
               {

                   Console.WriteLine("Numero Primo: " + numero);
               }

               numero++;
                tot++;
             }

            Console.ReadKey();
           
        } 
    }
    }



