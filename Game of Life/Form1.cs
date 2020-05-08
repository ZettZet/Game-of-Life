using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Game_of_Life {
	public partial class Form1 : Form {
		#region Свойства
		internal Life Univers { get; set; }
		public int Rows { get; set; }
		public int Columns { get; set; }
		public new int Scale { get; } = 10;
		public bool Pause { get; set; }
		#endregion

		public Form1() {
			InitializeComponent();
			Rows = UniversePanel.Height / Scale;
			Columns = UniversePanel.Width / Scale;
			Size = MaximumSize = MinimumSize = new Size(Columns * Scale + 17, Rows * Scale + 40);

			Univers = new Life(Columns, Rows);
			Pause = false;
			ChangePauseState();

			UniversePanel.MouseClick += Universe_MouseClick;
		}

		#region Перерисовка
		private void Redraw(Point point) {
			using(Graphics g = UniversePanel.CreateGraphics()) {
				Rectangle rect = new Rectangle(new Point(point.X * Scale + 1, point.Y * Scale + 1),
											   new Size(Scale - 1, Scale - 1));

				g.FillRectangle(new Pen(Univers.Allive[point.X][point.Y] == true ? Color.White : Color.Black, 0.5f).Brush,
								rect);
			}
		}
		#endregion

		#region Системные методы
		private void Form1_KeyDown(object sender, KeyEventArgs e) {
			switch(e.KeyCode) {
				case Keys.Space:
					ChangePauseState();
					break;
				case Keys.Tab:
					foreach(Point item in Univers.Clear()) {
						Redraw(item);
					}
					break;
				default:
					break;
			}
		}
		private void ChangePauseState() {
			if(Pause) {
				timer1.Stop();
			}
			else {
				timer1.Start();
			}

			Pause = !Pause;
		}
		private void Timer1_Tick(object sender, EventArgs e) {
			foreach(Point item in Univers.CheckAllives()) {
				Redraw(item);
			}
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
		#endregion
	}
}
