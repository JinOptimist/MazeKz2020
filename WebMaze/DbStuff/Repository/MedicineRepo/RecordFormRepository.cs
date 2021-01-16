using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Medicine;

namespace WebMaze.DbStuff.Repository.MedicineRepository
{
    public class RecordFormRepository : BaseRepository<RecordForm>
    {
        public RecordFormRepository(WebMazeContext context) : base(context) { }

        
    }
}
