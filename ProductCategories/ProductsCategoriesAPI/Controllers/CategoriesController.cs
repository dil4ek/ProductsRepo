using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BusinessLogic;
using BusinessLogic.Repositories;
using BusinessLogic.ConectToDB;

namespace ProductsCategoriesAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        private TextCategoriesRepositoy categoryRepo = new TextCategoriesRepositoy();

        // GET: api/Categories
        public IEnumerable<Categories> Get()
        {
            return categoryRepo.GetAll();
        }

        // GET: api/Categories/5
        public Categories Get(string id)
        {
            Categories category = new Categories();
            category = categoryRepo.GetById(id);

            //if not faound search by name
            if (category == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);  
            }

            return category;
        }

        // POST: api/Categories
        public Categories Post(Categories value)
        {
            return categoryRepo.Add(value);
        }

        // PUT: api/Categories/5
        public void Put(Categories value)
        {
            categoryRepo.UpdateItem(value);
        }

        // DELETE: api/Categories/5
        public void Delete(string id)
        {
            categoryRepo.Delete(id);
        }
    }
}
