using DTOs.BaseDTOs;

namespace DTOs;

public class SkillDTO : BaseDTOWithName
{
    public string Ability { get; set; }
    public int SkillId { get; set; }
    public int Proficiency { get; set; }
}
