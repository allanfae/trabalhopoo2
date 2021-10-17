using System;
using System.Linq;
using System.Collections.Generic;
public class Relatorio
{
	public List<Venda> Vendas;

	//private Iarquivo iarquivo;

	public Relatorio()
	{
		Vendas = new List<Venda>();
	}

	public void insereVenda(Venda venda)
	{
		Vendas.Add(venda);
	}

}

