/*=====================================================================*
* Class: <Position>
* Version/date: <2016.03.21> v2
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
    class Position
    {
        [PrimaryKey]
        public int ID_POSITION { get; set; }

        public string LABEL { get; set; }

        public string LAT_SEX { get; set;}

        public string LONG_SEX { get; set; }

        public float LAT_DEC { get; set; }

        public float LONG_DEC { get; set; }
    }
}
