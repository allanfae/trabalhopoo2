using System;
using System.Linq;
using System.Collections.Generic;
public class Loja
{
	public int Codigo{get; set;}

	public Estoque EstoqueLoja{get; set;}

	private List<Vendedor> vendedores;

	public void cadastrarVendedores(Vendedor vendedor)
	{
		vendedores.Add(vendedor);
	}

    public Loja(int codigo, Estoque estoque)
    {
        Codigo = codigo;
		EstoqueLoja = estoque;
		vendedores = new List<Vendedor>();
    }
}