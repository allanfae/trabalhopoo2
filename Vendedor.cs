using System;
using System.Linq;
using System.Collections;
public class Vendedor
{
	public string Nome{get; set;}

	public int Matricula{get; set;}

    public Vendedor(string nome, int matricula)
    {
        Nome = nome;
        Matricula = matricula;
    }
}
