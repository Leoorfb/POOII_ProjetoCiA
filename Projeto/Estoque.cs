using System;


namespace Projeto
{
    public class Estoque
    {
        public int id;
        public int lojaId;

        public Estoque()
        {
            Console.WriteLine("Id do Estoque:");
            this.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Id da Loja:");
            this.lojaId = Convert.ToInt32(Console.ReadLine());
        }

        public Estoque(string ID, string IDLOJA)
        {
            this.id = Convert.ToInt32(ID);
            this.lojaId = Convert.ToInt32(IDLOJA);
        }
    }
}