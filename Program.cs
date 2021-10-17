using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //DECLARAÇÃO DAS VARIÁVEIS GLOBAIS
        Relatorio relatorio = new Relatorio();
        Dictionary<string, Cliente> listaClientes = new Dictionary<string, Cliente>();
        int contaClientes = 1;
        Dictionary<int, Vendedor> listaVendedores = new Dictionary<int, Vendedor>();
        int contaVendedores = 1;
        Dictionary<int, Produto> listaProdutos = new Dictionary<int, Produto>();
        int contaProdutos = 1;
        Dictionary<int, Estoque> listaEstoques = new Dictionary<int, Estoque>();
        int contaEstoques = 1;
        Dictionary<int, Loja> listaLojas = new Dictionary<int, Loja>();
        int contaLojas = 1;
        Dictionary<int, Venda> listaVendas = new Dictionary<int, Venda>();
        int contaVendas = 1;
        Ientrega delivery = new Delivery();
        Ientrega retirada = new Retirada();
        Iarquivo arquivoVendas = new RelatorioExcel();

        while(true)
        {
            //MENU DA INTERFACE
            Console.WriteLine("Bem vindo ao programa. Selecione uma opção conforme menu abaixo:");
            Console.WriteLine("1: Cadastrar cliente");
            Console.WriteLine("2: Cadastrar vendedor");
            Console.WriteLine("3: Cadastrar produto");
            Console.WriteLine("4: Cadastrar estoque");
            Console.WriteLine("5: Cadastrar loja");
            Console.WriteLine("6: Cadastrar venda");
            Console.WriteLine("7: Finalizar pedido");
            Console.WriteLine("8: Baixar relatório de vendas");
            Console.WriteLine("0: Sair");
            int opcao = Convert.ToInt32(Console.ReadLine());
            if (opcao == 1)//CADASTRO DE CLIENTES
            {
                Console.WriteLine("Insira o nome do cliente:");
                string nomeCliente = Console.ReadLine();
                Console.WriteLine("Insira o cpf do cliente:");
                string cpf = Console.ReadLine();
                Console.WriteLine("Insira o email do cliente:");
                string email = Console.ReadLine();
                Console.WriteLine("Insira a data de nascimento do cliente:");
                string data = Console.ReadLine();
                Console.WriteLine("Insira o enredeço do cliente:");
                string endereco = Console.ReadLine();
                Cliente cliente = new Cliente(nomeCliente, cpf, email, data, endereco);
                listaClientes.Add(email, cliente);
                contaClientes++;
            }
            if (opcao == 2)//CADASTRO DE VENDEDORES
            {
                Console.WriteLine("Insira o nome do vendedor:");
                string nomeVendedor = Console.ReadLine();
                Vendedor vendedor = new Vendedor(nomeVendedor, contaVendedores);
                listaVendedores.Add(contaVendedores, vendedor);
                contaVendedores++;
            }
            if (opcao == 3)//CADASTRO DE PRODUTOS
            {
                Console.WriteLine("Insira a marca do produto:");
                string marca = Console.ReadLine();
                Console.WriteLine("Insira o modelo do produto:");
                string modelo = Console.ReadLine();
                Console.WriteLine("Insira o preço do produto:");
                double precoProduto = Convert.ToDouble(Console.ReadLine());
                Produto produto = new Produto(marca, modelo, contaProdutos, precoProduto);
                listaProdutos.Add(contaProdutos, produto);
                contaProdutos++;
            }
            if (opcao == 4)//CADASTRO DE ESTOQUES, COM A INSERÇÃO DOS PRODUTOS QUE ELE CONTÉM
            {
                Estoque novoEstoque = new Estoque();
                Console.WriteLine("Deseja cadastrar produtos neste estoque? (S/N)");
                string escolha = Console.ReadLine();
                if(escolha == "S" || escolha == "s")
                {
                    Console.WriteLine("Qual o id do produto: ");
                    int idProduto = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Qual a quantidade inicial: ");
                    int qtd = Convert.ToInt32(Console.ReadLine());
                    novoEstoque.CadastrarProduto(listaProdutos[idProduto],qtd);
                }
                listaEstoques.Add(contaEstoques, novoEstoque);
                contaEstoques++;
            }
            if (opcao == 5)//CADASTRO DA LOJA, INDICANDO QUAL É O ESTOQUE DELA E QUEM TRABALHA NA LOJA
            {
                Console.WriteLine("Qual o id do estoque que pertence a essa loja?");
                int idEstoque = Convert.ToInt32(Console.ReadLine());
                Loja novaLoja = new Loja(contaLojas, listaEstoques[idEstoque]);
                while(true)
                {
                    Console.WriteLine("Qual a matrícula do vendedor que trabalha nessa loja?");
                    int matricula = Convert.ToInt32(Console.ReadLine());
                    novaLoja.cadastrarVendedores(listaVendedores[matricula]);
                    Console.WriteLine("Essa loja tem mais algum vendedor? (S/N)");
                    string insereVendedor = Console.ReadLine();
                    if(insereVendedor != "S" || insereVendedor != "s")
                        break;
                }
                listaLojas.Add(contaLojas, novaLoja);
                contaLojas++;
            }
            if (opcao == 6)//CADASTRO DOS ITENS DA VENDA
            {
                Console.WriteLine("Qual a matrícula do vendedor que efetuou a venda?");
                int matricula = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Qual o email do cliente?");
                string email = Console.ReadLine();
                Console.WriteLine("Qual o código da loja em que foi feita a venda?");
                int codigo = Convert.ToInt32(Console.ReadLine());
                Venda novaVenda = new Venda(listaVendedores[matricula], listaClientes[email], listaLojas[codigo], contaVendas);
                try
                {
                    while(true)
                    {
                        Console.WriteLine("Qual o código do produto que está sendo vendido?");
                        int cod = Convert.ToInt32(Console.ReadLine());
                        novaVenda.insereProduto(listaProdutos[cod]);
                        listaLojas[codigo].EstoqueLoja.DarBaixaDeProduto(listaProdutos[cod]);
                        Console.WriteLine("Adicionar mais itens na venda? (S/N)");
                        string addProduto = Console.ReadLine();
                        if(addProduto != "S" || addProduto != "s")
                            break;
                    }
                    novaVenda.calculaValor();
                    relatorio.insereVenda(novaVenda);
                    listaVendas.Add(contaVendas, novaVenda);
                    contaVendas++;
                }
                catch
                {
                    Console.WriteLine("Quantidade insuficiente em estoque. Venda cancelada.");
                }
            }
            if (opcao == 7)//FINALIZAÇÃO DA VENDA, COM A ESCOLHA DA OPÇÃO DE RETIRADA
            {
                Console.WriteLine("Qual é o id da venda: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Qual é a opção de retirada do pedido: ");
                Console.WriteLine("1: delivery");
                Console.WriteLine("2: retirada na loja");
                int opRetirada = Convert.ToInt32(Console.ReadLine());
                if(opRetirada == 1)
                {
                    Console.WriteLine("A opção escolhida foi delivery. Trabalhamos com taxa fixa de R$19,90");
                    Carrinho carrinho = new Carrinho(delivery, listaVendas[id]);
                }
                if(opRetirada == 2)
                {
                    Carrinho carrinho = new Carrinho(retirada, listaVendas[id]);
                }
            }
            if (opcao == 8)//BAIXAR RELATORIO.TXT
            {
                arquivoVendas.gerarRelatorio(relatorio);
            }
            if (opcao == 0)
                break;
        }
    }
}