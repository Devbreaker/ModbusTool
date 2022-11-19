using System;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Media;
using Modbus.Common;
using ModbusLib;
using ModbusLib.Protocols;
using SciChart.Charting.ChartModifiers;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals;
using SciChart.Charting.Visuals.Axes;
using SciChart.Charting.Visuals.RenderableSeries;
using SciChart.Data.Model;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals.Annotations;
using System.Linq;
using System.Text.RegularExpressions;
using SciChart.Drawing.VisualXcceleratorRasterizer;
using SciChart.Drawing.XamlRasterizer;
using SciChart.Charting;
using System.Windows;

namespace ModbusMaster
{
    public partial class MasterForm : BaseForm
    {
        private int _transactionId;
        private ModbusClient _driver;
        private ICommClient _portClient;
        private SerialPort _uart;

        private byte _lastReadCommand = 0;

        #region Form
        SciChartSurface sciChartSurface;
        FastLineRenderableSeries renderableSeries0;
        XyDataSeries<DateTime, double> xyData;
        private int _second;
        DateTimeAxis xAxis;// = new DateTimeAxis() { AxisTitle = "TimeSpan (per series)" };
        NumericAxis yAxis;// = new NumericAxis() { AxisTitle = "Value" };
        private void UpdateLabel(VerticalLineAnnotation annotation)
        {
            var expr = annotation.GetBindingExpression(LineAnnotationWithLabelsBase.LabelValueProperty);

            if (expr != null)
            {
                var binding = expr.ParentBinding;
                annotation.SetBinding(LineAnnotationWithLabelsBase.LabelValueProperty, binding);
            }
        }
        public MasterForm()
        {
            InitializeComponent();
            this.Text += String.Format(" ({0})", Assembly.GetExecutingAssembly().GetName().Version.ToString());
          ;
            //  _series0 = new UniformXyDataSeries<double>(t, dt) { FifoCapacity = FifoSize };

            //_series0 = new UniformXyDataSeries<double>(dt) { FifoCapacity = FifoSize, SeriesName = "Orange Series" };

            //    lineSeries.DataSeries = _series0;
            //scs.s DataSeries(_series0);
            Load += MasterForm_Load1;
            //ucChart ucChart = new ucChart();
            //panel1.Controls.Add(ucChart);
            //sci = ucChart.GetSciChartSurface;
            //xyData = ucChart.GetXYData;
           
        }
        

        SciChartSurface sci;
        /// <summary>
        /// Convert a hex string to a .NET Color object.
        /// </summary>
        /// <param name="hexColor">a hex string: "FFFFFF", "#000000"</param>
        public static Color HexStringToColor(string hexColor)
        {
            string hc = ExtractHexDigits(hexColor);
            if (hc.Length != 6)
            {
                // you can choose whether to throw an exception
                //throw new ArgumentException("hexColor is not exactly 6 digits.");
                return Colors.White;
            }
            string r = hc.Substring(0, 2);
            string g = hc.Substring(2, 2);
            string b = hc.Substring(4, 2);
            Color color = Colors.White;
            try
            {
                byte ri = byte.Parse(r, System.Globalization.NumberStyles.HexNumber);
                byte gi = byte.Parse(g, System.Globalization.NumberStyles.HexNumber);
                byte bi = byte.Parse(b, System.Globalization.NumberStyles.HexNumber);
                color = Color.FromArgb(100,ri, gi, bi);
            }
            catch
            {
                // you can choose whether to throw an exception
                //throw new ArgumentException("Conversion failed.");
                return Colors.White;
            }
            return color;
        }
        /// <summary>
        /// Extract only the hex digits from a string.
        /// </summary>
        public static string ExtractHexDigits(string input)
        {
            // remove any characters that are not digits (like #)
            Regex isHexDigit
               = new Regex("[abcdefABCDEF\\d]+", RegexOptions.Compiled);
            string newnum = "";
            foreach (char c in input)
            {
                if (isHexDigit.IsMatch(c.ToString()))
                    newnum += c.ToString();
            }
            return newnum;
        }

        //private void ClearDataSeries()
        //{
        //    using (sciChartSurface.SuspendUpdates())
        //    {
        //        _series0?.Clear();
        
        //    }
        //}


        // Data Sample Rate (sec) - 20 Hz
        private const double dt = 0.05;

