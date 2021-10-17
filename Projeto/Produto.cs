using System;
using System.Globalization;

namespace Projeto
{
    public class Produto
    {
        public int id;
        public string nome;
        public string marca;
        public float valor;

        public Produto(){
            Console.WriteLine("Id do Produto:");
            this.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nome do Produto:");
            this.nome = Console.ReadLine();
            Console.WriteLine("Marca do Produto:");
            this.marca = Console.ReadLine();
            Console.WriteLine("Valor do Produto:");
            this.valor = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);
        }

        public Produto(string ID, string NOME, string MARCA, string VALOR){
            this.id = Convert.ToInt32(ID);
            this.nome = NOME;
            this.marca = MARCA;
            this.valor = float.Parse(VALOR.Replace(",", "."), CultureInfo.InvariantCulture.NumberFormat);
        }

    }
}