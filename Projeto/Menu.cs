using System;
using System.Collections.Generic;

namespace Projeto
{
    class Menu
    {
        static private List<Produto> AddProduto(List<Produto> Produtos){
            Produto novoP = new Produto();
            if(ConfereProduto(Produtos,novoP)){
                Singleton.getInstancia().Gravar(novoP);
                Produtos = Singleton.getInstancia().LerProdutos();
            }
            return Produtos;
        }

        static private List<Loja> AddLoja(List<Loja> Lojas){
            Loja novoL = new Loja();
            if(ConfereLoja(Lojas,novoL)){
                Singleton.getInstancia().Gravar(novoL);
                Lojas = Singleton.getInstancia().LerLojas();
            }
            return Lojas;
        }

        static private List<Estoque> AddEstoque(List<Estoque> Estoques){
            Estoque novoE = new Estoque();
            if(ConfereEstoque(Estoques,novoE)){
                Singleton.getInstancia().Gravar(novoE);
                Estoques = Singleton.getInstancia().LerEstoques();
            }
            return Estoques;
        }

        static public bool ConfereProduto(List<Produto> Produtos, Produto nProd){
            bool valido = true;
            foreach (Produto prod in Produtos)
            {
                if (prod.id == nProd.id) 
                {
                    valido = false;
                    Console.WriteLine("Já existe um Produto com este Id;");
                }
                if (prod.nome == nProd.nome && prod.marca == nProd.marca) 
                {
                    valido = false;
                    Console.WriteLine("Já existe um Produto com este nome desta marca;");
                }
            }

            return valido;
        }

        static public bool ConfereLoja(List<Loja> Lojas, Loja nLoja){
            bool valido = true;
            foreach (Loja loj in Lojas)
            {
                if (loj.id == nLoja.id) 
                {
                    valido = false;
                    Console.WriteLine("Já existe um Loja com este Id;");
                }
                if (loj.nome == nLoja.nome && loj.local == nLoja.local) 
                {
                    valido = false;
                    Console.WriteLine("Já existe um Loja com este nome neste local;");
                }
            }

            return valido;
        }

        static public bool ConfereEstoque(List<Estoque> Estoques, Estoque nEstoque){
            bool valido = true;
            foreach (Estoque estq in Estoques)
            {
                if (estq.id == nEstoque.id) 
                {
                    valido = false;
                    Console.WriteLine("Já existe um Estoque com este Id;");
                }
                if (estq.lojaId == nEstoque.lojaId) 
                {
                    valido = false;
                    Console.WriteLine("Já existe um Estoque desta loja;");
                }
            }

            return valido;
        }

        static public bool ConfereVenda(List<Venda> Vendas, Venda nVenda){
            bool valido = true;
            foreach (Venda vend in Vendas)
            {
                if (vend.id == nVenda.id) 
                {
                    valido = false;
                    Console.WriteLine("Já existe uma Venda com este Id;");
                }
            }

            return valido;
        }

        /*static public bool ConfereProdutoVendido(List<ProdutoVendido> ProdutosVendidos, ProdutoVendido nProdutoVendido){
            bool valido = true;
            foreach (ProdutoVendido prodV in ProdutosVendidos)
            {
                if (prodV.id == nProdutoVendido.id) 
                {
                    valido = false;
                    Console.WriteLine("Já existe uma Venda com este Id;");
                }
            }

            return valido;
        }*/


        static public int ConfereProdutoEmEstoque(List<ProdutoEmEstoque> ProdutosEmEstoque, ProdutoEmEstoque nProdE){
            int valido = 0;
            foreach (ProdutoEmEstoque prodE in ProdutosEmEstoque)
            {
                if (prodE.prodId == nProdE.prodId && prodE.estqId == nProdE.estqId ) 
                {
                    valido = 1;
                }
            }

            switch(valido){
                case 1:
                    Console.WriteLine("Já existe um Produto com este Id neste estoque;\n O produto será somado ao outro já estocado;");
                    break;
            }
            return valido;
        }

        static public List<ProdutoEmEstoque> SomaProdutoAoEstoque(List<ProdutoEmEstoque> ProdutosEmEstoque, ProdutoEmEstoque nProdE){
            for (int i = 0; i < ProdutosEmEstoque.Count; i++) 
            {
                if (ProdutosEmEstoque[i].prodId == nProdE.prodId && ProdutosEmEstoque[i].estqId == nProdE.estqId ) 
                {
                    ProdutosEmEstoque[i].quantidade = ProdutosEmEstoque[i].quantidade + nProdE.quantidade;
                }
            }

            return ProdutosEmEstoque;
        }

