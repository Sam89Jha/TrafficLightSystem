using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightSystem
{
    public partial class Form1 : Form, ILightView
    {
        private LightController lightController;
        private SynchronizationContext synchronizationContext;
        public Form1()
        {
            InitializeComponent();
            synchronizationContext = SynchronizationContext.Current;
            lightController = new LightController(this);
        }

        public void ChangeSouthLight(State state)
        {
            ControlColor(btnSouth, state);
            
        }

        public void ChangeWestLight(State state)
        {
            ControlColor(btnWest, state);
        }

        public void ChangeEastLight(State state)
        {
            ControlColor(btnEast, state);
        }
        public void ChangeNorthLight(State state)
        {
            ControlColor(btnNorth, state);
        }

        private void ControlColor(Button colorButton, State state)
        {
            synchronizationContext.Post((syncState) =>
            {
                
                if (state.LightType == LightType.Yellow)
                {

                    colorButton.BackColor = System.Drawing.Color.Yellow;
                }
                else if (state.LightType == LightType.Green)
                {
                    colorButton.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    colorButton.BackColor = System.Drawing.Color.Red;
                }
            }, null);
        }

        public void ChangeSouthWestLight(State state)
        {
            ControlColor(btnSouthWest, state);
        }

        public void ChangeNorthEastLight(State state)
        {
            ControlColor(btnNorthEast, state);
        }

        public void ChangeSouthEastLight(State state)
        {
            ControlColor(btnSouthEast, state);
        }

        public void ChangeNorthWestLight(State state)
        {
            ControlColor(btnNorthWest, state);
        }
    }
}
