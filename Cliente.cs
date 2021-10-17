using System;
using System.Linq;
using System.Collections.Generic;

public class Cliente
{
    public string Endereco{get; set;}
	public string Nome{get; set;}

	public string Cpf{get; set;}

	public string Email{get; set;}

	public string DataNascimento{get; set;}

    public Cliente(string nome, string cpf, string email, string dataNascimento, string endereco)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        DataNascimento = dataNascimento;
        Endereco = endereco;
    }
}
