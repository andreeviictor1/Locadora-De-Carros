using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalizaMenu.Models;

namespace LocalizaMenu.Repository
{
    public class CarroRepository
    {
        public readonly List<Carro> _carros = new List<Carro>();


        public void AdicionarCarro(Carro carro) => _carros.Add(carro);

        public List<Carro> ListarTodos () => _carros;

        public List<Carro> ListarOcupados () => _carros.Where(c => c.Ocupado).ToList();

        public Carro ObterPorId(int id) => _carros.FirstOrDefault(c => c.Id == id);
    }
}
