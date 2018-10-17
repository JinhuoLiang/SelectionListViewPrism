using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace SelectionListViewPrism
{
    /// <summary>
    /// This class is used to support multiple selection in the listview with data binding
    /// </summary>
    public class ListItem : BindableBase
    {
        private readonly Object _value;
        private bool _isSelected;

        /// <summary>
        /// Constructor with data object.
        /// </summary>
        /// <param name="value">Data object</param>
        public ListItem(Object value)
        {
            _value = value;
        }

        /// <summary>
        /// Text of list item in the listview
        /// </summary>
        /// <returns>Name of the data object</returns>
        public override string ToString()
        {
            return _value.ToString();
        }

        /// <summary>
        /// Data binding to selected/unselected list item
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                SetProperty(ref _isSelected, value);
            }
        }
    }

    public class ListedItemCollection : BindableBase
    {
        private ObservableCollection<ListItem> m_ListItems;
        private ObservableCollection<ListItem> m_AvailableListItems;
        private ListItem m_SelectedListItem;
        private ListItem m_AvailableSelectedListItem;

        /// <summary>
        /// Constructor with a list of objects to be displayed in the list view
        /// </summary>
        /// <param name="list">A list of objects to be displayed in the list view</param>
        public ListedItemCollection(List<Object> list = null)
        {
            Objects = list;
        }

        /// <summary>
        /// Set/get all items associated with the list view
        /// </summary>
        public ObservableCollection<ListItem> ListItems
        {
            get
            {
                return m_ListItems;
            }

            set
            {
                SetProperty(ref m_ListItems, value);
            }
        }

        /// <summary>
        /// Set/get the selected item associated with the list view
        /// </summary>
        public ListItem SelectedListItem
        {
            get
            {
                return m_SelectedListItem;
            }

            set
            {
                SetProperty(ref m_SelectedListItem, value);
            }
        }

        /// <summary>
        /// Set/get all items associated with the list view
        /// </summary>
        public ObservableCollection<ListItem> AvailableListItems
        {
            get
            {
                return m_AvailableListItems;
            }

            set
            {
                SetProperty(ref m_AvailableListItems, value);
            }
        }

        /// <summary>
        /// Set/get the selected item associated with the Available list view
        /// </summary>
        public ListItem AvailableSelectedListItem
        {
            get
            {
                return m_AvailableSelectedListItem;
            }

            set
            {
                SetProperty(ref m_AvailableSelectedListItem, value);
            }
        }

        /// <summary>
        /// Set/get all objects in this list
        /// </summary>
        public List<Object> Objects
        {
            set
            {
                if (value == null)
                {
                    ListItems = null;
                    return;
                }

                m_ListItems = new ObservableCollection<ListItem>();

                foreach (var item in value)
                    m_ListItems.Add(new ListItem(item));

                ListItems = m_ListItems;
            }
        }

        /// <summary>
        /// Move the selected item up one index
        /// </summary>
        public void MoveUp()
        {
            MoveUpSelectedItems();
        }

        /// <summary>
        /// Move the selected item down one index
        /// </summary>
        public void MoveDown()
        {
            MoveDownSelectedItems();
        }

        /// <summary>
        /// Move the selected item to the top
        /// </summary>
        public void MoveTop()
        {
            MoveUpSelectedItems(-1);
        }

        /// <summary>
        /// Move the selected item to the bottom
        /// </summary>
        public void MoveBottom()
        {
            MoveDownSelectedItems(-1);
        }

        /// <summary>
        /// Move up selected items in the listview
        /// </summary>
        /// <param name="numSteps">Moving steps. -1 means to the top or bottom.</param>
        private void MoveUpSelectedItems(int numSteps = 1)
        {
            if (ListItems == null || ListItems.Count == 0)
                return;

            var selectedIndex = 0;
            var count = ListItems.Count;
            var isFirstSelected = true;

            for (int j = 0; j < count; j++)
            {
                selectedIndex = j;
                ListItem item = ListItems[selectedIndex];

                if (item.IsSelected == false)
                    continue;

                if (isFirstSelected && numSteps < 0)
                    numSteps = j;

                var destIndex = j - numSteps;
                if (destIndex < 0)
                    return;

                for (int i = 0; i < numSteps; i++)
                {
                    var itemToMoveUp = ListItems[destIndex];
                    ListItems.RemoveAt(destIndex);
                    ListItems.Insert(j, itemToMoveUp);
                }
            }
        }

        /// <summary>
        /// Move down selected items in the listview
        /// </summary>
        /// <param name="numSteps">Moving steps. -1 means to the top or bottom.</param>
        private void MoveDownSelectedItems(int numSteps = 1)
        {
            if (ListItems == null || ListItems.Count == 0)
                return;

            var selectedIndex = 0;
            var count = ListItems.Count;
            var isFirstSelected = true;

            for (int j = 0; j < count; j++)
            {
                selectedIndex = count - j - 1;
                ListItem item = ListItems[selectedIndex];

                if (item.IsSelected == false)
                    continue;

                if (isFirstSelected && numSteps < 0)
                    numSteps = j;

                var destIndex = selectedIndex + numSteps;
                if (destIndex >= count)
                    return;

                for (int i = 0; i < numSteps; i++)
                {
                    destIndex = selectedIndex + i + 1;
                    var itemToMoveUp = ListItems[destIndex];
                    ListItems.RemoveAt(destIndex);
                    ListItems.Insert(destIndex - 1, itemToMoveUp);
                }
            }
        }

        /// <summary>
        /// Move the selected item to the UpDownListView
        /// </summary>
        public void Remove()
        {
            if (AvailableListItems == null || AvailableListItems.Count == 0)
                return;

            if (ListItems == null)
                ListItems = new ObservableCollection<ListItem>();

            var selectedIndex = 0;
            var count = AvailableListItems.Count;

            for (int j = 0; j < count; j++)
            {
                selectedIndex = count - j - 1;
                ListItem item = AvailableListItems[selectedIndex];

                if (item.IsSelected == false)
                    continue;

                ListItems.Add(item);
                AvailableListItems.Remove(item);
            }
        }

        /// <summary>
        /// Move all items to the UpDownListView
        /// </summary>
        public void RemoveAll()
        {
            if (AvailableListItems == null || AvailableListItems.Count == 0)
                return;

            if (ListItems == null)
                ListItems = new ObservableCollection<ListItem>();

            int count = AvailableListItems.Count;
            for (int i = 0; i < count; i++)
            {
                var item = AvailableListItems[0];
                AvailableListItems.RemoveAt(0);
                ListItems.Add(item);
            }
        }

        /// <summary>
        /// Add the selected item from the UpDownListView
        /// </summary>
        public void Add()
        {
            if (ListItems == null || ListItems.Count == 0)
                return;

            if (AvailableListItems == null)
                AvailableListItems = new ObservableCollection<ListItem>();

            var selectedIndex = 0;
            var count = ListItems.Count;

            for (int j = 0; j < count; j++)
            {
                selectedIndex = count - j - 1;
                ListItem item = ListItems[selectedIndex];

                if (item.IsSelected == false)
                    continue;

                AvailableListItems.Add(item);
                ListItems.Remove(item);
            }
        }

        /// <summary>
        /// Add all items from the UpDownListView
        /// </summary>
        public void AddAll()
        {
            if (ListItems == null || ListItems.Count == 0)
                return;

            if (AvailableListItems == null)
                AvailableListItems = new ObservableCollection<ListItem>();

            int count = ListItems.Count;
            for (int i = 0; i < count; i++)
            {
                var item = ListItems[0];
                ListItems.RemoveAt(0);
                AvailableListItems.Add(item);
            }
        }
    }
}