using System.Threading.Tasks;
using AutoMapper;
using Manager.API.ViewModes;
using Manager.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Manager.Services.DTO;
using Microsoft.AspNetCore.Authorization;
using Manager.Core.Exceptions;
using Manager.API.Utilities;

namespace Manager.API.Controllers{
    [ApiController]
    public class UserController : ControllerBase{

        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(userViewModel);

                var userCreated = await _userService.Create(userDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso!",
                    Success = true,
                    Data = userCreated
                });
            // 37:05

            }
           catch(DomainException ex)
           {
              return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
           }
            catch(Exception)
            {
                //36:37
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }

        }
    }
}