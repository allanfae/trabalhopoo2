using System;
using System.Linq;
using System.Collections;
using System.IO;
public class RelatorioExcel : Iarquivo
{
	public string gerarRelatorio(Relatorio relatorio)//programa para arquivo
	{
		using (StreamWriter writer = new StreamWriter("relatoriodevendas.txt"))
		{
			foreach (var venda in relatorio.Vendas)
			{
				writer.WriteLine(venda.ToString());
			}
		}
		return "O relatório de vendas foi salvo em arquivo";
	}
}

