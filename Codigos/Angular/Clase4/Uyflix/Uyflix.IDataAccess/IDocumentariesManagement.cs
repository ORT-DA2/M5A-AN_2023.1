using System;
using System.Collections.Generic;
using Uyflix.Domain;

namespace Uyflix.IDataAccess
{
    public interface IDocumentariesManagement
    {
        IEnumerable<Documentary> GetDocumentaries();
        void InsertDocumentary(Documentary documentary);
        Documentary GetDocumentaryById(int id);
        void DeleteDocumentary(Documentary documentary);
        void UpdateDocumentary(Documentary documentary);
    }
}
