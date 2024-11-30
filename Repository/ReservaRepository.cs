using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalizaMenu.Models;


namespace LocalizaMenu.Repository
{
    public class ReservaRepository
    {
        
        private readonly List<Reserva> _reservas = new List<Reserva>();

        public void Adicionar(Reserva reserva) => _reservas.Add(reserva);

        public List<Reserva> ListarTodos() => _reservas;   

        public Reserva ObterPorId(int id) => _reservas.FirstOrDefault(r => r.Id == id);

    }
}
