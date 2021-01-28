using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Medicine;

namespace WebMaze.DbStuff.Repository.MedicineRepo
{
    public class ReceptionOfPatientsRepository : BaseRepository<ReceptionOfPatients>
    {
        public ReceptionOfPatientsRepository(WebMazeContext context) : base(context) { }

        
    }
}
