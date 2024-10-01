using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocNet1.Contracts;
using System.Reflection;

namespace SocNet1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User1Controller : ControllerBase
    {
        private IUserService _userService;
        public User1Controller(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Полученние всех данных
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        /// <summary>
        /// ПОлучение id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = result.Adapt<GetUserResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///     POST /Todo
        ///     {
        ///     "username": "AnnPiano"
        ///     "email": "AnnaS8694@gmail.com"
        ///     "password_hash": "Anka839(Df)"
        ///     "first_name": "Анна"
        ///     "last_name": "Салтова"
        ///     "birthdate": "28.04.2000"
        ///     "gender": "Женский"
        ///     "profile_picture": "ссылка на фото в фаловой системе"
        ///     "bio": "Привет, меня зовут Анна, я профессиональная пианистка"
        ///     "created_at": "2023-10-05 14:30:45.123456"
        ///     "Updated_at": "2023-10-05 14:30:45.123456"
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<User>();
            await _userService.Create(userDto);
            return Ok();
        }

        /// <summary>
        /// Обновление данных о пользователях
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _userService.Update(user);
            return Ok();
        }

        /// <summary>
        /// удаление данных о пользователе
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}