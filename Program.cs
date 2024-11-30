using LocalizaMenu.Models;
using LocalizaMenu.Repository;
using System;

class Program
{
    static void Main(string[] args)
    {
        var clienteRepo = new ClienteRepository();
        var carroRepo = new CarroRepository();
        var reservaRepo = new ReservaRepository();

        clienteRepo.Adicionar(new Cliente { Id = 1, Nome = "João Silva", Telefone = "1234-5678" });
        clienteRepo.Adicionar(new Cliente { Id = 2, Nome = "Maria Souza", Telefone = "8765-4321" });

        carroRepo.AdicionarCarro(new Carro { Id = 1, Modelo = "Fiat Uno", Placa = "ABC-1234", Ocupado = false });
        carroRepo.AdicionarCarro(new Carro { Id = 2, Modelo = "Toyota Corolla", Placa = "DEF-5678", Ocupado = true });

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Menu Locadora de Carros ===");
            Console.WriteLine("1. Listar Clientes");
            Console.WriteLine("2. Adicionar Cliente");
            Console.WriteLine("3. Mostrar Detalhes do Cliente");
            Console.WriteLine("4. Listar Carros");
            Console.WriteLine("5. Adicionar Carro");
            Console.WriteLine("6. Listar Carros Ocupados");
            Console.WriteLine("7. Mostrar Detalhes do Carro");
            Console.WriteLine("8. Adicionar um carro à reserva de um cliente");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            int opcao = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (opcao)
            {
                case 1:
                    Console.WriteLine("=== Lista de Clientes ===");
                    foreach (var cliente in clienteRepo.ListarTodos())
                        Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, Telefone: {cliente.Telefone}");
                    break;

                case 2:
                    Console.WriteLine("=== Adicionar Novo Cliente ===");
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Telefone: ");
                    string telefone = Console.ReadLine();

                    int novoClienteId = clienteRepo.ListarTodos().Count + 1;
                    clienteRepo.Adicionar(new Cliente { Id = novoClienteId, Nome = nome, Telefone = telefone });
                    Console.WriteLine("Cliente adicionado com sucesso!");
                    break;

                case 3:
                    Console.Write("Digite o ID do cliente: ");
                    int clienteId = int.Parse(Console.ReadLine());
                    var clienteDetalhe = clienteRepo.ObterPorId(clienteId);
                    if (clienteDetalhe != null)
                        Console.WriteLine($"ID: {clienteDetalhe.Id}, Nome: {clienteDetalhe.Nome}, Telefone: {clienteDetalhe.Telefone}");
                    else
                        Console.WriteLine("Cliente não encontrado!");
                    break;

                case 4:
                    Console.WriteLine("=== Lista de Carros ===");
                    foreach (var carro in carroRepo.ListarTodos())
                        Console.WriteLine($"ID: {carro.Id}, Modelo: {carro.Modelo}, Placa: {carro.Placa}, Ocupado: {carro.Ocupado}");
                    break;

                case 5:
                    Console.WriteLine("=== Adicionar Novo Carro ===");
                    Console.Write("Modelo: ");
                    string modelo = Console.ReadLine();
                    Console.Write("Placa: ");
                    string placa = Console.ReadLine();

                    int novoCarroId = carroRepo.ListarTodos().Count + 1;
                    carroRepo.AdicionarCarro(new Carro { Id = novoCarroId, Modelo = modelo, Placa = placa, Ocupado = false });
                    Console.WriteLine("Carro adicionado com sucesso!");
                    break;

                case 6:
                    Console.WriteLine("=== Lista de Carros Ocupados ===");
                    foreach (var carro in carroRepo.ListarOcupados())
                        Console.WriteLine($"ID: {carro.Id}, Modelo: {carro.Modelo}, Placa: {carro.Placa}");
                    break;

                case 7:
                    Console.Write("Digite o ID do carro: ");
                    int carroId = int.Parse(Console.ReadLine());
                    var carroDetalhe = carroRepo.ObterPorId(carroId);
                    if (carroDetalhe != null)
                        Console.WriteLine($"ID: {carroDetalhe.Id}, Modelo: {carroDetalhe.Modelo}, Placa: {carroDetalhe.Placa}, Ocupado: {carroDetalhe.Ocupado}");
                    else
                        Console.WriteLine("Carro não encontrado!");
                    break;

                case 8:
                    Console.Write("Digite o ID do cliente: ");
                    int clienteReservaId = int.Parse(Console.ReadLine());
                    var clienteReserva = clienteRepo.ObterPorId(clienteReservaId);

                    Console.Write("Digite o ID do carro: ");
                    int carroReservaId = int.Parse(Console.ReadLine());
                    var carroReserva = carroRepo.ObterPorId(carroReservaId);

                    if (clienteReserva != null && carroReserva != null && !carroReserva.Ocupado)
                    {
                        carroReserva.Ocupado = true;
                        reservaRepo.Adicionar(new Reserva
                        {
                            Id = reservaRepo.ListarTodos().Count + 1,
                            ClientId = clienteReservaId,
                            CarroId = carroReservaId,
                            DataReserva = DateTime.Now
                        });
                        Console.WriteLine("Reserva realizada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao realizar a reserva!");
                    }
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
