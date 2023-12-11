namespace consoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var values = new List<object> { 1, 2, 3, new List<object> { 4, 5, 6 } };
            
            int sum = Sum(values);
            
            Console.WriteLine("Sum: " + sum);
            
            
        }
        
        public static int Sum(IEnumerable<object> values)
        {
            var sum = 0;
            foreach (var item in values)
            {
                switch (item)
                {
                    case 0:
                        break;
                    case int val:
                        sum += val;
                        break;
                    case IEnumerable<object> subList when subList.Any():
                        sum += Sum(subList);
                        break;
                }
            }
            
            return sum;
        }
    }
}