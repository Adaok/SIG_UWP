/*=====================================================================*
* Class: <NavMenuItem>
* Version/date: <2016.03.20>
*
* Description: <This class is used for define format of items in burgermenu.>
* Specificities: <Ways for differents Pages is define here.>
*
* Authors: Marco LOIODICE
* Copyright: all rights reserved.
*
*=====================================================================*/
using System;
using Windows.UI.Xaml.Controls;

namespace SIG_UWP.Navigation
{
    class NavMenuItem
    {
        public string Label { get; set; }
        public Symbol Symbol { get; set; }
        public char SymbolAsChar
        {
            get
            {
                return (char)Symbol;
            }
        }

        public Type DestPage { get; set; }
        public object Arguments { get; set; }
    }
}
