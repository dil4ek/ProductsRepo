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
    public class ProductsController : ApiController
    {
        private static readonly TextProductsRepositoy prodcutRepo = new TextProductsRepositoy();

        // GET: api/Products
        public IEnumerable<Products> Get()
        {
            return prodcutRepo.GetAll().AsQueryable();
        }

        // GET: api/Products/5
        public Products Get(string id)
        {
            Products product = prodcutRepo.GetById(id);
            if (product == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No product with ID = {0}", id)),
                    ReasonPhrase = "Product ID Not Found"
                };
                throw new HttpResponseException(resp);
                //throw new HttpResponseException(HttpStatusCode.NotFound);         
            }

            return product;          
        }

        public IEnumerable<Products> Get(string idCategory, string nameCategory)
        {
            IEnumerable<Products> product = prodcutRepo.GetProduct(idCategory, nameCategory);
            if (product == null)
            {
              throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return product;
        }

        // POST: api/Products
        public Products Post(Products value)
        {
            var item = prodcutRepo.Add(value);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return item;
        }

        // PUT: api/Products/5
        public void Put(Products value)
        {
            prodcutRepo.UpdateItem(value);
        }

        // DELETE: api/Products/5
        public void Delete(string id)
        {
            prodcutRepo.Delete(id);
        }
    }
}