        // FIFO Size is 100 samples, meaning after 100 samples have been appended, each new sample appended
        // results in one sample being discarded
        private const int FifoSize = 100;

        // Timer to process updates
        private readonly Timer _timerNewDataUpdate;

        // The current time
        private DateTime t;

        // The dataseries to fill
        private readonly IUniformXyDataSeries<double> _series0;
        private readonly IUniformXyDataSeries<double> _series1;
        private readonly IUniformXyDataSeries<double> _series2;
        private void MasterForm_Load1(object sender, EventArgs e)
        {
            sciChartSurface = new SciChartSurface();
            xAxis = new DateTimeAxis()
            {
                TextFormatting = @"hh\:mm\:ss",
                AutoRange = AutoRange.Always,
                AxisTitle = "Time Axis Title",
                //VisibleRange = new TimeSpanRange(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000)),
                //GrowBy = new DoubleRange(0.0, 0.1),
                //AxisAlignment = AxisAlignment.Bottom,
            };

            yAxis = new NumericAxis()
            {
                AxisTitle = "Axis Left Title",
                AutoRange = AutoRange.Once,
                AxisAlignment = AxisAlignment.Right,
                DrawMajorBands = true,
                Id = "PrimaryAxisId",
                TextFormatting = "#,0",
                GrowBy = new DoubleRange(0.2, 0.1),

            };

            sciChartSurface.XAxis = xAxis;
            sciChartSurface.YAxis = yAxis;
            sciChartSurface.RenderSurface = new XamlRenderSurface();
            if (sciChartSurface.RenderSurface.GetType() == typeof(VisualXcceleratorRenderSurface))
            {
                // DirectX is enabled!
            }
            renderableSeries0 = new FastLineRenderableSeries()
            {
                Name = "lineSeries",
                YAxisId = "PrimaryAxisId",
                //Stroke = Colors.DarkOrange,//HexStringToColor("#FF3376E5"),
                StrokeThickness = 2,
                AntiAliasing = false,
                StrokeDashArray = new double[] { 2, 2 },
            };
            //scs.YAxis.AutoRange = AutoRange.Once;
            sciChartSurface.ChartModifier = new ModifierGroup(new RubberBandXyZoomModifier(), new ZoomExtentsModifier() { ExecuteOn = ExecuteOn.MouseDoubleClick }, new PinchZoomModifier(), new MouseWheelZoomModifier(),
                new XAxisDragModifier(), new YAxisDragModifier()
                {
                    AxisId = "PrimaryAxisId"
                }
                , new LegendModifier()
                {
                    Margin = new System.Windows.Thickness(10),
                    ShowLegend = true,
                    ShowVisibilityCheckboxes = false,
                    //GetLegendDataFor = SourceMode.AllSeries

                }
                , new CursorModifier()
                {
                    IsEnabled = true,
                    ShowTooltipOn = ShowTooltipOptions.MouseOver,
                    ShowAxisLabels = true,
                    ShowTooltip = true,
                    SourceMode = SourceMode.AllSeries,
                }
                );
            //var customTheme = new MyCustomTheme();
            ResourceDictionary skinDict = System.Windows.Application.LoadComponent(new Uri(@"/ModbusMaster;component/Dictionary1.xaml", UriKind.Relative)) as ResourceDictionary;
            ThemeManager.AddTheme("MyCustomTheme", skinDict);
            ThemeManager.SetTheme(sciChartSurface, "MyCustomTheme");

            xyData = new XyDataSeries<DateTime, double>() { SeriesName = "Line Series" };

            //scs.RenderableSeries.Add(new FastLineRenderableSeries() { DataSeries = xyData, Stroke = Colors.Crimson });
            //lineSeries = new FastLineRenderableSeries()
            //{
            //    Stroke = Colors.DarkOrange,//HexStringToColor("#FF3376E5"),
            //    StrokeThickness = 2,
            //    AntiAliasing = true,
            //    StrokeDashArray = new double[] { 2, 2 },
            //};

            // Set some data
            //var dataSeries = new XyDataSeries<double, double>();
            //for (int i = 0; i < 100; i++)
            //    dataSeries.Append(i, Math.Sin(i * 0.2));
            renderableSeries0.DataSeries = xyData;
            sciChartSurface.RenderableSeries.Add(renderableSeries0);
            elementHost1.Child = sciChartSurface;
        }
   
      
        private void MasterFormClosing(object sender, FormClosingEventArgs e)
        {
            DoDisconnect();
        }

