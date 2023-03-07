using System;
using System.Collections.Generic;
using Uyflix.Domain;

namespace Uyflix.IBusinessLogic
{
    public interface IDocumentariesService
    {
        IEnumerable<Documentary> GetDocumentaries();
        Documentary GetDocumentaryById(int id);
        Documentary InsertDocumentary(Documentary documentary);
        Documentary UpdateDocumentary(Documentary documentary);
        void DeleteDocumentary(int id);
    }
}
