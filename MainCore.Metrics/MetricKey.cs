using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MainCore.Metrics
{
    public class MetricKey : IComparable<MetricKey>, IComparable
    {
        private static Dictionary<SensorType, Dictionary<string, MetricKey>> metricKeys = new Dictionary<SensorType, Dictionary<string, MetricKey>>();
        public static MetricKey Create(SensorType sensorType, string name)
        {
            return metricKeys
                .GetValueOrInsertedLazyDefault(sensorType, () => new Dictionary<string, MetricKey>())
                .GetValueOrInsertedLazyDefault(name, () => new MetricKey(sensorType, name));
        }

        public readonly static MetricKey NONE = MetricKey.Create(SensorType.MAIN, "None");
        private string name;
        private SensorType sensorType;

        private int? hashCode = null;
        private MetricKey(SensorType sensorType, string name)
        {
            this.sensorType = sensorType;
            this.name = name;
        }
        public SensorType SensorType { get { return sensorType; } }
        public string Name { get { return name; } }
        public override int GetHashCode()
        {
            if (hashCode == null)
            {
                int hash = 13;
                hash = (hash * 7) + sensorType.GetHashCode();
                hash = (hash * 7) + name.GetHashCode();
                hashCode = hash;
            }
            return hashCode.Value;
        }
        public override bool Equals(object obj)
        {
            if (obj is MetricKey)
            {
                var key = (MetricKey)obj;
                return this == key || (this.SensorType == key.SensorType && this.Name.Equals(key.Name));
            }
            return false;
        }
        public override string ToString()
        {
            return SensorType.ToString() + "." + Name;
        }
        public static MetricKey Parse(string key)
        {
            SensorType sensorType;
            var firstIndex = key.IndexOf(".");
            if (firstIndex == -1 || firstIndex == key.Length - 1 || !Enum.TryParse<SensorType>(key.Substring(0, firstIndex), out sensorType))
                throw new ArgumentException("MetricKey must have the format: <sensor type>.<name>, where sensor type is one of the values: " + string.Join(", ", Enum.GetNames(typeof(SensorType))));
            return MetricKey.Create(sensorType, key.Substring(firstIndex + 1));
        }

        public static bool TryParse(string key, out MetricKey result)
        {
            try { result = Parse(key); return true; }
            catch { result = MetricKey.NONE; return false; }
        }

        public int CompareTo(MetricKey other)
        {
            if (other == null)
                return 1;
            var me = this.ToString();
            var you = other.ToString();
            return me.CompareTo(you);
        }

        public int CompareTo(object obj)
        {
            if (obj == this)
                return 0;
            MetricKey other = null;
            if (obj is MetricKey)
                other = obj as MetricKey;
            return this.CompareTo(other);
        }
    }
}
