using Dayo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayo
{
    public class RawFileStore : IStore
    {
        private readonly IFileAccess fileAccess;

        public RawFileStore(IFileAccess fileAccess)
        {
            this.fileAccess = fileAccess;
        }


        private const string StorageName = "DayoStore.txt";
        public void StoreMemoryList(Note note)
        {
            fileAccess.WriteAllText(StorageName, note.Content);
        }

        public Note ReadMemoryList()
        {
            if (fileAccess.Exists(StorageName))
            {
                return new Note() { Content = fileAccess.ReadAllText(StorageName) };
            }

            return new Note();
        }
    }
}
