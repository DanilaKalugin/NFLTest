namespace Entities.Tables
{
    public class NationalDivision
    {
        public byte DivisionId { get; set; }
        public string DivisionTitle { get; set; }
        public virtual List<Conference> Conferences { get; set; } = new();
    }
}
