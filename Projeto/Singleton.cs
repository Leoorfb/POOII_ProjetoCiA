using System;
using System.Collections.Generic;
using System.IO;

namespace Projeto
{
    public class Singleton
    {
        private string arquivoProduto;
        private string arquivoLoja;
        private string arquivoEstoque;
        private string arquivoProdutoEmEstoque;
        private string arquivoVenda;
        private string arquivoProdutoVendido;

        private static Singleton instancia;
        private Singleton()
        {
            this.arquivoEstoque = "estoques.txt";
            this.arquivoLoja = "lojas.txt";
            this.arquivoProduto = "produtos.txt";
            this.arquivoProdutoEmEstoque = "produtosEmEstoque.txt";
            this.arquivoVenda = "venda.txt";
            this.arquivoProdutoVendido = "produtosVendido.txt";
        }

        public static Singleton getInstancia()
        {
            if(instancia is null)
            {
                instancia = new Singleton();
            }
            return instancia;
        }

        public bool Gravar(Produto p)
        {
            StreamWriter sw = new StreamWriter(this.arquivoProduto, true);

            sw.WriteLine(string.Format("Id: {0}\nNome: {1}\nMarca: {2}\nValor: {3}", p.id, p.nome, p.marca, p.valor));
            sw.Close();
            return true;
        }

        public bool Gravar(Loja l)
        {
            StreamWriter sw = new StreamWriter(this.arquivoLoja, true);

            sw.WriteLine(string.Format("Id: {0}\nNome: {1}\nLocal: {2}", l.id, l.nome, l.local));
            sw.Close();
            return true;
        }

        public bool Gravar(Estoque e)
        {
            StreamWriter sw = new StreamWriter(this.arquivoEstoque, true);

            sw.WriteLine(string.Format("Id: {0}\nLojaId: {1}", e.id, e.lojaId));
            sw.Close();
            return true;
        }

        public bool Gravar(ProdutoEmEstoque pe, bool sobreescrever = true)
        {
            StreamWriter sw = new StreamWriter(this.arquivoProdutoEmEstoque, sobreescrever);

            sw.WriteLine(string.Format("ProdId: {0}\nEstqId: {1}\nQuantidade: {2}", pe.prodId, pe.estqId, pe.quantidade));
            sw.Close();
            return true;
        }

        public bool Gravar(Venda v)
        {
            StreamWriter sw = new StreamWriter(this.arquivoVenda, true);

            sw.WriteLine(string.Format("Id: {0}\nLojaId: {1}", v.id, v.lojaId));
            sw.Close();
            return true;
        }

        public bool Gravar(ProdutoVendido pv)
        {
            StreamWriter sw = new StreamWriter(this.arquivoProdutoVendido, true);

            sw.WriteLine(string.Format("VendaId: {0}\nEstqId: {1}\nProdId: {2}\nQuantidade: {3}", pv.vendaId, pv.estoqueId, pv.produtoId, pv.quantidade));
            sw.Close();
            return true;
        }


        public bool Atualizar(List<ProdutoEmEstoque> ProdutosEmEstoque)
        {
            bool sobreescreveu = false;
            foreach (ProdutoEmEstoque prodE in ProdutosEmEstoque)
            {
                this.Gravar(prodE, sobreescreveu);
                sobreescreveu = true;
            }
            return true;
        }

        public List<Produto> LerProdutos()
        {
            List<Produto> listaProduto = new List<Produto>();

            if(File.Exists(this.arquivoProduto)){

                StreamReader sr = new StreamReader(this.arquivoProduto);
                
                List<string> prod = new List<string>();
                while (!sr.EndOfStream)
                {
                    string linha = sr.ReadLine();
                    char[] MyChar = {'I', 'd','N','o','m', 'e','M','a','r', 'c','V','l','L',':' };
                    prod.Add(linha.TrimStart(MyChar).TrimStart(' '));
                    
                    
                    if(prod.Count >= 4)
                    {
                        listaProduto.Add(new Produto(prod[0], prod[1], prod[2], prod[3]));

                        prod.Clear();
                    }
                }
                
                sr.Close();
            }

            return listaProduto;
        }

        public List<Loja> LerLojas()
        {   
            List<Loja> listaLoja = new List<Loja>();
            if(File.Exists(this.arquivoLoja)){

                StreamReader sr = new StreamReader(this.arquivoLoja);
                

                List<string> loj = new List<string>();
                while (!sr.EndOfStream)
                {
                    string linha = sr.ReadLine();
                    char[] MyChar = {'I', 'd','N','o','m', 'e','M','a','r', 'c','V','l','L',':' };
                    loj.Add(linha.TrimStart(MyChar).TrimStart(' '));
                    
                    
                    if(loj.Count >= 3)
                    {
                        listaLoja.Add(new Loja(loj[0], loj[1], loj[2]));

                        loj.Clear();
                    }
                }
                
                sr.Close();
            }
            return listaLoja;
        }

