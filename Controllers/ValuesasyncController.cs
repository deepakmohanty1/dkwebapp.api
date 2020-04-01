using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dkwebapp.api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace dkwebapp.api.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesasyncController: ControllerBase
    {
        private datacontext _context;
         public  ValuesasyncController(datacontext context)
         {
            _context=context;
         }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //throw new Exception("test exception");
            var objvalues=await _context.values.ToListAsync();
            return Ok(objvalues);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var objvalue=await _context.values.FirstOrDefaultAsync(x => x.id==id);
            return Ok(objvalue);
        }
    }
}