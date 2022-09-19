using CardProject.Data.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Data.Entity.Card.Debit
{
    public class DebitCard: BaseEntity<Guid>
    {
        public string Bill { get; set; }

    }
}
