using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Rendering;

namespace TP_OH_AdminControlPanel
{
    public partial class QRCodeGeneration : Form
    {
        public QRCodeGeneration()
        {
            InitializeComponent();
        }

        private TPOHEntities context = new TPOHEntities();
        private List<EventsTable> eventList;

        private void QRCodeGeneration_Load(object sender, EventArgs e)
        {
            eventList = context.EventsTables.ToList();
            foreach (var program in eventList)
            {
                eventCB.Items.Add($"{program.eventName} - ({program.CourseTable.courseShortName})");
            }
        }

        private void qrCodePhoto_Click(object sender, EventArgs e)
        {
        }

        private void eventCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var eventQRCode = eventList[eventCB.SelectedIndex].qrCodeString;
            var barcodeWriter = new QRCodeWriter();
            BitMatrix bm = barcodeWriter.encode(eventQRCode, ZXing.BarcodeFormat.QR_CODE, 600, 600);
            BitmapRenderer bit = new BitmapRenderer();
            Bitmap image = bit.Render(bm, ZXing.BarcodeFormat.QR_CODE, eventQRCode);
            qrCodePhoto.Image = image;
        }
    }
}