using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Aplicacion.Core;
using Utilitarios.InC;


namespace WebApi.Controllers
{
    [RoutePrefix("arq_ddd/api")]
    public class PersonaController : ApiController
    {
        private readonly IPersonaServicio _personaServicio;

        public PersonaController(IPersonaServicio personaServicio)
        {
            _personaServicio = personaServicio;
        }

        [Route("listartodo")] 
        [HttpGet]
        [ResponseType(typeof(IEnumerable<PersonaDTO>))]
        public IHttpActionResult ListarPersonas()
        {
            IEnumerable<PersonaDTO> listadoPersona = new List<PersonaDTO>();
            try
            {                                
                listadoPersona = _personaServicio.ListarTodos();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok(listadoPersona);
        }


        [Route("crearpersona")]
        [HttpPost]
        [ResponseType(typeof(PersonaDTO))]
        public IHttpActionResult CrearPersona([FromBody]PersonaDTO request)
        {
            PersonaDTO Persona = new PersonaDTO();
            try
            {
                Persona = _personaServicio.Crear(request);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok(Persona);
        }




        [Route("obtenerporid")]
        [HttpPost]
        [ResponseType(typeof(PersonaDTO))]
        public IHttpActionResult ObtenerPorId([FromBody]PersonaDTO request)
        {
            PersonaDTO Persona = new PersonaDTO();
            try
            {
                Persona = _personaServicio.ObtenerPorId(Convert.ToInt64(request.PersonaId));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok(Persona);
        }

        [Route("obtenerporRut")]
        [HttpPost]
        [ResponseType(typeof(PersonaDTO))]
        public IHttpActionResult ObtenerPorRut([FromBody]PersonaDTO request)
        {
            PersonaDTO Persona = new PersonaDTO();
            try
            {
                Persona = _personaServicio.ObtenerPorRut(request.Rut);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return Ok(Persona);
        }
    }
}
