using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_of_Life {
	public partial class Form1 : Form {
		internal Life Univers { get; set; }
		public int Rows { get; set; }
		public int Columns { get; set; }
		public new int Scale { get; } = 20;
		public bool Pause { get; set; }

		public Form1() {
			InitializeComponent();
			Rows = UniversePanel.Height / Scale;
			Columns = UniversePanel.Width / Scale;
			Univers = new Life(Columns, Rows);
			RedrawAll();
			Pause = true;

			UniversePanel.MouseClick += Universe_MouseClick;
		}

		private void Universe_MouseClick(object sender, MouseEventArgs e) {
			Point inLocal = new Point(e.Location.X / Scale, e.Location.Y / Scale);
			switch(e.Button) {
				case MouseButtons.Left:
					Univers.SetAlliveCell(inLocal);
					break;
				case MouseButtons.Right:
					Univers.SetDeadCell(inLocal);
					break;
				default:
					break;
			}
			Redraw(inLocal);
		}

		private void Redraw(Point point) {
			using(Graphics g = UniversePanel.CreateGraphics()) {
				Rectangle rect = new Rectangle(new Point(point.X * Scale + 1, point.Y * Scale + 1),
											   new Size(Scale - 1, Scale - 1));

				g.FillRectangle(new Pen(Univers.Allive[point.X][point.Y] == true ? Color.White : Color.Black, 0.5f).Brush,
								rect);
			}
		}

		private void RedrawAll() {
			using(Graphics g = UniversePanel.CreateGraphics()) {
				for(int x = 0; x < Columns; x++) {
					for(int y = 0; y < Rows; y++) {
						Rectangle rect = new Rectangle(new Point((x * Scale) + 1, (y * Scale) + 1),
													   new Size(Scale - 1, Scale - 1));

						g.FillRectangle(new Pen(Univers.Allive[x][y] == true ? Color.White : Color.Black, 0.5f).Brush,
								rect);
					}
				}
			}
		}

		private void Timer1_Tick(object sender, EventArgs e) {
			RedrawAll();
			Univers.CheckAllives();
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			switch(e.KeyCode) {
				case Keys.Space:
					if(Pause == true) {
						timer1.Stop();
					}
					else {
						timer1.Start();
					}
					Pause = !Pause;
					break;
				case Keys.Tab:
					Univers.Clear();
					break;
				default:
					break;
			}
		}
	}
}
