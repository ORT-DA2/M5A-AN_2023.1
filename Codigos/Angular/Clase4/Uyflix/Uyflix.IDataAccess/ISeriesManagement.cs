using System;
using System.Collections.Generic;
using Uyflix.Domain;

namespace Uyflix.IDataAccess
{
    public interface ISeriesManagement
    {
        IEnumerable<Series> GetSeries();
        void InsertSeries(Series series);
        Series GetSeriesById(int id);
        void DeleteSeries(Series series);
        void UpdateSeries(Series series);
    }
}
