#region

using System.Runtime.Serialization;
using UNWomen.Common.Contracts;

#endregion

namespace UNWomen.Common
{
    [DataContract]
    public abstract class EntityBase : IEntityBase, IExtensibleDataObject
    {
        #region IExtensibleDataObject Members

        /// <summary>
        ///     Gets or sets the structure that contains extra data.
        /// </summary>
        /// <value>The extension data.</value>
        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
    }
}