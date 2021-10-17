using System;
using System.Linq;
using System.Collections.Generic;
public class Estoque
{
	public Dictionary<int, int> estoqueProdutos;

	
    public Estoque()//construtor, quando instancia um objeto estoque já cria o dicionário
    {
        estoqueProdutos = new Dictionary<int, int>(); //a chave é o código do produto, o valor é a quantidade em estoque
    }

	public void CadastrarProduto(Produto prod, int qtdInicial)
    {
        estoqueProdutos.Add(prod.Id, qtdInicial);
    }
    public void DarBaixaDeProduto(Produto prod)
    {
        estoqueProdutos[prod.Id]--;
    }
    public void exibeQtd(Produto prod)//exibir qtd do produto X no estoque Y
    {
        Console.WriteLine($"O estoque atual é de {estoqueProdutos[prod.Id]}");
    }
}