using AutoMapper;
using Journal.Api.Models;
using Journal.Api.Repositories;
using Journal.Data.Interfaces;
using Journal.MessageBus;
using Journal.MessageBus.Messages;
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
        private readonly IPublisher<JournalMessage> _journalPublisher;

        public JournalController(IMapper mapper, IUnitOfWork unitOfWork, IJournalRepository journalRepository, IPublisher<JournalMessage> journalPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _journalRepository = journalRepository;
            _journalPublisher = journalPublisher;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] JournalRequest journalRequest)
        {
            var journalMessage = _mapper.Map<JournalMessage>(journalRequest);

            await _journalPublisher.SendMessageAsync(journalMessage, QueuesName.JournalQueue);

            return Ok(journalMessage.Id);
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
