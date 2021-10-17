using System;
using System.Linq;
using System.Collections.Generic;
public class Estoque
{
	public Dictionary<int, int> estoqueProdutos;

	
    public Estoque()//Construtor, quando instancia um objeto estoque já cria o dicionário
    {
        estoqueProdutos = new Dictionary<int, int>(); //A chave é o código do produto, o valor é a quantidade em estoque
    }

	public void CadastrarProduto(Produto prod, int qtdInicial) //Adiciona quantidade inicial do produto ao seu respectivo ID
    {
        estoqueProdutos.Add(prod.Id, qtdInicial);
    }
    public void DarBaixaDeProduto(Produto prod) //Remove 1 quantidade do produto ao seu respectivo ID quando o produto for vendido
    {
        estoqueProdutos[prod.Id]--;
    }

    public void exibeQtd(Produto prod)//Exibir quantidade do produto X no estoque Y
    {
        Console.WriteLine($"O estoque atual é de {estoqueProdutos[prod.Id]}");
    }
}
 