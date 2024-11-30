using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizaMenu.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int ClientId {  get; set; }
        public int CarroId { get; set; }
        public DateTime DataReserva {  get; set; }
    }
}
