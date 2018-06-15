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
                        ExternalId = data.ExternalId
                    };
                    sensorMeta.SensorProperties.Add("TargetNodeDisplayName", new Property(data.TargetNodeDisplayName));
                    sensorMeta.SensorProperties.Add("PollFrequency", new Property(data.ExternalPollFrequency.ToString()));
                    sensorMeta.SensorProperties.Add("TargetPath", new Property(data.TargetPath.ToString()));
                    sensorMeta.SensorProperties.Add("SensorReadingType", new Property(data.ExternalReadingType.ToString()));
                    sensorMeta.SensorProperties.Add("ExternalIndexDelayTimeSec", new Property(data.ExternalIndexDelayTimeSec.ToString()));
                    sensorMeta.SensorProperties.Add("Description", new Property(data.ExternalSensorColumnDescription.ToString()));
                    sensorMeta.SensorProperties.Add("MeasureUnit", new Property(data.ExternalColumnMeasureunit.ToString()));
                    sensorMetadata.Add(sensorMeta);
                }
                return sensorMetadata;
            }

        }
    }
}
