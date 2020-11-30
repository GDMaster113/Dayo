using Dayo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dayo.Tests
{
    public class TestingNoteStorage
    {
        class DummyFileAccess : IFileAccess
        {
            private string[] fileLines;
            public DummyFileAccess(string fileContent)
            {
                fileLines = fileContent.Split("\n");
            }
            public bool Exists(string path)
            {
                return true;
            }

            public string[] ReadAllLines(string path)
            {
                return fileLines;
            }

            public string ReadAllText(string path)
            {
                throw new NotImplementedException();
            }

            public void WriteAllLines(string path, IEnumerable<string> contents)
            {
                throw new NotImplementedException();
            }

            public void WriteAllText(string path, string contents)
            {
                throw new NotImplementedException();
            }
        }

        [Fact]
        public void Should_read_note_file()
        {
            //Arange
            string fileContent = "Title_5\nFirstLine\nSecondLine";
            DummyFileAccess dummyFile = new DummyFileAccess(fileContent);
            NoteStorage noteStorage = new NoteStorage(dummyFile);
            //Act
            Note note = noteStorage.ReadMemoryList();
            //Assert
            Assert.Equal("Title_5", note.Title);
            Assert.Equal("FirstLine\nSecondLine", note.Content);
        }
    }
}
