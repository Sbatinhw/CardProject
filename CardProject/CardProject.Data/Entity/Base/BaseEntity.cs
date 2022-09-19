using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardProject.Data.Entity.Base;

namespace CardProject.Data.Entity.Entity
{
    public abstract class BaseEntity<T>: IBaseEntity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        object IBaseEntity.Id
        {
            get { return Id; }
            set { Id = (T)value; }
        }
    }
}
