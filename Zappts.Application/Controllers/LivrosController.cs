using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zappts.Domain.Entities;
using Zappts.Domain.Interfaces;
using Zappts.Domain.Returns;
using Zappts.Infra.Data.Context;
using Zappts.Service.Validators;

namespace Zappts.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {

        private readonly IBaseService<Livros> _baseService;
        ReturnResponse r = new ReturnResponse();

        public LivrosController(IBaseService<Livros> baseService)
        {
            _baseService = baseService;
        }
        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();


                if (result is string[])
                {
                    r.Success = false;
                }

                r.Result = result;
                return Ok(r);


            }
            catch (Exception ex)
            {
                r.Success = false;
                r.Result = ex.Message;

            }

            return Ok(r);
        }

        [HttpGet]
        public IActionResult Get() => Execute(() => _baseService.Get());


        [HttpGet("{id}")]
        public IActionResult Get(Guid id) =>  Execute(() => _baseService.GetById(id));

        [HttpPost]
        public IActionResult Create(Livros entity)
        {
            if (entity == null) return BadRequest("Parametro nullo");
            
            return Execute(() => _baseService.Add<LivrosValidator>(entity));
        }

        [HttpPut]
        public IActionResult Update(Livros entity)
        {
            if (entity == null) return BadRequest("Parametro nullo");

            return Execute(() => _baseService.Update<LivrosValidator>(entity));
        }
    }
}
