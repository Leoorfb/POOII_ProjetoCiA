using System;

namespace Projeto
{
    public class ProdutoVendido
    {
        public int vendaId;
        public int estoqueId;
        public int produtoId;
        public int quantidade;

        public ProdutoVendido()
        {
            Console.WriteLine("Id da Venda:");
            this.vendaId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Id do Estoque:");
            this.estoqueId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Id do produto:");
            this.produtoId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quantidade:");
            this.quantidade = Convert.ToInt32(Console.ReadLine());
        }

        public ProdutoVendido(int VENDAID)
        {
            this.vendaId = VENDAID;
            Console.WriteLine("Id do Estoque:");
            this.estoqueId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Id do produto:");
            this.produtoId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quantidade:");
            this.quantidade = Convert.ToInt32(Console.ReadLine());
        }

        public ProdutoVendido(string VENDAID, string ESTQID, string PRODID, string QNTD)
        {
            this.vendaId = Convert.ToInt32(VENDAID);
            this.estoqueId = Convert.ToInt32(ESTQID);
            this.produtoId = Convert.ToInt32(PRODID);
            this.quantidade = Convert.ToInt32(QNTD);
        }
        }
}
