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


        // Post Method
        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto) 
        {
            var stockModel = stockDto.ToStockFromCreateDto();
            _Context.Stocks.Add(stockModel);
            _Context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());

        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id , [FromBody] UpdateStockRequestDto updateDto)
        {
            var stockModel = _Context.Stocks.FirstOrDefault(s => s.Id == id);

            if(stockModel == null) 
            {
                return NotFound();
            }

            stockModel.Symbol = updateDto.Symbol;
            stockModel.Purchase = updateDto.Purchase;
            stockModel.MarketCap = updateDto.MarketCap;
            stockModel.LastDiv = updateDto.LastDiv;
            stockModel.CompanyName = updateDto.CompanyName;
            stockModel.Industry = updateDto.Industry;

            _Context.SaveChanges();

            return Ok(stockModel.ToStockDto() );

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id) 
        {
            var stockModel = _Context.Stocks.FirstOrDefault(x => x.Id == id);

            if (stockModel == null)
            {
                return NotFound();
            }

            _Context.Stocks.Remove(stockModel);
            _Context.SaveChanges();
            return NoContent();

        }

    }
}
