using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SorterExpress.Controls
{
    /// <summary>
    /// A binding list that supports raising a "BeforeRemove" event, to indicate that items have been removed and shows what items they were.
    /// Some credit goes to answers in this thread: https://stackoverflow.com/q/23339233/8306962
    /// </summary>
    public class RBindingList<T> : BindingList<T>
    {
        public new void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (RaiseListChangedEvents)
                BeforeRemove?.Invoke(new T[] { base[index] });

            RemoveItem(index);
        }

        public new void Remove(T item)
        {
            if (RaiseListChangedEvents && this.Contains(item))
                BeforeRemove?.Invoke(new T[] { item });

            base.Remove(item);
        }

        /// <summary>
        /// Clear the list raising the BeforeRemove event with a list of all items currently in the list (if RaiseListChangedEvents is true).
        /// </summary>
        public new void Clear()
        {
            if (RaiseListChangedEvents)
                BeforeRemove?.Invoke(this);

            bool fireEvents = RaiseListChangedEvents;   //Remember whether or not to raise list change events.

            if (Count > 0) 
                RaiseListChangedEvents = false;         //Set raise list events to false because we only want to do it once on the last element.

            while (Count > 0)
            {
                //Raise list changed once on the last element.
                if (Count == 1)
                    RaiseListChangedEvents = fireEvents;    //Set RaiseListChangedEvents back to what it's value was at the start of this method.

                RemoveAt(0);
            }
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            bool fireEvents = RaiseListChangedEvents;

            //TODO: Can use https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.intersect later.
            List<T> intersect = new List<T>();  //Items that are in both lists.

            foreach (T item in items)
                if (this.Contains(item))
                    intersect.Add(item);

            if (RaiseListChangedEvents)
                BeforeRemove?.Invoke(intersect);

            if (intersect.Count > 0)
                RaiseListChangedEvents = false;

            for (int i = intersect.Count - 1; i >= 0; i--)
            {
                //Raise list changed once on the last element.
                if (i == 0)
                    RaiseListChangedEvents = fireEvents;

                this.Remove(intersect[i]);
                intersect.RemoveAt(i);
            }
        }

        /// <summary>
        /// Add a range of elements, raising the ListChanged event individually for each item.
        /// Accepts null, returns instantly.
        /// </summary>
        public void AddRange(IEnumerable<T> items)
        {
            if (items == null)
            {
                return;
            }

            for (int i = 0; i < items.Count(); i++)
            { 
                Add(items.ElementAt(i));
            }
        }

        public delegate void BeforeRemoveDelegate(IEnumerable<T> deletedItems);
        public event BeforeRemoveDelegate BeforeRemove;
    }
}