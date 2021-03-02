using Google.Protobuf;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Websocket.Client;

namespace YahooQuotesLive
{
    public partial class MainForm : Form
    {
        private delegate void SetTextDelegate(Label ticker, string labelValue, Label quote, string quoteValue, Color color);

        private Label _lastLabelTicker;
        private Label _lastLabelQuote;
        private MessageParser<YahooQuote> _parser;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _parser = new MessageParser<YahooQuote>(() => new YahooQuote());
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            CenterToScreen();
        }

        private void Update(Label ticker, string tickerValue, Label quote, string quoteValue, Color color)
        {
            ticker.Text = tickerValue;
            quote.Text = quoteValue;
            quote.ForeColor = color;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (_lastLabelTicker == null)
            {
                _lastLabelTicker = new Label();
                _lastLabelTicker.Location = new Point(lblYahooSymbol.Location.X, lblYahooSymbol.Location.Y + lblYahooSymbol.Size.Height + 20);
            }
            else
            {
                var previousLabelTicker = _lastLabelTicker;
                _lastLabelTicker = new Label();
                _lastLabelTicker.Location = new Point(previousLabelTicker.Location.X, previousLabelTicker.Location.Y + previousLabelTicker.Size.Height + 20);
            }

            _lastLabelQuote = new Label();
            _lastLabelQuote.Location = new Point(_lastLabelTicker.Location.X + 60, _lastLabelTicker.Location.Y);
            _lastLabelQuote.Size = new Size(500, _lastLabelQuote.Size.Height);

            Controls.Add(_lastLabelQuote);
            Controls.Add(_lastLabelTicker);

            string yahooSymbol = tbxYahooSymbol.Text.ToUpper();

            await Task.Factory.StartNew(() =>
            {
                var lastLabelTicker = _lastLabelTicker;
                var lastLabelQuote = _lastLabelQuote;

                using (var client = new WebsocketClient(new Uri("wss://streamer.finance.yahoo.com")))
                {
                    client.ReconnectTimeout = TimeSpan.FromSeconds(10);
                    client.MessageReceived.Subscribe(msg =>
                    {
                        byte[] data = Convert.FromBase64String(msg.Text);
                        var quote = _parser.ParseFrom(data);
                        string quoteText = DisplayQuote(quote);                        
                        Invoke(new SetTextDelegate(Update),
                            lastLabelTicker,
                            yahooSymbol,
                            lastLabelQuote,
                            quoteText,
                            quote.ChangePercent > 0 ? Color.Green : Color.Red);
                    });
                    client.Start();
                    client.Send(@"{ ""subscribe"": [""[TICKER]""] }".Replace("[TICKER]", yahooSymbol));
                    new ManualResetEvent(false).WaitOne();
                }
            });
        }

        private string DisplayQuote(YahooQuote quote)
        {
            return $"{Math.Round(quote.Price, 2)} {Math.Round(quote.Change, 2)} ({Math.Round(quote.ChangePercent, 2)}%)";
        }        
    }
}
