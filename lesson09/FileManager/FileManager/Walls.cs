using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            //Отрисовка линий

            HorizontalLine upLine1 = new HorizontalLine(0, mapWidth - 2, 26, '=');
            HorizontalLine upLine2 = new HorizontalLine(0, mapWidth - 2, 20, '=');

            wallList.Add(upLine1);
            wallList.Add(upLine2);
        }
        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
