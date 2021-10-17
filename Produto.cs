using System;
using System.Linq;
using System.Collections.Generic;

public class Produto
{
	public string Marca{get; set;}

	public string Modelo{get; set;}

	public int Id{get; set;}

	public double Preco{get; set;}

    public Produto(string marca, string modelo, int id, double preco)
    {
        Marca = marca;
        Modelo = modelo;
        Id = id;
        Preco = preco;
    }
} 