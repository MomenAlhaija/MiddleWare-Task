using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var iP = new IP(119, 112,24, 55);
            Console.WriteLine(iP.Address);
            var first=  iP[0];
            Console.WriteLine(first);
            var ip2 = new IP("123.252.25.63");
            Console.WriteLine(ip2.Address);
            Console.ReadKey();
        }
        
        public class IP
        {

            private int[] seqmants=new int[4];
            public int this[int index] 
            {

                get {
                    return seqmants[index];
                }
                set {
                    seqmants[index] = value;    
                }
            }
            public IP(string ip)
            {
                var sq=ip.Split('.');
                for
                    (int i=0; i<sq.Length; i++)
                {
                    seqmants[i] = int.Parse(sq[i]);
                }

            }
            public IP(int seqmant1, int seqmant2, int seqmant3, int seqmant4)
            {
                seqmants[0]=seqmant1;
                seqmants[1]=seqmant2;
                seqmants[2]=seqmant3;
                seqmants[3]=seqmant4;

            }
            public string Address=> string.Join(".", seqmants);
        };

    }
}
