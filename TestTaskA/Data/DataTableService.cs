using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace TestTaskA.Data
{
    public class DataTableService : IDataTableService
    {
        public Task<DataTable> GetDataTableAsync(string pthurl, string pthparname, int nTestRows)
        {
            DataTable dataTable = new DataTable();
            
            string uirWebAPI = pthurl + "?" + pthparname + "=" + nTestRows.ToString();
            string exceptionMessage = string.Empty;
            string webResponse = string.Empty;
            try
            {
                Uri uri = new Uri(uirWebAPI);
                WebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.Method = "GET";               
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    webResponse = streamReader.ReadToEnd();
                }
                dataTable.content = webResponse;
            }
            catch (Exception ex)
            {
                exceptionMessage = $"An error occurred. {ex.Message}";
                dataTable.errorMessage = exceptionMessage;
            }

            return Task.FromResult(dataTable);
        }
    }
}
