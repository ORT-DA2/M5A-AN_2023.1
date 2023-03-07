using System;
using System.Collections.Generic;
using Uyflix.Domain;
using Uyflix.IDataAccess;
using Uyflix.Exceptions;
using Uyflix.IBusinessLogic;

namespace Uyflix.BusinessLogic
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesManagement seriesManagement;
        public SeriesService(ISeriesManagement seriesManagement)
        {
            this.seriesManagement = seriesManagement;
        }

        public IEnumerable<Series> GetSeries()
        {
            return seriesManagement.GetSeries();
        }

        public Series GetSeriesById(int id)
        {
            Series series = seriesManagement.GetSeriesById(id);
            if (series == null)
            {
                throw new NotFoundException("La serie no existe");
            }
            return series;
        }

        public Series InsertSeries(Series series)
        {
            if (IsSeriesValid(series))
            {
                seriesManagement.InsertSeries(series);
            }
            return series;
        }

        public Series UpdateSeries(Series seriesToUpdate)
        {
            if (IsSeriesValid(seriesToUpdate))
            {
                Series series = seriesManagement.GetSeriesById(seriesToUpdate.Id);
                if (series == null)
                {
                    throw new NotFoundException("La serie no existe");
                }
                seriesManagement.UpdateSeries(seriesToUpdate);
            }
            return seriesToUpdate;
        }

        public void DeleteSeries(int id)
        {
            Series seriesToDelete = seriesManagement.GetSeriesById(id);
            if (seriesToDelete == null)
            {
                throw new NotFoundException("La serie no existe");
            }
            seriesManagement.DeleteSeries(seriesToDelete);
        }

        private bool IsSeriesValid(Series series)
        {
            if (series == null)
            {
                throw new BusinessLogicException("Serie inválida");
            }
            if (series.Name == null || series.Name == "")
            {
                throw new BusinessLogicException("Debe ingresar un nombre");
            }
            if (series.Category == null || series.Category == "")
            {
                throw new BusinessLogicException("Debe ingresar una categoría");
            }

            return true;
        }
    }
}
