using AutoMapper;
using Journal.Api.Models;
using Journal.Api.Repositories;
using Journal.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Journal.Api.Controllers
{
    [ApiController]
    [Route("api/journal")]
    public class JournalController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJournalRepository _journalRepository;
        public JournalController(IMapper mapper, IUnitOfWork unitOfWork, IJournalRepository journalRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _journalRepository = journalRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] JournalRequest journalRequest)
        {
            var journal = _mapper.Map<Data.Models.Journal>(journalRequest);

            await _journalRepository.AddAsync(journal);

            await _unitOfWork.SaveChangesAsync();

            return Ok(journal.Id);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _journalRepository.GetByIdAsync(id);

            var response = _mapper.Map<JournalResponse>(result);

            return Ok(response);
        }
    }
}
