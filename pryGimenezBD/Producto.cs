﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryGimenezBD
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        SqlCliente1 conector = new SqlCliente1();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnMostra_Click(object sender, EventArgs e)
        {
            conector.Conectar(GrillaSql);
            
        }
    }
}
