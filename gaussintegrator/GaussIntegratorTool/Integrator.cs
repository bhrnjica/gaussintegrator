using BHNumericLib;
using Ciloci.Flee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace GaussNumericIntegrator
{
    public partial class Integrator : Form
    {
        private Register register= null;
        private ExpressionContext context = null;
        private IGenericExpression<double> function = null;
      
        public Integrator()
        {
            InitializeComponent();
            comboBox3.SelectedIndex = 1;
            cmbGPoints.SelectedIndex = 0;
            this.Load+=Form1_Load;
            
        }
        void Form1_Load(object sender, EventArgs e)
        {
            register = new Register();
            context = new ExpressionContext(register);
            context.Imports.AddType(typeof(Math));
        }

        //selected index changed
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                textFunction.Text = "";
                textBox1.Text = "0";
                textBox2.Text = "1.5";
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    textFunction.Text = comboBox1.SelectedItem.ToString();
                    textBox1.Text = "-1";
                    textBox2.Text = "1";
                    comboBox4.SelectedIndex = 0;
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    textFunction.Text = comboBox1.SelectedItem.ToString();
                    textBox1.Text = "0.5";
                    textBox2.Text = "2";
                    comboBox4.SelectedIndex = 0;
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    textFunction.Text = comboBox1.SelectedItem.ToString();
                    textBox1.Text = "0";
                    textBox2.Text = "0.8";
                    comboBox4.SelectedIndex = 0;
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    textFunction.Text = comboBox1.SelectedItem.ToString();
                    textBox1.Text = "4";
                    textBox2.Text = "10";
                    comboBox4.SelectedIndex = 0;
                }
                
                if (comboBox1.SelectedIndex == 4)
                {
                    textFunction.Text = comboBox1.SelectedItem.ToString();
                    textBox1.Text = "1";
                    textBox2.Text = "3";
                    comboBox4.SelectedIndex = 0;
                }
                if (comboBox1.SelectedIndex == 5)
                {
                    textFunction.Text = comboBox1.SelectedItem.ToString();
                    textBox1.Text = "1";
                    textBox2.Text = "3";
                    comboBox4.SelectedIndex = 0;
                }
                if (comboBox1.SelectedIndex == 6)
                {
                    textFunction.Text = comboBox1.SelectedItem.ToString();
                    textBox1.Text = "1";
                    textBox2.Text = "3";
                    comboBox4.SelectedIndex = 0;
                }
                if (comboBox1.SelectedIndex == 7)
                {
                    textFunction.Text = comboBox1.SelectedItem.ToString();
                    textBox1.Text = "2";
                    textBox2.Text = "3";
                    comboBox4.SelectedIndex = 0;
                }
                if (comboBox1.SelectedIndex == 8)
                {
                    textFunction.Text = comboBox1.SelectedItem.ToString();
                    textBox1.Text = "1";
                    textBox2.Text = "3";
                    comboBox4.SelectedIndex = 0;
                }
                if (comboBox1.SelectedIndex == 9)
                {
                    textFunction.Text = comboBox1.SelectedItem.ToString();
                    textBox1.Text = "1";
                    textBox2.Text = "3";
                    comboBox4.SelectedIndex = 0;
                }
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                textBox4.Text = "x*y";
                comboBox3.SelectedIndex = 0;
                cmbGPoints.SelectedIndex = 1;
                textx1.Text = "1";
                texty1.Text = "1";

                textx2.Text = "3";
                texty2.Text = "2";

                textx3.Text = "2";
                texty3.Text = "3";
            }

            if (comboBox2.SelectedIndex == 1)
            {
                textBox4.Text = "x*y";
                comboBox3.SelectedIndex = 1;
                cmbGPoints.SelectedIndex = 1;

                textx1.Text = "1";
                texty1.Text = "1";

                textx2.Text = "3";
                texty2.Text = "2";

                textx3.Text = "4";
                texty3.Text = "4";

                textx4.Text = "2";
                texty4.Text = "3";
            }

            if (comboBox2.SelectedIndex == 2)
            {
                textBox4.Text = "x*y";
                comboBox3.SelectedIndex = 2;
                cmbGPoints.SelectedIndex = 1;

                textx1.Text = "1";
                texty1.Text = "1";

                textx2.Text = "3";
                texty2.Text = "2";

                textx3.Text = "4";
                texty3.Text = "4";

                textx4.Text = "2";
                texty4.Text = "3";

                textx5.Text = "2";
                texty5.Text = "1.5";

                textx6.Text = "3.5";
                texty6.Text = "3";

                textx7.Text = "3";
                texty7.Text = "3.5";

                textx8.Text = "1.5";
                texty8.Text = "2.0";
            }
        }

        /// <summary>
        /// Perform integration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Integrate1D_Click(object sender, EventArgs e)
        {
           
            double a = 0,b=0;
            int n=2;

            if (double.TryParse(textBox1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out a) != true)
            {
               MessageBox.Show("First point \"a\" of interval is invalid!");
                label5.Text ="";
                return;
            }

            if (double.TryParse(textBox2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out b) != true)
            {
               MessageBox.Show("Second point \"b\" of interval is invalid!");
                label5.Text ="";
                return;
            }

            if (int.TryParse(comboBox4.Text, NumberStyles.None, CultureInfo.InvariantCulture, out n) != true)
            {
               MessageBox.Show("Number of points is invalid!");
              label5.Text ="";  
              return;
            }
            
            if(n>64)
            {
               MessageBox.Show("Number of points must be less than 65!");
                label5.Text ="";
                return;
            }

            try 
            {	  
                var funstr = textFunction.Text;
	            function = context.CompileGeneric<double>(funstr);
            }
            catch (Exception ex)
            {
	            MessageBox.Show("Error in fun definition. ERROR: "+ex.Message);
                label5.Text = "I=n/a";
	            return;
            }

            double[][] pi = new double[2][];
            pi[0] = new double[2];
            pi[1] = new double[2];
            pi[0][0] = a;
            pi[1][0] = b;

            //perform integration
            double retVal = GaussIntegrator.Calculate1DIntegral(function, register, n, pi);
            label5.Text = string.Format("I={0:0.0000000000}", retVal);

        }

        //INtegration of 3/4/8 point area
        private void Integrate2D_Click(object sender, EventArgs e)
        {
            int m = 3;
            if (comboBox3.SelectedIndex == 1)
                m = 4;
            if (comboBox3.SelectedIndex == 2)
                m = 8;

            double [][]pi = new double[m][];

            for (int i = 0; i < m; i++)
                pi[i]= new double[2];

            if (!ValidateAreaPoints(pi))
               return;
            
            try
            {
                var funstr = textBox4.Text;
                function = context.CompileGeneric<double>(funstr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in fun definition. ERROR: " + ex.Message);
                label5.Text = "I=n/a";
                return;
            }

            int gp = 0;
            if (int.TryParse(cmbGPoints.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out gp) != true)
            {
                MessageBox.Show("Invalid number of Gaussian points!");
                label11.Text = "";
                return;
            }

            double retVal = 0;
            if (comboBox3.SelectedIndex == 0)
                retVal = GaussIntegrator.Calculate2DIntegral_Triangle(function, register, gp , pi);
            else
                retVal = GaussIntegrator.Calculate2DIntegral_Quadrilateral(function, register, gp , pi);


            label11.Text = string.Format("I={0:0.0000000000}", retVal);
        }

        private bool ValidateAreaPoints(double[][] pi)
        {
            if (double.TryParse(textx1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[0][0]) != true)
            {
                MessageBox.Show("First point coordinate \"x1\" is invalid!");
                label11.Text = "";
                return false;
            }
            if (double.TryParse(texty1.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[0][1]) != true)
            {
                MessageBox.Show("First point coordinate \"y1\" is invalid!");
                label11.Text = "";
                return false;
            }

            if (double.TryParse(textx2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[1][0]) != true)
            {
                MessageBox.Show("First point coordinate \"x2\" is invalid!");
                label11.Text = "";
                return false;
            }
            if (double.TryParse(texty2.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[1][1]) != true)
            {
                MessageBox.Show("First point coordinate \"y2\" is invalid!");
                label11.Text = "";
                return false;
            }
            if (double.TryParse(textx3.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[2][0]) != true)
            {
                MessageBox.Show("First point coordinate \"x3\" is invalid!");
                label11.Text = "";
                return false;
            }
            if (double.TryParse(texty3.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[2][1]) != true)
            {
                MessageBox.Show("First point coordinate \"y3\" is invalid!");
                label11.Text = "";
                return false;
            }
            if (comboBox3.SelectedIndex > 0)
            {
                if (double.TryParse(textx4.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[3][0]) != true)
                {
                    MessageBox.Show("First point coordinate \"x4\" is invalid!");
                    label11.Text = "";
                    return false;
                }
                if (double.TryParse(texty4.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[3][1]) != true)
                {
                    MessageBox.Show("First point coordinate \"y4\" is invalid!");
                    label11.Text = "";
                    return false;
                }
            }
            if (comboBox3.SelectedIndex > 1)
            {
                if (double.TryParse(textx5.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[4][0]) != true)
                {
                    MessageBox.Show("First point coordinate \"x5\" is invalid!");
                    label11.Text = "";
                    return false;
                }
                if (double.TryParse(texty5.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[4][1]) != true)
                {
                    MessageBox.Show("First point coordinate \"y5\" is invalid!");
                    label11.Text = "";
                    return false;
                }
                if (double.TryParse(textx6.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[5][0]) != true)
                {
                    MessageBox.Show("First point coordinate \"x4\" is invalid!");
                    label11.Text = "";
                    return false;
                }
                if (double.TryParse(texty6.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[5][1]) != true)
                {
                    MessageBox.Show("First point coordinate \"y4\" is invalid!");
                    label11.Text = "";
                    return false;
                }
                if (double.TryParse(textx7.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[6][0]) != true)
                {
                    MessageBox.Show("First point coordinate \"x4\" is invalid!");
                    label11.Text = "";
                    return false;
                }
                if (double.TryParse(texty7.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[6][1]) != true)
                {
                    MessageBox.Show("First point coordinate \"y4\" is invalid!");
                    label11.Text = "";
                    return false;
                }
                if (double.TryParse(textx8.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[7][0]) != true)
                {
                    MessageBox.Show("First point coordinate \"x4\" is invalid!");
                    label11.Text = "";
                    return false;
                }
                if (double.TryParse(texty8.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out pi[7][1]) != true)
                {
                    MessageBox.Show("First point coordinate \"y4\" is invalid!");
                    label11.Text = "";
                    return false;
                }
            }
            return true;
        }

        private void ChangeElementType(object sender, EventArgs e)
        {
            cmbGPoints.Items.Clear();

            if (comboBox3.SelectedIndex == 0)
            {
                textx4.Visible = false;
                texty4.Visible = false;
                lx4.Visible = false;
                ly4.Visible = false;
                textx5.Visible = false;
                texty5.Visible = false;
                lx5.Visible = false;
                ly5.Visible = false;
                textx6.Visible = false;
                texty6.Visible = false;
                lx6.Visible = false;
                ly6.Visible = false;
                textx7.Visible = false;
                texty7.Visible = false;
                lx7.Visible = false;
                ly7.Visible = false;
                textx8.Visible = false;
                texty8.Visible = false;
                lx8.Visible = false;
                ly8.Visible = false;

                cmbGPoints.Items.Add("1");
                cmbGPoints.Items.Add("3");
                cmbGPoints.Items.Add("4");
                cmbGPoints.Items.Add("7");
                cmbGPoints.SelectedIndex = 1;
            }
                //4-node element
            else if(comboBox3.SelectedIndex == 1)
            {
                textx4.Visible = true;
                texty4.Visible = true;
                lx4.Visible = true;
                ly4.Visible = true;
                textx5.Visible = false;
                texty5.Visible = false;
                lx5.Visible = false;
                ly5.Visible = false;
                textx6.Visible = false;
                texty6.Visible = false;
                lx6.Visible = false;
                ly6.Visible = false;
                textx7.Visible = false;
                texty7.Visible = false;
                lx7.Visible = false;
                ly7.Visible = false;
                textx8.Visible = false;
                texty8.Visible = false;
                lx8.Visible = false;
                ly8.Visible = false;

                cmbGPoints.Items.Add("2");
                cmbGPoints.Items.Add("3");
                cmbGPoints.Items.Add("4");
                cmbGPoints.Items.Add("5");
                cmbGPoints.SelectedIndex = 0;
            }
                //8-node element
            else if (comboBox3.SelectedIndex == 2)
            {
                cmbGPoints.Items.Add("2");
                cmbGPoints.Items.Add("3");
                cmbGPoints.Items.Add("4");
                cmbGPoints.Items.Add("5");
                cmbGPoints.SelectedIndex = 0;
                textx4.Visible = true;
                texty4.Visible = true;
                lx4.Visible = true;
                ly4.Visible = true;
                textx5.Visible = true;
                texty5.Visible = true;
                lx5.Visible = true;
                ly5.Visible = true;
                textx6.Visible = true;
                texty6.Visible = true;
                lx6.Visible = true;
                ly6.Visible = true;
                textx7.Visible = true;
                texty7.Visible = true;
                lx7.Visible = true;
                ly7.Visible = true;
                textx8.Visible = true;
                texty8.Visible = true;
                lx8.Visible = true;
                ly8.Visible = true;
            }
        }

       
    }
}
