using Models.BaseModels;

namespace Models;

public class ShipModel : BaseModelWithName
{
    public virtual SizeModel Size { get; set; }
    public virtual ArmorModel Armor { get; set; }
    public virtual ShieldModel Shield { get; set; }
    public virtual ReactorModel Reactor { get; set; }
    public virtual PowerCouplingModel PowerCoupling { get; set; }
    public virtual int Tier { get; set; }
    public virtual int Strength { get; set; }
    public virtual int Dexterity { get; set; }
    public virtual int Constitution { get; set; }
    public virtual int Intelligence { get; set; }
    public virtual int Wisdom { get; set; }
    public virtual int Charisma { get; set; }
    public virtual int RolledHitPoints { get; set; }
    public virtual int CurrentHitPoints { get; set; }
    public virtual int TemporaryHitPoints { get; set; }
    public virtual int RolledShieldPoints { get; set; }
    public virtual int CurrentShieldPoints { get; set; }
    public virtual int TemporaryShieldPoints { get; set; }
    public virtual IEnumerable<FeatureModel> InstalledFeatures { get; set; }
    public virtual IEnumerable<WeaponModel> Weapons { get; set; }
    public virtual IEnumerable<ShipAmmunitionCrossReferenceModel> AmmunitionCrossReference { get; set; }
    public virtual IEnumerable<ShipSkillCrossReferenceModel> SkillCrossReference { get; set; }
}
