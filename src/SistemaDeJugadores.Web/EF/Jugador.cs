using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaDeJugadores.Web.EF
{
    public partial class Jugador
    {
        public int JugadorId { get; set; }
        public string Nombre { get; set; }
        public int EquipoId { get; set; }

        public virtual Equipo Equipo { get; set; }
    }
}
