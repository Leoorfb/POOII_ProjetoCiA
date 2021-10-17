using System;


namespace Projeto
{
    public class Loja
    {
        public int id;
        public string nome;
        public string local;

        public Loja(){
            Console.WriteLine("Id da Loja:");
            this.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nome da Loja:");
            this.nome = Console.ReadLine();
            Console.WriteLine("Local da Loja:");
            this.local = Console.ReadLine();
        }

        public Loja(string ID, string NOME, string LOCAL){
            this.id = Convert.ToInt32(ID);
            this.nome = NOME;
            this.local = LOCAL;
        }
    }
}