using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ModuloNotificacionesDto
    {
        public int Id { get; set; }
        public DateTime FechaCreacion {get; set; }
        public DateTime FechaModificacion {get; set; }
        public string AsuntoNotificacion { get; set; }
        public string TextoNotificacion { get; set; }
        public int IdTipoNotificacionFk { get; set; }
        public int IdRadicadoFk { get; set; }
        public int IdEstadoNotificacionFk { get; set; }
        public int IdHiloRespuestaFk { get; set; }
        public int IdFormatoFk { get; set; }
        public int IdRequerimientoFk { get; set; }
    }
}