using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace MeyerSStore
{
    public partial class ConfigurarControl : UserControl
    {
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice;
        private string selectedCamera;

        public ConfigurarControl()
        {
            InitializeComponent();
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            comboBoxCameraIniciar();
            selectedCamera = GetSelectedVideoCaptureDevice();
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void comboBoxCameraIniciar()
        {
            foreach (FilterInfo filterinfo in filterInfoCollection)
            {
                comboBoxCamera.Items.Add(filterinfo.Name);
            }

            comboBoxCamera.SelectedIndex = 0;
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            bitmap = ResizeImage(bitmap, pictureBoxCamera.Width, pictureBoxCamera.Height);
            pictureBoxCamera.Image = bitmap;
        }

        public Bitmap ResizeImage(Bitmap originalImage, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(originalImage, 0, 0, width, height);
            }

            return resizedImage;
        }

        public string GetSelectedVideoCaptureDevice()
        {
            try
            {
                if (comboBoxCamera.SelectedIndex >= 0)
                {
                    selectedCamera = filterInfoCollection[comboBoxCamera.SelectedIndex].MonikerString;
                    return selectedCamera;
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado una cámara válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener la cámara: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void ConfigurarControl_Enter(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(GetSelectedVideoCaptureDevice());
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }

        public void DetenerCamara()
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice.WaitForStop();
            }
        }

        private void ConfigurarControl_Leave(object sender, EventArgs e)
        {
            DetenerCamara();
        }
    }
}
