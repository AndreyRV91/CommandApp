using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using AutoMapper;
using CommandApp.Data;
using CommandApp.Dtos;
using CommandApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandApp
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandFromRepo = _repository.GetCommandById(id);

            if (commandFromRepo != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandFromRepo));
            }

            return NotFound();
        }

        //POST api/commands/
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            //validations
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandFromRepo = _repository.GetCommandById(id);

            //validations
            if(commandFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandFromRepo);

            _repository.UpdateCommand(commandFromRepo);//Good practice

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public  ActionResult DeleteCommand(int id)
        {
            var commandFromRepo = _repository.GetCommandById(id);

            if (commandFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
