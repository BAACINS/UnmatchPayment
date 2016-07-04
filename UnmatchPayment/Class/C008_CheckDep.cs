using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnmatchPayment.Class
{
    public class C008_CheckDep
    {

        // ตรวจสอบเลขที่บัญชีถูกต้องหรือไม่? 49927398716
        //เลขทะเบียนเงินกู้
        public static bool IsCCValid(string _accnum)
        {
            //  java code
            //  public static boolean isValidCC(String num) 
            //  {
            //    final int[][] sumTable = {{0,1,2,3,4,5,6,7,8,9},{0,2,4,6,8,1,3,5,7,9}};
            //    int sum = 0, flip = 0; 
            //    for (int i = num.length() - 1; i >= 0; i--)
            //      sum += sumTable[flip++ & 0x1][Character.digit(num.charAt(i), 10)];
            //    return sum % 10 == 0;
            //  }

            int sum = 0, flip = 0;
            int[][] sumTable = { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 } };

            try
            {
                if (_accnum.Length == 0)
                    return false;
                else
                {
                    for (int i = _accnum.Length - 1; i >= 0; i--)
                    {
                        sum += sumTable[flip++ & 0x1][Convert.ToInt32(_accnum.Substring(i, 1))];
                    }
                    return ((sum % 10) == 0);
                }
            }
            catch
            {
                return false;
            }

        }

        public static bool IsCCValidDeposit(string _accnum)
        {

            int sum = 0, total = 0, acc = 0;
            int[] sumTable = { 0, 0, 8, 7, 9, 9, 8, 7, 4, 3, 2 };
            //0  2  0  0  4  2  3  2  5  0  8  6
            try
            {
                if (_accnum.Length == 0)
                    return false;
                else
                {


                    for (int i = 0; i <= 10; i++)
                    {
                        switch (i)
                        {
                            case 3://ตำแหน่ง ที่ 4 
                                {
                                    acc = Convert.ToInt32(_accnum.Substring(i, 1));
                                    total = sumTable[i] * acc * -1;
                                    sum = sum + total;
                                }
                                break;
                            case 4://ตำแหน่ง ที่ 5
                                {
                                    acc = Convert.ToInt32(_accnum.Substring(i, 1));
                                    total = sumTable[i] * acc * -1;
                                    sum = sum + total;
                                }
                                break;
                            default:
                                {
                                    acc = Convert.ToInt32(_accnum.Substring(i, 1));
                                    total = sumTable[i] * acc;
                                    sum = sum + total;
                                }
                                break;
                        }

                    }


                    if (_accnum.Substring(0, 2) == "01" | _accnum.Substring(0, 2) == "30")
                    {
                        int d1 = 10 - (sum % 10);

                        if (d1 > 10)
                        {
                            d1 = d1 % 10;
                        }

                        if (d1 == Convert.ToInt32(_accnum.Substring(10, 1)))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        int mod = sum % 10;
                        int d1 = 10 - mod + Convert.ToInt32(_accnum.Substring(0, 1)) + Convert.ToInt32(_accnum.Substring(1, 1));

                        if (d1 > 10)
                        {
                            d1 = d1 % 10;
                        }

                        int cack = Convert.ToInt32(_accnum.Substring(11, 1));
                        if (d1 == cack)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }


                }
            }
            catch
            {
                return false;
            }

        }
    }
    
}