        public List<Estoque> LerEstoques()
        {   
            List<Estoque> listaEstoque = new List<Estoque>();
            if(File.Exists(this.arquivoEstoque)){

                StreamReader sr = new StreamReader(this.arquivoEstoque);
                

                List<string> estq = new List<string>();
                while (!sr.EndOfStream)
                {
                    string linha = sr.ReadLine();
                    char[] MyChar = {'I', 'd','N','o','m', 'e','M','a','r', 'c','V','l','L','j',':' };
                    estq.Add(linha.TrimStart(MyChar).TrimStart(' '));
                    
                    
                    if(estq.Count >= 2)
                    {
                        listaEstoque.Add(new Estoque(estq[0], estq[1]));

                        estq.Clear();
                    }
                }
                
                sr.Close();
            }
            return listaEstoque;
        }

        public List<ProdutoEmEstoque> LerProdutosEmEstoque()
        {
            List<ProdutoEmEstoque> listaProdutoEmEstoque = new List<ProdutoEmEstoque>();

            if(File.Exists(this.arquivoProdutoEmEstoque)){

                StreamReader sr = new StreamReader(this.arquivoProdutoEmEstoque);
                
                List<string> prodE = new List<string>();
                while (!sr.EndOfStream)
                {
                    string linha = sr.ReadLine();
                    char[] MyChar = {'I', 'd','N','o','m', 'e','M','a','r', 'c','V','l','L','U','u','t','P','Q','E','s','n','i','q',':' };
                    prodE.Add(linha.TrimStart(MyChar).TrimStart(' '));
                    
                    
                    if(prodE.Count >= 3)
                    {
                        listaProdutoEmEstoque.Add(new ProdutoEmEstoque(prodE[0], prodE[1], prodE[2]));

                        prodE.Clear();
                    }
                }
                
                sr.Close();
            }

            return listaProdutoEmEstoque;
        }

        public List<Venda> LerVendas()
        {
            List<Venda> listaVenda = new List<Venda>();

            if(File.Exists(this.arquivoVenda)){

                StreamReader sr = new StreamReader(this.arquivoVenda);
                
                List<string> vend = new List<string>();
                while (!sr.EndOfStream)
                {
                    string linha = sr.ReadLine();
                    char[] MyChar = {'I', 'd','N','o','m', 'e','M','a','r', 'c','V','l','L','U','u','t','P','Q','E','s','n','i','q','j',':' };
                    vend.Add(linha.TrimStart(MyChar).TrimStart(' '));
                    
                    
                    if(vend.Count >= 2)
                    {
                        /*Console.WriteLine(vend[0]);
                        Console.WriteLine(vend[1]);*/
                        listaVenda.Add(new Venda(vend[0], vend[1]));

                        vend.Clear();
                    }
                }
                
                sr.Close();
            }

            return listaVenda;
        }

        public List<ProdutoVendido> LerProdutosVendidos()
        {
            List<ProdutoVendido> listaProdutoVendido = new List<ProdutoVendido>();

            if(File.Exists(this.arquivoProdutoVendido)){

                StreamReader sr = new StreamReader(this.arquivoProdutoVendido);
                
                List<string> prodV = new List<string>();
                while (!sr.EndOfStream)
                {
                    string linha = sr.ReadLine();
                    char[] MyChar = {'I', 'd','N','o','m', 'e','M','a','r', 'c','V','l','L','U','u','t','P','Q','E','s','n','i','q',':' };
                    prodV.Add(linha.TrimStart(MyChar).TrimStart(' '));
                    
                    
                    if(prodV.Count >= 4)
                    {
                        listaProdutoVendido.Add(new ProdutoVendido(prodV[0], prodV[1], prodV[2], prodV[3]));

                        prodV.Clear();
                    }
                }
                
                sr.Close();
            }

            return listaProdutoVendido;
        }

        public List<Produto> DeleteProdutos(){
            File.Delete(arquivoProduto);
            return new List<Produto>();
        }

        public List<Loja> DeleteLojas(){
            File.Delete(arquivoLoja);
            return new List<Loja>();
        }

        public List<Estoque> DeleteEstoques(){
            File.Delete(arquivoEstoque);
            return new List<Estoque>();
        }

        public List<ProdutoEmEstoque> DeleteProdutosEmEstoque(){
            File.Delete(arquivoProdutoEmEstoque);
            return new List<ProdutoEmEstoque>();
        }

        public List<Venda> DeleteVendas(){
            File.Delete(arquivoVenda);
            return new List<Venda>();
        }

        public List<ProdutoVendido> DeleteProdutosVendido(){
            File.Delete(arquivoProdutoVendido);
            return new List<ProdutoVendido>();
        }

    }
}