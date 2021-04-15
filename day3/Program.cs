using System;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {

            uint dec = 12;
            Console.WriteLine("in binary "+binary(12));
            Console.WriteLine("  \n"+dec +" in binary: "+toBinary(dec));

            //packing
            byte one = 2;
            byte two = 255;
            byte three =1;
            byte four = 255;
            uint combined = (uint)((one << 24) | (two<< 16) | (three << 8) | (four));
            Console.WriteLine("packed: " + combined+ " in binary: "+toBinary(combined)); //Convert.ToString(combined, 2)
            //unpacking
            byte fourth = (byte) (combined & 255);
            byte third = (byte)((combined >> 8) & 255);
            byte second= (byte)((combined >> 16) & 255);
            byte first = (byte)((combined >> 24) & 255);
            Console.WriteLine("unpacked: "+first + " " + second + " " + third + " " + fourth);
            //isOdd
            uint test = 12;
            Console.WriteLine(test+" is odd? "+isOdd(test));
        }

        static string toBinary(uint value)
        {
            string res = null;

            while (value >0)
            {

                var bit = value % 2;
                
                if (bit == 0)
                {
                    res += "0";
                }
                else
                {
                    res += "1";
                }
                value /= 2 ;
                

            }

            char[] charArray = res.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);

           
        }

        //any binary number with 1 at the most right digit is odd number and if it's zero then it's even
        static bool isOdd(uint value)
        {
            //using bitwise opr
            if ((value| 1) == value)
                                   // 000001 (1)
                                   //    |
                                   // 000011 (3)
                                   //    =
                                   // 000011 (3) equal to the value then 3 is odd

                                   // 000001 (1)
                                   //    |
                                   // 000010 (2)
                                   //    =
                                   // 000011 (3) bigger than value then 2 is not odd
                return true;
            else
                return false;
        }

 

        static string binary (uint num)
        {
            string res = "";
            for(int i =0; i <32; i++)
            {
                res = (num & 1)+res;
                num >>= 1;
                
            }
            return res;
            
        }
    }
}
