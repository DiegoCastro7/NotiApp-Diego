using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class SubmodulosDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion {get; set; }
        public DateTime FechaModificacion {get; set; }
        public string NombreSubmodulo { get; set; }
        public ICollection<MaestrosVsSubmodulos> MaestrosVsSubmodulos { get; set; }
    }
}