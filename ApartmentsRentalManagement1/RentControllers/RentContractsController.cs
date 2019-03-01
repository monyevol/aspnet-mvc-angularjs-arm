using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApartmentsRentalManagement1.Models;

namespace ApartmentsRentalManagement1.RentControllers
{
    public class RentContractsController : ApiController
    {
        private RentManagementModel db = new RentManagementModel();

        // GET: api/RentContracts
        public IQueryable<RentContract> GetRentContracts()
        {
            return db.RentContracts;
        }

        // GET: api/RentContracts/5
        [ResponseType(typeof(RentContract))]
        public IHttpActionResult GetRentContract(int id)
        {
            RentContract rentContract = db.RentContracts.Find(id);
            if (rentContract == null)
            {
                return NotFound();
            }

            return Ok(rentContract);
        }

        // PUT: api/RentContracts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRentContract(int id, RentContract rentContract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rentContract.RentContractId)
            {
                return BadRequest();
            }

            db.Entry(rentContract).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentContractExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RentContracts
        [ResponseType(typeof(RentContract))]
        public IHttpActionResult PostRentContract(RentContract rentContract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RentContracts.Add(rentContract);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rentContract.RentContractId }, rentContract);
        }

        // DELETE: api/RentContracts/5
        [ResponseType(typeof(RentContract))]
        public IHttpActionResult DeleteRentContract(int id)
        {
            RentContract rentContract = db.RentContracts.Find(id);
            if (rentContract == null)
            {
                return NotFound();
            }

            db.RentContracts.Remove(rentContract);
            db.SaveChanges();

            return Ok(rentContract);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentContractExists(int id)
        {
            return db.RentContracts.Count(e => e.RentContractId == id) > 0;
        }
    }
}