using System;
using System.ComponentModel;
using System.Formats.Asn1;
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RVezy.WebAPI.Domain.Enums;
using RVezy.WebAPI.Domain.Models;
using RVezy.WebAPI.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RVezy.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CSVController : ControllerBase
    {
        private readonly string _csvFilePath = "listings.csv";

        private readonly CSVParseService _parse;

        public CSVController(CSVParseService parse)
        {
            _parse = parse;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get(int page = 1, int pageSize = 10)
        {
            var result = _parse.ToListingModel(_csvFilePath);
            var totalItems = result.Count;
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var paginatedBooks = result.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var response = new
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                Page = page,
                PageSize = pageSize,
                Items = paginatedBooks
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _parse.ToListingModel(_csvFilePath)
                .Where(b => b.Id == id)
                .ToList();

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("GetByProperty")]
        public IActionResult GetByPropertyType(string propertyType, int page = 1, int pageSize = 10)
        {
            var result = _parse.ToListingModel(_csvFilePath)
                .Where(b => b.PropertyType.Equals(propertyType, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var totalItems = result.Count;
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var paginatedBooks = result.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var response = new
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                Page = page,
                PageSize = pageSize,
                Items = paginatedBooks
            };
            return Ok(response);
        }
    }
}

