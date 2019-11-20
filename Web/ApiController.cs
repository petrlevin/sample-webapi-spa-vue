using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Common;


namespace Web
{
    public class ApiController<T>: ApiController
    {

        private readonly IRepository<T> _repository;

        public ApiController(IRepository<T> repository)
        {
            _repository = repository;
        }

        // GET api/values
        public IEnumerable<T> Get()
        {
            return _repository.GetAll();
        }

        // GET api/values/5
        public T Get(int id)
        {
            return _repository.Get(id);
        }

        // POST api/values
        public void Post([FromBody]T value)
        {
            _repository.Update(value);
        }

        // PUT api/values
        public int Put([FromBody]T value)
        {
            return _repository.Add(value);
        }

        
        // DELETE api/values/5
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
