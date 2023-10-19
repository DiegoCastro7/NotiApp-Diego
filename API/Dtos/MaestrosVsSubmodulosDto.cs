using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class MaestrosVsSubmodulosDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion {get; set; }
        public DateTime FechaModificacion {get; set; }
        public int IdMaestroFk { get; set; }
        public int IdSubmodulosFk { get; set; }
        public ICollection<GenericosVsSubmodulos> GenericosVsSubmodulos { get; set;}
    }
}