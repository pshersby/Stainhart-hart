using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steinhart_Hart
{
     class Steinhart3{

        double[]? R;
        double[]? T;
        double[]? Y;
        double[,]? X;
        double[,] A = new double[4, 3];
        double[,] B = new double[3, 3];
        double[,] E = new double[3, 3];
        double[] C = new double[3];

        double SUM;
        double DET;
        double H;
        double SIGMA;

        double C1;
        double C2;
        double C3;
        int i, j, k, l;
        int N;


        //
        //  Stein 3 
        //  Least squares fit program to find the thermistor coefficients
        //  C1, C2 and C3 in the Steinhart-Hart equation:
        //
        //      1/T = C1 + C2* (ln R) + C3* (ln R)**3
        public void CalcCoefficients(TempReading[] items)
        {

            N = items.Count();

            R = new double[N];
            T = new double[N];
            Y = new double[N];
            X = new double[4, N];
            C1 = 0;
            C2 = 0;
            C3 = 0;
            i = 0;
            j = 0;
            k = 0;
            l = 0;

            //Convert the listbox conent into arrays to match the ILX original program we are zero based arrays
             i = 0;
            foreach (TempReading item in items)
            {
                R[i] = item.GetResistance();
                T[i] = item.GetTemp();
                i++;
            }


            // Calc 4x3 MAtrix
            for (i = 0; i < N; i++)
            {
                H = Math.Log(R[i]);
                X[0, i] = 1;
                X[1, i] = H;
                X[2, i] = H * H * H;
                X[3, i] = 1 / (T[i] + 273.15);

            }

            //1290 REM**** Calculate alpha(i = 1 to 3) and beta(i= 4) ****
            //1300 REM(Bevington eqns 8 - 23)
            //1310 FOR I = 1 TO 4 : FOR J = 1 TO 3 : A(I, J) = 0 : NEXT J : NEXT I
            //1320 FOR I = 1 TO N : FOR J = 1 TO 4 : FOR K = 1 TO 3
            //1330 A(J, K) = A(J, K) + X(J, I) * X(K, I)
            //1340 NEXT K : NEXT J : NEXT I

            for (i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    A[i, j] = 0;
                }
            }

            for (i = 0; i < N; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        A[j, k] = A[j, k] + X[j, i] * X[k, i];
                    }
                }


            }

            // Error matrix "E" = inverse of alpha (3x3 part of A) ****
            // 1360 GOSUB 2010
            Sub2010();

            // 1370 REM**** Coefficients = beta(fourth column of A) x E ****
            //1380 REM(eqn 8 - 26 of Bevington)

            for (i = 0; i < 3; i++)
            {
                C[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    C[i] = C[i] + E[i, j] * A[3, j];
                }
            }

           /* SIGMA = 0;
            for (i=0; i < N; i++)
            {
                H = X[3,i] - C[0] * X[0,i] -C[1] * X[1, i] - C[2] * X[2, i];
                SIGMA = SIGMA + H * H;
            }

            SIGMA = Math.Sqrt(SIGMA / (N - 3));
           */
            C1 = (C[0] * 1000);
            C2 = (C[1] * 10000);
            C3 = (C[2] * 10000000);

            //TODO POPULATE THE ACCURACY OF EACH TEMP READING

            i = 0;
            double Z, TCALC;
            foreach (TempReading item in items)
            {
                Z=Math.Log(R[i]);
                TCALC = (1 / (C[0] + (C[1] * Z) + (C[2] * Math.Pow(Z,3)))) - 273.15;

                item.setAccuracy(T[i] - TCALC);
                i++;
            }

    



        }

        public double getC1()
        {
            return C1;
        }


        public double getC2()
        {
            return C2;
        }
        public double getC3()
        {
            return C3;
        }


        //Subroutine 2160 is a scratch copy       FOR I = 1 TO 3 : FOR J = 1 TO 3 : B(I, J) = A(I, J) : NEXT J : NEXT I
        private void Sub2160()
        {
            int i = 0;

            for (i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    B[i, j] = A[i, j];
                }
            }
        }

        //**** 3 x 3 determinant routine ****

        private void Sub2120()
        {
            SUM = B[0, 0] * B[1, 1] * B[2, 2] + B[0, 1] * B[1, 2] * B[2, 0] + B[0, 2] * B[1, 0] * B[2, 1];
            SUM = SUM - B[0,0] * B[1,2] * B[2,1] - B[0,1] * B[1,0] * B[2,2] - B[0,2] * B[1,1] * B[2,0];

        }

        // Sub2010 Invert a 3x3 matrix by coefficients
        private void Sub2010()
        {
            Sub2160();
            Sub2120();

            DET = SUM;
            //FOR K = 1 TO 3 : FOR L = 1 TO 3
            for (int k = 0; k < 3; k++)
            {
                for (int l = 0; l < 3; l++)
                {
                    Sub2160();
                    for (int j = 0; j < 3; j++)
                    {
                        B[j, l] = 0;
                        B[k, j] = 0;
                    }
                    B[k, l] = 1;
                    Sub2120();
                    //2080 Transpose cofactor
                    E[l, k] = SUM / DET;


                }
            }
        }


    }
}
