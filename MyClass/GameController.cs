using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

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
        public static int backgroundShift = 0;
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
            MoveObjects(roads);
            MoveObjects(skelets);
            MoveObjects(birds);
            MoveObjects(coins);
            MoveObjects(ghoats);
        }

        private static void MoveObjects<T>(List<T> objects) where T : Transform
        {
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                objects[i].TransformData.Position = new PointF(
                    objects[i].TransformData.Position.X - 7,
                    objects[i].TransformData.Position.Y
                );

                if (objects[i].TransformData.Position.X + objects[i].TransformData.Size.Width < 0)
                {
                    if (objects[i] is Road) GetNewRoad();
                    objects.RemoveAt(i);
                }
            }
        }

        public static void GetNewRoad()
        {
            var roadTransform = new TransformData(
                new Point(0 + 100 * 9, 290),
                new Size(200, 80)
            );
            roads.Add(new Road(roadTransform));
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
                        var skeletTransform = new TransformData(
                            new PointF(0 + 100 * 9, 210),
                            new Size(80, 80)
                        );
                        skelets.Add(new Skelet(skeletTransform));
                        break;
                    case 1:
                        var birdTransform = new TransformData(
                            new PointF(0 + 100 * 9, 210),
                            new Size(30, 40)
                        );
                        birds.Add(new Bird(birdTransform));
                        break;
                    case 2:
                        int coinposition = r.Next(0, 2);
                        var coinTransform = new TransformData(
                            new PointF(0 + 100 * 9, coinposition == 0 ? 240 : 190),
                            new Size(40, 40)
                        );
                        coins.Add(new Coin(coinTransform));
                        break;
                    case 3:
                        var ghoastTransform = new TransformData(
                            new PointF(0 + 100 * 9, 180),
                            new Size(70, 70)
                        );
                        ghoats.Add(new Ghoast(ghoastTransform));
                        break;
                }
            }
        }

        public static void GenerateRoad()
        {
            for (int i = 0; i < 10; i++)
            {
                var roadTransform = new TransformData(
                    new PointF(0 + 100 * i, 290),
                    new Size(200, 80)
                );
                roads.Add(new Road(roadTransform));
                countDangerSpawn++;
            }
        }

        public static void DrawObjets(Graphics g)
        {
            for (int i = 0; i < roads.Count; i++)
            {
                roads[i].DrawSprite(g);
            }
            for (int i = 0; i < skelets.Count; i++)
            {
                skelets[i].DrawSprite(g);
            }
            for (int i = 0; i < birds.Count; i++)
            {
                birds[i].DrawSprite(g);
            }
            for (int i = 0; i < ghoats.Count; i++)
            {
                ghoats[i].DrawSprite(g);
            }
            for (int i = 0; i < coins.Count; i++)
            {
                coins[i].DrawSprite(g);
            }

            backgroundShift -= 1;
            if (backgroundShift <= -back.Width)
            {
                backgroundShift = 0;
            }
        }
    }
}