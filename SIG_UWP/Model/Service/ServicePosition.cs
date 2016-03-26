﻿/*=====================================================================*
* Class: <ServicePosition>
* Version/date: <2016.03.26>
*
* Description: <Service for Position objects, who make process in database.>
* Specificities: <No.>
*
* Authors: Marco LOIODICE
* Copyright: all rights reserved.
*
*=====================================================================*/
using SIG_UWP.Model.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG_UWP.Model.Service
{
    class ServicePosition
    {
        public static ObservableCollection<Position> GetListPosition()
        {
            ObservableCollection<Position> positionListDatabase = new ObservableCollection<Position>();

            var query = App.dbConnect.Table<Position>();
            foreach(var item in query)
            {
                positionListDatabase.Add(item);
            }

            return positionListDatabase;
        }

        public static bool CreateOrUpdatePositionInDB(Position position)
        {
            var query = App.dbConnect.Table<Position>();
            int valueReturn;
            foreach(var item in query)
            {
                if(position.ID_POSITION == item.ID_POSITION)
                {
                    item.LABEL = position.LABEL;
                    item.LATITUDE = position.LATITUDE;
                    item.LAT_DEC = position.LAT_DEC;
                    item.LAT_SEX = position.LAT_SEX;
                    item.LONGITUDE = position.LONGITUDE;
                    item.LONG_DEC = position.LONG_DEC;
                    item.LONG_SEX = position.LONG_SEX;
                    valueReturn = App.dbConnect.Update(item);
                    if(valueReturn != 1)
                    {
                        Exception e = new Exception("Error update in database");
                        return false;
                    }
                    return true;
                }
            }
            valueReturn = App.dbConnect.Insert(position);
            if(valueReturn != 1)
            {
                Exception e = new Exception("Error insert in database");
                return false;
            }
            return true;
        }
    }
}