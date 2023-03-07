using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Uyflix.Domain;
using Uyflix.IDataAccess;

namespace Uyflix.DataAccess
{
    public class SeriesManagement : ISeriesManagement
    {
        private UyflixContext UyflixContext { get; set; }
        public SeriesManagement(UyflixContext uyflixContext)
        {
            this.UyflixContext = uyflixContext;
        }

        public IEnumerable<Series> GetSeries()
        {
            return UyflixContext.Series.ToList();
        }

        public void InsertSeries(Series series)
        {
            UyflixContext.Series.Add(series);
            UyflixContext.SaveChanges();
        }

        public Series GetSeriesById(int id)
        {
            return UyflixContext.Series.Where<Series>(series => series.Id == id).AsNoTracking().FirstOrDefault();
        }

        public void DeleteSeries(Series seriesToDelete)
        {
            UyflixContext.Series.Remove(seriesToDelete);
            UyflixContext.SaveChanges();
        }

        public void UpdateSeries(Series seriesToUpdate)
        {
            UyflixContext.Series.Attach(seriesToUpdate);
            UyflixContext.Entry(seriesToUpdate).State = EntityState.Modified;
            UyflixContext.SaveChanges();
        }
    }
}
