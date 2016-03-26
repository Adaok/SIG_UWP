/*=====================================================================*
* Class: <HomeViewModel>
* Version/date: <2016.03.20> v2
*
* Description: <HomeViewModel is file who pilotes the page.>
* Specificities: <No.>
*
* Authors: Marco LOIODICE
* Copyright: all rights reserved.
*
*=====================================================================*/
using SIG_UWP.Base;
using SIG_UWP.Model.Class;
using SIG_UWP.Model.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SIG_UWP.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        #region Constructor
        public HomeViewModel()
        {
            PositionList = ServicePosition.GetListPosition();
        }

        #endregion

        #region List Position

        private ObservableCollection<Position> m_PositionList = new ObservableCollection<Position>();

        public ObservableCollection<Position> PositionList
        {
            get { return m_PositionList; }
            set { m_PositionList = value; }
        }

        #endregion

        #region Actions in CommandBar

        public ICommand AddPositionCommand
        {
            get { return new DelegateCommand(AddPosition); }
        }

        private void AddPosition()
        {
            throw new NotImplementedException();
        }

        public ICommand EditPositionCommand
        {
            get { return new DelegateCommand(EditPosition); }
        }

        private void EditPosition()
        {
            throw new NotImplementedException();
        }

        public ICommand DeletePositionCommand
        {
            get { return new DelegateCommand(DeletePosition); }
        }

        private void DeletePosition()
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
