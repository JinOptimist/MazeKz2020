using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.DbStuff.Model.Medicine
{
    public class RecordForm : BaseModel
    {
        public virtual string Name { get; set; }

        public virtual string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public virtual string PhoneNumber { get; set; }
    }
}
