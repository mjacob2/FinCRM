
using System.ComponentModel.DataAnnotations;


namespace FinCRM.DataAccess.Entities
{
   public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
