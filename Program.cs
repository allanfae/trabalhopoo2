using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

/*Para os testes vamos cadastrar 3 objetos de cada classe, na seguinte ordem:
Endereço->Cliente->Vendedor->Estoque->Loja->Produto->Venda->Delivery->Retirada->Carrinho*/
class Program
{
    static void Main(string[] args)
    {
        Relatorio relatorio = new Relatorio();
        Endereco end1 = new Endereco("Rua A", 1, "11111-111", "ABC", "Apt 111");
        Endereco end2 = new Endereco("Rua B", 2, "22222-222", "BCD", "Apt 222");
        Endereco end3 = new Endereco("Rua C", 3, "33333-333", "CDE", "Apt 333");

        Cliente cli1 = new Cliente("Marcio", "123123123-123", "mp@xyz.com", "19/12/1991", end1);
        Cliente cli2 = new Cliente("Rafael", "231231231-231", "rc@xyz.com", "01/12/1991", end2);
        Cliente cli3 = new Cliente("Allan", "321321321-321", "af@xyz.com", "10/12/1991", end3);

        Vendedor vendedor1 = new Vendedor("Joao", 001);
        Vendedor vendedor2 = new Vendedor("Jose", 002);
        Vendedor vendedor3 = new Vendedor("Juca", 003);

        Produto produto1 = new Produto("bic", "caneta", 1, 5);
        Produto produto2 = new Produto("faber", "lapis", 2, 1.5);
        Produto produto3 = new Produto("mercur", "borracha", 3, 2);

        Estoque estoque1 = new Estoque();
        estoque1.CadastrarProduto(produto1,100);
        estoque1.CadastrarProduto(produto2,100);
        Estoque estoque2 = new Estoque();
        estoque2.CadastrarProduto(produto3,100);
        Estoque estoque3 = new Estoque();
        estoque3.CadastrarProduto(produto1,100);
        estoque3.CadastrarProduto(produto2,100);
        estoque3.CadastrarProduto(produto3,100);

        Loja loja1 = new Loja(1, estoque1);
        loja1.cadastrarVendedores(vendedor1);
        Loja loja2 = new Loja(2, estoque2);
        loja2.cadastrarVendedores(vendedor2);
        Loja loja3 = new Loja(3, estoque3);
        loja3.cadastrarVendedores(vendedor3);
        
        Venda venda1 = new Venda(vendedor1, cli1, loja1);
        try
        {
            venda1.insereProduto(produto1);
            venda1.Loja.EstoqueLoja.DarBaixaDeProduto(produto1);
            venda1.insereProduto(produto1);
            venda1.Loja.EstoqueLoja.DarBaixaDeProduto(produto1);
            venda1.insereProduto(produto1);
            venda1.Loja.EstoqueLoja.DarBaixaDeProduto(produto1);
            venda1.insereProduto(produto2);
            venda1.Loja.EstoqueLoja.DarBaixaDeProduto(produto2);
            venda1.calculaValor();
            relatorio.insereVenda(venda1);
        }
        catch
        {
            Console.WriteLine("Quantidade insuficiente em estoque. Venda cancelada.");
        }
         
        Venda venda2 = new Venda(vendedor2, cli2, loja2);
        try
        {
            venda2.insereProduto(produto3);
            venda2.Loja.EstoqueLoja.DarBaixaDeProduto(produto3);
            venda2.insereProduto(produto3);
            venda2.Loja.EstoqueLoja.DarBaixaDeProduto(produto3);
            venda2.calculaValor();
            relatorio.insereVenda(venda2);
        }
        catch
        {
            Console.WriteLine("Quantidade insuficiente em estoque. Venda cancelada.");
        }
        
        Venda venda3 = new Venda(vendedor3, cli3, loja3);
        try
        {
            venda3.insereProduto(produto1);
            venda3.Loja.EstoqueLoja.DarBaixaDeProduto(produto1);
            venda3.calculaValor();
            relatorio.insereVenda(venda3);
        }
        catch
        {
            Console.WriteLine("Quantidade insuficiente em estoque. Venda cancelada.");
        }
        
        Ientrega delivery = new Delivery();
        Ientrega retirada = new Retirada();
        Iarquivo excel = new RelatorioExcel();
        excel.gerarRelatorio(relatorio);
    
        Carrinho carrinho1 = new Carrinho(delivery,venda1);
        Console.WriteLine($"O valor do pedido é {carrinho1.Total}");
        Carrinho carrinho2 = new Carrinho(delivery,venda2);
        Console.WriteLine($"O valor do pedido é {carrinho2.Total}");        
        Carrinho carrinho3 = new Carrinho(retirada,venda3);
        Console.WriteLine($"O valor do pedido é {carrinho3.Total}");


    }
}