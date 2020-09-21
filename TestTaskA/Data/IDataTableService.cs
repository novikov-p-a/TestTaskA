using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTaskA.Data
{
    public interface IDataTableService
    {
        Task<DataTable> GetDataTableAsync(string pthurl, string pthparname, int nTestRows);
    }
}