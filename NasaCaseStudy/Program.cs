using Microsoft.Extensions.DependencyInjection;
using NasaCaseStudy.Core.Entity;
using NasaCaseStudy.Core.Interface;
using NasaCaseStudy.Service;

namespace MarsRover.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IRobotMovementService, RobotMovementService>()  
                .BuildServiceProvider();


            Console.WriteLine("Mars yüzeyi için koordinat değeri girin (örn: 5 5):");
            string[] surfaceCoordinates = Console.ReadLine().Split(' ');
            int surfaceX = int.Parse(surfaceCoordinates[0]);
            int surfaceY = int.Parse(surfaceCoordinates[1]);
            MarsSurface surface = new MarsSurface { MaxX = surfaceX, MaxY = surfaceY };
            if (surfaceX < 0 || surfaceY < 0)
            {
                Console.WriteLine("Geçersiz yüzey koordinatı! Koordinat negatif olamaz.");
                return;
            }

            Console.WriteLine("İlk robot için pozisyon ve yön bilgisi girin (örn:, 1 2 N):");
            string[] robot1Position = Console.ReadLine().Split(' ');
            int robot1X = int.Parse(robot1Position[0]);
            int robot1Y = int.Parse(robot1Position[1]);
            char robot1Direction = char.Parse(robot1Position[2].ToUpper());
            if (!"NSWE".Contains(robot1Direction))
            {
                Console.WriteLine("Geçersiz yön bilgisi! Lütfen N, S, W, veya E değerlerinden birini seçin.");
                return;
            }
            if (robot1X < 0 || robot1Y < 0 || robot1X > surface.MaxX || robot1Y > surface.MaxY)
            {
                Console.WriteLine("Geçersiz konum, lütfen robotu Mars yüzeyinde konumlandırın");
                robot1X = Math.Min(Math.Max(robot1X, 0), surface.MaxX);  
                robot1Y = Math.Min(Math.Max(robot1Y, 0), surface.MaxY);  
            }
            Robot robot1 = new Robot { X=robot1X, Y=robot1Y, Direction=robot1Direction };

            Console.WriteLine("Nasa'nın gönderdiği talimatları girin (L, R, M):");
            string robot1Commands = Console.ReadLine().ToUpper();
            if (!robot1Commands.All(c => "LMR".Contains(c)))
            {
                Console.WriteLine("Geçersiz talimat, sadece L, R, ve M değerleri geçerlidir.");
                return;
            }

            Console.WriteLine("İkinci robot için pozisyon ve yön bilgisi girin (örn; 3 3 E):");
            string[] robot2Position = Console.ReadLine().Split(' ');
            int robot2X = int.Parse(robot2Position[0]);
            int robot2Y = int.Parse(robot2Position[1]);
            char robot2Direction = char.Parse(robot2Position[2].ToUpper());
            if (!"NSWE".Contains(robot2Direction))
            {
                Console.WriteLine("Geçersiz yön bilgisi! Lütfen N, S, W, veya E değerlerinden birini seçin.");
                return;
            }
            if (robot2X < 0 || robot2Y < 0 || robot2X > surface.MaxX || robot2Y > surface.MaxY)
            {
                Console.WriteLine("Geçersiz konum, lütfen robotu Mars yüzeyinde konumlandırın");
                robot2X = Math.Min(Math.Max(robot2X, 0), surface.MaxX);
                robot2Y = Math.Min(Math.Max(robot2Y, 0), surface.MaxY);
            }
            Robot robot2 = new Robot { X = robot2X, Y = robot2Y, Direction = robot2Direction };

            Console.WriteLine("Nasa'nın gönderdiği talimatları girin (L, R, M):");
            string robot2Commands = Console.ReadLine().ToUpper();
            if (!robot2Commands.All(c => "LMR".Contains(c)))
            {
                Console.WriteLine("Geçersiz talimat, sadece L, R, ve M değerleri geçerlidir.");
                return;
            }


            RobotMovementService movementService = new RobotMovementService();
            movementService.ProcessMovement(robot1, surface, robot1Commands);
            movementService.ProcessMovement(robot2, surface, robot2Commands);

            Console.WriteLine($"Robot 1 son pozisyonu: {robot1.X} {robot1.Y} {robot1.Direction}");
            Console.WriteLine($"Robot 2 son pozisyonu: {robot2.X} {robot2.Y} {robot2.Direction}");
        }
    }
}