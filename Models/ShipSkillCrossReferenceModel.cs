using Models.BaseModels;

namespace Models;

public class ShipSkillCrossReferenceModel : BaseModel
{
    public virtual ShipModel Ship { get; set; }
    public virtual SkillModel Skill { get; set; }
    public virtual int Proficiency { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (ShipSkillCrossReferenceModel)obj;

        return Ship == other.Ship && Skill == other.Skill;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + (Ship != null ? Ship.GetHashCode() : 0);
            hash = hash * 23 + (Skill != null ? Skill.GetHashCode() : 0);
            return hash;
        }
    }
}
