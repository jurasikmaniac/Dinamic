// Created by SharpDevelop.
// User: Миха
// Date: 01.04.2009
// Time: 10:07

using System;
//using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace graph
{

	public partial class MainForm : Form
	{
		//==============================================//
		//-------------------DRAWING--------------------//
		//----------------------------------------------//
		
		Bitmap im;
		
		void ReFillAll()
		{
			if (nowGraph < 0)
				return;
			im = new Bitmap(pictures[nowGraph].Width, pictures[nowGraph].Height);
			g = Graphics.FromImage(im);
			
			if (makeLines)
				toolStripLabelMakeLine.Visible = ! Equals(letsMakeLine, null);
			
			DrawLines();
			
			DrawEllipses();
			
			if (showWeight)
				DrawWeights();
			
			if (showLabels)
				DrawLabels();
			
			if (showWeightFromPoint)
				DrawWeightsFromPoint();
			
			if (showNumsFleri)
				DrawNumsFleri();
			
			pictures[nowGraph].Image = im;
		}
		
		void DrawEllipses()
		{
			Vertex p = GRAPHS[nowGraph].V_Root.Next;
			while (p != null){
				if ( p == forChange ){
					g.FillEllipse(red_b, p.P.X - Radius, p.P.Y - Radius, 2*Radius, 2*Radius);
				}else
					g.FillEllipse(black_b, p.P.X - Radius, p.P.Y - Radius, 2*Radius, 2*Radius);
				p = p.Next;
			}
		}
		
		void DrawLabels()
		{
			Vertex p = GRAPHS[nowGraph].V_Root.Next;
			while (p != null){
				g.DrawString(p.Label, font, black_b, new Point(p.X + Radius, p.Y - Radius) );
				p = p.Next;
			}
		}
		
		void DrawWeightsFromPoint()
		{
			GRAPHS[nowGraph].SyncFloydMasses(forChange);
			
			Vertex p = GRAPHS[nowGraph].V_Root.Next;
			while (p != null){
				if (p.MassaFromNowPoint != double.PositiveInfinity)
					g.DrawString(p.MassaFromNowPoint.ToString(), font, red_b, new Point(p.X - Radius -10, p.Y - Radius -10) );
				p = p.Next;
			}
		}
		
		void DrawLines()
		{
			Edge ed = GRAPHS[nowGraph].E_Root.Next;
			while (ed != null){
				double length, alpha;
				if (! ed.iAmFirstLine ){
					//Find Center:
					int dx = (int)(ed.V_from.X - ed.V_where.X);
					int dy = (int)(ed.V_from.Y - ed.V_where.Y);
					int x = ed.V_where.X + dx/2;
					int y = ed.V_where.Y + dy/2;
					
					length = 30; // длина отступа для DrawBezier
					alpha = Math.Atan2(dx, dy);
					int x_n = (int)Math.Round(length * Math.Cos(alpha));
					int y_n = (int)Math.Round( /* minus mlia minus!!111*/- length * Math.Sin(alpha));
					
					// End FindCenter;
					if (usingLine == ed)
						g.DrawBezier(red_p, ed.V_from.X, ed.V_from.Y, ed.V_from.X, ed.V_from.Y,
						             x + x_n , y + y_n  , ed.V_where.X, ed.V_where.Y);
					else
						g.DrawBezier(black_p, ed.V_from.X, ed.V_from.Y, ed.V_from.X, ed.V_from.Y,
						             x + x_n , y + y_n  , ed.V_where.X, ed.V_where.Y);
					//g.DrawLine(black_p, x + x_n+2, y - y_n+2, x+x_n, y - y_n); // for Testing
//					}else{
//						g.DrawLine(red_p, ed.V_from.X, ed.V_from.Y, ed.V_where.X, ed.V_where.Y);
				}
				
				length = 10; // длина стрелки
				alpha = Math.PI / 8; // угол наклона стрелки
				if (ed.V_from == ed.V_where){
					// Draw ---> on myself
					int x = (int)Math.Round(Math.Cos(alpha)*length);
					int y = (int)Math.Round(Math.Sin(alpha)*length);
					if (usingLine == ed){
						g.DrawEllipse(red_p, ed.V_from.X, ed.V_from.Y - 2*Radius, 2*Radius, 2*Radius);
						g.DrawLine(red_p, ed.V_from.X + Radius, ed.V_from.Y, ed.V_from.X + Radius + x, ed.V_from.Y + y-2);
						g.DrawLine(red_p, ed.V_from.X + Radius, ed.V_from.Y, ed.V_from.X + Radius + x, ed.V_from.Y - y-2);
					}else{
						g.DrawEllipse(black_p, ed.V_from.X, ed.V_from.Y - 2*Radius, 2*Radius, 2*Radius);
						g.DrawLine(black_p, ed.V_from.X + Radius, ed.V_from.Y, ed.V_from.X + Radius + x, ed.V_from.Y + y-2);
						g.DrawLine(black_p, ed.V_from.X + Radius, ed.V_from.Y, ed.V_from.X + Radius + x, ed.V_from.Y - y-2);
					}
				}else{
					if (isOriented){
						if (ed.iAmFirstLine){
							if (usingLine == ed)
								DrawArrow(red_p, ed.V_from.X, ed.V_from.Y, ed.V_where.X, ed.V_where.Y, alpha, length, true);
							else
								DrawArrow(black_p, ed.V_from.X, ed.V_from.Y, ed.V_where.X, ed.V_where.Y, alpha, length, true);
						}else{
							int dx = (int)(ed.V_from.X - ed.V_where.X);
							int dy = (int)(ed.V_from.Y - ed.V_where.Y);
							int x_center = ed.V_where.X + dx/2;
							int y_center = ed.V_where.Y + dy/2;

							int len = 23; // длина отступа от DrawBezier
							double alph = Math.Atan2(dx, dy);
							x_center += (int)Math.Round(len * Math.Cos(alph));
							y_center += (int)Math.Round( /* minus mlia minus!!111*/- len * Math.Sin(alph));
							if (usingLine == ed)
								DrawArrow(red_p, x_center, y_center, ed.V_where.X, ed.V_where.Y, alpha, length, false);
							else
								DrawArrow(black_p, x_center, y_center, ed.V_where.X, ed.V_where.Y, alpha, length, false);
							//DrawArrow(green_p,x , alpha, length, false);
						}
						
						
					}
				}
//					MessageBox.Show("Hello p_fromX="+ed.V_from.X+", p_formY="+ ed.V_from.Y +
//							                ", p_whereX=" + ed.V_where.X + "p_whereY=" + ed.V_where.Y);
				ed = ed.Next;
			}
		}
		
		void DrawArrow(Pen p, int x0, int y0, int x1, int y1, double alpha, double length, bool drawLine)
		{
			if (drawLine)
				g.DrawLine(p, x0, y0, x1, y1);
			
			// Draw --->
			int dx = x0 - x1;
			int dy = y0 - y1;
			int x = (int)(Radius * dx / Math.Sqrt(dx*dx + dy*dy) + x1);
			int y = (int)(Radius * dy / Math.Sqrt(dx*dx + dy*dy) + y1);
			
			double betta = Math.Atan2(dy , dx);
			double gamma = alpha + betta - Math.PI;
			
			int xl = (int)Math.Round(x - Math.Cos(gamma) * length);
			int yl = (int)Math.Round(y - Math.Sin(gamma) * length);
			g.DrawLine(p, x, y, xl, yl);
			
			xl = (int)(x - Math.Cos(gamma - 2*alpha - Math.PI/24) * length); // math.pi / 24 так чисто для красоты
			yl = (int)(y - Math.Sin(gamma - 2*alpha - Math.PI/24) * length);
			g.DrawLine(p, x, y, xl, yl);
			
		}
		
		void DrawWeights()
		{
			Edge ed = GRAPHS[nowGraph].E_Root.Next;
			while (ed != null){
				int x0 = ed.V_from.X, y0 = ed.V_from.Y;
				int x1 = ed.V_where.X, y1 = ed.V_where.Y;
				int dx = (int)(x0 - x1);
				int dy = (int)(y0 - y1);
				int x = x1 + dx/2;
				int y = y1 + dy/2;
				if (Equals(ed.V_from, ed.V_where))
					g.DrawString(ed.Massa.ToString(), font, black_b, ed.V_from.X + 2*Radius - 5, ed.V_from.Y - 2*Radius - 5);
				else{
					if (ed.iAmFirstLine){
						g.DrawString(ed.Massa.ToString(), font, black_b, x -2, y -2);
					}else{
						int length = 20; // длина отступа для поиска точки для альтернативной линии
						double alpha = Math.Atan2(dx, dy);
						int x_n = (int)Math.Round(length * Math.Cos(alpha));
						int y_n = (int)Math.Round( - length * Math.Sin(alpha));
						g.DrawString(ed.Massa.ToString(), font, black_b, x + x_n - 2, y + y_n - 2);
					}
				}
				ed = ed.Next;
			}
		}
		
		void DrawNumsFleri()
		{
			Edge ed = GRAPHS[nowGraph].E_Root.Next;
			while (ed != null){
				if (ed.numForFleri == -1){
					ed = ed.Next;
					continue;
				}
				int x0 = ed.V_from.X, y0 = ed.V_from.Y;
				int x1 = ed.V_where.X, y1 = ed.V_where.Y;
				int dx = (int)(x0 - x1);
				int dy = (int)(y0 - y1);
				int x = x1 + dx/4;
				int y = y1 + dy/4;
				if (Equals(ed.V_from, ed.V_where))
					g.DrawString(ed.numForFleri.ToString(), font, green_b, ed.V_from.X + Radius - 5, ed.V_from.Y - 2*Radius - 5);
				else{
					if (ed.iAmFirstLine){
						g.DrawString(ed.numForFleri.ToString(), font, green_b, x -2, y -2);
					}else{
						int length = 20; // длина отступа для поиска точки для альтернативной линии
						double alpha = Math.Atan2(dx, dy);
						int x_n = (int)Math.Round(length * Math.Cos(alpha));
						int y_n = (int)Math.Round( - length * Math.Sin(alpha));
						g.DrawString(ed.numForFleri.ToString(), font, green_b, x + x_n - 2, y + y_n - 2);
					}
				}
				ed = ed.Next;
			}
		}
	
		
		//----------------------------------------------//
		//-----------------END--DRAWING-----------------//
		//==============================================//
	}
}