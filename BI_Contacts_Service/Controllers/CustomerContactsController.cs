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
    public class CustomerContactsController : ODataController
    {
        private readonly Context _context;

        public CustomerContactsController(Context context)
        {
            _context = context;
        }


        [EnableQuery(PageSize = 10, MaxExpansionDepth = 4)]
        public IActionResult Get()
        {
            return Ok(_context.CustomerContacts.OrderBy(p => p.ContactID));
        }

        public IActionResult Post([FromBody] CustomerContacts CustomerContacts)
        {
            if (ModelState.IsValid)
            {
                _context.CustomerContacts.Add(CustomerContacts);
                _context.SaveChanges();
                return Created(CustomerContacts);
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

        public IActionResult Put(int key, [FromBody] CustomerContacts CustomerContacts)
        {
            var isExistCustomerContacts = _context.CustomerContacts.Where(p => p.ContactID == key).Any();
            if (!isExistCustomerContacts)
            {
                return NotFound($"Not found CustomerContacts with id = {key}");
            }
            if (ModelState.IsValid)
            {
                _context.Entry(CustomerContacts).State = EntityState.Modified;
                _context.SaveChanges();
                return Updated(CustomerContacts);
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
            var original = _context.CustomerContacts.FirstOrDefault(p => p.ContactID == key);
            if (original == null)
            {
                return NotFound($"Not found CustomerContacts with id = {key}");
            }
            
            _context.CustomerContacts.Remove(original);
            _context.SaveChanges();
            return Ok();
        }
    }
}

