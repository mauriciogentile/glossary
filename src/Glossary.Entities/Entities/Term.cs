using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Company.Glossary.Entities
{
    public class Term : BaseEntity
    {
        public string Name { get; set; }
        public string Definition { get; set; }
    }
}
