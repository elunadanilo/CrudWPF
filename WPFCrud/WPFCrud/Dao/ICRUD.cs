using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCrud.Utils;

namespace WPFCrud.Dao
{
    interface ICRUD<T>
    {
        OperationResponse GetAll();
        Task<OperationResponse> Delete(int id);
        Task<OperationResponse> Add(T obj);
        Task<OperationResponse> Update(T obj);

        OperationResponse Get(int id);
    }
}
