using System.ComponentModel.DataAnnotations;
using BI_Contacts_Service.DataBase;
using BI_Contacts_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BI_Contacts_Service.Controllers
{
    public class ContactTypesController : ODataController
    {
        private readonly Context _context;

        public ContactTypesController(Context context)
        {
            _context = context;
        }


        [EnableQuery(PageSize = 10, MaxExpansionDepth = 4)]
        public IActionResult Get()
        {
            return Ok(_context.ContactTypes.OrderBy(p => p.Type));
        }

        public IActionResult Post([FromBody] ContactTypes contactTypes)
        {
            if (ModelState.IsValid)
            {
                _context.ContactTypes.Add(contactTypes);
                _context.SaveChanges();
                return Created(contactTypes);
            }
            string validationErrors = string.Empty;
            foreach (var modelError in ModelState)
            {
                foreach (var error in modelError.Value.Errors)
                {
                    validationErrors = validationErrors + " " + error.ErrorMessage;
                }
            }
            throw new Exception(validationErrors);
        }

        public IActionResult Put(int key, [FromBody] ContactTypes contactTypes)
        {
            var isExistContactTypes = _context.ContactTypes.Where(p => p.Type == key).Any();
            if (!isExistContactTypes)
            {
                return NotFound($"Not found ContactTypes with id = {key}");
            }
            if (ModelState.IsValid)
            {
                _context.Entry(contactTypes).State = EntityState.Modified;
                _context.SaveChanges();
                return Updated(contactTypes);
            }
            string validationErrors = string.Empty;
            foreach (var modelError in ModelState)
            {
                foreach (var error in modelError.Value.Errors)
                {
                    validationErrors = validationErrors + " " + error.ErrorMessage;
                }
            }
            throw new Exception(validationErrors);
        }

        public IActionResult Delete(int key)
        {
            var original = _context.ContactTypes.FirstOrDefault(p => p.Type == key);
            if (original == null)
            {
                return NotFound($"Not found ContactTypes with id = {key}");
            }
            
            _context.ContactTypes.Remove(original);
            _context.SaveChanges();
            return Ok();
        }
    }
}

