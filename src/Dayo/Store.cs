using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayo
{
    public class Store
    {
        private const string StorageName = "DayoStore.txt";
        public void StoreMemoryList(Note note)
        {
            System.IO.File.WriteAllText(StorageName, note.Content);
        }

        public Note ReadMemoryList()
        {
            if (System.IO.File.Exists(StorageName))
            {
                return new Note() { Content = System.IO.File.ReadAllText(StorageName) };
            }

            return new Note();
        }
    }
}
