using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Eron.core.PersianDateTime
{
    public class Persian : IPersian
    {
        private PersianCalendar Pc;
        public Persian()
        {
            this.Pc = new PersianCalendar();
        }
        public string PersianDate(DateTime date)
        {

            return Pc.GetYear(date) + "/" + Pc.GetMonth(date) + "/" + Pc.GetDayOfMonth(date);
        }

        public string PersianDateTime(DateTime date)
        {
            return Pc.GetYear(date) + "/" + Pc.GetMonth(date) + "/" + Pc.GetDayOfMonth(date) + "  " + Pc.GetHour(date) + ":" + Pc.GetMinute(date)+":"+Pc.GetSecond(date);
        }

        public DateTime GregorianDateTime(int year, int month, int day, int hour, int minute,int second)
        {
            DateTime date = new DateTime(year,month,day,hour,minute,second,Pc);

            //todo: I must check for this one...
            return date;
        }

        public DateTime GregorianDateTime(int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day,Pc);

            //todo: I must check for this one...
            return date;
        }

        public DateTime GregorianDateTime(string datetime)
        {
            string[] date = datetime.Substring(0, 10).Split('/');
            int year = Convert.ToInt16(date[0]);
            int month = Convert.ToInt16(date[1]);
            int day = Convert.ToInt16(date[2]);
            string[] time = datetime.Substring(10).Split(':');
            int hour = Convert.ToInt16(time[0]);
            int minute = Convert.ToInt16(time[1]);
            int second = Convert.ToInt16(time[2]);

            return GregorianDateTime(year,month,day,hour,minute,second);
        }
    }
}