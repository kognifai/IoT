/* -----------------------------------------------------------------------------
 *
 * M2MQTT client example using Kognifai Serialization library for serializing
 * 
 * The example client shows how to connect/disconnect to/from a MQTT server/broker
 * as well as giving examples on how to send messages to the Kognifai platform
 * using the Kognifai Serialization library.
 * 
 * The following messages are supported:
 * - TimeseriesDoublesReplicationMessage
 * - AlarmReplicationMessage
 * - StateChangeReplicationMessage
 * - DataframeReplicationMessage
 * 
 * The program also includes an example on how messages can be grouped together and
 * sent in a container.
 *
 * Supports both Net40 and Net462
 *
 * Copyright Kongsberg Digital AS © 2017
 *
 * ------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Kognifai.Serialization;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Kognifai.Mqtt;
#if NET_FRAMEWORK40
#else
using Google.Protobuf;
#endif

namespace M2MqttExampleClient
{
    class Program
    {
        private static MqttClient client;
        private static uint state = 0;
        private static bool alarmOnOff = false;
        private static bool toggleCosSin = false;
        private static string clientId;
        private static string server;
        private static CancellationTokenSource cancel;

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: <clientId> <server>");
                return;
            }

            cancel = new CancellationTokenSource();
            clientId = args[0];
            server = args[1];
            RunClient(clientId, server);
        }

        private static Task Delay(int milliseconds)
        {
            var tcs = new TaskCompletionSource<object>();
            new Timer(_ => tcs.SetResult(null)).Change(milliseconds, -1);
            return tcs.Task;
        }

        private static void Connect(bool isReconnect)
        {
            while (!cancel.IsCancellationRequested && !client.IsConnected)
            {
                try
                {
                    if (isReconnect)
                    {
                        var task = Delay(5000);
                        task.Wait(cancel.Token);
                    }
                    Console.WriteLine("### Connecting to the server ###");
                    client.Connect(clientId);
                    Console.WriteLine("### M2MQTT Client connected and ready ### ");
                }
                catch (Exception ex)
                {
                    if ((ex is OperationCanceledException) || cancel.IsCancellationRequested)
                        break;

                    Console.WriteLine("### Connecting to the server failed retrying in 5s ###");
                    isReconnect = true;
                }
            }
        }
        private static void ConnectionClosed(object sender, EventArgs e)
        {
            if (cancel.IsCancellationRequested)
                return;

            /* reconnect to the server */
            Console.WriteLine("### Disconnected from server, reconnecting in 5 seconds.... ###");
            var connect = new Task(() => Connect(true));
            connect.Start();
        }
        private static void RunClient(string clientId, string server)
        {
            /* create the client instance */
            client = new MqttClient(server);

            /* register handler for connectio closed event */
            client.ConnectionClosed += ConnectionClosed;

            /* connect to the server */
            var connectClient = new Task(() => Connect(false));
            connectClient.Start();

            while (!cancel.IsCancellationRequested)
            {
                try
                {
                    Console.WriteLine("1 = Send time series messages");
                    Console.WriteLine("2 = send alarm {0} message", alarmOnOff ? "off" : "on");
                    Console.WriteLine("3 = send a state changed message");
                    Console.WriteLine("4 = send a sample set message");
                    Console.WriteLine("5 = send a compressed container");
                    Console.WriteLine("6 = send available sensors");
                    Console.WriteLine("Q = quit");
                    var pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.Q)
                    {
                        cancel.Cancel();
                        if (client.IsConnected)
                        {
                            Console.WriteLine("### Disconnecting from server ###");
                            client.Disconnect();
                        }
                        Console.WriteLine("### Done, press any key to continue ###");
                        Console.ReadKey(true);
                        continue;
                    }

                    if (!client.IsConnected)
                    {
                        Console.WriteLine("### Not Connected to the server, try again later ### ");
                        continue;
                    }

                    /* send timeseries doubles messages (a sinus periode) */
                    if (pressedKey.Key == ConsoleKey.D1)
                    {
                        double i;
                        for (i = 0.0; i < 360.0; i++)
                        {
                            DateTimeOffset time = DateTimeOffset.Now.AddYears(0);

                            TimeseriesDoublesReplicationMessage tds = new TimeseriesDoublesReplicationMessage("TimeSeries01", time, Math.Sin(Math.PI / 180 * i));
                            var messageWrpper = tds.ToMessageWrapper();
                            client.Publish(Topics.CloudBound, messageWrpper.ToByteArray(), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                            var delay = Delay(1);
                            delay.Wait();
                        }
                    }

                    /* send alarm event messages, toggles the alarm on/off */
                    if (pressedKey.Key == ConsoleKey.D2)
                    {
                        AlarmStateType alarmState;
                        alarmOnOff = !alarmOnOff;

                        if (alarmOnOff)
                            alarmState = AlarmStateType.AlarmState;
                        else
                            alarmState = AlarmStateType.NormalState;

                        var alarm = new AlarmReplicationMessage
                        {
                            ExternalId = "Alarm01"
                        };
                        AlarmEvent aEv = new AlarmEvent(
                            DateTime.UtcNow,
                            AlarmLevelType.EmergencyLevel,
                            alarmState,
                            "Info level, Normal state");
                        alarm.AlarmEvents.Add(aEv);
                        var messageWrapper = alarm.ToMessageWrapper();
                        client.Publish(Topics.CloudBound, messageWrapper.ToByteArray(), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                        var delay = Delay(10);
                        delay.Wait();
                    }

                    /* send state change event messages */
                    if (pressedKey.Key == ConsoleKey.D3)
                    {
                        state %= 5;
                        var stateChanged = new StateChangeReplicationMessage()
                        {
                            ExternalId = "StateChangeEvent01",
                        };
                        var sEv = new StateChange(
                            DateTime.UtcNow,
                            "Donald Duck",
                            true,
                            state);
                        stateChanged.StateChanges.Add(sEv);
                        var messageWrapper = stateChanged.ToMessageWrapper();
                        client.Publish(Topics.CloudBound, messageWrapper.ToByteArray(), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                        state++;
                    }

                    /* send sample set messages, alternates between a sinus/cosinus periode */
                    if (pressedKey.Key == ConsoleKey.D4)
                    {
                        toggleCosSin = !toggleCosSin;
                        /* create a sample set */
                        List<double> samples = new List<double>();
                        double i;
                        for (i = 0.0; i < 360.0; i++)
                        {
                            int count = 0;
                            double value;
                            if (toggleCosSin)
                                value = Math.Sin(Math.PI / 180 * i);
                            else
                                value = Math.Cos(Math.PI / 180 * i);
                            samples.Add(value);
                            count++;
                        }

                        DataframeColumn dataframeColumn = new DataframeColumn(samples);
                        DataframeEvent dataFrame = new DataframeEvent(DateTimeOffset.UtcNow, dataframeColumn);

                        DataframeReplicationMessage samplesetReplicationMessage = new DataframeReplicationMessage("SampleSet01", dataFrame);
                        var messageWrapper = samplesetReplicationMessage.ToMessageWrapper();
                        client.Publish(Topics.CloudBound, messageWrapper.ToByteArray(), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                    }

                    /* send a compressed container consisting of time series,
                     * alarm, state changes and sample set
                     */
                    if (pressedKey.Key == ConsoleKey.D5)
                    {
                        int i;
                        MessageArray array = new MessageArray();

                        /* add some timeseries messages */
                        for (i = 0; i < 10; i++)
                        {
                            DateTimeOffset time = DateTimeOffset.UtcNow;

                            TimeseriesDoublesReplicationMessage tds = new TimeseriesDoublesReplicationMessage("TimeSeries01", time, i + 1);
                            array.Messages.Add(tds.ToMessageWrapper());
                            var delay = Delay(10);
                            delay.Wait();
                        }

                        /* add some state change event messages */
                        bool manOverride = true;
                        var stateChanged = new StateChangeReplicationMessage
                        {
                            ExternalId = "StateChangeEvent01",
                        };
                        for (i = 0; i < 10; i++)
                        {
                            manOverride = !manOverride;
                            var sEv = new StateChange(
                                DateTime.UtcNow,
                                "Donald Duck",
                                manOverride,
                                (uint)i + 1);
                            stateChanged.StateChanges.Add(sEv);
                            var delay = Delay(10);
                            delay.Wait();
                        }
                        array.Messages.Add(stateChanged.ToMessageWrapper());

                        /* add some sample set messages */
                        for (i = 0; i < 10; i++)
                        {
                            List<double> samples = new List<double>();
                            for (int j = 0; j < 10; j++)
                            {
                                samples.Add(j);
                            }
                            DataframeColumn dataframeColumn = new DataframeColumn(samples);
                            DataframeEvent dataFrame = new DataframeEvent(DateTimeOffset.UtcNow, dataframeColumn);
                            DataframeReplicationMessage samplesetReplicationMessage = new DataframeReplicationMessage("SampleSet01", dataFrame);
                            array.Messages.Add(samplesetReplicationMessage.ToMessageWrapper());
                            var delay = Delay(10);
                            delay.Wait();
                        }

                        /* add some alarm event messages */
                        alarmOnOff = false;
                        for (i = 0; i < 10; i++)
                        {
                            Kognifai.Serialization.AlarmStateType alarmState;
                            alarmOnOff = !alarmOnOff;
                            alarmState = alarmOnOff ? AlarmStateType.AlarmState : AlarmStateType.NormalState;

                            var alarm = new AlarmReplicationMessage
                            {
                                ExternalId = "Alarm01",
                            };
                            AlarmEvent aEv = new AlarmEvent(
                                DateTime.UtcNow,
                                AlarmLevelType.EmergencyLevel,
                                alarmState,
                                "Info level, Normal state");
                            alarm.AlarmEvents.Add(aEv);
                            array.Messages.Add(alarm.ToMessageWrapper());
                            var delay = Delay(10);
                            delay.Wait();
                        }
                        MessageArrayContainer container = new MessageArrayContainer("", array, true);
                        client.Publish(Topics.CloudBoundContainer, container.ToByteArray(), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                    }


                    /*send available sensors
                     * Place your avaialablesensor.csv file under GatewayConfigurationFiles folder
                     */
                    if (pressedKey.Key == ConsoleKey.D6)
                    {
                        var sensors = CsvFileReader.ReadDataFromCsvFile("..\\GatewayConfigurationFiles\\availablesensorlist.csv");
                        AvailableSensorListReplicationMessage availableSensors = new AvailableSensorListReplicationMessage();
                        availableSensors.ConnectorType = "Mqtt";
                        availableSensors.SourceName = "source1";
                        availableSensors.Sensors.AddRange(sensors);
                        var messageWrapper = availableSensors.ToMessageWrapper();
                        client.Publish(Topics.AvaialableSensorList, messageWrapper.ToByteArray(), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
                        Console.WriteLine("Published available sensor list");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
            cancel.Dispose();
        }

    }
}