        static public List<ProdutoEmEstoque> SubtraiProdutoAoEstoque(List<ProdutoEmEstoque> ProdutosEmEstoque, ProdutoEmEstoque nProdE, bool exibir = true){
            int valido = 0;
            for (int i = 0; i < ProdutosEmEstoque.Count; i++) 
            {
                if (ProdutosEmEstoque[i].prodId == nProdE.prodId && ProdutosEmEstoque[i].estqId == nProdE.estqId ) 
                {
                    if(ProdutosEmEstoque[i].quantidade >= nProdE.quantidade){
                        //Console.WriteLine("dentro "+ProdutosEmEstoque[i].quantidade);
                        //Console.WriteLine("dentro "+nProdE.quantidade);
                        ProdutosEmEstoque[i].quantidade = ProdutosEmEstoque[i].quantidade - nProdE.quantidade;
                        valido = 1;
                    }
                    else {
                        valido = 2;
                    }
                }
            }
            if (valido == 0 && exibir){
                Console.WriteLine("\nProduto não encontrado no estoque;");
            }
            if (valido == 2 && exibir){
                Console.WriteLine("\nEstoque não possui tantos deste produto;");
            }
            if (valido == 1){
                Singleton.getInstancia().Atualizar(ProdutosEmEstoque);
            }

            return ProdutosEmEstoque;
        }

        static private List<ProdutoEmEstoque> AddProdutoEmEstoque(List<ProdutoEmEstoque> ProdutosEmEstoque){
            ProdutoEmEstoque novoPE = new ProdutoEmEstoque();
            int confere = ConfereProdutoEmEstoque(ProdutosEmEstoque,novoPE);
            if(confere == 0){
                Singleton.getInstancia().Gravar(novoPE);
                ProdutosEmEstoque = Singleton.getInstancia().LerProdutosEmEstoque();
            }
            else if(confere == 1){
                ProdutosEmEstoque = SomaProdutoAoEstoque(ProdutosEmEstoque,novoPE);
                Singleton.getInstancia().Atualizar(ProdutosEmEstoque);
            }

            return ProdutosEmEstoque;
        }


        static private (List<Venda>, List<ProdutoVendido>) GerarVenda(List<Venda> Vendas, List<ProdutoVendido> ProdutosVendidos, List<ProdutoEmEstoque> ProdutosEmEstoque){
            Venda novaV = new Venda();
            if(ConfereVenda(Vendas,novaV)){
                Singleton.getInstancia().Gravar(novaV);
                Vendas = Singleton.getInstancia().LerVendas();

                bool add = true;
                while (add)
                {
                    Console.WriteLine("\n\nAdicionando Produto Vendido\n");
                    var values = AddProdutoVendido(ProdutosVendidos,novaV.id,ProdutosEmEstoque);
                    ProdutosVendidos = values.Item1;
                    ProdutosEmEstoque = values.Item2;

                    //ProdutoVendidos = AddProdutoVendido(ProdutoVendidos,novaV.id,ProdutosEmEstoque);

                    Console.WriteLine("\n\nProduto adicionado; \nDeseja adicionar outro Produto?\n");
                    Console.WriteLine("1) Sim");
                    Console.WriteLine("2) Não");
                    
                    
                    int escolha = Convert.ToInt32(Console.ReadLine());
                    switch (escolha){
                        case 1:
                            add = true;
                            break;
                        case 2:
                            add = false;
                            break;
                    }
                }



            }
            return (Vendas,ProdutosVendidos);
        }

