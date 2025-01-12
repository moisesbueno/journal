using Journal.Application.DTOs;
using Journal.Application.Journal.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Journal.Api.Controllers
{
    [ApiController]
    [Route("api/journal")]
    public class JournalController : Controller
    {
        //private readonly IMapper _mapper;
        //private readonly IUnitOfWork _unitOfWork;
        //private readonly IJournalRepository _journalRepository;
        //private readonly IPublisher<JournalMessage> _journalPublisher;
        //private readonly IConnectionMultiplexer _connectionMultiplexer;

        //public JournalController(IMapper mapper,
        //                         IUnitOfWork unitOfWork,
        //                         IJournalRepository journalRepository,
        //                         IPublisher<JournalMessage> journalPublisher,
        //                         IConnectionMultiplexer connectionMultiplexer)
        //{
        //    _mapper = mapper;
        //    _unitOfWork = unitOfWork;
        //    _journalRepository = journalRepository;
        //    _journalPublisher = journalPublisher;
        //    _connectionMultiplexer = connectionMultiplexer;
        //}

        private readonly IMediator _mediator;
        public JournalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]

        public async Task<IActionResult> GetJournals([FromQuery] JournalListRequest journalListRequest, CancellationToken cancellationToken)
        {
            var query = new GetJournalsQuery()
            {
                PageNumber = journalListRequest.PageNumber,
                PageSize = journalListRequest.PageSize,
                Search = journalListRequest.Search
            };

            var journals = await _mediator.Send(query, cancellationToken);

            return Ok(journals);
        }



        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] JournalAddRequest journalRequest)
        {
            return Ok();
            //var journalMessage = _mapper.Map<JournalMessage>(journalRequest);

            //await _journalPublisher.SendMessageAsync(journalMessage, QueuesName.JournalQueue);

            //return Ok(journalMessage.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] JournalAddRequest journalRequest)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok();
            //var redisDb = _connectionMultiplexer.GetDatabase();

            //string keyName = $"{typeof(JournalResponse).Name}-{id}";

            //string response = await redisDb.StringGetAsync(keyName);

            //if (string.IsNullOrEmpty(response))
            //{
            //    var result = await _journalRepository.GetByIdAsync(id);

            //    if (result is not null)
            //    {
            //        var mapperResponse = _mapper.Map<JournalResponse>(result);

            //        response = JsonConvert.SerializeObject(mapperResponse);
            //    }

            //    await redisDb.StringSetAsync(keyName, response, TimeSpan.FromMinutes(1));
            //}

            //return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            return Ok();
            //var result = await _journalRepository.DeleteAsync(id);

            //if (result)
            //{
            //    await _unitOfWork.CommitAsync();
            //    return Ok();
            //}

            //return NotFound();
        }
    }
}