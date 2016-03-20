/*=====================================================================*
* Class: <ViewModelBase>
* Version/date: <2016.03.20>
*
* Description: <”This class is use for every viewmodel>
* Specificities: <No>
*
* Authors: Marco LOIODICE
* Copyright: all rights reserved.
*
*=====================================================================*/
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SIG_UWP.Base
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            //If change is different of null, we catch arguments of event.
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected bool NotifyPropertyChanged<TProperty>(ref TProperty myObject, TProperty value, [CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(myObject, value))
            {
                OnPropertyChanging(propertyName, myObject, value);
                myObject = value;
                NotifyPropertyChanged(propertyName);
                OnPropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        //method for free re-implentation after my Change
        protected virtual void OnPropertyChanged(string propertyName) { }

        //method for free re-implentation before my Change
        protected virtual void OnPropertyChanging(string propertyName, object oldValue, object newValue) { }
    }
}
