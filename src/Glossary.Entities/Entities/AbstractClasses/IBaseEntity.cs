using System;
namespace Company.Glossary.Entities
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        bool Active { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }
}
