using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class GenericosVsSubmodulosDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion {get; set; }
        public DateTime FechaModificacion {get; set; }
        public int IdGenericosFk { get; set; }
        public int IdSubmodulosFk { get; set; }
        public int IdRolFk { get; set; }
    }
}