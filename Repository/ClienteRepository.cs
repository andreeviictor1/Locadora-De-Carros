using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalizaMenu.Models;

namespace LocalizaMenu.Repository
{
    public class ClienteRepository
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public void Adicionar(Cliente cliente) => _clientes.Add(cliente);

        public List<Cliente> ListarTodos() => _clientes;

        public Cliente ObterPorId(int id) => _clientes.FirstOrDefault(c => c.Id == id);
    }
}
