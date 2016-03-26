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
            set { NotifyPropertyChanged(ref m_PositionList, value); }
        }

        #endregion

        #region Textblock

        private string m_InfoBlock;

        public string InfoBlock
        {
            get { return m_InfoBlock; }
            set { NotifyPropertyChanged(ref m_InfoBlock, value); }
        }

        #endregion

        #region input

        private string m_Label;

        public string Label
        {
            get { return m_Label; }
            set { NotifyPropertyChanged(ref m_Label, value); }
        }

        #region Latitude

        private int m_LatitudeDegre;

        public int LatitudeDegre
        {
            get { return m_LatitudeDegre; }
            set { NotifyPropertyChanged(ref m_LatitudeDegre, value); }
        }

        private int m_LatitudeMinute;

        public int LatitudeMinute
        {
            get { return m_LatitudeMinute; }
            set { NotifyPropertyChanged(ref m_LatitudeMinute, value); }
        }

        private int m_LatitudeSeconde;

        public int LatitudeSeconde
        {
            get { return m_LatitudeSeconde; }
            set { NotifyPropertyChanged(ref m_LatitudeSeconde, value); }
        }

        #endregion

        #region Longtitude

        private int m_LongtitudeDegre;

        public int LongtitudeDegre
        {
            get { return m_LongtitudeDegre; }
            set { NotifyPropertyChanged(ref m_LongtitudeDegre, value); }
        }

        private int m_LongtitudeMinute;

        public int LongtitudeMinute
        {
            get { return m_LongtitudeMinute; }
            set { NotifyPropertyChanged(ref m_LongtitudeMinute, value); }
        }

        private int m_LongtitudeSeconde;

        public int LongtitudeSeconde
        {
            get { return m_LongtitudeSeconde; }
            set { NotifyPropertyChanged(ref m_LongtitudeSeconde, value); }
        }

        #endregion

        #endregion

        #region Actions in CommandBar

        public ICommand AddPositionCommand
        {
            get { return new DelegateCommand(AddPosition); }
        }

        private void AddPosition()
        {
            Position newPosition = ServicePosition.CreatePosition(m_Label, m_LatitudeDegre, m_LatitudeMinute, m_LatitudeSeconde, m_LongtitudeDegre, m_LongtitudeMinute, m_LongtitudeSeconde, null, null);
            ServicePosition.CreateOrUpdatePositionInDB(newPosition);
            PositionList = ServicePosition.GetListPosition();
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
