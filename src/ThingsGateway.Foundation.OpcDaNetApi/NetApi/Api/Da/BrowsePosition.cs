﻿

using System;


namespace Opc.Da
{
    [Serializable]
    public class BrowsePosition : IBrowsePosition, IDisposable, ICloneable
    {
        private bool m_disposed;
        private BrowseFilters m_filters;
        private ItemIdentifier m_itemID;

        public ItemIdentifier ItemID => m_itemID;

        public BrowseFilters Filters => (BrowseFilters)m_filters.Clone();

        public int MaxElementsReturned
        {
            get => m_filters.MaxElementsReturned;
            set => m_filters.MaxElementsReturned = value;
        }

        public BrowsePosition(ItemIdentifier itemID, BrowseFilters filters)
        {
            if (filters == null)
                throw new ArgumentNullException(nameof(filters));
            m_itemID = itemID != null ? (ItemIdentifier)itemID.Clone() : (ItemIdentifier)null;
            m_filters = (BrowseFilters)filters.Clone();
        }

        ~BrowsePosition() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (m_disposed)
                return;
            int num = disposing ? 1 : 0;
            m_disposed = true;
        }

        public virtual object Clone() => (object)(BrowsePosition)MemberwiseClone();
    }
}
