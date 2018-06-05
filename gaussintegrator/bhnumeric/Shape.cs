//////////////////////////////////////////////////////////////////////////////////////////
// Gauss Numeric Integrator                                                              //
// Copyright 2013-2018 Bahrudin Hrnjica                                                     //
//                                                                                      //
// This code is free software under the GNU Library General Public License (LGPL)       //
// See license section of  http://gauss.codeplex.com/license                           //
//                                                                                      //
// Bahrudin Hrnjica                                                                     //
// bhrnjica@hotmail.com                                                                 //
// Bihac,Bosnia and Herzegovina                                                         //
// http://bhrnjica.wordpress.com                                                        //
//////////////////////////////////////////////////////////////////////////////////////////
using System;

namespace BHNumericLib
{
    /// <summary>
    /// Implementation of SHape function for any type of finite element Nodes w 
    /// </summary>
    public class Shape
    {
        /// <summary>
        /// Returns Value of Shape function for specific arguments
        /// </summary>
        /// <param name="ksi">value of first coordinate </param>
        /// <param name="eta">value of second coordinate</param>
        /// <param name="i">Number of Shape function.1=>N1,2=>N2,3=>N3,..... </param>
        /// <param name="nodes">Number of nodes, type of finite element.
        /// 1D element Number of nodes: 2,4
        /// 2D element triangle 3,6,10,15
        /// 2D element quadrilateral 4,8,9,
        /// 3D element tetrahedron 4
        /// 3D element hexaedron 8,14,20
        /// </param>
        /// <returns> Result of shape function</returns>
        public static double Ni(double ksi, double eta, int i, int nodes = 4)
        {
            switch (i)
            {
                //N1 => shape function
                case 1:
                    if (nodes == 2)
                        return 0.5 * (1 + ksi);
                    if (nodes == 3)
                        return ksi;
                    else if (nodes == 4)
                        return 0.25 * (1 - ksi) * (1 - eta);
                    else if (nodes == 6)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 8)
                        return 0.25 * (1 + ksi) * (1 + eta) - 0.5 * (Ni(ksi, eta, 5, nodes) + Ni(ksi, eta, 8, nodes));
                    else if (nodes == 9)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 10)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 15)
                        throw new Exception("Unsupported node number.!");
                    else
                        return 0;
                //N2 => shape function
                case 2:
                    if (nodes == 2)
                        return 0.5 * (1 - ksi);
                    if (nodes == 3)
                        return eta;
                    else if (nodes == 4)
                        return 0.25 * (1 + ksi) * (1 - eta);
                    else if (nodes == 6)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 8)
                        return 0.25 * (1 - ksi) * (1 + eta) - 0.5 * (Ni(ksi, eta, 5, nodes) + Ni(ksi, eta, 6, nodes));
                    else if (nodes == 9)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 10)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 15)
                        throw new Exception("Unsupported node number.!");
                    else
                        return 0;
                //N3 => shape function
                case 3:
                    if (nodes == 3)
                        return 1 - ksi - eta;
                    else if (nodes == 4)
                        return 0.25 * (1 + ksi) * (1 + eta);
                    else if (nodes == 8)
                        return 0.25 * (1 - ksi) * (1 - eta) - 0.5 * (Ni(ksi, eta, 6, nodes) + Ni(ksi, eta, 7, nodes));
                    else if (nodes == 9)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 10)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 15)
                        throw new Exception("Unsupported node number.!");
                    else
                        return 0;
                //N4 => shape function
                case 4:
                    if (nodes == 4)
                        return 0.25 * (1 - ksi) * (1 + eta);
                    else if (nodes == 8)
                        return 0.25 * (1 + ksi) * (1 - eta) - 0.5 * (Ni(ksi, eta, 7, nodes) + Ni(ksi, eta, 8, nodes));
                    else if (nodes == 9)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 10)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 15)
                        throw new Exception("Unsupported node number.!");
                    else
                        return 0;

                //N5 => shape function
                case 5:
                    if (nodes == 8)
                        return 0.5 * (1 - ksi * ksi) * (1 + eta);
                    else if (nodes == 9)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 10)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 15)
                        throw new Exception("Unsupported node number.!");
                    else
                        return 0;
                //N6 => shape function
                case 6:
                    if (nodes == 8)
                        return 0.5 * (1 - ksi) * (1 - eta * eta);
                    else if (nodes == 9)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 10)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 15)
                        throw new Exception("Unsupported node number.!");
                    else
                        return 0;
                //N7 => shape function
                case 7:
                    if (nodes == 8)
                        return 0.5 * (1 + ksi * ksi) * (1 - eta);
                    else
                        return 0;
                //N8 => shape function
                case 8:
                    if (nodes == 8)
                        return 0.5 * (1 + ksi) * (1 - eta * eta);
                    else if (nodes == 9)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 10)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 15)
                        throw new Exception("Unsupported node number.!");
                    else
                        return 0;
                //N9 => shape function
                case 9:
                    if (nodes == 9)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 10)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 15)
                        throw new Exception("Unsupported node number.!");
                    else
                        return 0;
                //N10 => shape function
                case 10:
                    if (nodes == 10)
                        throw new Exception("Unsupported node number.!");
                    else if (nodes == 15)
                        throw new Exception("Unsupported node number.!");
                    else
                        return 0;
                default:
                    return 0;
            }
        }
        /// <summary>
        /// partial derivatives of shape function by specific local coordinate
        /// </summary>
        /// <param name="ksi">first local coordinate</param>
        /// <param name="eta">second loal coordinate</param>
        /// <param name="i">Shape function number i=>Ni</param>
        /// <param name="isKsi">derivative by fisrst coiordinate</param>
        /// <param name="nodes">Number of nodes</param>
        /// <returns></returns>
        public static double partialNi(double ksi, double eta, int i, bool isKsi = true, int nodes = 4)
        {
            //shape function switch
            switch (i)
            {
                //N1 => shape function
                case 1:
                    //1D nodes
                    if (nodes == 2)
                    {
                        return -0.5 * ksi;
                    }
                    //2D triange nodes = 3
                    if (nodes == 3)
                    {
                        if (isKsi)
                            return eta;
                        else
                            return ksi;
                    }
                    //2D quadrilateral nodes = 4
                    else if (nodes == 4)
                    {
                        if (isKsi)
                            return -0.25 * (1 - eta);
                        else
                            return -0.25 * (1 - ksi);
                    }
                    //2D quadrilateral nodes = 8
                    else if (nodes == 8)
                    {
                        if (isKsi)
                            return 0.25 * (1 + eta) - 0.5 * (partialNi(ksi, eta, 5, true, 8) + partialNi(ksi, eta, 8, true, 8));
                        else
                            return 0.25 * (1 + ksi) - 0.5 * (partialNi(ksi, eta, 5, false, 8) + partialNi(ksi, eta, 8, false, 8));
                    }
                    else
                        throw new Exception("Unknown number of nodes!");

                //N2 => shape function
                case 2:
                    //1D nodes
                    if (nodes == 2)
                    {
                        return 0.5 * ksi;
                    }
                    //2D triange nodes = 3
                    if (nodes == 3)
                    {
                        if (isKsi)
                            return eta;
                        else
                            return ksi;
                    }
                    //2D quadrilateral nodes = 4
                    else if (nodes == 4)
                    {
                        if (isKsi)
                            return 0.25 * (1 - eta);
                        else
                            return -0.25 * (1 + ksi);
                    }
                    //2D quadrilateral nodes = 4
                    else if (nodes == 8)
                    {
                        if (isKsi)
                            return -0.25 * (1 + eta) - 0.5 * (partialNi(ksi, eta, 5, true, 8) + partialNi(ksi, eta, 6, true, 8));
                        else
                            return 0.25 * (1 - ksi) - 0.5 * (partialNi(ksi, eta, 5, false, 8) + partialNi(ksi, eta, 6, false, 8)); ;
                    }
                    else
                        throw new Exception("Unknown number of nodes!");
                //N3 => shape function
                case 3:
                    if (nodes == 3)
                    {
                        if (isKsi)
                            return -1;
                        else
                            return -1;
                    }
                    else if (nodes == 4)
                    {
                        if (isKsi)
                            return 0.25 * (1 + eta);
                        else
                            return 0.25 * (1 + ksi);
                    }
                    else if (nodes == 8)
                    {
                        if (isKsi)
                            return -0.25 * (1 - eta) - 0.5 * (partialNi(ksi, eta, 6, true, 8) + partialNi(ksi, eta, 7, true, 8));
                        else
                            return -0.25 * (1 - ksi) - 0.5 * (partialNi(ksi, eta, 6, false, 8) + partialNi(ksi, eta, 7, false, 8));
                    }
                    else
                        throw new Exception("Unknown number of nodes!");
                case 4:
                    if (nodes == 4)
                    {
                        if (isKsi)
                            return -0.25 * (1 + eta);
                        else
                            return 0.25 * (1 - ksi);
                    }
                    else if (nodes == 8)
                    {
                        if (isKsi)
                            return 0.25 * (1 - eta) - 0.5 * (partialNi(ksi, eta, 7, true, 8) + partialNi(ksi, eta, 8, true, 8));
                        else
                            return -0.25 * (1 + ksi) - 0.5 * (partialNi(ksi, eta, 7, false, 8) + partialNi(ksi, eta, 8, false, 8));
                    }
                    else
                        throw new Exception("Unknown number of nodes!");
                case 5:
                    if (nodes == 8)
                    {
                        if (isKsi)
                            return -ksi * (1 + eta);
                        else
                            return 0.5 * (1 - ksi * ksi);
                    }
                    else
                        throw new Exception("Unknown number of nodes!");
                case 6:
                    if (nodes == 8)
                    {
                        if (isKsi)
                            return -0.5 * (1 - eta * eta);
                        else
                            return -eta * (1 - ksi);
                    }
                    else
                        throw new Exception("Unknown number of nodes!");
                case 7:
                    if (nodes == 8)
                    {
                        if (isKsi)
                            return ksi * (1 - eta);
                        else
                            return -0.5 * (1 + ksi * ksi);
                    }
                    else
                        throw new Exception("Unknown number of nodes!");
                case 8:
                    if (nodes == 8)
                    {
                        if (isKsi)
                            return 0.5 * (1 - eta * eta);
                        else
                            return -1 * eta * (1 + ksi);
                    }
                    else
                        throw new Exception("Unknown number of nodes!");
                default:
                    throw new Exception("Unknown number of nodes!");
            }
        }

        /// <summary>
        /// Calculation of determinate of Jacobian
        /// </summary>
        /// <param name="pi">Shape points which need to be mapped in to unit shape</param>
        /// <returns>determinant of Jacobian</returns>
        public static double Jacobian(double [][] pi)
        {
            //define Jacobian matrix for 2D
            double[][] J = new double[2][];
            for (int i = 0; i < 2; i++)
                J[i] = new double[2];

            int points = pi.Length;
            if (points < 2 && points > 8)
                throw new Exception("Number of points must be in segment of [2-8]!");

            switch (points)
            {
                case 2:
                    //Calculate Jacobian for 4 points and 2 gaussian points
                    J[0][0] = pi[0][0] * partialNi(1, 0, 1, true, 2) + pi[1][0] * partialNi(1, 0, 2, true, 2);
                    J[0][1] = 0;
                    J[1][0] = 0;
                    J[1][1] = 1;
                    break;
                case 3:
                    //Calculate Jacobian for 4 points and 2 gaussian points
                    J[0][0] = pi[0][0] * partialNi(1, 1, 1, true, 3) + pi[1][0] * partialNi(0, 0, 2, true, 3) + pi[2][0] * partialNi(1, 1, 3, true, 3);
                    J[0][1] = pi[0][1] * partialNi(1, 1, 1, false, 3) + pi[1][1] * partialNi(0, 0, 2, false, 3) + pi[2][1] * partialNi(1, 1, 3, false, 3);
                    J[1][0] = pi[0][0] * partialNi(0, 0, 1, true, 3) + pi[1][0] * partialNi(1, 1, 2, true, 3) + pi[2][0] * partialNi(1, 1, 3, true, 3);
                    J[1][1] = pi[0][1] * partialNi(0, 0, 1, false, 3) + pi[1][1] * partialNi(1, 1, 2, false, 3) + pi[2][1] * partialNi(1, 1, 3, false, 3);
                    break;
                case 4:
                    //Calculate Jacobian for 4 points
                    for (int k = 0; k < 4; k++)
                    {
                        J[0][0] += Shape.partialNi(1, 1, k + 1, true, 4) * pi[k][0];
                        J[0][1] += Shape.partialNi(1, 1, k + 1, true, 4) * pi[k][1];
                        J[1][0] += Shape.partialNi(1, 1, k + 1, false, 4) * pi[k][0];
                        J[1][1] += Shape.partialNi(1, 1, k + 1, false, 4) * pi[k][1];
                    }
                    break;
                case 5:
                    throw new Exception("Not supported number of points!");
                case 6:
                    throw new Exception("Not supported number of points!");
                case 7:
                    throw new Exception("Not supported number of points!");
                case 8:
                    //Calculate Jacobian for 8 points
                    for (int k = 0; k < 8; k++)
                    {
                        J[0][0] += Shape.partialNi(1, 1, k + 1, true, 8) * pi[k][0];
                        J[0][1] += Shape.partialNi(1, 1, k + 1, true, 8) * pi[k][1];
                        J[1][0] += Shape.partialNi(1, 1, k + 1, false, 8) * pi[k][0];
                        J[1][1] += Shape.partialNi(1, 1, k + 1, false, 8) * pi[k][1];
                    }
                    break;
                default:
                    break;
            }

            //return determinant
            return J[0][0] * J[1][1] - J[0][1] * J[1][0];
        }
      
    }
}
