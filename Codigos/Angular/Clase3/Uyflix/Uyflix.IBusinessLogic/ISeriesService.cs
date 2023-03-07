using System;
using System.Collections.Generic;
using Uyflix.Domain;

namespace Uyflix.IBusinessLogic
{
    public interface ISeriesService
    {
        IEnumerable<Series> GetSeries();
        Series GetSeriesById(int id);
        Series InsertSeries(Series series);
        Series UpdateSeries(Series series);
        void DeleteSeries(int id);
    }
}
