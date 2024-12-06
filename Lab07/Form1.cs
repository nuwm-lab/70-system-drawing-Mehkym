namespace Lab07
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen penRed;
        Pen penBlue;
        public Form1()
        {
            InitializeComponent();
            penRed = new Pen(Color.Red, 2);
            penBlue = new Pen(Color.Blue, 3);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(this.BackColor);

            // ������ ������ ����
            int maxX = this.ClientSize.Width;
            int maxY = this.ClientSize.Height;

            int centerX = maxX / 2;
            int centerY = maxY / 2;
            // ��������� ���� ���������
            e.Graphics.DrawLine(penRed, 0, centerY, maxX, centerY);
            e.Graphics.DrawLine(penRed, centerX, 0, centerX, maxY);
            double startX = -4;
            double endX = 4;
            double step = 0.1;
            // ������� �� �� �
            int scaleX = this.ClientSize.Width / (int)(endX - startX);
            // ������� �� �� Y
            int scaleY = 20;
            
            Brush brush = Brushes.Green;
            // ���������� ����� ����� ������ ��� ���������
            int prevX = centerX + (int)(startX * scaleX);
            int prevY = centerY - (int)(Func(startX) * scaleY);
            // ���������� ����� ����� ������ ��� ���������
            int paintX, paintY;

            for (double x = startX + step; x <= endX + 0.01; x += step)
            {
                double y = Func(x);
                paintX = centerX + (int)(x * scaleX);
                paintY = centerY - (int)(y * scaleY);
                e.Graphics.DrawLine(penBlue, prevX, prevY, paintX, paintY);
                prevY = paintY;
                prevX = paintX;
            }
        }

        private double Func(double x)
        {
            return (x * x + 2 * x) / (Math.Cos(5 * x) + 2);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // ����������� ���������������� ��� ��� ������
            this.Invalidate();
        }
    }
}
