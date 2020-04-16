using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dkwebapp.api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace dkwebapp.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController: ControllerBase
    {
        private datacontext _context;
         public  ValuesController(datacontext context)
         {
            
            _context=context;
         }
        [HttpGet]
        public IActionResult Get()
        {
             
            //throw new Exception("test exception");
            var objvalues= _context.values.ToList();
            //if(objvalues != null)
            //{
            throw new Exception("dk custom exception");
           // }
            return Ok(objvalues);
            
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var objvalue=_context.values.FirstOrDefault(x => x.id==id);
            return Ok(objvalue);
        }



        
    }
}