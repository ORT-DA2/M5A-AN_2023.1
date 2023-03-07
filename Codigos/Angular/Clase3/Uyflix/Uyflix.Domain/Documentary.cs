using System;
namespace Uyflix.Domain
{
    public class Documentary
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Documentary() { }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Documentary documentary = obj as Documentary;
            if (documentary == null)
            {
                return false;
            }
            return this.Id == documentary.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
