using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public static class GameController
    {
        public static Image spritesheet;
        public static Image coin;
        public static Image back;
        public static Image buttons;
        public static Image boy;
        public static Image halloween;
        public static Image candy;
        public static List<Road> roads;
        public static List<Coin> coins;
        public static List<Skelet> skelets;
        public static List<Bird> birds;
        public static List<Ghoast> ghoats;
       

        public static int dangerSpawn = 10;
        public static int countDangerSpawn = 0;
        public static int coinCount = 0;
       
        public static int backgroundShift = 0;// зміщення фонового зображення "halloween"
        public static int coinposition;

        public static void Init()
        {
            roads = new List<Road>();
            birds = new List<Bird>();
            ghoats = new List<Ghoast>();
            skelets = new List<Skelet>();
            coins = new List<Coin>();
           

            coin = Properties.Resource1.coin;
            back = Properties.Resource1.back;
            halloween = Properties.Resource1.helloween1;
            

            GenerateRoad();
        }

        public static void MoveMap()
        {
            for (int i = 0; i < roads.Count; i++)
            {
                roads[i].position = new PointF(roads[i].position.X - 7, roads[i].position.Y);
                if (roads[i].position.X + roads[i].size.Width < 0)
                {
                    GetNewRoad();
                    roads.RemoveAt(i);
                }
            }
            for (int i = 0; i < skelets.Count; i++)
            {
                skelets[i].position = new PointF(skelets[i].position.X - 7, skelets[i].position.Y);
                if (skelets[i].position.X + skelets[i].size.Width < 0)
                {
                    skelets.RemoveAt(i);
                }
            }
            for (int i = 0; i < birds.Count; i++)
            {
                birds[i].position = new PointF(birds[i].position.X - 7, birds[i].position.Y);
                if (birds[i].position.X + roads[i].size.Width < 0)
                {
                    birds.RemoveAt(i);
                }
            }
            for (int i = 0; i < coins.Count; i++)
            {
                coins[i].position = new PointF(coins[i].position.X - 7, coins[i].position.Y);
                if (coins[i].position.X + roads[i].size.Width < 0)
                {
                    coins.RemoveAt(i);
                }
            }
            for (int i = 0; i < ghoats.Count; i++)
            {
                ghoats[i].position = new PointF(ghoats[i].position.X - 7, ghoats[i].position.Y);
                if (ghoats[i].position.X + roads[i].size.Width < 0)
                {
                    ghoats.RemoveAt(i);
                }
            }
        }

        public static void GetNewRoad()
        {
            Road road = new Road(new Point(0 + 100 * 9, 290), new Size(200, 80));
            roads.Add(road);
            countDangerSpawn++;

            if (countDangerSpawn < dangerSpawn)
                return;

            Random r = new Random();
            dangerSpawn = r.Next(5, 9);

            countDangerSpawn = 0;
            int obj = r.Next(0, 4);
            switch (obj)
            {
                case 0:
                    skelets.Add(new Skelet(new PointF(0 + 100 * 9, 210), new Size(80, 80)));
                    break;
                case 1:
                    birds.Add(new Bird(new PointF(0 + 100 * 9, 210), new Size(30, 40)));
                    break;
                case 2:
                    int coinposition = r.Next(0, 2);
                    float y;
                    if (coinposition == 0)
                        y = 240;
                    else
                        y = 190;
                    coins.Add(new Coin(new PointF(0 + 100 * 9, y), new Size(40, 40)));
                    break;
                case 3:
                    ghoats.Add(new Ghoast(new PointF(0 + 100 * 9, 180), new Size(70, 70)));
                    break;
            }
        }

        public static void GenerateRoad()
        {
            for (int i = 0; i < 10; i++)
            {
                Road road = new Road(new PointF(0 + 100 * i, 290), new Size(200, 80));
                roads.Add(road);
                countDangerSpawn++;
            }
        }

        public static void DrawObjets(Graphics g)
        {
            roads.ForEach(r => r.DrawSprite(g));
            skelets.ForEach(s => s.DrawSprite(g));
            birds.ForEach(b => b.DrawSprite(g));
            ghoats.ForEach(g => g.DrawSprite(g));
            coins.ForEach(c => c.DrawSprite(g));

            backgroundShift -= 1;
            if (backgroundShift <= -back.Width)
                backgroundShift = 0;   
        }
    }
}
