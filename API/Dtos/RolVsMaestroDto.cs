using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class RolVsMaestroDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion {get; set; }
        public DateTime FechaModificacion {get; set; }
        public int IdRolFk { get; set; }
        public int IdMaestroFk { get; set; }
    }
}