using System;
using System.Collections.Generic;
using Uyflix.Domain;
using Uyflix.IDataAccess;
using Uyflix.Exceptions;
using Uyflix.IBusinessLogic;

namespace Uyflix.BusinessLogic
{
    public class DocumentariesService : IDocumentariesService
    {
        private readonly IDocumentariesManagement documentariesManagement;
        public DocumentariesService(IDocumentariesManagement documentariesManagement)
        {
            this.documentariesManagement = documentariesManagement;
        }

        public IEnumerable<Documentary> GetDocumentaries()
        {
            return documentariesManagement.GetDocumentaries();
        }

        public Documentary GetDocumentaryById(int id)
        {
            Documentary documentary = documentariesManagement.GetDocumentaryById(id);
            if (documentary == null)
            {
                throw new NotFoundException("El documental no existe");
            }
            return documentary;
        }

        public Documentary InsertDocumentary(Documentary documentary)
        {
            if (IsDocumentaryValid(documentary))
            {
                documentariesManagement.InsertDocumentary(documentary);
            }
            return documentary;
        }

        public Documentary UpdateDocumentary(Documentary documentaryToUpdate)
        {
            if (IsDocumentaryValid(documentaryToUpdate))
            {
                Documentary documentary = documentariesManagement.GetDocumentaryById(documentaryToUpdate.Id);
                if (documentary == null)
                {
                    throw new NotFoundException("El documental no existe");
                }
                documentariesManagement.UpdateDocumentary(documentaryToUpdate);
            }
            return documentaryToUpdate;
        }

        public void DeleteDocumentary(int id)
        {
            Documentary documentaryToDelete = documentariesManagement.GetDocumentaryById(id);
            if (documentaryToDelete == null)
            {
                throw new NotFoundException("El documental no existe");
            }
            documentariesManagement.DeleteDocumentary(documentaryToDelete);
        }

        private bool IsDocumentaryValid(Documentary documentary)
        {
            if (documentary == null)
            {
                throw new BusinessLogicException("Documental inválido");
            }
            if (documentary.Name == null || documentary.Name == "")
            {
                throw new BusinessLogicException("Debe ingresar un nombre");
            }

            return true;
        }
    }
}
