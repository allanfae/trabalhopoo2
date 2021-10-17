using System;
using System.Linq;
using System.Collections.Generic;
public class Carrinho
{
	public double Total{get; set;}

	public Ientrega Frete{get; set;}

	public Venda Venda{get; set;}

    public Carrinho(Ientrega frete, Venda venda)
    {
        Frete = frete;
        Venda = venda;
        if(Venda.Valor == 0)
        {
            Total = 0;
        }
        else
        {
            Total = Venda.Valor + Frete.calculaFrete();
        }
    }
}