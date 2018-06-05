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
using System;

namespace BHNumericLib
{
    
    /// <summary>
    /// class holds gauss values for one point
    /// </summary>
    public class GValues
    {
        public int n;
        public double[] wi;
        public double[] gi;
    }
    /// <summary>
    /// Helper class for Expression evaluator
    /// </summary>
    public class Register
    {
        public Register()
        {
            e = Math.E;
            pi = Math.PI;
        }

        //constants
        public double e { get; set; }
        public double pi { get; set; }

        //vars
        public double x { get; set; }
        public double y { get; set; }
        // public double z { get; set; }
    }
}
