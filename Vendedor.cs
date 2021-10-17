using System;
using System.Linq;
using System.Collections;
public class Vendedor
{
    //Gets e Sets
	public string Nome{get; set;}

	public int Matricula{get; set;}

    public Vendedor(string nome, int matricula)// Construtor Vendedor
    {
        Nome = nome;
        Matricula = matricula;
    }
}
