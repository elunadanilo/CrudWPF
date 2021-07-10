using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCrud.Dao;
using WPFCrud.Model;
using WPFCrud.Services;

namespace WPFCrud.ViewModels
{
    //Esta capa extra sirve para mostrar los datos tal y como lo requiere la vista, pero como es un crud sencillo se muestran las operaciones basicas de un CRUD
    class PersonViewModel2
    {
        private IPersonDao personDao = new PersonService();

        public List<person> GetAll()
        {
            var result = personDao.GetAll();

            if (result.Code == 1)
                return (List<person>)result.Data;
            else
                return new List<person>() { };
        }

        public async Task<int> AddAsync(person person)
        {
            var result = await personDao.Add(person);

            return result.Code;
        }

        public async Task<int> delete(int id)
        {
            var result = await personDao.Delete(id);

            return result.Code;
        }

        public async Task<int> updateAsync(person person)
        {
            var result = await personDao.Update(person);

            return result.Code;
        }

        public person GetOne(int id)
        {
            var result = personDao.Get(id);

            if (result.Code == 1)
                return (person)result.Data;
            return new person();
        }
    }
}
