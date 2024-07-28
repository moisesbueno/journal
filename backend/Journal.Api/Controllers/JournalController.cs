using AutoMapper;
using Journal.Api.Models;
using Journal.Api.Repositories;
using Journal.Data.Interfaces;
using Journal.MessageBus;
using Journal.MessageBus.Messages;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;

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
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public JournalController(IMapper mapper,
                                 IUnitOfWork unitOfWork,
                                 IJournalRepository journalRepository,
                                 IPublisher<JournalMessage> journalPublisher,
                                 IConnectionMultiplexer connectionMultiplexer)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _journalRepository = journalRepository;
            _journalPublisher = journalPublisher;
            _connectionMultiplexer = connectionMultiplexer;
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
            var redisDb = _connectionMultiplexer.GetDatabase();

            string keyName = $"{typeof(JournalResponse).Name}-{id}";

            string response = await redisDb.StringGetAsync(keyName);

            if (string.IsNullOrEmpty(response))
            {
                var result = await _journalRepository.GetByIdAsync(id);

                var mapperResponse = _mapper.Map<JournalResponse>(result);

                response = JsonConvert.SerializeObject(mapperResponse);
                await redisDb.StringSetAsync(keyName, response, TimeSpan.FromMinutes(1));
            }

            return Ok(response);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _journalRepository.DeleteAsync(id);

            if (result)
            {
                await _unitOfWork.SaveChangesAsync();
                return Ok();
            }

            return NotFound();

        }
    }
}
