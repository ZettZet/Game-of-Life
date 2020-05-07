using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace Game_of_Life {
	class Life {
		public bool[][] Allive { get; private set; }
		public Life(int x, int y) {
			Allive = new bool[x][];
			for(int i = 0; i < x; i++) {
				Allive[i] = new bool[y];
				for(int j = 0; j < y; j++) {
					Allive[i][j] = false;
				}
			}
		}
		#region Работа с ячейками
		public void SetAlliveCell(Point cursor) => Allive[cursor.X][cursor.Y] = true;
		public void SetDeadCell(Point cursor) => Allive[cursor.X][cursor.Y] = false;
		public IEnumerable<Point> CheckAllives() {
			List<Point> Changes = new List<Point>();

			int[] dx = { -1, -1, -1, 0, 1, 1, 1, 0 };
			int[] dy = { -1, 0, 1, 1, 1, 0, -1, -1 };
			bool[][] newAllive = new bool[Allive.Length][];

			for(int x = 0; x < Allive.Length; x++) {
				newAllive[x] = new bool[Allive[0].Length];
				for(int y = 0; y < Allive[0].Length; y++) {
					int countNeibour = 0;

					for(int k = 0; k < 8; k++) {
						countNeibour += Allive[Mod((x + dx[k]), Allive.Length)][Mod(y + dy[k], Allive[0].Length)] ? 1 : 0;
					}

					newAllive[x][y] = (countNeibour == 3) || (Allive[x][y] && countNeibour == 2);
					if(Allive[x][y] != newAllive[x][y]) {
						Changes.Add(new Point(x, y));
					}
				}
			}
			Allive = newAllive;
			return Changes;
		}
		public IEnumerable<Point> Clear() {
			List<Point> Changes = new List<Point>();

			for(int x = 0; x < Allive.Length; x++) {
				for(int y = 0; y < Allive[0].Length; y++) {
					if(Allive[x][y] == true) {
						Changes.Add(new Point(x, y));
						Allive[x][y] = false;
					}
				}
			}

			return Changes;
		}
		#endregion
		int Mod(int divident, int divisor) => divident < 0 ? divisor + divident : divident % divisor;
	}
}
