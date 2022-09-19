using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Data.Entity.Base
{
    public interface IBaseEntity
    {
        object Id { get; set; }
    }
    internal interface IBaseEntity<T> : IBaseEntity
    {
        new T Id { get; set; }
    }
}
