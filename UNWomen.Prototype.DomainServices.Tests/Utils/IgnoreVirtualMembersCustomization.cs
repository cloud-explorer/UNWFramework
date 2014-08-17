using Ploeh.AutoFixture;

namespace UNWomen.Prototype.DomainServices.Tests.Utils
{
    public class IgnoreVirtualMembersCustomization : ICustomization
    {
        #region ICustomization Members

        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new IgnoreVirtualMembers());
        }

        #endregion
    }
}