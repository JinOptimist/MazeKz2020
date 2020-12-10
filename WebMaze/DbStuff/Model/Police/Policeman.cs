namespace WebMaze.DbStuff.Model.Police
{
    public class Policeman : BaseModel
    {
        public CitizenUser User { get; set; }
        public bool Confirmed { get; set; }
    }
}
