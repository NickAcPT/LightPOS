using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NickAc.LightPOS.Backend.Mapping
{
    //Class taken from StackOverflow (https://stackoverflow.com/a/38870091).
    //All credits go to mdameer(https://stackoverflow.com/users/6327884/mdameer)
    public class NotLazyAttribute : Attribute
    {
    }

    public class ReferenceConvention : IReferenceConvention, IReferenceConventionAcceptance, IHasManyConvention, IHasManyConventionAcceptance
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.Fetch.Join();
        }

        public void Accept(IAcceptanceCriteria<IManyToOneInspector> criteria)
        {
            criteria.Expect(x => x.Property != null && x.Property.MemberInfo.GetCustomAttributes(typeof(NotLazyAttribute), false).Any());
        }

        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Fetch.Select();
        }

        public void Accept(IAcceptanceCriteria<IOneToManyCollectionInspector> criteria)
        {
            criteria.Expect(x => x.Member != null && x.Member.IsDefined(typeof(NotLazyAttribute), false));
        }
    }
}
