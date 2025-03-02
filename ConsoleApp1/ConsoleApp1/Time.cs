using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Time
    {
        private int _hour;
        private int _millisecond;
        private int _minute;
        private int _second;

        public Time()//Constructor sin parametros y que inicie la hora, segundos, minutos en cero
        {
            _hour = 00;
            _minute = 00;
            _second = 00;
            _millisecond = 000;
        }

        public Time(int hour)
        {
            _hour = ValidHour(hour);
        }
        public Time(int hour, int minute)
        {
            _hour = ValidHour(hour);
            _minute = ValidMinute(minute);
        }
        public Time(int hour, int minute, int second)
        {
            _hour = ValidHour(hour);
            _minute = ValidMinute(minute);
            _second = ValidSecond(second);
        }
        public Time(int hour, int minute, int second, int millisecond)
        {
            _hour = ValidHour(hour);
            _minute = ValidMinute(minute);
            _second = ValidSecond(second);
            _millisecond = ValidMillisecond(millisecond);
        }
        public int Hour
        {
            get => _hour;
            set => _hour = value;
        }
        public int Millisecond
        {
            get => _millisecond;
            set => _millisecond = value;
        }
        public int Minute
        {
            get => _minute;
            set => _minute = value;
        }
        public int Second
        {
            get => _second;
            set => _second = value;
        }

        public int ToMilliseconds()
        {
            return _hour * 3600000 + _minute * 60000 + _second * 1000 + _millisecond;
        }
        public int ToMinutes()
        {
            return _hour * 60 + _minute;
        }
        public int ToSeconds()
        {
            return _hour * 3600 + _minute * 60 + _second;
        }
        public override string ToString()
        {
            int hourNoMilli = _hour % 12;
            if (hourNoMilli == 0)
                hourNoMilli = 12;
            string amPm = _hour < 12 ? "AM" : "PM";

            return $"{hourNoMilli:00}:{_minute:00}:{_second:00}.{_millisecond:000}{amPm}";
        }
        internal Time Add(Time other)
        {
            int totalMilli = this._millisecond + other._millisecond;
            int carrySecond = totalMilli / 1000;
            int newMillisecond = totalMilli % 1000;

            int totalSec = this._second + other._second + carrySecond;
            int carryMinute = totalSec / 60;
            int newSecond = totalSec % 60;

            int totalMin = this._minute + other._minute + carryMinute;
            int carryHour = totalMin / 60;
            int newMinute = totalMin % 60;

            int totalHour = this._hour + other._hour + carryHour;
            int newHour = totalHour % 24;

            return new Time(newHour, newMinute, newSecond, newMillisecond);
        }

        internal bool IsOtherDay(Time t4)
        {
            return (this.ToMilliseconds() + t4.ToMilliseconds()) >= 86400000;
        }

        private int ValidHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentException($"The hour:{hour}, not is valid.");
            }
            return hour;
        }
        private int ValidMillisecond(int millisecond)
        {
            if (millisecond < 0 || millisecond > 999)
            {
                throw new ArgumentException($"The millisecond:{millisecond}, not is valid.");
            }
            return millisecond;
        }
        private int ValidMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentException($"The minute:{minute}, not is valid.");
            }
            return minute;
        }
        private int ValidSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentException($"The second:{second}, not is valid.");
            }
            return second;
        }
    }
}
