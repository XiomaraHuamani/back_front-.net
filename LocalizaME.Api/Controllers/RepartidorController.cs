﻿using System;
using LocalizaME.Dto.Request;
using LocalizaME.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalizaME.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepartidorController : ControllerBase
    {
        private readonly IRepartidorService _service;
        private readonly ILogger<RepartidorController> _logger;

        public RepartidorController(IRepartidorService service, ILogger<RepartidorController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAsync());
        }

        // GET: api/Producto/{id:int}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _service.GetAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RepartidorDtoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }

            return Ok(await _service.AddAsync(request));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] RepartidorDtoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }

            return Ok(await _service.UpdateAsync(id, request));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteAsync(id));
        }
    }
}