        #endregion

        #region Connect/disconnect

        private void DoDisconnect()
        {
            if (_socket != null)
            {
                _socket.Close();
                _socket.Dispose();
                _socket = null;
            }
            if (_uart != null)
            {
                _uart.Close();
                _uart.Dispose();
                _uart = null;
            }
            _portClient = null;
            _driver = null;
        }

        private void BtnConnectClick(object sender, EventArgs e)
        {
            try
            {
                switch (CommunicationMode)
                {
                    case CommunicationMode.RTU:
                        _uart = new SerialPort(PortName, Baud, Parity, DataBits, StopBits);
                        _uart.Open();
                        _portClient = _uart.GetClient();
                        _driver = new ModbusClient(new ModbusRtuCodec()) { Address = SlaveId };
                        _driver.OutgoingData += DriverOutgoingData;
                        _driver.IncommingData += DriverIncommingData;
                        AppendLog(String.Format("Connected using RTU to {0}", PortName));
                        break;

                    case CommunicationMode.UDP:
                        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                        _socket.Connect(new IPEndPoint(IPAddress, TCPPort));
                        _portClient = _socket.GetClient();
                        _driver = new ModbusClient(new ModbusTcpCodec()) { Address = SlaveId };
                        _driver.OutgoingData += DriverOutgoingData;
                        _driver.IncommingData += DriverIncommingData;
                        AppendLog(String.Format("Connected using UDP to {0}", _socket.RemoteEndPoint));
                        break;

                    case CommunicationMode.TCP:
                        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
                        _socket.SendTimeout = 2000;
                        _socket.ReceiveTimeout = 2000;
                        _socket.Connect(new IPEndPoint(IPAddress, TCPPort));
                        _portClient = _socket.GetClient();
                        _driver = new ModbusClient(new ModbusTcpCodec()) { Address = SlaveId };
                        _driver.OutgoingData += DriverOutgoingData;
                        _driver.IncommingData += DriverIncommingData;
                        AppendLog(String.Format("Connected using TCP to {0}", _socket.RemoteEndPoint));
                        break;
                }
            }
            catch (Exception ex)
            {
                AppendLog(ex.Message);
                return;
            }
            btnConnect.Enabled = false;
            buttonDisconnect.Enabled = true;
            groupBoxFunctions.Enabled = true;
            groupBoxTCP.Enabled = false;
            groupBoxRTU.Enabled = false;
            groupBoxMode.Enabled = false;
            grpExchange.Enabled = false;
        }

        private void ButtonDisconnectClick(object sender, EventArgs e)
        {
            DoDisconnect();
            btnConnect.Enabled = true;
            pollTimer.Enabled = false;
            buttonDisconnect.Enabled = false;
            groupBoxFunctions.Enabled = false;
            groupBoxMode.Enabled = true;
            grpExchange.Enabled = true;
            SetMode();
            AppendLog("Disconnected");
        }

        #endregion

        #region Functions buttons

        private void BtnReadCoilsClick(object sender, EventArgs e)
        {
            ExecuteReadCommand(ModbusCommand.FuncReadCoils);
        }

        private void BtnReadDisInpClick(object sender, EventArgs e)
        {
            ExecuteReadCommand(ModbusCommand.FuncReadInputDiscretes);
        }

        private void BtnReadHoldRegClick(object sender, EventArgs e)
        {
            ExecuteReadCommand(ModbusCommand.FuncReadMultipleRegisters);
        }

        private void BtnReadInpRegClick(object sender, EventArgs e)
        {
            ExecuteReadCommand(ModbusCommand.FuncReadInputRegisters);
        }
        DateTime load = DateTime.Now;


