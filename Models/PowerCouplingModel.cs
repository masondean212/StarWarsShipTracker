using Models.BaseModels;

namespace Models
{
    public class PowerCouplingModel : BaseModelWithName
    {
        public virtual int Cost { get; set; }
        public virtual int CentralStorageCapacity { get; set; }
        public virtual int SystemStorageCapacity { get; set;}
    }
}
