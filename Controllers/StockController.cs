using FinShark.api.Data;
using FinShark.api.Dtos.Stock;
using FinShark.api.Mappers;
using Microsoft.AspNetCore.Mvc;
using System;


namespace FinShark.api.Controllers
{
    [Route("api/stock")]
    [ApiController]

    public class StockController : ControllerBase
    {
        private readonly ApplicationDBContext _Context;
        public StockController(ApplicationDBContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var stock = _Context.Stocks.ToList()
                .Select(s => s.ToStockDto());
            return Ok(stock);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _Context.Stocks.Find(id);

            if (stock == null)
            {
                return NotFound();
            }


            return Ok(stock.ToStockDto());   
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto) 
        {
            var stockModel = stockDto.ToStockFromCreateDto();
            _Context.Stocks.Add(stockModel);
            _Context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());

        }


    }
}
