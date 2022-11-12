

namespace HomeWork_27
{
    public class PrintMessage
    {
        public PrintMessage()
        {
            _rand = new Random();
            Message = SetMessage();
        }
        public string Message { get; set; }

        private readonly Random _rand;


        private string SetMessage() => $"text {_rand.Next(20)}";
    
        private Task Print(string msg)
        {
            Console.WriteLine(msg);
            Console.WriteLine($"Номер потока - {Thread.CurrentThread.ManagedThreadId}");
            return Task.Delay(_rand.Next(100, 3000));
            
        }

        public Task Start()
        {
           return Print(Message);

        }
    }

    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var b = false;
            int countMessage;
            do
            {
                Console.WriteLine("Введите количество сообщений: ");
                b = int.TryParse(Console.ReadLine(), out countMessage); 
            } while (!b);


           
            for (var i = 0; i<countMessage; i++)
            {
               await new PrintMessage().Start();
            }

            Console.WriteLine("\nВыполнение завершено. Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}