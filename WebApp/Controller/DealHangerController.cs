﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Constants;
using WebApp.Core.Models.DeadHangerModels;
using WebApp.Repository.Entities;
using WebApp.Service.IServices;
using WebApp.Service.Services;

namespace WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealHangerController : ControllerBase
    {
        private readonly IDealHangerService _iDealHangerService;
        public DealHangerController(IDealHangerService iDealHangerService)
        {
            _iDealHangerService = iDealHangerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _iDealHangerService.GetAllDealhangers();

            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var dealHanger = await _iDealHangerService.GetDealHangerById(id);
            if (dealHanger == null)
            {
                return NotFound();
            }
            return Ok(dealHanger);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DealHangerModel dealHanger)
        {
            var createdDealHangerId = await _iDealHangerService.CreateDealHanger(dealHanger);
            return CreatedAtAction(nameof(GetById), new { id = createdDealHangerId }, new { Id = createdDealHangerId });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, DealHanger dealHanger)
        {
            if (id != dealHanger.Id)
            {
                return BadRequest();
            }

            var result = await _iDealHangerService.UpdateDealHanger(dealHanger);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [Route(WebApiEndpoint.DealHanger.RaisePrice)]
        [HttpPost]
        public async Task<IActionResult> StartAuction(DealHangerModel request)
        {
            try
            {
                string result = await _iDealHangerService.StartAuction(request);
                return Ok(result); // Return success message
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Return error message
            }

        }

        [HttpGet("Customer{id}")]
        public async Task<IActionResult> GetByCustomerId(string id)
        {
            var dealHanger = await _iDealHangerService.GetByCustomerId(id);
            if (dealHanger == null)
            {
                return NotFound();
            }
            return Ok(dealHanger);
        }
    }
}