using Dayo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dayo
{
    class NoteStorage : IStore
    {
        private const string StorageName = "NewDayoStore.txt";

        private readonly IFileAccess fileAccess;

        public NoteStorage(IFileAccess fileAccess)
        {
            this.fileAccess = fileAccess;
        }

        public Note ReadMemoryList()
        {
            if(fileAccess.Exists(StorageName))
            {
                string[] noteLines = fileAccess.ReadAllLines(StorageName);
                string title = noteLines[0];
                StringBuilder builder = new StringBuilder();
                for (int i = 1; i < noteLines.Length -1; i++)
                {
                    builder.Append(noteLines[i] + "\n");
                }
                builder.Append(noteLines[noteLines.Length - 1]);
                string content = builder.ToString();
                return new Note() { Title = title, Content = content };
            }

            return new Note();
        }

        public void StoreMemoryList(Note note)
        {
            fileAccess.WriteAllLines(StorageName, new List<string>() { note.Title, note.Content });
        }
    }
}
