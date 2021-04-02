using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SIFFormarion.RepositoryIM;
using SIFormation.IRepository;
using SIFormation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppliBibliotheque.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StagiairesController : ControllerBase
    {
        private IStagiaireRepository _stagiaireRepository = null;

        public StagiairesController ( IStagiaireRepository repository)
        {
            _stagiaireRepository = repository;
            //_stagiaireRepository = new StagiaireRepository();
        }

        // GET: stagiaires/<StagiairesController>
        //[HttpGet]
        [AcceptVerbs("GET","HEAD")]     //-- de type get et head
        public ActionResult<IEnumerable<Stagiaire>> Get()
        {

            IEnumerable<Stagiaire> stagiaires = _stagiaireRepository.GetAll();
            if ( stagiaires is null )
            {
                return NotFound(stagiaires);
            } 
            return _stagiaireRepository.GetAll().ToList();
        }

        // GET stagiaires/<StagiairesController>/5
        [HttpGet("{matricule}")]
        //public string Get(string matricule)
        //public Stagiaire Get(string matricule)
        public ActionResult<Stagiaire> Get(string matricule)
        {
            Stagiaire stagiaire = _stagiaireRepository.Find(matricule);
            if (stagiaire == null )
            {
                return NotFound(stagiaire);
            }
            //string json = JsonConvert.SerializeObject(stagiaire,formatting: Formatting.None);

            return stagiaire;

        }

        // POST stagiaires/<StagiairesController>
        [HttpPost]
        public ActionResult Post([FromBody] Stagiaire value)
        {
            if ( value is null )
                return BadRequest(value);
            
            if ( ValidationService.ValidateModel(value).Count() == 0 )
            {
                try
                {
                    _stagiaireRepository.Insert(value);
                }
                catch (Exception)
                {
                    return BadRequest(value);
                }
            }
            else
            {
                return BadRequest(value);
            }
                    
            return Ok();
        }

        // PUT stagiaires/<StagiairesController>/5
        [HttpPut("{matricule}")]
        public ActionResult Put(string matricule, [FromBody] Stagiaire value)
        {
            if (matricule != value.Matricule)
            {
                return BadRequest(value);
            }

            try
            {
                _stagiaireRepository.Update(value);
            }
            catch(Exception)
            {
                return BadRequest(value);
            }

            return Ok(value);
        }

        // DELETE stagiaires/<StagiairesController>/5
        [HttpDelete("{matricule}")]
        public ActionResult Delete(string matricule)
        {
            try
            {
                _stagiaireRepository.Delete(matricule);
            }catch(Exception)
            {
                return BadRequest(matricule);
            }

            return Ok();
        }
    }
}
