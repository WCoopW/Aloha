using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAloha
{
    public class ALOHA
    {
       
        int[] Window = new int[100];
        int reserved = 0;
       public void Simulation()
        {
            for (double lambda = 1; lambda < 10; lambda++)
            {
                var _random = new Random(DateTime.Now.Millisecond);
                int NumOfMess = Generate(lambda);
               while (NumOfMess > 0) 
                {
                   var win = _random.Next(1, 100); // случайный выбор окна
                    var j = _random.Next(1, NumOfMess);
                    Window[win] = +j;
                    NumOfMess = NumOfMess - j;
                }
                OutQueue();
            }
          
        }
        public void OutQueue()
        {
            for(int i = 0; i < 100; i++)
            {
                if (Window[i] != 0)
                {
                    var k = Window[i];
                    if (k > 1)
                    {
                        SearchEmptyWin(i);
                    }
                    else
                    {
                        Window[i] = 0;
                        Console.WriteLine($"Сообщение отправлено в окне {i} в {DateTime.Now}");
                    }                  
                }
                else
                {
                    Console.WriteLine($"В окне {i} сообщений нет.");
                }
            }
        }
        public int Generate(double lambda)
        {
            double L = Math.Exp(-lambda);
            double p = 1.0;
            int k = 0;
            //var _random = new Random(DateTime.Now.Millisecond);
            do
            {
                var _random = new Random(DateTime.Now.Millisecond);
                k++;
                double u = _random.NextDouble();
                p *= u;
            } while (p > L);

            return k - 1;
        }
        public void SearchEmptyWin(int i)
        {
            var messages = Window[i];
            for (int j = i + 1; j < 100; j++)
            {
                if (messages == 0)
                    break;
                if (Window[j] == 0)
                {
                    
                    messages--;
                    Window[j] = 1;
                    Console.WriteLine($" В окне {i} конфликт, сообщение перешло в окно {j} {DateTime.Now}");
                }
                
            }
            if (messages != 0)
            {
                Window[0] = +messages;
            }

        }
        double RndGenering()
        {
            var _random = new Random(DateTime.Now.Millisecond);
            return _random.NextDouble();
        }
    }
}
