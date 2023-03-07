using System;
namespace Uyflix.Domain
{
    public class Series
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public Series() { }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Series series = obj as Series;
            if (series == null)
            {
                return false;
            }
            return this.Id == series.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
