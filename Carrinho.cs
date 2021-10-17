using System;
using System.Linq;
using System.Collections.Generic;
public class Carrinho
{
    //Gets e Sets
	public double Total{get; set;}

	public Ientrega Frete{get; set;}

	public Venda Venda{get; set;}

    public Carrinho(Ientrega frete, Venda venda)
    {
        Frete = frete;
        Venda = venda;
        if(Venda.Valor == 0)
        {
            Total = 0; //Condicional de nao ter nada no carrinho e igualar a zero o total.
        }
        else
        {
            Total = Venda.Valor + Frete.calculaFrete(); //Calculo da venda juntamente com o frete.
        }
    }
}