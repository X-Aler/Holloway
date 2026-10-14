using System;

namespace Assets.Game.Scripts.Models
{
    [Serializable]
    public struct GameTime : IFormattable, IEquatable<GameTime>, IComparable<GameTime>
    {
        public int Hours;
        public int Minutes;
        public int Seconds;

        public int TotalSeconds => Hours * 3600 + Minutes * 60 + Seconds;

        public GameTime(int hours = 0, int minutes = 0, int seconds = 0)
        {
            long total = (long)hours * 3600 + (long)minutes * 60 + seconds;
            if (total < 0) total = 0;

            Hours = (int)(total / 3600);
            Minutes = (int)((total % 3600) / 60);
            Seconds = (int)(total % 60);
        }

        public static bool operator <(GameTime a, GameTime b) => a.TotalSeconds < b.TotalSeconds;
        public static bool operator >(GameTime a, GameTime b) => a.TotalSeconds > b.TotalSeconds;
        public static bool operator <=(GameTime a, GameTime b) => a.TotalSeconds <= b.TotalSeconds;
        public static bool operator >=(GameTime a, GameTime b) => a.TotalSeconds >= b.TotalSeconds;

        public static bool operator ==(GameTime a, GameTime b) => a.TotalSeconds == b.TotalSeconds;
        public static bool operator !=(GameTime a, GameTime b) => a.TotalSeconds != b.TotalSeconds;

        public static GameTime operator +(GameTime A, GameTime B)
        {
            return new GameTime(
                A.Hours + B.Hours,
                A.Minutes + B.Minutes,
                A.Seconds + B.Seconds
            );
        }

        public static GameTime operator -(GameTime A, GameTime B)
        {
            return new GameTime(
                A.Hours - B.Hours,
                A.Minutes - B.Minutes,
                A.Seconds - B.Seconds
            );
        }

        public bool Equals(GameTime other) => TotalSeconds == other.TotalSeconds;

        public override bool Equals(object obj) => obj is GameTime other && Equals(other);

        public override int GetHashCode() => TotalSeconds.GetHashCode();

        public int CompareTo(GameTime other) => TotalSeconds.CompareTo(other.TotalSeconds);

        public override string ToString() => ToString("G", null);

        public string ToString(string format) => ToString(format, null);

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "G";

            switch (format.ToUpperInvariant())
            {
                case "F0":
                    return $"{Hours:D2}";

                case "F1":
                    return $"{Hours:D2}:{Minutes:D2}";

                case "G":
                case "F2":
                    return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";

                default:
                    throw new FormatException($"Формат {format} не поддерживается.");
            }
        }
    }
}
