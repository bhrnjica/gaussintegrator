//////////////////////////////////////////////////////////////////////////////////////////
// Gauss Numeric Integrator                                                              //
// Copyright 2013-2018 Bahrudin Hrnjica                                                     //
//                                                                                      //
// This code is free software under the GNU Library General Public License (LGPL)       //
// See licence section of  http://gauss.codeplex.com/license                           //
//                                                                                      //
// Bahrudin Hrnjica                                                                     //
// bhrnjica@hotmail.com                                                                 //
// Bihac,Bosnia and Herzegovina                                                         //
// http://bhrnjica.wordpress.com                                                        //
//////////////////////////////////////////////////////////////////////////////////////////
using Ciloci.Flee;
using System.Collections.Generic;

namespace BHNumericLib
{
    public static class GaussIntegrator
    {
        static List<GValues> gaussValues1D = null;
        static List<GValues> gauss2DTriangleValues = null;
        static List<GValues> gauss2DQuadValues = null;
        static GaussIntegrator()
        {
            gaussValues1D = new List<GValues>();
            var g0 = new GValues() { };
            gaussValues1D.Add(g0);
            var g1 = new GValues() { n = 1, gi = new double[1] { 1 }, wi = new double[1] { 1 } };
            gaussValues1D.Add(g1);
            var g2 = new GValues() { n = 2, gi = new double[2] { -0.5773502692, 0.5773502692 }, wi = new double[2] { 1, 1 } };
            gaussValues1D.Add(g2);

            var g3 = new GValues() { n = 3, gi = new double[3] { -0.7745966692, +0.0000000000, +0.7745966692 }, wi = new double[3] { 0.5555555555, 0.8888888889, 0.5555555555 } };
            gaussValues1D.Add(g3);

            var g4 = new GValues() { n = 4, gi = new double[4] { -0.8611363115940526, -0.3399810435848563, 0.3399810435848563, 0.8611363115940526 }, wi = new double[4] { 0.3478548451374538, 0.6521451548625461, 0.6521451548625461, 0.3478548451374538 } };
            gaussValues1D.Add(g4);

            var g5 = new GValues() { n = 5, gi = new double[5] { -0.9061798459386640, -0.5384693101056831, 0.0000000000000000, 0.5384693101056831, 0.9061798459386640 }, wi = new double[5] { 0.2369268850561891, 0.4786286704993665, 0.5688888888888889, 0.4786286704993665, 0.2369268850561891 } };
            gaussValues1D.Add(g5);

            //triangle Gauss values 
            gauss2DTriangleValues = new List<GValues>();
            var g20 = new GValues() { };
            gauss2DTriangleValues.Add(g20);
            var g21 = new GValues() { n = 1, gi = new double[1] { 1.0 / 3.0 }, wi = new double[1] { 1.0 } };
            gauss2DTriangleValues.Add(g1);
            var g22 = new GValues() { n = 2, gi = null, wi = null };
            gauss2DTriangleValues.Add(g22);

            var g23 = new GValues() { n = 3, gi = new double[3] { 0.5, 0.5, 0 }, wi = new double[3] { 1.0 / 3.0, 1.0 / 3.0, 1.0 / 3.0 } };
            gauss2DTriangleValues.Add(g23);

            var g24 = new GValues() { n = 4, gi = new double[4] { 1.0 / 3.0, 0.6, 0.2, 0.2 }, wi = new double[4] { -27.0 / 48.0, 25.0 / 48.0, 25.0 / 48.0, 25.0 / 48.0 } };
            gauss2DTriangleValues.Add(g24);

            var g25 = new GValues() { n = 5, gi = null, wi = null };
            gauss2DTriangleValues.Add(g25);

            var g26 = new GValues() { n = 6, gi = null, wi = null };
            gauss2DTriangleValues.Add(g26);

            var g27 = new GValues() { n = 7, gi = new double[7] { 1.0 / 3.0, 0.0597158717, 0.4701420641, 0.4701420641, 0.7974269853, 0.1012865073, 0.1012865073 }, wi = new double[7] { 0.225, 0.1323941527, 0.1323941527, 0.1323941527, 0.1259391805, 0.1259391805, 0.1259391805 } };
            gauss2DTriangleValues.Add(g27);


            //quadrilateral Gaussian points
            gauss2DQuadValues = new List<GValues>();
            var g30 = new GValues() { };
            gauss2DQuadValues.Add(g30);
            var g31 = new GValues() { n = 1, gi = new double[1] { 1 }, wi = new double[1] { 1 } };
            gauss2DQuadValues.Add(g31);
            var g32 = new GValues() { n = 2, gi = new double[2] { -0.5773502692, 0.5773502692 }, wi = new double[2] { 1, 1 } };
            gauss2DQuadValues.Add(g32);

            var g33 = new GValues() { n = 3, gi = new double[3] { -0.7745966692, +0.0000000000, +0.7745966692 }, wi = new double[3] { 0.5555555555, 0.8888888889, 0.5555555555 } };
            gauss2DQuadValues.Add(g33);

            var g34 = new GValues() { n = 4, gi = new double[4] { -0.8611363116, -0.3399810436, 0.8611363116, 0.3399810436 }, wi = new double[4] { 0.3478548451, 0.6521451549, 0.3478548451, 0.6521451549 } };
            gauss2DQuadValues.Add(g34);

            var g35 = new GValues() { n = 5, gi = new double[5] { -0.9061798459, -0.5384693101, 0.0000000000, 0.5384693101, 0.9061798459 }, wi = new double[5] { 0.2369268851, 0.4786286705, 0.5688888889, 0.4786286705, 0.2369268851 } };
            gauss2DQuadValues.Add(g35);   


        }
        public static double Calculate1DIntegral(IGenericExpression<double> function, Register register, int gp, double[][] pi)
        {
           

            //Jacobian calculation
            var detJ = Shape.Jacobian(pi);

           

            double I = 0;


            for (int i = 0; i < gp; i++)
            {
                double sumx = 0;

                for (int k = 0; k < pi.Length; k++)
                    sumx += Shape.Ni(gaussValues1D[gp].gi[i], 1.1, k + 1, pi.Length) * pi[k][0];

                register.x = sumx;
                var f = function.Evaluate();

                //intgreation
                I += f * detJ * gaussValues1D[gp].wi[i];
            }
            return I;
        }
        public static double Calculate2DIntegral_Triangle(IGenericExpression<double> function, Register register, int gp, double[][] pi)
        {
            //Jacobian calculation
            var detJ = Shape.Jacobian(pi);
            detJ /= 2.0;
            double I = 0;
            int k = 0;

            if (gp > 3)
            {
                register.x = (pi[0][0] - pi[2][0]) * gauss2DTriangleValues[gp].gi[k] + (pi[1][0] - pi[2][0]) * gauss2DTriangleValues[gp].gi[k] + pi[2][0];
                register.y = (pi[0][1] - pi[2][1]) * gauss2DTriangleValues[gp].gi[k] + (pi[1][1] - pi[2][1]) * gauss2DTriangleValues[gp].gi[k] + pi[2][1];

                var f = function.Evaluate();

                //intgreation
                I += detJ * f * gauss2DTriangleValues[gp].wi[k];

                k++;
            }

            int i = k;
            for (; i < gp; i++)
            {
                int j = i + 1;
                if (i == 2 && gp == 3)
                    j = k;
                else if (i == 3 && (gp == 7 || gp == 4))
                    j = 1;
                else if (i == 6 && gp == 7)
                    j = 4;

                register.x = (pi[0][0] - pi[2][0]) * gauss2DTriangleValues[gp].gi[i] + (pi[1][0] - pi[2][0]) * gauss2DTriangleValues[gp].gi[j] + pi[2][0];
                register.y = (pi[0][1] - pi[2][1]) * gauss2DTriangleValues[gp].gi[i] + (pi[1][1] - pi[2][1]) * gauss2DTriangleValues[gp].gi[j] + pi[2][1];

                var f = function.Evaluate();

                //intgreation
                I += detJ * f * gauss2DTriangleValues[gp].wi[i];

            }
            return I;
        }
        public static double Calculate2DIntegral_Quadrilateral(IGenericExpression<double> function, Register register, int gp, double[][] pi)
        {
            //Jacobian calculation
            var detJ = Shape.Jacobian(pi);

                                                                                                                                                 
                                                                                                                                                                
            double I = 0;
            for (int i = 0; i < gp; i++)
                for (int j = 0; j < gp; j++)
                {
                    double sumx = 0, sumy = 0;
                    for (int k = 0; k < pi.Length; k++)
                    {
                        sumx += Shape.Ni(gauss2DQuadValues[gp].gi[i], gauss2DQuadValues[gp].gi[j], k + 1, pi.Length) * pi[k][0];
                        sumy += Shape.Ni(gauss2DQuadValues[gp].gi[i], gauss2DQuadValues[gp].gi[j], k + 1, pi.Length) * pi[k][1];
                    }

                    register.x = sumx;
                    register.y = sumy;

                    //evaluate function with new coordiantes
                    var f = function.Evaluate();

                    //intgreation
                    I += f * detJ * gauss2DQuadValues[gp].wi[i] * gauss2DQuadValues[gp].wi[j];
                }
            return I;
        }  
    }
}
