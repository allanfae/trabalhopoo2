using System;
using System.Linq;
using System.Collections.Generic;
public class Venda
{
	public double Valor{get; set;}

	public float Desconto{get; set;}

	public Vendedor Vendedor{set; get;}

	public Cliente Cliente{get; set;}

	private List<Produto> produtos;

	public Loja Loja{get; set;}

	public void insereProduto(Produto produto)
	{
		if(Loja.EstoqueLoja.estoqueProdutos[produto.Id] > 0)
		{
			produtos.Add(produto);
		}
		else
		{
			Console.WriteLine($"O estoque para o produto {produto.Id} está zerado.");
		}
	}
    public void calculaValor()
	{
		foreach (var produto in produtos)
		{
			Valor += produto.Preco;
		}
		if(Valor >= 1000)
		{
			Desconto = 5;
			Valor *= 0.95;
		}
	}

    public Venda(Vendedor vendedor, Cliente cliente, Loja loja)
    {
        Vendedor = vendedor;
        Cliente = cliente;
		Loja = loja;
		produtos = new List<Produto>();
    }

	override public string ToString()
	{
		return ($"O vendedor {Vendedor.Nome} efetuou uma venda no valor de R${Valor:f2} para o cliente {Cliente.Nome} na loja {Loja.Codigo}.");
	}
}
