using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCrud.Dao;
using WPFCrud.Model;
using WPFCrud.Utils;

namespace WPFCrud.Services
{
    class PersonService : IPersonDao
    {
        private WPFCrudEntities dbcontext = new WPFCrudEntities();
        public async Task<OperationResponse> Add(person obj)
        {
            try
            {
                dbcontext.person.Add(obj);

                await dbcontext.SaveChangesAsync();

                return new OperationResponse(1);
            }catch(Exception exc)
            {
                Debug.WriteLine(exc);

                return new OperationResponse(0);
            }
        }

        public async Task<OperationResponse> Delete(int id)
        {
            try
            {
                var found = dbcontext.person.SingleOrDefault(item => item.Id == id);

                dbcontext.person.Remove(found);
                await dbcontext.SaveChangesAsync();

                return new OperationResponse(1);
            }catch(Exception exc)
            {
                Debug.WriteLine(exc);

                return new OperationResponse(0);
            }
        }

        public OperationResponse Get(int id)
        {
            try
            {
                var found = dbcontext.person.Find(id);

                return new OperationResponse(1, found);
            }catch(Exception exc)
            {
                Debug.WriteLine(exc);

                return new OperationResponse(0);
            }
        }

        public OperationResponse GetAll()
        {
            try
            {
                var results = dbcontext.person.ToList();

                return new OperationResponse(1, results);
            }catch(Exception exc)
            {
                Debug.WriteLine(exc);

                return new OperationResponse(0);
            }
        }

        public async Task<OperationResponse> Update(person obj)
        {
            try
            {
                var found = dbcontext.person.Find(obj.Id);

                found.Name = obj.Name;
                found.Age = obj.Age;

                dbcontext.Entry(found).State = System.Data.Entity.EntityState.Modified;

                await dbcontext.SaveChangesAsync();

                return new OperationResponse(1);
            }catch(Exception exc)
            {
                Debug.WriteLine(exc);

                return new OperationResponse(0);
            }
        }
    }
}
