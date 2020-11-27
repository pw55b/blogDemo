using System;
using Blog.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
    }
}
