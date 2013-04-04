using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Company.Glossary.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        protected BaseEntity()
        {
            Active = true;
            CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
