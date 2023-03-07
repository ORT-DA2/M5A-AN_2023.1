using System;
using System.Collections.Generic;
using System.Text;
using Uyflix.Domain.Entities;

namespace Uyflix.Domain.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryModel() { }
        public CategoryModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }
        public Category ToEntity()
        {
            return new Category
            {
                Id = this.Id,
                Name = this.Name,
            };
        }
    }
}
