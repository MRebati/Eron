using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eron.core.PersianDateTime
{
    public interface IPersian
    {
        string PersianDate(DateTime date);

        string PersianDateTime(DateTime date);

        DateTime GregorianDateTime(int year, int month, int day, int hour, int minute,int second);

        DateTime GregorianDateTime(int year, int month, int day);

        DateTime GregorianDateTime(string date);
    }
}
