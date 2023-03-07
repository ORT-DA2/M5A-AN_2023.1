using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Uyflix.Domain;
using Uyflix.IDataAccess;

namespace Uyflix.DataAccess
{
    public class DocumentariesManagement : IDocumentariesManagement
    {
        private UyflixContext UyflixContext { get; set; }
        public DocumentariesManagement(UyflixContext uyflixContext)
        {
            this.UyflixContext = uyflixContext;
        }

        public IEnumerable<Documentary> GetDocumentaries()
        {
            return UyflixContext.Documentaries.ToList();
        }

        public void InsertDocumentary(Documentary documentary)
        {
            UyflixContext.Documentaries.Add(documentary);
            UyflixContext.SaveChanges();
        }

        public Documentary GetDocumentaryById(int id)
        {
            return UyflixContext.Documentaries.Where<Documentary>(documentary => documentary.Id == id).AsNoTracking().FirstOrDefault();
        }

        public void DeleteDocumentary(Documentary documentaryToDelete)
        {
            UyflixContext.Documentaries.Remove(documentaryToDelete);
            UyflixContext.SaveChanges();
        }

        public void UpdateDocumentary(Documentary documentaryToUpdate)
        {
            UyflixContext.Documentaries.Attach(documentaryToUpdate);
            UyflixContext.Entry(documentaryToUpdate).State = EntityState.Modified;
            UyflixContext.SaveChanges();
        }
    }
}