        private void ExecuteReadCommand(byte function)
        {
            _lastReadCommand = function;

            try
            {
                var command = new ModbusCommand(function) {Offset = StartAddress, Count = DataLength, TransId = _transactionId++};
                var result = _driver.ExecuteGeneric(_portClient, command);

                if (result.Status == CommResponse.Ack)
                {
                    command.Data.CopyTo(_registerData, StartAddress);
                    int idex = Convert.ToInt16(txtAddress.Text);
                    var value = Convert.ToDouble(_registerData[idex]);
                    //TimeSpan myDateResult = DateTime.Now.TimeOfDay;
                    using (sciChartSurface.SuspendUpdates())
                    {

                        xyData.Append(DateTime.Now, value);

                    }
                    //t += dt;
                    //t = _second;

                    //lineSeries.DataSeries = xyData;
                    //UpdateLineAnnotations();
                    UpdateDataTable();
                    AppendLog(String.Format("Read succeeded: Function code:{0}.", function));
                }
                else
                {
                    AppendLog(String.Format("Failed to execute Read: Error code:{0}", result.Status));
                }
            }
            catch (Exception ex)
            {
                AppendLog(ex.Message);
            }
        }

        private void ExecuteWriteCommand(byte function)
        {
            try
            {
                var command = new ModbusCommand(function)
                                  {
                                      Offset = StartAddress,
                                      Count = DataLength,
                                      TransId = _transactionId++,
                                      Data = new ushort[DataLength]
                                  };
                for (int i = 0; i < DataLength; i++)
                {
                    var index = StartAddress + i;
                    if (index > _registerData.Length)
                    {
                        break;
                    }
                    command.Data[i] = _registerData[index];
                }
                var result = _driver.ExecuteGeneric(_portClient, command);
                AppendLog(result.Status == CommResponse.Ack
                              ? String.Format("Write succeeded: Function code:{0}", function)
                              : String.Format("Failed to execute Write: Error code:{0}", result.Status));
            }
            catch (Exception ex)
            {
                AppendLog(ex.Message);
            }
        }


        private void BtnWriteSingleCoilClick(object sender, EventArgs e)
        {
            try
            {
                var command = new ModbusCommand(ModbusCommand.FuncWriteCoil)
                {
                    Offset = StartAddress,
                    Count = 1,
                    TransId = _transactionId++,
                    Data = new ushort[1]
                };
                command.Data[0] = (ushort)(_registerData[StartAddress] & 0x0100);
                var result = _driver.ExecuteGeneric(_portClient, command);
                AppendLog(result.Status == CommResponse.Ack
                              ? String.Format("Write succeeded: Function code:{0}", ModbusCommand.FuncWriteCoil)
                              : String.Format("Failed to execute Write: Error code:{0}", result.Status));
            }
            catch (Exception ex)
            {
                AppendLog(ex.Message);
            }
        }

        private void BtnWriteSingleRegClick(object sender, EventArgs e)
        {
            ExecuteWriteCommand(ModbusCommand.FuncWriteSingleRegister);
        }

        private void BtnWriteMultipleCoilsClick(object sender, EventArgs e)
        {
            ExecuteWriteCommand(ModbusCommand.FuncForceMultipleCoils);
        }

        private void BtnWriteMultipleRegClick(object sender, EventArgs e)
        {
            ExecuteWriteCommand(ModbusCommand.FuncWriteMultipleRegisters);
        }

        private void ButtonReadExceptionStatusClick(object sender, EventArgs e)
        {

        }

        #endregion

        private void txtPollDelay_Leave(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (int.TryParse(textBox.Text, out var parsedMillisecs))
            {
                pollTimer.Interval = parsedMillisecs;
            }
            else
            {
                textBox.Text = "0";
                cbPoll.Checked = false;
                pollTimer.Enabled = false;
            }

        }

        private void cbPoll_CheckStateChanged(object sender, EventArgs e)
        {
            pollTimer.Enabled = cbPoll.Checked;
            if (int.TryParse(txtPollDelay.Text, out var parsedMillisecs))
            {
                pollTimer.Interval = parsedMillisecs;
            }
            if (!pollTimer.Enabled)
                _lastReadCommand = 0;
        }

        private void pollTimer_Tick(object sender, EventArgs e)
        {
            if (_lastReadCommand != 0)
                ExecuteReadCommand(_lastReadCommand);
        }

        private void grpStart_Enter(object sender, EventArgs e)
        {

        }

        private void btnChartUIUdate_Click(object sender, EventArgs e)
        {
            sciChartSurface.XAxis.AxisTitle = txtChartXTitle.Text;
            sciChartSurface.YAxis.AxisTitle = txtChartYTitle.Text;
            if (int.TryParse(txtChartYMax.Text, out var parse))
            {
                sciChartSurface.YAxis.VisibleRange = new DoubleRange(0, parse);
            }

        }
    }

   
}
