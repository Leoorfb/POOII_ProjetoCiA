using System;
using System.Globalization;

namespace Projeto
{
    public class ProdutoEmEstoque
    {
        public int prodId;
        public int estqId;
        public float quantidade;

        public ProdutoEmEstoque()
        {
            Console.WriteLine("Id do Estoque:");
            this.estqId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Id do Produto:");
            this.prodId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quantidade do Produto:");
            this.quantidade = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);
        }

        public ProdutoEmEstoque(string PRODID, string ESTQID, string QNTD)
        {
            /*Console.WriteLine(PRODID);
            Console.WriteLine(ESTQID);
            Console.WriteLine(QNTD);
            Console.WriteLine(UND);*/
            this.prodId = Convert.ToInt32(PRODID);
            this.estqId = Convert.ToInt32(ESTQID);
            this.quantidade = float.Parse(QNTD.Replace(",", "."), CultureInfo.InvariantCulture.NumberFormat);
        }
    }
}