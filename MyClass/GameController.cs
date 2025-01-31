using System;
using System.Collections.Generic;
using System.Drawing;

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


            MoveEntities(skelets);
            MoveEntities(birds);
            MoveEntities(coins);
            MoveEntities(ghoats);
        }

        public static void MoveEntities<T>(List<T> Entities) where T : Transform
        {
            for (int i = 0; i < Entities.Count; i++)
            { 
                Entities[i].position = new PointF(Entities[i].position.X - 7, Entities[i].position.Y);
                if (Entities[i].position.X + roads[i].size.Width < 0)
                {
                    Entities.RemoveAt(i);
                }
            }
        }

        public static void GetNewRoad()
        {
            Road road = new Road(new Point(0 + 100 * 9, 290), new Size(200, 80));
            roads.Add(road);
            countDangerSpawn++;

            if (countDangerSpawn >= dangerSpawn)
            {
                Random r = new Random();
                dangerSpawn = r.Next(5, 9);

                countDangerSpawn = 0;
                int obj = r.Next(0, 4);
                switch (obj)
                {
                    case 0:
                        Skelet skelet = new Skelet(new PointF(0 + 100 * 9, 210), new Size(80, 80));
                        skelets.Add(skelet);
                        break;
                    case 1:
                        Bird bird = new Bird(new PointF(0 + 100 * 9, 210), new Size(30, 40));
                        birds.Add(bird);
                        break;
                    case 2:
                        int coinposition = r.Next(0, 2);
                        Coin coin;
                        if (coinposition == 0)
                        {
                            coin = new Coin(new PointF(0 + 100 * 9, 240), new Size(40, 40));
                        }
                        else
                        {
                            coin = new Coin(new PointF(0 + 100 * 9, 190), new Size(40, 40));
                        }
                        coins.Add(coin);
                        break;
                    case 3:
                        Ghoast ghoast = new Ghoast(new PointF(0 + 100 * 9, 180), new Size(70, 70));
                        ghoats.Add(ghoast);
                        break;
                   
                }
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
            roads.ForEach(road => road.DrawSprite(g));
            skelets.ForEach(skelet => skelet.DrawSprite(g));
            birds.ForEach(bird => bird.DrawSprite(g));
            ghoats.ForEach(ghoat => ghoat.DrawSprite(g));
            coins.ForEach(coin => coin.DrawSprite(g));

            backgroundShift -= 1;

            if (backgroundShift <= -back.Width)
            {
                backgroundShift = 0;
            }
        }
    }
}
