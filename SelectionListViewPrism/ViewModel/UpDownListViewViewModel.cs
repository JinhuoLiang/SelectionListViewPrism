using System;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Mvvm;

namespace SelectionListViewPrism
{
    /// <summary>
    /// View model for UserControl UpDownListView
    /// </summary>
    public class UpDownListViewViewModel : BindableBase
    {
        private ListedItemCollection m_upDownListModel;

        /// <summary>
        /// Default constructor 
        /// </summary>
        public UpDownListViewViewModel()
        {
            UpButtonClickCommand = new RelayCommand(ExecuteUpButtonClickCommand);
            DownButtonClickCommand = new RelayCommand(ExecuteDownButtonClickCommand);
            TopButtonClickCommand = new RelayCommand(ExecuteTopButtonClickCommand);
            BottomButtonClickCommand = new RelayCommand(ExecuteBottomButtonClickCommand);
            RemoveButtonClickCommand = new RelayCommand(ExecuteRemoveButtonClickCommand);
            AddButtonClickCommand = new RelayCommand(ExecuteAddButtonClickCommand);
            AddAllButtonClickCommand = new RelayCommand(ExecuteAddAllButtonClickCommand);
            RemoveAllButtonClickCommand = new RelayCommand(ExecuteRemoveAllButtonClickCommand);

            UpDownListModel = new ListedItemCollection();
        }

        /// <summary>
        /// Constructor with a list of objects
        /// </summary>
        /// <param name="list">List of objects to be displayed in the list view</param>
        public UpDownListViewViewModel(List<Object> list)
        {
            UpButtonClickCommand = new RelayCommand(ExecuteUpButtonClickCommand);
            DownButtonClickCommand = new RelayCommand(ExecuteDownButtonClickCommand);
            TopButtonClickCommand = new RelayCommand(ExecuteTopButtonClickCommand);
            BottomButtonClickCommand = new RelayCommand(ExecuteBottomButtonClickCommand);
            RemoveButtonClickCommand = new RelayCommand(ExecuteRemoveButtonClickCommand);
            AddButtonClickCommand = new RelayCommand(ExecuteAddButtonClickCommand);
            AddAllButtonClickCommand = new RelayCommand(ExecuteAddAllButtonClickCommand);
            RemoveAllButtonClickCommand = new RelayCommand(ExecuteRemoveAllButtonClickCommand);

            UpDownListModel = new ListedItemCollection(list);
        }

        /// <summary>
        /// Command for clicking the Up button
        /// </summary>
        public ICommand UpButtonClickCommand { get; protected set; }

        /// <summary>
        /// Command for clicking the Down button
        /// </summary>
        public ICommand DownButtonClickCommand { get; protected set; }

        /// <summary>
        /// Command for clicking the Top button
        /// </summary>
        public ICommand TopButtonClickCommand { get; protected set; }

        /// <summary>
        /// Command for clicking the Bottom button
        /// </summary>
        public ICommand BottomButtonClickCommand { get; protected set; }

        /// <summary>
        /// Command for clicking the Remove button
        /// </summary>
        public ICommand RemoveButtonClickCommand { get; protected set; }

        /// <summary>
        /// Command for clicking the Add button
        /// </summary>
        public ICommand AddButtonClickCommand { get; protected set; }

        /// <summary>
        /// Command for clicking the AddAll button
        /// </summary>
        public ICommand AddAllButtonClickCommand { get; protected set; }

        /// <summary>
        /// Command for clicking the RemoveAll button
        /// </summary>
        public ICommand RemoveAllButtonClickCommand { get; protected set; }

        /// <summary>
        /// Set/get UpDownList Model object
        /// </summary>
        public ListedItemCollection UpDownListModel
        {
            get
            {
                return m_upDownListModel;
            }

            set
            {
                SetProperty(ref m_upDownListModel, value);
            }
        }

        /// <summary>
        /// Action for the UpButtonClickCommand
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteUpButtonClickCommand(object obj)
        {
            if (m_upDownListModel != null)
                m_upDownListModel.MoveUp();
        }

        /// <summary>
        /// Action for the DownButtonClickCommand
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteDownButtonClickCommand(object obj)
        {
            if (m_upDownListModel != null)
                m_upDownListModel.MoveDown();
        }


        /// <summary>
        /// Action for the TopButtonClickCommand
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteTopButtonClickCommand(object obj)
        {
            if (m_upDownListModel != null)
                m_upDownListModel.MoveTop();
        }

        /// <summary>
        /// Action for the BottomButtonClickCommand
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteBottomButtonClickCommand(object obj)
        {
            if (m_upDownListModel != null)
                m_upDownListModel.MoveBottom();
        }

        /// <summary>
        /// Action for the RemoveButtonClickCommand
        /// </summary>
        /// <param name="obj"></param>
        protected void ExecuteRemoveButtonClickCommand(object obj)
        {
            if (m_upDownListModel != null)
                m_upDownListModel.Remove();
        }

        /// <summary>
        /// Action for the AddButtonClickCommand
        /// </summary>
        /// <param name="obj"></param>
        protected void ExecuteAddButtonClickCommand(object obj)
        {
            if (m_upDownListModel != null)
                m_upDownListModel.Add();
        }

        /// <summary>
        /// Action for the AddAllButtonClickCommand
        /// </summary>
        /// <param name="obj"></param>
        protected void ExecuteAddAllButtonClickCommand(object obj)
        {
            if (m_upDownListModel != null)
                m_upDownListModel.AddAll();
        }

        /// <summary>
        /// Action for the RemoveAllButtonClickCommand
        /// </summary>
        /// <param name="obj"></param>
        protected void ExecuteRemoveAllButtonClickCommand(object obj)
        {
            if (m_upDownListModel != null)
                m_upDownListModel.RemoveAll();
        }
    }
}
