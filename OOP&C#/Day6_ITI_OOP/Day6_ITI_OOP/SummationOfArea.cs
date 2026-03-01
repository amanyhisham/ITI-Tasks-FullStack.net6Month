using System;
using System.Collections.Generic;
using System.Text;

namespace Day6_ITI_OOP
{
     class SummationOfArea
    {
        public static double sumOFAllAreasV1(Rectangle[] R, Squara[] S, Triangle[] T, Circle[] C)
        {
            double sum = 0;
            for (int i = 0; i < R.Length; i++)
            {
                sum += R[i].Area();
            }
            for (int i = 0; i < S.Length; i++)
            {
                sum += S[i].Area();
            }
            for (int i = 0; i < T.Length; i++)
            {
                sum += T[i].Area();
            }
            for (int i = 0; i < C.Length; i++)
            {
                sum += C[i].Area();
            }
            return sum;
        }
        public static double sumOFAllAreasV2(GeoShap[] G)
        {
            double sum = 0;
            for (int i = 0; i < G.Length; i++)
            {
                sum += G[i].Area();
            }
            
            return sum;
        }
    }
}
