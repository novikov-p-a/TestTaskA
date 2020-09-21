using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestTaskA.Model
{
    public class TestResults
    {
        public List<string> Cols { get; set; }
        public List<List<float>> Rows { get; set; }
        public bool IsReady { get; set; } = false;

        public TestResults()
        {
            IsReady = false;
            Cols = new List<string>();
            Rows = new List<List<float>>();
        }

        public TestResults(string json_str)
        {
            GetFrom(json_str);
        }

        public TestResults(TestResults testResults, int nFirstTestRows)
        {
            GetFrom(testResults, nFirstTestRows);
        }

        public void Reset()
        {
            IsReady = false;
            Cols.Clear();
            Rows.Clear();
        }

        public void GetFrom(TestResults testResults, int nFirstTestRows)
        {
            try
            {
                Cols = new List<string>(testResults.Cols);
            }
            catch
            {
                Cols = new List<string>();
            }

            try
            {
                Rows = new List<List<float>>(testResults.Rows.Take(nFirstTestRows));
            }
            catch
            {
                Rows = new List<List<float>>();
            }

            IsReady = true;
        }

        public void GetFrom(string json_str)
        {
            try
            {
                dynamic dyn = JsonConvert.DeserializeObject(json_str);

                Cols = new List<string>();
                foreach (var c in dyn.cols)
                {
                    Cols.Add(c.Value);
                }

                Rows = new List<List<float>>();
                foreach (var r in dyn.rows)
                {
                    List<float> rlist = new List<float>();
                    foreach (var d in r)
                    {
                        rlist.Add((float)(d.Value));

                    }
                    Rows.Add(rlist);
                }
            }
            catch
            {
                Cols = new List<string>();
                Rows = new List<List<float>>();
            }

            IsReady = true;
        }
    }
}
