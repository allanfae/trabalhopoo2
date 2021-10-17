using System;
using System.Linq;
using System.Collections.Generic;

public class Cliente
{
    //Gets e Sets
	public Endereco Endereco{get; set;} //Pega o Endereço de outro contrutor, encapsula e coloca aquim para dividir melhor a aplicação 

	public string Nome{get; set;}

	public string Cpf{get; set;}

	public string Email{get; set;}

	public string DataNascimento{get; set;}

    public Cliente(string nome, string cpf, string email, string dataNascimento, Endereco endereco) //Construtor de Cliente
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        DataNascimento = dataNascimento;
        Endereco = endereco;
    }
}
