using System.ComponentModel;
using System.Threading;

class Program {
    static void Main(string[] args)
    {
        int n = 1;
        long big_prime = 8512677386048191063;
        int prime_root = (int)Math.Floor(Math.Cbrt(big_prime));
        IsPrime prime = new IsPrime();
        var watch = System.Diagnostics.Stopwatch.StartNew();
        int[] ints = new int[n+1];
        int temp = prime_root/n;
        for (int i = 0; i <= n; i++){
            if (i == 0)
            {
                ints[i] = 2;
            }
            else
            {
                ints[i] = i * temp;
            }
        }
        Thread[] threads = new Thread[n];
        for (int i = 0; i < n; i++)
        {
            var temp2 = ints[i];
            var temp3 = ints[i+1];
            threads[i] = new Thread(() => prime.isPrime(temp2,temp3, big_prime));
        }
        for (int i = 0; i < n; i++)
        {
            threads[i].Start();
        }
        for (int i = 0; i < n; i++)
            threads[i].Join();
        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine(elapsedMs + " ms");
        if (prime.prime == 0)
        {
            Console.WriteLine("Liczba pierwsza");
        }
        else
        {
            Console.WriteLine("Liczba złożona");
        }
        Console.Read();
    }
    public class IsPrime
    {
        public double[] array = new double[10];
        public int prime = 0;
        public void set(int i,int j)
        {
            double x = Math.Pow((int)i, 2.0f);
            array[(int)i] = x;
        }
        public void isPrime(int temp,int temp2,long prime_root){
       
           for (int j = temp; j <= temp2; j++)
           {
               if (prime_root % j == 0)
               {
                   prime++;
               }
               
           }
        }
    }
}