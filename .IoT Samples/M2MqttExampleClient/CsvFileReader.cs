using CsvHelper;
using Kognifai.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace M2MqttExampleClient
{
    public static class CsvFileReader
    {
        public static IEnumerable<SensorMetadata> ReadDataFromCsvFile(string filePath)
        {
            var text = File.ReadAllText(filePath);

            using (var csvReader = new CsvReader(new StringReader(text)))
            {

                List<SensorMetadata> sensorMetadata = new List<SensorMetadata>();
                var sensorData = csvReader.GetRecords<SensorData>();
                foreach (var data in sensorData)
                {
                    SensorMetadata sensorMeta = new SensorMetadata
                    {
                        SensorId = data.ExternalId
                    };
                    sensorMeta.Properties.Add("TargetNodeDisplayName", new Property(data.TargetNodeDisplayName));
                    sensorMeta.Properties.Add("PollFrequency", new Property(data.ExternalPollFrequency.ToString()));
                    sensorMeta.Properties.Add("TargetPath", new Property(data.TargetPath.ToString()));
                    sensorMeta.Properties.Add("SensorReadingType", new Property(data.ExternalReadingType.ToString()));
                    sensorMeta.Properties.Add("ExternalIndexDelayTimeSec", new Property(data.ExternalIndexDelayTimeSec.ToString()));
                    sensorMeta.Properties.Add("Description", new Property(data.ExternalSensorColumnDescription.ToString()));
                    sensorMeta.Properties.Add("MeasureUnit", new Property(data.ExternalColumnMeasureunit.ToString()));
                    sensorMetadata.Add(sensorMeta);
                }
                return sensorMetadata;
            }

        }
    }
}
