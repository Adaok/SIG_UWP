/*=====================================================================*
* Class: <ServicePosition>
* Version/date: <2016.03.26> v2
*
* Description: <Service for Position objects, who make process in database and other process.>
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
        #region Database Operation

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

        public static bool DeletePositionInDB(Position position)
        {
            var query = App.dbConnect.Table<Position>();
            int valueReturn;
            Exception e;
            foreach(var item in query)
            {
                if(position.ID_POSITION == item.ID_POSITION)
                {
                    valueReturn = App.dbConnect.Delete(item);
                    if(valueReturn != 1)
                    {
                        e = new Exception("Error delete in database.");
                        return false;
                    }
                    return true;
                }
            }
            e = new Exception("Bad argument for delete item");
            return false;
        }

        #endregion

        #region others methods

        //need update later for deletion.
        public static Position CreatePosition(int id, string label, int latitudeDegre, int latitudeMinute, int latitudeSeconde, int longitudeDegre, int longitudeMinute, int longitudeSeconde, int enumLat, int enumLong)
        {
            Position newPosition = new Position();
            if(id != 0)
            {
                newPosition.ID_POSITION = id;
            }
            else
            {
                if(GetListPosition().Count == 0)
                {
                    newPosition.ID_POSITION = 1;
                }
                else
                {
                    newPosition.ID_POSITION = GetListPosition().Last().ID_POSITION + 1;
                }
            }
            newPosition.LABEL = label;
            newPosition.LAT_SEX = latitudeDegre + "°" + latitudeMinute + "'" + latitudeSeconde + " '' ";
            newPosition.LONG_SEX = longitudeDegre + "°" + longitudeMinute + "'" + longitudeSeconde + " '' ";
            newPosition.LAT_DEC = ConvertSexToDec(latitudeDegre, latitudeMinute, latitudeSeconde);
            newPosition.LONG_DEC = ConvertSexToDec(longitudeDegre, longitudeMinute, longitudeSeconde);
            newPosition.LATITUDE = (LAT)enumLat;
            newPosition.LONGITUDE = (LONG)enumLong;

            return newPosition;
        }

        private static float ConvertSexToDec(int degre, int minute, int seconde)
        {
            float convert = degre + (minute / (float)60) + (seconde / (float)3600);
            return convert;
        }

        public static List<int> ConvertDecToSex(float decimalValue)
        {
            List<int> convertList = new List<int>();
            int degre = (int)decimalValue;
            int minute = (int)((decimalValue - degre) * 60);
            int seconde = (int)(((decimalValue - degre) * 60) - minute) * 60;
            convertList.Add(degre);
            convertList.Add(minute);
            convertList.Add(seconde);
            return convertList;
        }

        #endregion
    }
}
