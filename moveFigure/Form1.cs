namespace moveFigure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Graphics g;
        
        public int x = 10;
        public int y = 10;
        public int width = 100;
        public int height = 100;

        public bool ismd = false;

        public bool isInsideShape(int px, int py, int pw, int ph, int mx, int my)
        {
            if (mx > px && mx < px + pw) {
                if (my > py && my < py + ph)
                {
                    return true;
                }
            }
            return false;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1024;
            this.Height = 768;

            g = CreateGraphics();


        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            drawShape();
        }

        public void drawShape()
        {
            g.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(x,y,width,height));
        }
        public void clearScreen()
        { 
            g.Clear(BackColor);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = this.isInsideShape(x, y, width, height, e.X, e.Y).ToString();
            if ((this.isInsideShape(x, y, width, height, e.X, e.Y) == true) && (ismd == true))
            {
                this.x = e.X-10;
                this.y = e.Y-10;
                
            }
            clearScreen();
            drawShape();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            ismd = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ismd = true;
        }
    }
}