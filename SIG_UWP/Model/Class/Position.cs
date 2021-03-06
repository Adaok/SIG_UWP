﻿/*=====================================================================*
* Class: <Position>
* Version/date: <2016.03.21> v3
*
* Description: <Position file is the model object of files stocks in a MSQLite table.>
* Specificities: <No.>
*
* Authors: Marco LOIODICE
* Copyright: all rights reserved.
*
*=====================================================================*/
using SQLite.Net.Attributes;

namespace SIG_UWP.Model.Class
{
    public enum LAT
    {
        N,
        S
    }

    public enum LONG
    {
        E,
        O
    }

    class Position
    {
        [PrimaryKey]
        public int ID_POSITION { get; set; }

        public string LABEL { get; set; }

        public string LAT_SEX { get; set;}

        public string LONG_SEX { get; set; }

        public double LAT_DEC { get; set; }

        public double LONG_DEC { get; set; }

        public LAT LATITUDE { get; set; }

        public LONG LONGITUDE { get; set; }
    }
}
