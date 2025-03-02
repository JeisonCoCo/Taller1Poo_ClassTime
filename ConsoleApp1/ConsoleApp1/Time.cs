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
            int _hour = ValidHour(hour);
        }
        public Time(int hour, int minute)
        {
            int _hour = ValidHour(hour);
            int _minute = ValidMinute(minute);
        }
        public Time(int hour, int minute, int second)
        {
            int _hour = ValidHour(hour);
            int _minute = ValidMinute(minute);
            int _second = ValidSecond(second);
        }
        public Time(int hour, int minute, int second, int millisecond)
        {
            int _hour = ValidHour(hour);
            int _minute = ValidMinute(minute);
            int _second = ValidSecond(second);
            int _millisecond = ValidMillisecond(millisecond);
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
        public int ToSeconds()
        {
            return _hour * 3600 + _minute * 60 + _second;
        }
        public override string ToString()
        {
            int hourNo = _hour % 12;
            if (hourNo == 0)
                hourNo = 12;
            return $"{hourNo:00}:{_minute:00}:{_second:00}:{_millisecond:000}";
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