        static private List<ProdutoVendido> AddProdutoVendido(List<ProdutoVendido> ProdutosVendidos, List<ProdutoEmEstoque> ProdutosEmEstoque){
            ProdutoVendido novoPV = new ProdutoVendido();
            //if(ConfereProdutoVendido(ProdutosVendidos,novoPV)){
                Singleton.getInstancia().Gravar(novoPV);
                ProdutosVendidos = Singleton.getInstancia().LerProdutosVendidos();
            //}
            return ProdutosVendidos;
        }
        static private (List<ProdutoVendido>, List<ProdutoEmEstoque>) AddProdutoVendido(List<ProdutoVendido> ProdutosVendidos, int idVenda, List<ProdutoEmEstoque> ProdutosEmEstoque){
            ProdutoVendido novoPV = new ProdutoVendido(idVenda);
            //if(ConfereProdutoVendido(ProdutosVendidos,novoPV)){
                bool valido = false;
                foreach (ProdutoEmEstoque prodE in ProdutosEmEstoque)
                {
                    if(prodE.prodId == novoPV.produtoId && prodE.estqId == novoPV.estoqueId && prodE.quantidade >= novoPV.quantidade)
                    {
                        ProdutosEmEstoque = SubtraiProdutoAoEstoque(ProdutosEmEstoque, new ProdutoEmEstoque(prodE.prodId+"",prodE.estqId+"",novoPV.quantidade+""), false);
                        valido = true;
                        Singleton.getInstancia().Gravar(novoPV);
                        break;
                    }
                }
                
                if (!valido){
                    foreach (ProdutoEmEstoque prodE in ProdutosEmEstoque)
                    {
                        if(prodE.prodId == novoPV.produtoId && prodE.quantidade >= novoPV.quantidade)
                        {
                            Console.WriteLine("\nO Estoque escolhido não possui a Quantidade do Produto, por isso selecionamos outro para retirada do produto");
                            ProdutosEmEstoque = SubtraiProdutoAoEstoque(ProdutosEmEstoque, new ProdutoEmEstoque(prodE.prodId+"",prodE.estqId+"",novoPV.quantidade+""), false);
                            valido = true;
                            Singleton.getInstancia().Gravar(new ProdutoVendido(novoPV.vendaId+"",prodE.estqId+"",novoPV.produtoId+"",novoPV.quantidade+""));
                            break;
                        }
                    }
                }

                if (!valido) Console.WriteLine("\nNenhum Estoque possui essa quantidade deste produto;\n");
                else ProdutosVendidos = Singleton.getInstancia().LerProdutosVendidos();
            //}
            return (ProdutosVendidos, ProdutosEmEstoque);
        }


