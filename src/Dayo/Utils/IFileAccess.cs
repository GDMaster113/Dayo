using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayo.Utils
{
    public interface IFileAccess
    {
        bool Exists(string path);
        string ReadAllText(string path);
        void WriteAllText(string path, string contents);
        string[] ReadAllLines(string path);
        void WriteAllLines(string path, IEnumerable<string> contents);
    }
}
