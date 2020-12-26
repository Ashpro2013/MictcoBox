using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mictco_Box
{
    public static class StringExtension
    {
        public static T Cast<T>(this Object obj, T typeHolder)
        {
            return (T)obj;
        }
        public static bool toBool(this Boolean? obj)
        {
            try
            {
                return Convert.ToBoolean(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ToBool(this String obj)
        {
            try
            {
                return Convert.ToBoolean(obj);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static Int32 ToInt32(this String obj)
        {
            try
            {
                if (obj == null || obj.Trim() == "")
                    return 0;
                else
                    return Convert.ToInt32(obj);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Int16 ToInt16(this String obj)
        {
            try
            {
                if (obj == null || obj.Trim() == "")
                    return 0;
                else
                    return Convert.ToInt16(obj);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static Decimal ToDecimal(this String obj)
        {
            try
            {
                Decimal dcm = 0;
                if (Decimal.TryParse(obj, out dcm))
                    return dcm;
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static double ToDouble(this Decimal? obj)
        {
            return Convert.ToDouble(obj);
        }
       
        public static Double ToDouble(this String obj)
        {
            try
            {
                if (obj == null || obj.Trim() == "")
                    return 0;
                else
                    return Convert.ToDouble(obj);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static DateTime toDateTime(this String Obj)
        {
            try
            {
                return Convert.ToDateTime(Obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DateTime ToDateTime(this DateTime? Obj)
        {
            if (Obj == null) { return DateTime.Now; }
            return (DateTime)Obj;
        }
        public static bool isNumeric(this Object Expression)
        {
            double retNum;
            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        /// <summary>
        /// Used To Convert Any Object To String Even Null
        /// </summary>
        /// <param name="_obj"></param>
        /// <returns></returns>
        public static string ToString2(this Object _obj)
        {

            if (_obj != null)
            {
                return _obj.ToString();
            }
            else
            {
                return "";
            }

        }
        public static Int32 ToInt32(this Object _obj)
        {

            if (_obj != null)
            {
                return _obj.ToString().ToInt32();
            }
            else
            {
                return 0;
            }

        }
        public static int toInt32(this int? _obj)
        {
            if (_obj != null)
            {
                return Convert.ToInt32(_obj);
            }
            else
            {
                return 0;
            }

        }
        public static Decimal ToDecimal(this decimal? obj)
        {
            return Convert.ToDecimal(obj);
        }
        public static Decimal ToDecimal(this double obj)
        {
            return Convert.ToDecimal(obj);
        }
        public static Decimal Round(this decimal? obj, int NoofDecimals)
        {
            return Math.Round(obj.ToDecimal(), NoofDecimals);
        }
        public static string ToString(this decimal? obj, string sFormat)
        {
            return (obj.ToDecimal()).ToString(sFormat);
        }
        public static bool IsNumericKey(this System.Windows.Forms.KeyEventArgs key)
        {
            switch (key.KeyCode)
            {
                case System.Windows.Forms.Keys.Back:
                case System.Windows.Forms.Keys.Delete:
                case System.Windows.Forms.Keys.OemMinus:
                case System.Windows.Forms.Keys.D0:
                case System.Windows.Forms.Keys.D1:
                case System.Windows.Forms.Keys.D2:
                case System.Windows.Forms.Keys.D3:
                case System.Windows.Forms.Keys.D4:
                case System.Windows.Forms.Keys.D5:
                case System.Windows.Forms.Keys.D6:
                case System.Windows.Forms.Keys.D7:
                case System.Windows.Forms.Keys.D8:
                case System.Windows.Forms.Keys.D9:
                case System.Windows.Forms.Keys.NumPad0:
                case System.Windows.Forms.Keys.NumPad1:
                case System.Windows.Forms.Keys.NumPad2:
                case System.Windows.Forms.Keys.NumPad3:
                case System.Windows.Forms.Keys.NumPad4:
                case System.Windows.Forms.Keys.NumPad5:
                case System.Windows.Forms.Keys.NumPad6:
                case System.Windows.Forms.Keys.NumPad7:
                case System.Windows.Forms.Keys.NumPad8:
                case System.Windows.Forms.Keys.NumPad9:
                    return true;

                default:
                    return false;
            }
        }
       
    }
}
