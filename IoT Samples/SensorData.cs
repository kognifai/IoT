using Kognifai.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2MqttExampleClient
{
    public class SensorData
    {

        public string ExternalId { get; set; }

        public string TargetNodeDisplayName { get; set; }

        public ulong? ExternalPollFrequency { get; set; }

        public string TargetPath { get; set; }
        public SensorReadingType ExternalReadingType { get; set; }
        public ulong? ExternalIndexDelayTimeSec { get; set; }
        public string ExternalSensorColumnDescription { get; set; }
        public string ExternalColumnMeasureunit { get; set; }
        public string TargetColumnMeasureUnit { get; set; }


    }
}
