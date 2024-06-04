using Journal.Models;
using Journal.Repositories;
using Journal.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.Controllers
{
    [ApiController]
    [Route("api/journal")]
    public class JournalController : ControllerBase
    {
        private readonly ILogger<JournalController> _logger;
        private readonly JournalRepository _journalRepository;
       
        public JournalController(ILogger<JournalController> logger, JournalRepository journalRepository)
        {
            _logger = logger;
            _journalRepository = journalRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult<PaginatedList<JournalModel>>> GetJournals([FromQuery] int pageNumber = 0, [FromQuery] int pageSize = 15, [FromQuery] string search = "")
        {

            var (total, result) = await _journalRepository.GetAll(search, pageNumber, pageSize);

            return Ok(new PaginatedList<JournalModel>(result.ToList(), pageSize, pageNumber, total));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaginatedList<JournalModel>>> GetJouralById(Guid id)
        {
            var result = await _journalRepository.GetById(id);

            return Ok(result);

        }

    }

}

