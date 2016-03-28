/*=====================================================================*
* Class: <HomeViewModel>
* Version/date: <2016.03.20> v3
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
            m_IsEnabled = false;
        }

        #endregion

        #region Position id

        private int m_IdPosition;

        public int IdPosition
        {
            get { return m_IdPosition; }
            set { NotifyPropertyChanged(ref m_IdPosition, value); }
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

        #region Button Enabled

        private bool m_IsEnabled;

        public bool IsEnabled
        {
            get { return m_IsEnabled; }
            set { NotifyPropertyChanged(ref m_IsEnabled, value); }
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

        #region enum Value Latitude and Longitude

        private int m_EnumLatitude;

        public int EnumLatitude
        {
            get { return m_EnumLatitude; }
            set { NotifyPropertyChanged(ref m_EnumLatitude, value); }
        }

        private int m_EnumLongitude;

        public int EnumLongitude
        {
            get { return m_EnumLongitude; }
            set { NotifyPropertyChanged(ref m_EnumLongitude, value); }
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
            Position newPosition = ServicePosition.CreatePosition(m_IdPosition ,m_Label, m_LatitudeDegre, m_LatitudeMinute, m_LatitudeSeconde, m_LongtitudeDegre, m_LongtitudeMinute, m_LongtitudeSeconde, m_EnumLatitude, m_EnumLongitude);
            ServicePosition.CreateOrUpdatePositionInDB(newPosition);
            CleanInput();
            SelectedIndex = -1;
            IdPosition = 0;
            IsEnabled = false;
            InfoBlock = string.Empty;
            PositionList = ServicePosition.GetListPosition();
        }

        public ICommand EditPositionCommand
        {
            get { return new DelegateCommand(EditPosition); }
        }

        private void EditPosition()
        {
            int latitude = (int)SelectedPosition.LATITUDE;
            int longitude = (int)SelectedPosition.LONGITUDE;
            LoadInput(SelectedPosition.LABEL, SelectedPosition.LAT_DEC, SelectedPosition.LONG_DEC, latitude, longitude);
        }

        public ICommand DeletePositionCommand
        {
            get { return new DelegateCommand(DeletePosition); }
        }

        private void DeletePosition()
        {
            ServicePosition.DeletePositionInDB(SelectedPosition);
            IsEnabled = false;
            InfoBlock = string.Empty;
            PositionList = ServicePosition.GetListPosition();
        }

        #endregion

        #region selectItem

        int m_SelectedIndex = -1; //Set -1 for haven't item select

        public int SelectedIndex
        {
            get { return m_SelectedIndex; }
            set {
                if (NotifyPropertyChanged(ref m_SelectedIndex, value))
                {

                    NotifyPropertyChanged(nameof(SelectedPosition));
                    IsEnabled = true;
                    if(SelectedPosition != null)
                    {
                        IdPosition = SelectedPosition.ID_POSITION;
                    }
                }
            }
        }

        public Position SelectedPosition
        {
            get { return (m_SelectedIndex >= 0) ? m_PositionList[m_SelectedIndex] : null; }
        }


        #endregion

        #region Others methods

        private void CleanInput()
        {
            Label = string.Empty;
            LatitudeDegre = 0;
            LatitudeMinute = 0;
            LatitudeSeconde = 0;
            LongtitudeDegre = 0;
            LongtitudeMinute = 0;
            LongtitudeSeconde = 0;
        }

        private void LoadInput(string label, float latitude, float longitude, int enumLatitude, int enumLongitude)
        {
            Label = label;
            List<int> sexLatitudeList = ServicePosition.ConvertDecToSex(latitude);
            List<int> sexLongitudeList = ServicePosition.ConvertDecToSex(longitude);
            LatitudeDegre = sexLatitudeList[0];
            LatitudeMinute = sexLatitudeList[1];
            LatitudeSeconde = sexLatitudeList[2];
            LongtitudeDegre = sexLongitudeList[0];
            LongtitudeMinute = sexLongitudeList[1];
            LongtitudeSeconde = sexLongitudeList[2];
            EnumLatitude = enumLatitude;
            EnumLongitude = enumLongitude;
            InfoBlock = "Vous êtes en mode édition. Cliquez sur + pour valider vos changements.";
        }

        #endregion


    }
}
