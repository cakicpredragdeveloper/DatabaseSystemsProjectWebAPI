using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.Entities;
using FluentNHibernate.Mapping;

namespace DatabaseAccess.Mappings
{
    class JeSazvaloMap: ClassMap<JeSazvalo>
    {
        public JeSazvaloMap()
        {
            Table("JE_SAZVALO");

            Id(x => x.Id).GeneratedBy.TriggerIdentity();

            References(x => x.NarodniPoslanik).Column("NARODNI_POSLANIK_ID");
            References(x => x.Sednica).Column("SEDNICA_ID");
        }
    }
}