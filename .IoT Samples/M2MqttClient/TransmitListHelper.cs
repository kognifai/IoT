using CsvHelper;
using CsvHelper.Configuration;
using Kognifai.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace M2MqttExampleClient
{
    public class TransmittedDataSensor
    {
        public string ExternalId { get; set; }
        public SensorReadingType? ExternalReadingType { get; set; }
        public string TargetPath { get; set; }
        public string TargetNodeDisplayName { get; set; }
        public ulong? ExternalPollFrequency { get; set; }
        public ulong? ExternalIndexDelayTimeSec { get; set; }
        public string ExternalSensorColumnDescription { get; set; }
        public string ExternalColumnMeasureunit { get; set; }
        public string TargetColumnMeasureUnit { get; set; }
        //public IEnumerable<TransmittedDataColumn> Columns { get; set; }
    }

    public class TransmittedDataColumn
    {
        public string ExternalSensorColumnDescription { get; set; }
        public string ExternalColumnMeasureunit { get; set; }
        public string TargetColumnMeasureUnit { get; set; }
    }

    public sealed class TransmittedDataSensorMap : CsvClassMap<TransmittedDataSensor>
    {
        public TransmittedDataSensorMap()
        {
            // to extend or configure mapping check this resource: https://joshclose.github.io/CsvHelper/mapping#reference-mapping
            AutoMap();
        }
    }

    public class TransmittedEvent
    {
        public string EventID { get; set; }

        public string DisplayName { get; set; }

        public ulong? PollFrequency { get; set; }

        public string Path { get; set; }
    }

    public sealed class TransmittedEventMap : CsvClassMap<TransmittedEvent>
    {
        public TransmittedEventMap()
        {
            // to extend or configure mapping check this resource: https://joshclose.github.io/CsvHelper/mapping#reference-mapping
            AutoMap();
        }
    }

    public class TransmitListReader : IDisposable
    {
        private readonly ICsvReader _reader;
        private readonly EventType _eventType;

        public TransmitListReader(string csv, EventType eventType)
        {
            if (string.IsNullOrEmpty(csv)) throw new ArgumentNullException(nameof(csv));
            _reader = new CsvReader(new StringReader(csv));
            _eventType = eventType;
        }

        public TransmitListReader(Stream stream, EventType eventType)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            _reader = new CsvReader(new StreamReader(stream));
            _eventType = eventType;
        }

        public void Dispose()
        {
            _reader?.Dispose();
        }

        public IEnumerable<ExternalSensorMetadata> ReadAll()
        {
            switch (_eventType)
            {
                case EventType.SensorDataEventType:
                case EventType.DataframeEventType:
                    return ReadAllDataSensors();
                case EventType.AlarmEventType:
                case EventType.StateChangeEventType:
                    return ReadAllEventSensors();
                default:
                    return new List<ExternalSensorMetadata>();
            }
        }

        private IEnumerable<ExternalSensorMetadata> ReadAllEventSensors()
        {
            _reader.Configuration.RegisterClassMap<TransmittedEventMap>();
            return _reader.GetRecords<TransmittedEvent>()
                .Select(e => new ExternalSensorMetadata
                {
                    SensorId = e.EventID,
                    PollFrequency = e.PollFrequency,
                    TargetPath = e.Path,
                    TargetNodeDisplayName = e.DisplayName
                })
                .ToList();
        }

        private IEnumerable<ExternalSensorMetadata> ReadAllDataSensors()
        {
            _reader.Configuration.RegisterClassMap<TransmittedDataSensorMap>();
            return _reader.GetRecords<TransmittedDataSensor>()
                .Select(e =>
                {
                    var mapping = new ExternalSensorMetadata
                    {
                        SensorId = e.ExternalId,
                        SensorReadingType = e.ExternalReadingType,
                        PollFrequency = e.ExternalPollFrequency,
                        //ExternalIndexDelayTimeSec = e.ExternalIndexDelayTimeSec,
                        TargetPath = e.TargetPath,
                        TargetNodeDisplayName = e.TargetNodeDisplayName,
                    };
                    mapping.VectorElementsData.Add(new ExternalVectorElementMetadata
                    {
                        Description = e.ExternalSensorColumnDescription,
                        MeasureUnit = e.ExternalColumnMeasureunit,
                        TargetMeasureUnit = e.TargetColumnMeasureUnit
                    });
                    return mapping;
                })
                .ToList();
        }
    }

    public class AvailableSensor
    {
        public static MessageWrapper GetAvailableSensors(string sourceId, EventType eventType, string sensorListFilePath)
        {
            try
            {
                RemoteSourceAvailableSensors availableSensors = new RemoteSourceAvailableSensors();
                availableSensors.SourceId = sourceId;
                availableSensors.EventType = eventType;
                string csvText = File.ReadAllText(sensorListFilePath);
                using (var reader = new TransmitListReader(csvText, eventType))
                {
                    var sensors = reader.ReadAll();
                    switch (eventType)
                    {
                        case EventType.AlarmEventType:
                        case EventType.StateChangeEventType:
                            /* EventID, DisplayName, PollFrequency, Path */
                            foreach (var sensor in sensors)
                            {
                                var sensorMetadata = new SensorMetadata()
                                {
                                    SensorId = sensor.SensorId,
                                };
                                sensorMetadata.Properties.Add(Constants.KnownPropertyNames.SensorMetadata.DisplayName, new Property(sensor.TargetNodeDisplayName));
                                availableSensors.Sensors.Add(sensorMetadata);
                            }
                            break;
                        case EventType.SensorDataEventType:
                            foreach (var sensor in sensors)
                            {
                                var sensorMetadata = new SensorMetadata()
                                {
                                    SensorId = sensor.SensorId,
                                };
                                VectorElementMetadata vector = new VectorElementMetadata()
                                {
                                    Name = string.IsNullOrEmpty(sensor.VectorElementsData.First().Name) ? sensor.VectorElementsData.First().Name : sensor.VectorElementsData.First().Description,
                                    SourceUnit = sensor.VectorElementsData.First().MeasureUnit,
                                };
                                sensorMetadata.VectorElementsData.Add(vector);
                                sensorMetadata.Properties.Add(Constants.KnownPropertyNames.SensorMetadata.DisplayName, new Property(sensor.TargetNodeDisplayName));
                                availableSensors.Sensors.Add(sensorMetadata);
                            }
                            break;
                        case EventType.DataframeEventType:
                            foreach (var sensor in sensors)
                            {
                                var sensorMetadata = new SensorMetadata()
                                {
                                    SensorId = sensor.SensorId,
                                };
                                sensorMetadata.Properties.Add(Constants.KnownPropertyNames.SensorMetadata.DisplayName, new Property(sensor.TargetNodeDisplayName));
                                availableSensors.Sensors.Add(sensorMetadata);
                            }
                            break;
                    }
                }
                var messageWrapper = availableSensors.ToMessageWrapper();
                return messageWrapper;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
