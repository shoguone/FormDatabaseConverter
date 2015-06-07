using FormDatabaseConverter.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormDatabaseConverter.Utility
{
    public static class TablesEquality
    {
        public static bool Equals(this ChosenRecruit e, KN_P entity, int number, int year)
        {
            return (
                e.LastName.Equals(entity.FAM) &&
                e.FirstName.Equals(entity.IM) &&
                e.MiddleName.Equals(entity.OTCH) &&
                e.BirthDate.Equals(DateTime.Parse(entity.D_ROD)) &&
                e.Department.NameFull.Equals(entity.RVK) &&
                e.Destination.Equals(entity.KUDA) &&
                e.Patron.Equals(entity.KTO) &&
                e.Season.Year == year &&
                e.Season.Number == number
                );
        }

    }
}
