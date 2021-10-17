using System;
//using System.Collections.Generic;

namespace Projeto
{
    public class Venda
    {
        public int id;
        public int lojaId;

        public Venda()
        {
            Console.WriteLine("Id da Venda:");
            this.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Id da Loja:");
            this.lojaId = Convert.ToInt32(Console.ReadLine());
        }

        public Venda(string VENDAID, string LOJAID)
        {
            this.id = Convert.ToInt32(VENDAID);
            this.lojaId = Convert.ToInt32(LOJAID);
        }
    }
}