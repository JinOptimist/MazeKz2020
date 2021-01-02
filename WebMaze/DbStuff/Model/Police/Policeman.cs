namespace WebMaze.DbStuff.Model.Police
{
    public class Policeman : BaseModel
    {
        public virtual CitizenUser User { get; set; }
        
        public string Rank { get; set; }
    }
}
