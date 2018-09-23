using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace PM.Classes
{
    public interface IReader<T> : IDisposable, IEnumerable<T>
    {
        T Current { get; }
        bool Read();
        void Close();
        List<T> ToList();
        DataTable ToDataTable();
    }
}