        static void Main(string[] args)
        {
            bool runCode = true;

            List<Produto> Produtos = Singleton.getInstancia().LerProdutos();
            List<Estoque> Estoques = Singleton.getInstancia().LerEstoques();
            List<Loja> Lojas = Singleton.getInstancia().LerLojas();

            List<ProdutoEmEstoque> ProdutosEmEstoque = Singleton.getInstancia().LerProdutosEmEstoque();
            List<Venda> Vendas = Singleton.getInstancia().LerVendas();
            List<ProdutoVendido> ProdutosVendidos = Singleton.getInstancia().LerProdutosVendidos();

            while (runCode)
            {
                int escolha;

                 Console.WriteLine("\n\n#####   MENU   #####");             //OK
                 Console.WriteLine("1) Adicionar Produto");                 //OK
                 Console.WriteLine("2) Adicionar Loja");                    //OK
                 Console.WriteLine("3) Adicionar Estoque");                 //OK
                 Console.WriteLine("4) Exibe Produtos");                    //OK
                 Console.WriteLine("5) Exibe Lojas");                       //OK
                 Console.WriteLine("6) Exibe Estoques");                    //OK
                 Console.WriteLine("7) Adicionar Produto em Estoque");      //OK
                 Console.WriteLine("8) Remover Produto em Estoque");        //OK
                 Console.WriteLine("9) Gerar Venda");                       //OK
                 Console.WriteLine("10) Exibe Vendas");                     //OK
                 
                 Console.WriteLine("\n0) Encerrar Programa");              //OK
                 Console.WriteLine("\n99) Apagar Registros");              //OK

                 Console.WriteLine("\n\nSelecionar Menu:");
                 escolha = Convert.ToInt32(Console.ReadLine());
                 switch(escolha){
                     case 0:
                        runCode = false;
                        break;

                     case 1:
                        Produtos = AddProduto(Produtos);
                        break;

                     case 2:
                        Lojas = AddLoja(Lojas);
                        break;

                     case 3:
                        Estoques = AddEstoque(Estoques);
                        break;

                     case 4:
                        Console.WriteLine("\n\n##### PRODUTOS #####\n");
                        foreach (Produto prod in Produtos)
                        {
                            Console.WriteLine("Produto Id: " + prod.id + " - " + prod.nome + "(" + prod.marca+ "):  R$" + prod.valor);
                        }
                        break;

                     case 5:
                        Console.WriteLine("\n\n#####  LOJAS   #####\n");
                        foreach (Loja loj in Lojas)
                        {
                            Console.WriteLine("Loja Id: " + loj.id + " - " + loj.nome + ", " + loj.local);
                        }
                        break;

                     case 6:
                        Console.WriteLine("\n\n##### ESTOQUES #####\n");
                        
                        for (int i = 0; i < Estoques.Count; i++) 
                        {
                            Console.WriteLine((i+1) + ") Estoque Id: " + Estoques[i].id + " - Loja Id: " + Estoques[i].lojaId );
                        }
                        Console.WriteLine("\n0) Sair\n");
                        Console.WriteLine("\nSelecione o estoque que deseja Verificar os Produtos:");
                        escolha = Convert.ToInt32(Console.ReadLine());

                        switch(escolha){
                            case 0:
                                break;
                            default:
                                if (escolha <= Estoques.Count)
                                {
                                    int estqId = Estoques[(escolha-1)].id;
                                    Console.WriteLine("\n\n##### PRODUTOS - ESTOQUE "+ estqId +" #####\n");
                                    foreach (ProdutoEmEstoque prodE in ProdutosEmEstoque)
                                    {
                                        if (prodE.estqId == estqId)
                                        {
                                            Console.WriteLine("Produto Id: - " +prodE.prodId + " - Quantidade:" + prodE.quantidade);
                                        }
                                    }
                                }
                                else Console.WriteLine("\nEstoque não reconhecido\n");
                                break;
                        }

                        break;

                     case 7:
                        ProdutosEmEstoque = AddProdutoEmEstoque(ProdutosEmEstoque);
                        break;

                     case 8:
                        ProdutosEmEstoque = SubtraiProdutoAoEstoque(ProdutosEmEstoque, new ProdutoEmEstoque());
                        break;

                     case 9:
                        var values = GerarVenda(Vendas,ProdutosVendidos,ProdutosEmEstoque);
                        Vendas = values.Item1;
                        ProdutosVendidos = values.Item2;
                        break;

                     case 10:
                        Console.WriteLine("\n\n#####   VENDAS   #####\n");
                        
                        for (int i = 0; i < Vendas.Count; i++) 
                        {
                            Console.WriteLine((i+1) + ") Venda Id:" + Vendas[i].id + " - Loja Id:" + Vendas[i].lojaId );
                        }
                        Console.WriteLine("\n0) Sair\n");
                        Console.WriteLine("\nSelecione a Venda que deseja Verificar os Produtos Vendidos:");
                        escolha = Convert.ToInt32(Console.ReadLine());

                        switch(escolha){
                            case 0:
                                break;
                            default:
                                if (escolha <= Vendas.Count)
                                {
                                    int vendId = Estoques[(escolha-1)].id;
                                    Console.WriteLine("\n\n##### PRODUTOS - VENDA "+ vendId +" #####\n");
                                    foreach (ProdutoVendido prodV in ProdutosVendidos)
                                    {
                                        if (prodV.vendaId == vendId)
                                        {
                                            Console.WriteLine("Produto Id :" +prodV.produtoId + " - Estoque Id :" + prodV.estoqueId + " - Quantidade:" + prodV.quantidade);
                                        }
                                    }
                                }
                                else Console.WriteLine("\nEstoque não reconhecido\n");
                                break;
                        }

                        break;

                     case 99:
                        Console.WriteLine("\n\n#####  REGISTROS  #####\n");
                        Console.WriteLine("1) Produtos");
                        Console.WriteLine("2) Lojas");
                        Console.WriteLine("3) Estoques");
                        Console.WriteLine("4) Produtos Em Estoques");
                        Console.WriteLine("5) Vendas");
                        Console.WriteLine("6) Produtos Vendidos");
                        Console.WriteLine("7) Todos");

                        Console.WriteLine("\n0) Sair\n");
                        Console.WriteLine("\nSelecione o registro a ser apagado:");

                        escolha = Convert.ToInt32(Console.ReadLine());

                        switch(escolha){
                            case 1:
                                Produtos = Singleton.getInstancia().DeleteProdutos();
                                break;
                            case 2:
                                Lojas = Singleton.getInstancia().DeleteLojas();
                                break;
                            case 3:
                                Estoques = Singleton.getInstancia().DeleteEstoques();
                                break;
                            case 4:
                                ProdutosEmEstoque = Singleton.getInstancia().DeleteProdutosEmEstoque();
                                break;
                            case 5:
                                Vendas = Singleton.getInstancia().DeleteVendas();
                                break;
                            case 6:
                                ProdutosVendidos = Singleton.getInstancia().DeleteProdutosVendido();
                                break;
                            case 0:
                                break;
                            case 7:
                                Estoques = Singleton.getInstancia().DeleteEstoques();
                                Lojas = Singleton.getInstancia().DeleteLojas();
                                Produtos = Singleton.getInstancia().DeleteProdutos();
                                ProdutosEmEstoque = Singleton.getInstancia().DeleteProdutosEmEstoque();
                                Vendas = Singleton.getInstancia().DeleteVendas();
                                ProdutosVendidos = Singleton.getInstancia().DeleteProdutosVendido();
                                break;
                        }
                        break;

                     default:
                        Console.WriteLine("\n\nOpção não reconhecida\n");
                        break;
                 }  
            }
        }
    }
}
