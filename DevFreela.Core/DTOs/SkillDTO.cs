namespace DevFreela.Core.DTOs
{
    public class SkillDto
    {
        public SkillDto(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}