// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;

namespace NickAc.LightPOS.Backend.Data
{
    public class MioReaderWrapper : IDisposable
    {
        public MioReaderWrapper(int id) : this("COM" + id)
        {
        }

        public MioReaderWrapper(string portId)
        {
            InternalSerial = new SerialPort(portId);
            try
            {
                InternalSerial.Open();
                Task.Factory.StartNew(() => StartReadingPort(16));
            }
            catch (Exception)
            {
                // ignored
            }
        }

        internal SerialPort InternalSerial { get; set; }

        //%00 04030201 01?
        public char StartChar => '%';

        public char EndChar => '?';

        public Stack<char> CardId { get; set; } = new Stack<char>();

        public void Dispose()
        {
            InternalSerial.Dispose();
        }

        public event Action<string> CardRead;

        private void StartReadingPort(int blockLimit)
        {
            var port = InternalSerial;
            var buffer = new byte[blockLimit];

            void StartReading()
            {
                try
                {
                    port.BaseStream.BeginRead(buffer, 0, buffer.Length, delegate(IAsyncResult ar)
                    {
                        try
                        {
                            var actualLength = port.BaseStream.EndRead(ar);
                            var received = new byte[actualLength];
                            Buffer.BlockCopy(buffer, 0, received, 0, actualLength);
                            for (var i = 0; i < blockLimit; i++)
                                if (buffer[i] == StartChar)
                                {
                                    CardId.Clear();
                                    buffer = new byte[blockLimit];
                                }
                                else if (buffer[i] == EndChar)
                                {
                                    CardRead?.Invoke(string.Join("", CardId.ToArray()).Substring(2, 8));
                                    CardId.Clear();
                                    buffer = new byte[blockLimit];
                                }
                                else
                                {
                                    CardId.Push((char) buffer[i]);
                                }
                        }
                        catch (IOException)
                        {
                        }

                        StartReading();
                    }, null);
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            StartReading();
        }
    }
}