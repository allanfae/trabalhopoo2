using System;
using System.Linq;
using System.Collections.Generic;
public class Endereco
{
	public string Logradouro{get; set;}//Gets e Sets

	public int Numero{get; set;}

	public string Cep{get; set;}

	public string Bairro{get; set;}

	public string Complemento{get; set;}

    public Endereco(string logradouro, int numero, string cep, string bairro, string complemento) //Construtor de Endereço
    {
        Logradouro = logradouro;
        Numero = numero;
        Cep = cep;
        Bairro = bairro;
        Complemento = complemento;
    }
}
