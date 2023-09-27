﻿using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

internal class ReactorMapping : BaseMapWithName<ReactorModel>
{
    public ReactorMapping() : base("ShipReactors")
    {
        Map(x => x.Cost);
        Map(x => x.FuelUseModifier);
        Map(x => x.PowerDiceRecovery);
    }
}
