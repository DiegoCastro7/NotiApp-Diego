using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class RolDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Nombre { get; set; }
        public ICollection<RolVsMaestro> RolVsMaestro { get; set; }
        public ICollection<GenericosVsSubmodulos> GenericosVsSubmodulos { get; set; }
    }
}