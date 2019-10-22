using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoLavoratori2
{
    public class Insert : Lavoratori
    {
        public static int Numero()
        {
            try
            {
                int b = Int32.Parse(Console.ReadLine());
                return b;
            }
            catch (Exception)
            {
                Console.WriteLine("WARNING, YOU HAVE WRITTEN AN INCORRECT NUMBER!" +
                    "\nDIGIT '1' TO INSERT A INDIPENDENT WORKER " +
                    "OTHERWISE DIGIT ANOTHER NUMBER TO INSERT AN EMPLOYEE");
                Console.ReadLine();
            }
            return 1;
        }

    }
}
